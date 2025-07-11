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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
           // chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 4);
           // chartControl1.Series["Series 1"].Points.AddPoint("İzmmir", 8);
           // chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 6);
           // chartControl1.Series["Series 1"].Points.AddPoint("Adana", 5);

            SqlDataAdapter da = new SqlDataAdapter("Select UrunAd,Sum(Adet) as 'Miktar' from TBL_URUNLER GROUP BY URUNAD",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //Charta Stok miktarı listeleme
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                SqlCommand komut = new SqlCommand("Select UrunAd, Sum(Adet) as Miktar from TBL_URUNLER GROUP BY URUNAD", conn);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    chartControl1.Series["Series 1"].Points.AddPoint(dr[0].ToString(), int.Parse(dr[1].ToString()));
                }
            }
            // CHARTA FİRMA – ŞEHİR SAYISI EKLEME
            using (SqlConnection conn2 = bgl.baglanti())
            {
                conn2.Open();
                SqlCommand komut2 = new SqlCommand("Select IL,Count(*) from TBL_FIRMALAR GROUP BY IL", conn2);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
                }
            }
        }
    }
}
