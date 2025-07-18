﻿using System;
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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = bgl.baglanti())
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", conn))
                {
                    da.Fill(dt);
                }
            }
            gridControl1.DataSource = dt;
        }

        void sehirlistesi()
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                using (SqlCommand komut = new SqlCommand("Select SEHIR From TBL_ILLER", conn))
                {
                    using (SqlDataReader dr = komut.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Cmbil.Properties.Items.Add(dr[0]);
                        }
                    }
                }
            }
        }

        void firmalistesi()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = bgl.baglanti())
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Select ID,AD From TBL_FIRMALAR", conn))
                {
                    da.Fill(dt);
                }
            }
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AD";
            lookUpEdit1.Properties.DataSource = dt;


        }

        void temizle()
        {
            TxtBankaAd.Text = "";
            TxtHesapNo.Text = "";
            TxtHesapTuru.Text = "";
            TxtIBAN.Text = "";
            Txtid.Text = "";
            TxtSube.Text = "";
            TxtYetkili.Text = "";
            MskTarih.Text = "";
            MskTelefon.Text = "";
            lookUpEdit1.Text ="";
            
        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            listele();
            sehirlistesi();
            firmalistesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                using (SqlCommand komut = new SqlCommand("insert into TBL_BANKALAR (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", conn))
                {
                    komut.Parameters.AddWithValue("@p1", TxtBankaAd.Text);
                    komut.Parameters.AddWithValue("@p2", Cmbil.Text);
                    komut.Parameters.AddWithValue("@p3", Cmbilce.Text);
                    komut.Parameters.AddWithValue("@p4", TxtSube.Text);
                    komut.Parameters.AddWithValue("@p5", TxtIBAN.Text);
                    komut.Parameters.AddWithValue("@p6", TxtHesapNo.Text);
                    komut.Parameters.AddWithValue("@p7", TxtYetkili.Text);
                    komut.Parameters.AddWithValue("@p8", MskTelefon.Text);
                    komut.Parameters.AddWithValue("@p9", MskTarih.Text);
                    komut.Parameters.AddWithValue("@p10", TxtHesapTuru.Text);
                    komut.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue ?? DBNull.Value);
                    komut.ExecuteNonQuery();
                }
            }
            listele();
            MessageBox.Show("Banka Bilgisi Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbilce.Properties.Items.Clear();
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                using (SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where Sehir = @p1", conn))
                {
                    komut.Parameters.AddWithValue("@p1", Cmbil.SelectedIndex + 1);
                    using (SqlDataReader dr = komut.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Cmbilce.Properties.Items.Add(dr[0]);
                        }
                    }
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                TxtBankaAd.Text = dr["BANKAADI"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbil.Text = dr["ILCE"].ToString();
                TxtSube.Text = dr["SUBE"].ToString();
                TxtIBAN.Text = dr["IBAN"].ToString();
                TxtHesapNo.Text = dr["HESAPNO"].ToString();
                TxtYetkili.Text = dr["YETKILI"].ToString();
                MskTelefon.Text = dr["TELEFON"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                TxtHesapTuru.Text = dr["HESAPTURU"].ToString();


            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                using (SqlCommand komut = new SqlCommand("Delete from TBL_BANKALAR where ID=@p1", conn))
                {
                    komut.Parameters.AddWithValue("@p1", Txtid.Text);
                    komut.ExecuteNonQuery();
                }
            }
            temizle();
            MessageBox.Show("Banka Bilgisi Sistemden Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                using (SqlCommand komut = new SqlCommand("update TBL_BANKALAR set BANKAADI=@P1,IL=@P2,ILCE=@P3,SUBE=@P4,IBAN=@P5,HESAPNO=@P6,YETKILI=@P7,TELEFON=@P8,TARIH=@P9,HESAPTURU=@P10,FIRMAID=@P11 WHERE ID=@P12", conn))
                {
                    komut.Parameters.AddWithValue("@p1", TxtBankaAd.Text);
                    komut.Parameters.AddWithValue("@p2", Cmbil.Text);
                    komut.Parameters.AddWithValue("@p3", Cmbilce.Text);
                    komut.Parameters.AddWithValue("@p4", TxtSube.Text);
                    komut.Parameters.AddWithValue("@p5", TxtIBAN.Text);
                    komut.Parameters.AddWithValue("@p6", TxtHesapNo.Text);
                    komut.Parameters.AddWithValue("@p7", TxtYetkili.Text);
                    komut.Parameters.AddWithValue("@p8", MskTelefon.Text);
                    komut.Parameters.AddWithValue("@p9", MskTarih.Text);
                    komut.Parameters.AddWithValue("@p10", TxtHesapTuru.Text);
                    komut.Parameters.AddWithValue("@p11", lookUpEdit1.EditValue ?? DBNull.Value);
                    komut.Parameters.AddWithValue("@p12", Txtid.Text);
                    komut.ExecuteNonQuery();
                }
            }
            listele();
            MessageBox.Show("Banka Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
