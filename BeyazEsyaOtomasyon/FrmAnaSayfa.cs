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
using System.Xml;

namespace BeyazEsyaOtomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,Sum(Adet) as 'Adet' From TBL_URUNLER group by URUNAD having sum(Adet) <=20 order by Sum(Adet)", bgl.baglanti());
            da.Fill(dt);
            GridControlStoklar.DataSource = dt;
        }

        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 10 TARIH ,SAAT ,BASLIK From TBL_NOTLAR order by ID DESC",bgl.baglanti());
            da.Fill(dt);
            GridControlAjanda.DataSource = dt;

        }

        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec FirmaHareket2", bgl.baglanti());
            da.Fill(dt);
            GridControlFirmaHareket.DataSource = dt;
        }

        void FirmaTelefonListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,TELEFON1 FROM TBL_FIRMALAR",bgl.baglanti());
            da.Fill(dt);
            GridControlTelefon.DataSource = dt;

        }

        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");                             // xml deki dosyları okur
            while (xmloku.Read())
            {
                if (xmloku.Name =="title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();

            ajanda();

            FirmaHareketleri();

            FirmaTelefonListesi();

            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");

            haberler();

        }
    }
}
