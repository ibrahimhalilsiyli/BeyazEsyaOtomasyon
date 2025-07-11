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
using DevExpress.Charts;


namespace BeyazEsyaOtomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        // SqlDataAdapter işlemlerini de using ile güvenli hale getiriyorum
        void musteriHareket()
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Execute MusteriHareketler", conn);
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
        }
        void firmaHareket()
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter("Execute FirmaHareketler", conn);
                da2.Fill(dt2);
                gridControl3.DataSource = dt2;
            }
        }
        void Giderler()
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                DataTable dt3 = new DataTable();
                SqlDataAdapter da3 = new SqlDataAdapter("Select *From TBL_GIDERLER", conn);
                da3.Fill(dt3);
                gridControl2.DataSource = dt3;
            }
        }


        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            LblAktifKullanici.Text = ad;
            musteriHareket();
            Giderler();
            firmaHareket();

            // Toplam Tutarı Hesaplama
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                SqlCommand komut1 = new SqlCommand("Select Sum(Tutar) From TBL_FATURADETAY", conn);
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    LblKasaToplam.Text = dr1[0].ToString();
                }
            }
            // Son ayın faturaları
            using (SqlConnection conn2 = bgl.baglanti())
            {
                conn2.Open();
                SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) from TBL_GIDERLER order by ID ASC", conn2);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    LblOdemeler.Text = dr2[0].ToString() + " TL";
                }
            }

            // son ayın personel maaşları
            using (SqlConnection conn3 = bgl.baglanti())
            {
                conn3.Open();
                SqlCommand komut3 = new SqlCommand("Select MAASLAR From TBL_GIDERLER order by ID ASC", conn3);
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    LblPersonelMaas.Text = dr3[0].ToString();
                }
            }
            // Toplam müşteri sayısı
            using (SqlConnection conn4 = bgl.baglanti())
            {
                conn4.Open();
                SqlCommand komut4 = new SqlCommand("select count(*) From TBL_MUSTERILER", conn4);
                SqlDataReader dr4 = komut4.ExecuteReader();
                while (dr4.Read())
                {
                    LblMusteriSayisi.Text = dr4[0].ToString();
                }
            }


            // Toplam Firma Sayısı
            using (SqlConnection conn5 = bgl.baglanti())
            {
                conn5.Open();
                SqlCommand komut5 = new SqlCommand("Select Count(*) From TBL_FIRMALAR", conn5);
                SqlDataReader dr5 = komut5.ExecuteReader();
                while (dr5.Read())
                {
                    LblFirmaSayisi.Text = dr5[0].ToString();
                }
            }
            // Toplam Firma Şehir Sayısı
            using (SqlConnection conn6 = bgl.baglanti())
            {
                conn6.Open();
                SqlCommand komut6 = new SqlCommand("Select Count(Distinct(IL)) From TBL_FIRMALAR", conn6);
                SqlDataReader dr6 = komut6.ExecuteReader();
                while (dr6.Read())
                {
                    LblSehirSayisi.Text = dr6[0].ToString();
                }
            }

            // Toplam Müşteri Şehir Sayısı
            using (SqlConnection conn7 = bgl.baglanti())
            {
                conn7.Open();
                SqlCommand komut7 = new SqlCommand("Select Count(Distinct(IL)) From TBL_MUSTERILER", conn7);
                SqlDataReader dr7 = komut7.ExecuteReader();
                while (dr7.Read())
                {
                    LblSehirSayisi2.Text = dr7[0].ToString();
                }
            }
            // Toplam Personel Sayısı
            using (SqlConnection conn8 = bgl.baglanti())
            {
                conn8.Open();
                SqlCommand komut8 = new SqlCommand("Select Count(*) From TBL_PERSONELLER", conn8);
                SqlDataReader dr8 = komut8.ExecuteReader();
                while (dr8.Read())
                {
                    LblPersonelSayisi.Text = dr8[0].ToString();
                }
            }

            // Toplam Ürün Sayısı
            using (SqlConnection conn9 = bgl.baglanti())
            {
                conn9.Open();
                SqlCommand komut9 = new SqlCommand("Select Count(*) From TBL_URUNLER", conn9);
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    LblStokSayisi.Text = dr9[0].ToString();
                }
            }
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            //Elektrik
            if(sayac > 0 && sayac <= 5)
            {            
                groupControl10.Text = "Elektrik";
                chartControl1.Series["Aylar"].Points.Clear();
                using (SqlConnection conn10 = bgl.baglanti())
                {
                    conn10.Open();
                    SqlCommand komut10 = new SqlCommand("Select Top 4 Ay,ELEKTRIK From TBL_GIDERLER order by ID DESC", conn10);
                    SqlDataReader dr10 = komut10.ExecuteReader();
                    while (dr10.Read())
                    {
                        chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                    }
                }
            }
            //Su
            if(sayac > 5 && sayac <= 10)
            {
                groupControl10.Text = "Su";
                chartControl1.Series["Aylar"].Points.Clear();
                using (SqlConnection conn11 = bgl.baglanti())
                {
                    conn11.Open();
                    SqlCommand komut11 = new SqlCommand("Select Top 4 Ay,SU From TBL_GIDERLER order by ID DESC", conn11);
                    SqlDataReader dr11 = komut11.ExecuteReader();
                    while (dr11.Read())
                    {
                        chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                    }
                }
            }
            //Dogalgaz
            if (sayac > 10 && sayac <= 15)
            {
                groupControl10.Text = "Doğalgaz";
                chartControl1.Series["Aylar"].Points.Clear();
                using (SqlConnection conn12 = bgl.baglanti())
                {
                    conn12.Open();
                    SqlCommand komut12 = new SqlCommand("Select Top 4 Ay,DOGALGAZ From TBL_GIDERLER order by ID DESC", conn12);
                    SqlDataReader dr12 = komut12.ExecuteReader();
                    while (dr12.Read())
                    {
                        chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                    }
                }
            }
            //Internet
            if (sayac > 15 && sayac <= 20)
            {
                groupControl10.Text = "İnternet";
                chartControl1.Series["Aylar"].Points.Clear();
                using (SqlConnection conn13 = bgl.baglanti())
                {
                    conn13.Open();
                    SqlCommand komut13 = new SqlCommand("Select Top 4 Ay,INTERNET From TBL_GIDERLER order by ID DESC", conn13);
                    SqlDataReader dr13 = komut13.ExecuteReader();
                    while (dr13.Read())
                    {
                        chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                    }
                }
            }
            //Ekstra
            if (sayac > 20 && sayac <= 25)
            {
                groupControl10.Text = "Ekstra";
                chartControl1.Series["Aylar"].Points.Clear();
                using (SqlConnection conn14 = bgl.baglanti())
                {
                    conn14.Open();
                    SqlCommand komut14 = new SqlCommand("Select Top 4 Ay,EKSTRA From TBL_GIDERLER order by ID DESC", conn14);
                    SqlDataReader dr14 = komut14.ExecuteReader();
                    while (dr14.Read())
                    {
                        chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                    }
                }
            }
            if (sayac == 25) sayac = 0;
        }

        int sayac2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;
            //Elektrik
            if (sayac2 > 0 && sayac2 <= 5)
            {
                groupControl11.Text = "Elektrik";
                chartControl2.Series["Aylar"].Points.Clear();
                using (SqlConnection conn10 = bgl.baglanti())
                {
                    conn10.Open();
                    SqlCommand komut10 = new SqlCommand("Select Top 4 Ay,ELEKTRIK From TBL_GIDERLER order by ID DESC", conn10);
                    SqlDataReader dr10 = komut10.ExecuteReader();
                    while (dr10.Read())
                    {
                        chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                    }
                }
            }
            //Su
            if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl11.Text = "Su";
                chartControl2.Series["Aylar"].Points.Clear();
                using (SqlConnection conn11 = bgl.baglanti())
                {
                    conn11.Open();
                    SqlCommand komut11 = new SqlCommand("Select Top 4 Ay,SU From TBL_GIDERLER order by ID DESC", conn11);
                    SqlDataReader dr11 = komut11.ExecuteReader();
                    while (dr11.Read())
                    {
                        chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                    }
                }
            }
            //Dogalgaz
            if (sayac2 > 10 && sayac2 <= 15)
            {
                groupControl11.Text = "Doğalgaz";
                chartControl2.Series["Aylar"].Points.Clear();
                using (SqlConnection conn12 = bgl.baglanti())
                {
                    conn12.Open();
                    SqlCommand komut12 = new SqlCommand("Select Top 4 Ay,DOGALGAZ From TBL_GIDERLER order by ID DESC", conn12);
                    SqlDataReader dr12 = komut12.ExecuteReader();
                    while (dr12.Read())
                    {
                        chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                    }
                }
            }
            //Internet
            if (sayac2 > 15 && sayac2 <= 20)
            {
                groupControl11.Text = "İnternet";
                chartControl2.Series["Aylar"].Points.Clear();
                using (SqlConnection conn13 = bgl.baglanti())
                {
                    conn13.Open();
                    SqlCommand komut13 = new SqlCommand("Select Top 4 Ay,INTERNET From TBL_GIDERLER order by ID DESC", conn13);
                    SqlDataReader dr13 = komut13.ExecuteReader();
                    while (dr13.Read())
                    {
                        chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                    }
                }
            }
            //Ekstra
            if (sayac2 > 20 && sayac2 <= 25)
            {
                groupControl11.Text = "Ekstra";
                chartControl2.Series["Aylar"].Points.Clear();
                using (SqlConnection conn14 = bgl.baglanti())
                {
                    conn14.Open();
                    SqlCommand komut14 = new SqlCommand("Select Top 4 Ay,EKSTRA From TBL_GIDERLER order by ID DESC", conn14);
                    SqlDataReader dr14 = komut14.ExecuteReader();
                    while (dr14.Read())
                    {
                        chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                    }
                }
            }
            if (sayac2 == 25) sayac2 = 0;
        }
    }
}
