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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void personelliste()
        {
         DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_PERSONELLER Order By AD Asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;   

        }

        void sehirlistesi()
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

        void temizle()
        {
            Txtid.Text = "";
            TxtAd.Text = "";
            TxtGorev.Text = "";
            TxtSoyad.Text = "";
            TxtMail.Text = "";
            MskTC.Text = "";
            MskTelefon1.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
           



        }

        private void FrmPersonel_Load(object sender, EventArgs e)

        {
            personelliste();
            sehirlistesi();
            temizle();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            using (var baglanti = bgl.baglanti())
            {
                baglanti.Open();
                using (SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)", baglanti))
                {
                    komut.Parameters.AddWithValue("@P1", TxtAd.Text);
                    komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
                    komut.Parameters.AddWithValue("@P3", MskTelefon1.Text);
                    komut.Parameters.AddWithValue("@P4", MskTC.Text);
                    komut.Parameters.AddWithValue("@P5", TxtMail.Text);
                    komut.Parameters.AddWithValue("@P6", Cmbil.Text);
                    komut.Parameters.AddWithValue("@P7", Cmbilce.Text);
                    komut.Parameters.AddWithValue("@P8", RchAdres.Text);
                    komut.Parameters.AddWithValue("@P9", TxtGorev.Text);
                    komut.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Personel Bilgileri Kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            personelliste();
        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where Sehir = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTelefon1.Text = dr["TELEFON"].ToString();
                MskTC.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["IL"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtGorev.Text = dr["GOREV"].ToString();

            }      
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            using (var baglanti = bgl.baglanti())
            {
                baglanti.Open();
                using (SqlCommand komutsil = new SqlCommand("delete from TBL_PERSONELLER where ID = @p1", baglanti))
                {
                    komutsil.Parameters.AddWithValue("@p1", Txtid.Text);
                    komutsil.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Personel Listeden Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            personelliste();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            using (var baglanti = bgl.baglanti())
            {
                baglanti.Open();
                using (SqlCommand komut = new SqlCommand("Update tbl_personeller set AD=@P1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAIL=@P5,IL=@P6,ILCE=@P7,ADRES=@P8,GOREV=@P9 WHERE ID=@P10", baglanti))
                {
                    komut.Parameters.AddWithValue("@P1", TxtAd.Text);
                    komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
                    komut.Parameters.AddWithValue("@P3", MskTelefon1.Text);
                    komut.Parameters.AddWithValue("@P4", MskTC.Text);
                    komut.Parameters.AddWithValue("@P5", TxtMail.Text);
                    komut.Parameters.AddWithValue("@P6", Cmbil.Text);
                    komut.Parameters.AddWithValue("@P7", Cmbilce.Text);
                    komut.Parameters.AddWithValue("@P8", RchAdres.Text);
                    komut.Parameters.AddWithValue("@P9", TxtGorev.Text);
                    komut.Parameters.AddWithValue("@P10", Txtid.Text);
                    komut.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Personel Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            personelliste();
        }
    }
}
