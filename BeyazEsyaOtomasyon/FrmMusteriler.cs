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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From TBL_MUSTERILER ORDER BY AD Asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            TxtAd.Text = "";
            Txtid.Text = "";
            TxtMail.Text = "";
            TxtSoyad.Text = "";
            TxtVergi.Text = "";
            MskTC.Text = "";
            MskTelefon1.Text = "";
            MskTelefon2.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            RchAdres.Text = "";


        }

        void sehirListesi()
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                SqlCommand komut = new SqlCommand("Select SEHIR From TBL_ILLER", conn);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Cmbil.Properties.Items.Add(dr[0]);
                }
            }
        }
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
            sehirListesi();
            temizle();

        }                  
        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where Sehir = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            using (var baglanti = bgl.baglanti())
            {
                baglanti.Open();
                using (SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER(AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                    komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                    komut.Parameters.AddWithValue("@p3", MskTelefon1.Text);
                    komut.Parameters.AddWithValue("@p4", MskTelefon2.Text);
                    komut.Parameters.AddWithValue("@p5", MskTC.Text);
                    komut.Parameters.AddWithValue("@p6", TxtMail.Text);
                    komut.Parameters.AddWithValue("@p7", Cmbil.Text);
                    komut.Parameters.AddWithValue("@p8", Cmbilce.Text);
                    komut.Parameters.AddWithValue("@p9", TxtVergi.Text);
                    komut.Parameters.AddWithValue("@p10", RchAdres.Text);
                    komut.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Müşteri Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTelefon1.Text = dr["TELEFON"].ToString();
                MskTelefon2.Text = dr["TELEFON2"].ToString();
                MskTC.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                TxtVergi.Text = dr["VERGIDAIRE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();

            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            using (var baglanti = bgl.baglanti())
            {
                baglanti.Open();
                using (SqlCommand komut = new SqlCommand("Delete from TBL_MUSTERILER where ID = @p1", baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", Txtid.Text);
                    komut.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Müşteri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            using (var baglanti = bgl.baglanti())
            {
                baglanti.Open();
                using (SqlCommand komut = new SqlCommand("update TBL_MUSTERILER set AD=@P1,SOYAD=@P2,TELEFON=@P3,TELEFON2=@P4,TC=@P5,MAIL=@P6,IL=@P7,ILCE=@P8,VERGIDAIRE=@P9,ADRES=@P10 where ID=@P11", baglanti))
                {
                    komut.Parameters.AddWithValue("@P1", TxtAd.Text);
                    komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
                    komut.Parameters.AddWithValue("@P3", MskTelefon1.Text);
                    komut.Parameters.AddWithValue("@P4", MskTelefon2.Text);
                    komut.Parameters.AddWithValue("@P5", MskTC.Text);
                    komut.Parameters.AddWithValue("@P6", TxtMail.Text);
                    komut.Parameters.AddWithValue("@P7", Cmbil.Text);
                    komut.Parameters.AddWithValue("@P8", Cmbilce.Text);
                    komut.Parameters.AddWithValue("@P9", TxtVergi.Text);
                    komut.Parameters.AddWithValue("@P10", RchAdres.Text);
                    komut.Parameters.AddWithValue("@P11", Txtid.Text);
                    komut.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Müşteri bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
