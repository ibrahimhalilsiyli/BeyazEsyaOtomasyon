using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BeyazEsyaOtomasyon;

namespace BeyazEsyaOtomasyon
{
    public partial class FrmSatis : DevExpress.XtraEditors.XtraForm
    {
        SqlBaglantisi bgl = new SqlBaglantisi();

        public FrmSatis()
        {
            InitializeComponent();
            UrunleriListele();
            MusterileriListele();
        }

        void UrunleriListele()
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID, URUNAD, ADET, SATISFIYAT FROM TBL_URUNLER WHERE ADET > 0", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbUrun.Properties.DataSource = dt;
                cmbUrun.Properties.DisplayMember = "URUNAD";
                cmbUrun.Properties.ValueMember = "ID";
            }
        }

        void MusterileriListele()
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID, AD + ' ' + SOYAD AS MUSTERI FROM TBL_MUSTERILER", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbMusteri.Properties.DataSource = dt;
                cmbMusteri.Properties.DisplayMember = "MUSTERI";
                cmbMusteri.Properties.ValueMember = "ID";
            }
        }

        void SatislariListele()
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT 
                        f.FATURABILGIID,
                        f.SERI + f.SIRANO AS FATURA_NO,
                        f.TARIH,
                        f.SAAT,
                        m.AD + ' ' + m.SOYAD AS MUSTERI,
                        fd.URUNAD,
                        fd.MIKTAR,
                        fd.FIYAT,
                        fd.TUTAR
                    FROM TBL_FATURABILGI f
                    INNER JOIN TBL_FATURADETAY fd ON f.FATURABILGIID = fd.FATURAID
                    INNER JOIN TBL_MUSTERILER m ON f.ALICI = m.AD + ' ' + m.SOYAD
                    ORDER BY f.TARIH DESC, f.SAAT DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
        }

        private void btnYeniSatis_Click(object sender, EventArgs e)
        {
            // Form temizleme
            cmbUrun.EditValue = null;
            cmbMusteri.EditValue = null;
            nudMiktar.Value = 1;
            txtFiyat.Text = "";
            txtToplam.Text = "";
        }

        private void btnSatisYap_Click(object sender, EventArgs e)
        {
            try
            {
                // Giriş kontrolleri
                if (cmbUrun.EditValue == null)
                {
                    MessageBox.Show("Lütfen ürün seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbMusteri.EditValue == null)
                {
                    MessageBox.Show("Lütfen müşteri seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nudMiktar.Value <= 0)
                {
                    MessageBox.Show("Lütfen geçerli miktar giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal fiyat = 0;
                if (!decimal.TryParse(txtFiyat.Text, out fiyat) || fiyat <= 0)
                {
                    MessageBox.Show("Lütfen geçerli fiyat giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Stok kontrolü
                using (SqlConnection conn = bgl.baglanti())
                {
                    conn.Open();
                    SqlCommand komutStokKontrol = new SqlCommand("SELECT ADET FROM TBL_URUNLER WHERE ID = @ID", conn);
                    komutStokKontrol.Parameters.AddWithValue("@ID", cmbUrun.EditValue);
                    int mevcutStok = (int)komutStokKontrol.ExecuteScalar();

                    if (mevcutStok < nudMiktar.Value)
                    {
                        MessageBox.Show($"Yetersiz stok! Mevcut stok: {mevcutStok}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (SqlConnection conn = bgl.baglanti())
                {
                    conn.Open();
                    // 1. Fatura Bilgisi Ekle
                    SqlCommand komutFatura = new SqlCommand("INSERT INTO TBL_FATURABILGI (SERI, SIRANO, TARIH, SAAT, VERGIDAIRE, ALICI, TESLIMEDEN, TESLIMALAN) OUTPUT INSERTED.FATURABILGIID VALUES (@SERI, @SIRANO, @TARIH, @SAAT, @VERGIDAIRE, @ALICI, @TESLIMEDEN, @TESLIMALAN)", conn);
                    komutFatura.Parameters.AddWithValue("@SERI", "A");
                    komutFatura.Parameters.AddWithValue("@SIRANO", Guid.NewGuid().ToString().Substring(0, 8));
                    komutFatura.Parameters.AddWithValue("@TARIH", DateTime.Now.ToString("yyyy-MM-dd"));
                    komutFatura.Parameters.AddWithValue("@SAAT", DateTime.Now.ToString("HH:mm"));
                    komutFatura.Parameters.AddWithValue("@VERGIDAIRE", "Otomatik");
                    komutFatura.Parameters.AddWithValue("@ALICI", cmbMusteri.Text);
                    komutFatura.Parameters.AddWithValue("@TESLIMEDEN", "IHS");
                    komutFatura.Parameters.AddWithValue("@TESLIMALAN", "Çanakkale/MERKEZ 03. 459 TKL");
                    int faturaId = (int)komutFatura.ExecuteScalar();

                    // 2. Fatura Detay Ekle
                    SqlCommand komutDetay = new SqlCommand("INSERT INTO TBL_FATURADETAY (URUNAD, MIKTAR, FIYAT, TUTAR, FATURAID) VALUES (@URUNAD, @MIKTAR, @FIYAT, @TUTAR, @FATURAID)", conn);
                    komutDetay.Parameters.AddWithValue("@URUNAD", cmbUrun.Text);
                    komutDetay.Parameters.AddWithValue("@MIKTAR", nudMiktar.Value);
                    komutDetay.Parameters.AddWithValue("@FIYAT", fiyat);
                    komutDetay.Parameters.AddWithValue("@TUTAR", nudMiktar.Value * fiyat);
                    komutDetay.Parameters.AddWithValue("@FATURAID", faturaId);
                    komutDetay.ExecuteNonQuery();

                    // 3. Stoktan Düş
                    SqlCommand komutStok = new SqlCommand("UPDATE TBL_URUNLER SET ADET = ADET - @MIKTAR WHERE ID = @URUNID", conn);
                    komutStok.Parameters.AddWithValue("@MIKTAR", nudMiktar.Value);
                    komutStok.Parameters.AddWithValue("@URUNID", cmbUrun.EditValue);
                    komutStok.ExecuteNonQuery();

                    // 4. Stok Hareketi Kaydı
                    SqlCommand hareketEkle = new SqlCommand(
                        "INSERT INTO TBL_STOKHAREKET (URUNID, TARIH, MIKTAR, TIP, ACIKLAMA) VALUES (@URUNID, @TARIH, @MIKTAR, @TIP, @ACIKLAMA)", conn);
                    hareketEkle.Parameters.AddWithValue("@URUNID", cmbUrun.EditValue);
                    hareketEkle.Parameters.AddWithValue("@TARIH", DateTime.Now);
                    hareketEkle.Parameters.AddWithValue("@MIKTAR", nudMiktar.Value);
                    hareketEkle.Parameters.AddWithValue("@TIP", "Çıkış");
                    hareketEkle.Parameters.AddWithValue("@ACIKLAMA", "Satış işlemi");
                    hareketEkle.ExecuteNonQuery();
                }

                MessageBox.Show("Satış ve faturalandırma işlemi başarıyla tamamlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Form temizleme
                btnYeniSatis_Click(sender, e);
                
                // Listeleri güncelle
                UrunleriListele();
                SatislariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            UrunleriListele();
            MusterileriListele();
            SatislariListele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("Lütfen silinecek satışı seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçili satışı silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int faturaId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("FATURABILGIID"));
                    
                    using (SqlConnection conn = bgl.baglanti())
                    {
                        conn.Open();
                        
                        // Fatura detayını sil
                        SqlCommand komutDetaySil = new SqlCommand("DELETE FROM TBL_FATURADETAY WHERE FATURAID = @FATURAID", conn);
                        komutDetaySil.Parameters.AddWithValue("@FATURAID", faturaId);
                        komutDetaySil.ExecuteNonQuery();
                        
                        // Fatura bilgisini sil
                        SqlCommand komutFaturaSil = new SqlCommand("DELETE FROM TBL_FATURABILGI WHERE FATURABILGIID = @FATURAID", conn);
                        komutFaturaSil.Parameters.AddWithValue("@FATURAID", faturaId);
                        komutFaturaSil.ExecuteNonQuery();
                    }
                    
                    MessageBox.Show("Satış başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SatislariListele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyası | *.xlsx";
            sfd.Title = "Excel Dosyası Kaydet";
            sfd.FileName = "Satışlar_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXlsx(sfd.FileName);
                MessageBox.Show("Excel dosyası başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Dosyası | *.pdf";
            sfd.Title = "PDF Dosyası Kaydet";
            sfd.FileName = "Satışlar_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToPdf(sfd.FileName);
                MessageBox.Show("PDF dosyası başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbUrun_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbUrun.EditValue != null)
            {
                using (SqlConnection conn = bgl.baglanti())
                {
                    conn.Open();
                    // Seçilen ürünün fiyatını getir
                    SqlCommand komut = new SqlCommand("SELECT SATISFIYAT FROM TBL_URUNLER WHERE ID = @ID", conn);
                    komut.Parameters.AddWithValue("@ID", cmbUrun.EditValue);
                    object fiyat = komut.ExecuteScalar();
                    if (fiyat != null)
                    {
                        txtFiyat.Text = fiyat.ToString();
                        ToplamHesapla();
                    }
                }
            }
        }

        private void nudMiktar_ValueChanged(object sender, EventArgs e)
        {
            ToplamHesapla();
        }

        private void txtFiyat_TextChanged(object sender, EventArgs e)
        {
            ToplamHesapla();
        }

        void ToplamHesapla()
        {
            decimal fiyat = 0;
            if (decimal.TryParse(txtFiyat.Text, out fiyat))
            {
                decimal toplam = nudMiktar.Value * fiyat;
                txtToplam.Text = toplam.ToString("C2");
            }
        }

        private void FrmSatis_Load(object sender, EventArgs e)
        {
            SatislariListele();
        }
    }
} 