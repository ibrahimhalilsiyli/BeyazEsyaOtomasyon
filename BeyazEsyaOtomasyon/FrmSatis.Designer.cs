namespace BeyazEsyaOtomasyon
{
    partial class FrmSatis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtToplam = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtFiyat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.nudMiktar = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbMusteri = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbUrun = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnPdf = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSatisYap = new DevExpress.XtraEditors.SimpleButton();
            this.btnYeniSatis = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFATURABILGIID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFATURA_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMUSTERI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colURUNAD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMIKTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFIYAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTUTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMusteri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUrun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.txtToplam);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtFiyat);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.nudMiktar);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cmbMusteri);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cmbUrun);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(400, 250);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "SATIŞ BİLGİLERİ";
            // 
            // txtToplam
            // 
            this.txtToplam.Location = new System.Drawing.Point(120, 200);
            this.txtToplam.Name = "txtToplam";
            this.txtToplam.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtToplam.Properties.Appearance.Options.UseFont = true;
            this.txtToplam.Properties.ReadOnly = true;
            this.txtToplam.Size = new System.Drawing.Size(250, 26);
            this.txtToplam.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(30, 203);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(84, 19);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "TOPLAM:";
            // 
            // txtFiyat
            // 
            this.txtFiyat.Location = new System.Drawing.Point(120, 160);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFiyat.Properties.Appearance.Options.UseFont = true;
            this.txtFiyat.Size = new System.Drawing.Size(250, 26);
            this.txtFiyat.TabIndex = 7;
            this.txtFiyat.TextChanged += new System.EventHandler(this.txtFiyat_TextChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(30, 163);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 19);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "FİYAT:";
            // 
            // nudMiktar
            // 
            this.nudMiktar.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMiktar.Location = new System.Drawing.Point(120, 120);
            this.nudMiktar.Name = "nudMiktar";
            this.nudMiktar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudMiktar.Properties.Appearance.Options.UseFont = true;
            this.nudMiktar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nudMiktar.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMiktar.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMiktar.Size = new System.Drawing.Size(250, 26);
            this.nudMiktar.TabIndex = 5;
            this.nudMiktar.ValueChanged += new System.EventHandler(this.nudMiktar_ValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(30, 123);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(84, 19);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "MİKTAR:";
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.Location = new System.Drawing.Point(120, 80);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbMusteri.Properties.Appearance.Options.UseFont = true;
            this.cmbMusteri.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMusteri.Properties.NullText = "Müşteri Seçiniz";
            this.cmbMusteri.Size = new System.Drawing.Size(250, 26);
            this.cmbMusteri.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(30, 83);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 19);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "MÜŞTERİ:";
            // 
            // cmbUrun
            // 
            this.cmbUrun.Location = new System.Drawing.Point(120, 40);
            this.cmbUrun.Name = "cmbUrun";
            this.cmbUrun.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbUrun.Properties.Appearance.Options.UseFont = true;
            this.cmbUrun.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUrun.Properties.NullText = "Ürün Seçiniz";
            this.cmbUrun.Size = new System.Drawing.Size(250, 26);
            this.cmbUrun.TabIndex = 1;
            this.cmbUrun.EditValueChanged += new System.EventHandler(this.cmbUrun_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(30, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ÜRÜN:";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.btnPdf);
            this.groupControl2.Controls.Add(this.btnExcel);
            this.groupControl2.Controls.Add(this.btnSil);
            this.groupControl2.Controls.Add(this.btnGuncelle);
            this.groupControl2.Controls.Add(this.btnSatisYap);
            this.groupControl2.Controls.Add(this.btnYeniSatis);
            this.groupControl2.Location = new System.Drawing.Point(430, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(200, 250);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "İŞLEMLER";
            // 
            // btnPdf
            // 
            this.btnPdf.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPdf.Appearance.Options.UseFont = true;
            this.btnPdf.Location = new System.Drawing.Point(20, 200);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(160, 35);
            this.btnPdf.TabIndex = 5;
            this.btnPdf.Text = "PDF\'ye Aktar";
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcel.Appearance.Options.UseFont = true;
            this.btnExcel.Location = new System.Drawing.Point(20, 160);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(160, 35);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "Excel\'e Aktar";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.Location = new System.Drawing.Point(20, 120);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(160, 35);
            this.btnSil.TabIndex = 3;
            this.btnSil.Text = "SİL";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Appearance.Options.UseFont = true;
            this.btnGuncelle.Location = new System.Drawing.Point(20, 80);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(160, 35);
            this.btnGuncelle.TabIndex = 2;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSatisYap
            // 
            this.btnSatisYap.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatisYap.Appearance.Options.UseFont = true;
            this.btnSatisYap.Location = new System.Drawing.Point(20, 40);
            this.btnSatisYap.Name = "btnSatisYap";
            this.btnSatisYap.Size = new System.Drawing.Size(160, 35);
            this.btnSatisYap.TabIndex = 1;
            this.btnSatisYap.Text = "SATIŞ YAP";
            this.btnSatisYap.Click += new System.EventHandler(this.btnSatisYap_Click);
            // 
            // btnYeniSatis
            // 
            this.btnYeniSatis.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeniSatis.Appearance.Options.UseFont = true;
            this.btnYeniSatis.Location = new System.Drawing.Point(20, 40);
            this.btnYeniSatis.Name = "btnYeniSatis";
            this.btnYeniSatis.Size = new System.Drawing.Size(160, 35);
            this.btnYeniSatis.TabIndex = 0;
            this.btnYeniSatis.Text = "YENİ SATIŞ";
            this.btnYeniSatis.Click += new System.EventHandler(this.btnYeniSatis_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupControl3.Appearance.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.gridControl1);
            this.groupControl3.Location = new System.Drawing.Point(12, 280);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1180, 400);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "SATIŞ LİSTESİ";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 28);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1176, 370);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFATURABILGIID,
            this.colFATURA_NO,
            this.colTARIH,
            this.colSAAT,
            this.colMUSTERI,
            this.colURUNAD,
            this.colMIKTAR,
            this.colFIYAT,
            this.colTUTAR});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colFATURABILGIID
            // 
            this.colFATURABILGIID.Caption = "FATURA ID";
            this.colFATURABILGIID.FieldName = "FATURABILGIID";
            this.colFATURABILGIID.Name = "colFATURABILGIID";
            this.colFATURABILGIID.Visible = true;
            this.colFATURABILGIID.VisibleIndex = 0;
            this.colFATURABILGIID.Width = 100;
            // 
            // colFATURA_NO
            // 
            this.colFATURA_NO.Caption = "FATURA NO";
            this.colFATURA_NO.FieldName = "FATURA_NO";
            this.colFATURA_NO.Name = "colFATURA_NO";
            this.colFATURA_NO.Visible = true;
            this.colFATURA_NO.VisibleIndex = 1;
            this.colFATURA_NO.Width = 120;
            // 
            // colTARIH
            // 
            this.colTARIH.Caption = "TARİH";
            this.colTARIH.FieldName = "TARIH";
            this.colTARIH.Name = "colTARIH";
            this.colTARIH.Visible = true;
            this.colTARIH.VisibleIndex = 2;
            this.colTARIH.Width = 100;
            // 
            // colSAAT
            // 
            this.colSAAT.Caption = "SAAT";
            this.colSAAT.FieldName = "SAAT";
            this.colSAAT.Name = "colSAAT";
            this.colSAAT.Visible = true;
            this.colSAAT.VisibleIndex = 3;
            this.colSAAT.Width = 80;
            // 
            // colMUSTERI
            // 
            this.colMUSTERI.Caption = "MÜŞTERİ";
            this.colMUSTERI.FieldName = "MUSTERI";
            this.colMUSTERI.Name = "colMUSTERI";
            this.colMUSTERI.Visible = true;
            this.colMUSTERI.VisibleIndex = 4;
            this.colMUSTERI.Width = 150;
            // 
            // colURUNAD
            // 
            this.colURUNAD.Caption = "ÜRÜN";
            this.colURUNAD.FieldName = "URUNAD";
            this.colURUNAD.Name = "colURUNAD";
            this.colURUNAD.Visible = true;
            this.colURUNAD.VisibleIndex = 5;
            this.colURUNAD.Width = 200;
            // 
            // colMIKTAR
            // 
            this.colMIKTAR.Caption = "MİKTAR";
            this.colMIKTAR.FieldName = "MIKTAR";
            this.colMIKTAR.Name = "colMIKTAR";
            this.colMIKTAR.Visible = true;
            this.colMIKTAR.VisibleIndex = 6;
            this.colMIKTAR.Width = 80;
            // 
            // colFIYAT
            // 
            this.colFIYAT.Caption = "FİYAT";
            this.colFIYAT.FieldName = "FIYAT";
            this.colFIYAT.Name = "colFIYAT";
            this.colFIYAT.Visible = true;
            this.colFIYAT.VisibleIndex = 7;
            this.colFIYAT.Width = 100;
            // 
            // colTUTAR
            // 
            this.colTUTAR.Caption = "TUTAR";
            this.colTUTAR.FieldName = "TUTAR";
            this.colTUTAR.Name = "colTUTAR";
            this.colTUTAR.Visible = true;
            this.colTUTAR.VisibleIndex = 8;
            this.colTUTAR.Width = 120;
            // 
            // FrmSatis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmSatis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SATIŞ İŞLEMLERİ";
            this.Load += new System.EventHandler(this.FrmSatis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMusteri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUrun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtToplam;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtFiyat;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit nudMiktar;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit cmbMusteri;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cmbUrun;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnPdf;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnSatisYap;
        private DevExpress.XtraEditors.SimpleButton btnYeniSatis;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFATURABILGIID;
        private DevExpress.XtraGrid.Columns.GridColumn colFATURA_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colSAAT;
        private DevExpress.XtraGrid.Columns.GridColumn colMUSTERI;
        private DevExpress.XtraGrid.Columns.GridColumn colURUNAD;
        private DevExpress.XtraGrid.Columns.GridColumn colMIKTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colFIYAT;
        private DevExpress.XtraGrid.Columns.GridColumn colTUTAR;
    }
}