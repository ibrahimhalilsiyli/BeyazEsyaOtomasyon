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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            BtnGirisYap.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            BtnGirisYap.BackColor = Color.DarkTurquoise;
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = bgl.baglanti())
            {
                conn.Open();
                SqlCommand komut = new SqlCommand("Select *From TBL_ADMIN where KULLANICIAD = @p1 and SIFRE = @p2", conn);
                komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    FrmAnaModul fr = new FrmAnaModul();
                    fr.kullanici = TxtKullaniciAd.Text;
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifreyi hatalı girdiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
