using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BeyazEsyaOtomasyon
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From TBL_URUNLER Order By URUNAD Asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            TxtAd.Text = "";
            TxtAlis.Text = "";
            Txtid .Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            TxtSatis.Text = "";
            MskYil.Text = "";
            NudAdet.Value = 0;
            RchDetay.Text = "";
        }
                   
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Verileri kaydetme
            using (var baglanti = bgl.baglanti())
            {
                baglanti.Open();
                using (SqlCommand komut = new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                    komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
                    komut.Parameters.AddWithValue("@p3", TxtModel.Text);
                    komut.Parameters.AddWithValue("@p4", MskYil.Text);
                    komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
                    komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text));
                    komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));
                    komut.Parameters.AddWithValue("@p8", RchDetay.Text);
                    komut.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            using (var baglanti = bgl.baglanti())
            {
                baglanti.Open();
                using (SqlCommand komutsil = new SqlCommand("Delete From Tbl_URUNLER where ID = @p1", baglanti))
                {
                    komutsil.Parameters.AddWithValue("@p1", Txtid.Text);
                    komutsil.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtid.Text = dr["ID"].ToString();
            TxtAd.Text = dr["URUNAD"].ToString();
            TxtMarka.Text = dr["MARKA"].ToString();
            TxtModel.Text = dr["MODEL"].ToString();
            MskYil.Text = dr["YIL"].ToString();
            NudAdet.Value = decimal.Parse(dr["ADET"].ToString());
            TxtAlis.Text = dr["ALISFIYAT"].ToString();
            TxtSatis.Text = dr["SATISFIYAT"].ToString();
            RchDetay.Text = dr["DETAY"].ToString();



        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            using (var baglanti = bgl.baglanti())
            {
                baglanti.Open();
                using (SqlCommand komut = new SqlCommand("update Tbl_URUNLER set URUNAD = @P1,MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@P8 where ID =@P9", baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                    komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
                    komut.Parameters.AddWithValue("@p3", TxtModel.Text);
                    komut.Parameters.AddWithValue("@p4", MskYil.Text);
                    komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
                    komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text));
                    komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));
                    komut.Parameters.AddWithValue("@p8", RchDetay.Text);
                    komut.Parameters.AddWithValue("@p9", Txtid.Text);
                    komut.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Ürün Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
