using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System.Globalization;

namespace BeyazEsyaOtomasyon
{
    public partial class FrmRaporlar : Form
    {
        // GridControl'leri class seviyesinde tanımla
        GridControl gridMusteri, gridFirma, gridKasa, gridGider, gridPersonel;
        SimpleButton btnExportMusteri, btnExportFirma, btnExportKasa, btnExportGider, btnExportPersonel;
        SimpleButton btnExportMusteriPdf, btnExportFirmaPdf, btnExportKasaPdf, btnExportGiderPdf, btnExportPersonelPdf;

        public FrmRaporlar()
        {
            InitializeComponent();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            SqlBaglantisi bgl = new SqlBaglantisi();
            // Müşteri Raporları
            gridMusteri = new GridControl();
            GridView viewMusteri = new GridView();
            gridMusteri.MainView = viewMusteri;
            gridMusteri.Dock = DockStyle.Fill;
            DataTable dtMusteri = new DataTable();
            SqlDataAdapter daMusteri = new SqlDataAdapter("SELECT AD, SOYAD, IL, ILCE, TELEFON FROM TBL_MUSTERILER", bgl.baglanti());
            daMusteri.Fill(dtMusteri);
            gridMusteri.DataSource = dtMusteri;
            // Export butonları
            btnExportMusteri = new SimpleButton();
            btnExportMusteri.Text = "Excel'e Aktar";
            btnExportMusteri.Dock = DockStyle.Top;
            btnExportMusteri.Click += BtnExportMusteri_Click;
            btnExportMusteriPdf = new SimpleButton();
            btnExportMusteriPdf.Text = "PDF'ye Aktar";
            btnExportMusteriPdf.Dock = DockStyle.Top;
            btnExportMusteriPdf.Click += BtnExportMusteriPdf_Click;
            xtraTabPage1.Controls.Add(gridMusteri);
            xtraTabPage1.Controls.Add(btnExportMusteriPdf);
            xtraTabPage1.Controls.Add(btnExportMusteri);

            // Firma Raporları
            gridFirma = new GridControl();
            GridView viewFirma = new GridView();
            gridFirma.MainView = viewFirma;
            gridFirma.Dock = DockStyle.Fill;
            DataTable dtFirma = new DataTable();
            SqlDataAdapter daFirma = new SqlDataAdapter("SELECT AD, YETKILIADSOYAD, IL, ILCE, TELEFON1 FROM TBL_FIRMALAR", bgl.baglanti());
            daFirma.Fill(dtFirma);
            gridFirma.DataSource = dtFirma;
            btnExportFirma = new SimpleButton();
            btnExportFirma.Text = "Excel'e Aktar";
            btnExportFirma.Dock = DockStyle.Top;
            btnExportFirma.Click += BtnExportFirma_Click;
            btnExportFirmaPdf = new SimpleButton();
            btnExportFirmaPdf.Text = "PDF'ye Aktar";
            btnExportFirmaPdf.Dock = DockStyle.Top;
            btnExportFirmaPdf.Click += BtnExportFirmaPdf_Click;
            xtraTabPage2.Controls.Add(gridFirma);
            xtraTabPage2.Controls.Add(btnExportFirmaPdf);
            xtraTabPage2.Controls.Add(btnExportFirma);

            // Kasa Raporları
            gridKasa = new GridControl();
            GridView viewKasa = new GridView();
            gridKasa.MainView = viewKasa;
            gridKasa.Dock = DockStyle.Fill;
            DataTable dtKasa = new DataTable();
            SqlDataAdapter daKasa = new SqlDataAdapter("SELECT * FROM TBL_KASA", bgl.baglanti());
            daKasa.Fill(dtKasa);
            gridKasa.DataSource = dtKasa;
            btnExportKasa = new SimpleButton();
            btnExportKasa.Text = "Excel'e Aktar";
            btnExportKasa.Dock = DockStyle.Top;
            btnExportKasa.Click += BtnExportKasa_Click;
            btnExportKasaPdf = new SimpleButton();
            btnExportKasaPdf.Text = "PDF'ye Aktar";
            btnExportKasaPdf.Dock = DockStyle.Top;
            btnExportKasaPdf.Click += BtnExportKasaPdf_Click;
            xtraTabPage3.Controls.Add(gridKasa);
            xtraTabPage3.Controls.Add(btnExportKasaPdf);
            xtraTabPage3.Controls.Add(btnExportKasa);

            // Gider Raporları
            gridGider = new GridControl();
            GridView viewGider = new GridView();
            gridGider.MainView = viewGider;
            gridGider.Dock = DockStyle.Fill;
            DataTable dtGider = new DataTable();
            SqlDataAdapter daGider = new SqlDataAdapter("SELECT AY, YIL, ELEKTRIK, SU, DOGALGAZ, INTERNET, MAASLAR, EKSTRA FROM TBL_GIDERLER", bgl.baglanti());
            daGider.Fill(dtGider);
            gridGider.DataSource = dtGider;
            btnExportGider = new SimpleButton();
            btnExportGider.Text = "Excel'e Aktar";
            btnExportGider.Dock = DockStyle.Top;
            btnExportGider.Click += BtnExportGider_Click;
            btnExportGiderPdf = new SimpleButton();
            btnExportGiderPdf.Text = "PDF'ye Aktar";
            btnExportGiderPdf.Dock = DockStyle.Top;
            btnExportGiderPdf.Click += BtnExportGiderPdf_Click;
            xtraTabPage4.Controls.Add(gridGider);
            xtraTabPage4.Controls.Add(btnExportGiderPdf);
            xtraTabPage4.Controls.Add(btnExportGider);

            // Personel Raporları
            gridPersonel = new GridControl();
            GridView viewPersonel = new GridView();
            gridPersonel.MainView = viewPersonel;
            gridPersonel.Dock = DockStyle.Fill;
            DataTable dtPersonel = new DataTable();
            SqlDataAdapter daPersonel = new SqlDataAdapter("SELECT AD, SOYAD, GOREV, IL, TELEFON FROM TBL_PERSONELLER", bgl.baglanti());
            daPersonel.Fill(dtPersonel);
            gridPersonel.DataSource = dtPersonel;
            btnExportPersonel = new SimpleButton();
            btnExportPersonel.Text = "Excel'e Aktar";
            btnExportPersonel.Dock = DockStyle.Top;
            btnExportPersonel.Click += BtnExportPersonel_Click;
            btnExportPersonelPdf = new SimpleButton();
            btnExportPersonelPdf.Text = "PDF'ye Aktar";
            btnExportPersonelPdf.Dock = DockStyle.Top;
            btnExportPersonelPdf.Click += BtnExportPersonelPdf_Click;
            xtraTabPage5.Controls.Add(gridPersonel);
            xtraTabPage5.Controls.Add(btnExportPersonelPdf);
            xtraTabPage5.Controls.Add(btnExportPersonel);
        }

        private void BtnExportMusteri_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyası|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                gridMusteri.ExportToXlsx(saveFileDialog.FileName);
                MessageBox.Show("Müşteri raporu başarıyla Excel dosyasına aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnExportFirma_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyası|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                gridFirma.ExportToXlsx(saveFileDialog.FileName);
                MessageBox.Show("Firma raporu başarıyla Excel dosyasına aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnExportKasa_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyası|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                gridKasa.ExportToXlsx(saveFileDialog.FileName);
                MessageBox.Show("Kasa raporu başarıyla Excel dosyasına aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnExportGider_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyası|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                gridGider.ExportToXlsx(saveFileDialog.FileName);
                MessageBox.Show("Gider raporu başarıyla Excel dosyasına aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnExportPersonel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosyası|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                gridPersonel.ExportToXlsx(saveFileDialog.FileName);
                MessageBox.Show("Personel raporu başarıyla Excel dosyasına aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnExportMusteriPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Dosyası|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PrintingSystem ps = new PrintingSystem();
                PrintableComponentLink link = new PrintableComponentLink(ps);
                link.Component = gridMusteri;
                string raporAdi = "Müşteri Raporu";
                string tarihSaat = DateTime.Now.ToString("dd.MM.yyyy HH:mm", CultureInfo.GetCultureInfo("tr-TR"));
                string imza = "Bu dosya elektronik olarak imzalanmıştır.";
                string sirket = "IHS";
                string adres = "Çanakkale/MERKEZ 03. 459 TKL";
                link.CreateReportHeaderArea += (s, e2) =>
                {
                    e2.Graph.Font = new Font("Tahoma", 14, FontStyle.Bold);
                    e2.Graph.DrawString($"{raporAdi}", Color.Black, new RectangleF(0, 0, e2.Graph.ClientPageSize.Width, 40), BorderSide.None);
                    e2.Graph.Font = new Font("Tahoma", 10, FontStyle.Regular);
                    e2.Graph.DrawString($"Tarih/Saat: {tarihSaat}", Color.Black, new RectangleF(0, 40, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString($"Şirket: {sirket}", Color.Black, new RectangleF(0, 60, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString($"Adres: {adres}", Color.Black, new RectangleF(0, 80, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString(imza, Color.Black, new RectangleF(0, 100, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                };
                link.ExportToPdf(saveFileDialog.FileName);
                MessageBox.Show("Müşteri raporu başarıyla PDF dosyasına aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnExportFirmaPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Dosyası|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PrintingSystem ps = new PrintingSystem();
                PrintableComponentLink link = new PrintableComponentLink(ps);
                link.Component = gridFirma;
                string raporAdi = "Firma Raporu";
                string tarihSaat = DateTime.Now.ToString("dd.MM.yyyy HH:mm", CultureInfo.GetCultureInfo("tr-TR"));
                string imza = "Bu dosya elektronik olarak imzalanmıştır.";
                string sirket = "IHS";
                string adres = "Çanakkale/MERKEZ 03. 459 TKL";
                link.CreateReportHeaderArea += (s, e2) =>
                {
                    e2.Graph.Font = new Font("Tahoma", 14, FontStyle.Bold);
                    e2.Graph.DrawString($"{raporAdi}", Color.Black, new RectangleF(0, 0, e2.Graph.ClientPageSize.Width, 40), BorderSide.None);
                    e2.Graph.Font = new Font("Tahoma", 10, FontStyle.Regular);
                    e2.Graph.DrawString($"Tarih/Saat: {tarihSaat}", Color.Black, new RectangleF(0, 40, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString($"Şirket: {sirket}", Color.Black, new RectangleF(0, 60, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString($"Adres: {adres}", Color.Black, new RectangleF(0, 80, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString(imza, Color.Black, new RectangleF(0, 100, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                };
                link.ExportToPdf(saveFileDialog.FileName);
                MessageBox.Show("Firma raporu başarıyla PDF dosyasına aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnExportKasaPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Dosyası|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PrintingSystem ps = new PrintingSystem();
                PrintableComponentLink link = new PrintableComponentLink(ps);
                link.Component = gridKasa;
                string raporAdi = "Kasa Raporu";
                string tarihSaat = DateTime.Now.ToString("dd.MM.yyyy HH:mm", CultureInfo.GetCultureInfo("tr-TR"));
                string imza = "Bu dosya elektronik olarak imzalanmıştır.";
                string sirket = "IHS";
                string adres = "Çanakkale/MERKEZ 03. 459 TKL";
                link.CreateReportHeaderArea += (s, e2) =>
                {
                    e2.Graph.Font = new Font("Tahoma", 14, FontStyle.Bold);
                    e2.Graph.DrawString($"{raporAdi}", Color.Black, new RectangleF(0, 0, e2.Graph.ClientPageSize.Width, 40), BorderSide.None);
                    e2.Graph.Font = new Font("Tahoma", 10, FontStyle.Regular);
                    e2.Graph.DrawString($"Tarih/Saat: {tarihSaat}", Color.Black, new RectangleF(0, 40, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString($"Şirket: {sirket}", Color.Black, new RectangleF(0, 60, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString($"Adres: {adres}", Color.Black, new RectangleF(0, 80, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString(imza, Color.Black, new RectangleF(0, 100, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                };
                link.ExportToPdf(saveFileDialog.FileName);
                MessageBox.Show("Kasa raporu başarıyla PDF dosyasına aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnExportGiderPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Dosyası|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PrintingSystem ps = new PrintingSystem();
                PrintableComponentLink link = new PrintableComponentLink(ps);
                link.Component = gridGider;
                string raporAdi = "Gider Raporu";
                string tarihSaat = DateTime.Now.ToString("dd.MM.yyyy HH:mm", CultureInfo.GetCultureInfo("tr-TR"));
                string imza = "Bu dosya elektronik olarak imzalanmıştır.";
                string sirket = "IHS";
                string adres = "Çanakkale/MERKEZ 03. 459 TKL";
                link.CreateReportHeaderArea += (s, e2) =>
                {
                    e2.Graph.Font = new Font("Tahoma", 14, FontStyle.Bold);
                    e2.Graph.DrawString($"{raporAdi}", Color.Black, new RectangleF(0, 0, e2.Graph.ClientPageSize.Width, 40), BorderSide.None);
                    e2.Graph.Font = new Font("Tahoma", 10, FontStyle.Regular);
                    e2.Graph.DrawString($"Tarih/Saat: {tarihSaat}", Color.Black, new RectangleF(0, 40, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString($"Şirket: {sirket}", Color.Black, new RectangleF(0, 60, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString($"Adres: {adres}", Color.Black, new RectangleF(0, 80, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString(imza, Color.Black, new RectangleF(0, 100, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                };
                link.ExportToPdf(saveFileDialog.FileName);
                MessageBox.Show("Gider raporu başarıyla PDF dosyasına aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnExportPersonelPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Dosyası|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                PrintingSystem ps = new PrintingSystem();
                PrintableComponentLink link = new PrintableComponentLink(ps);
                link.Component = gridPersonel;
                string raporAdi = "Personel Raporu";
                string tarihSaat = DateTime.Now.ToString("dd.MM.yyyy HH:mm", CultureInfo.GetCultureInfo("tr-TR"));
                string imza = "Bu dosya elektronik olarak imzalanmıştır.";
                string sirket = "IHS";
                string adres = "Çanakkale/MERKEZ 03. 459 TKL";
                link.CreateReportHeaderArea += (s, e2) =>
                {
                    e2.Graph.Font = new Font("Tahoma", 14, FontStyle.Bold);
                    e2.Graph.DrawString($"{raporAdi}", Color.Black, new RectangleF(0, 0, e2.Graph.ClientPageSize.Width, 40), BorderSide.None);
                    e2.Graph.Font = new Font("Tahoma", 10, FontStyle.Regular);
                    e2.Graph.DrawString($"Tarih/Saat: {tarihSaat}", Color.Black, new RectangleF(0, 40, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString($"Şirket: {sirket}", Color.Black, new RectangleF(0, 60, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString($"Adres: {adres}", Color.Black, new RectangleF(0, 80, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                    e2.Graph.DrawString(imza, Color.Black, new RectangleF(0, 100, e2.Graph.ClientPageSize.Width, 20), BorderSide.None);
                };
                link.ExportToPdf(saveFileDialog.FileName);
                MessageBox.Show("Personel raporu başarıyla PDF dosyasına aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
