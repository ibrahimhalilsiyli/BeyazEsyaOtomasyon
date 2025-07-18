﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeyazEsyaOtomasyon
{
    public partial class FrmAnaModul : DevExpress.XtraEditors.XtraForm
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        FrmUrunler fr;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null)
            {
            fr = new FrmUrunler();
            fr.MdiParent = this;
            fr.Show();
        }
    }
        public string kullanici;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (fr15 == null)
            {
                fr15 = new FrmAnaSayfa();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }

        FrmMusteriler fr2;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null)
            {
                fr2 = new FrmMusteriler();
                fr2.MdiParent = this;
                fr2.Show();
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
        FrmFirmalar fr3;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        if(fr3 == null)
            {
            fr3 = new FrmFirmalar();
            fr3.MdiParent = this;
            fr3.Show();
            }
        }

        FrmPersonel fr4;
        private void BtnPersonaller_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null)
            {
                fr4 = new FrmPersonel();   // fr4 nesnesini personal sınıfımdan ürettik
                fr4.MdiParent = this;
                fr4.Show();
            }
         
        }

        FrmRehber fr5;

        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         if (fr5 == null)
            {
                fr5 = new FrmRehber();
                fr5.MdiParent = this;
                fr5.Show();
            }

        }

        FrmGiderler fr6;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null)
            {
                fr6 = new FrmGiderler();
                fr6.MdiParent = this;
                fr6.Show();
            }

        }

        FrmBankalar fr7;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null)
            {
                fr7 = new FrmBankalar();
                fr7.MdiParent = this;
                fr7.Show();
            }

        }

        FrmFaturalar fr8;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null)
            {
                fr8 = new FrmFaturalar();
                fr8.MdiParent = this;
                fr8.Show();
            }

        }

        FrmNotlar fr9;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null)
            {
                fr9 = new FrmNotlar();
                fr9.MdiParent = this;
                fr9.Show();
            }

        }

        FrmHareketler fr10;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null)
            {
                fr10 = new FrmHareketler();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }

        FrmRaporlar fr11;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr11 == null)
            {
                fr11 = new FrmRaporlar();
                fr11.MdiParent = this;
                fr11.Show();
            }

        }

        FrmStoklar fr12;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null)
            {
                fr12 = new FrmStoklar();
                fr12.MdiParent = this;
                fr12.Show();
            }

        }
        FrmAyarlar fr13;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null)
            {
                fr13 = new FrmAyarlar();
                fr13.Show();
            }
        }
        FrmKasa fr14;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null)
            {
                fr14 = new FrmKasa();
                fr14.ad = kullanici;
                fr14.MdiParent = this;
                fr14.Show();
            }

        }
        FrmAnaSayfa fr15;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15 == null)
            {
                fr15 = new FrmAnaSayfa();            
                fr15.MdiParent = this;
                fr15.Show();
            }
        }

        FrmSatis fr16;
        private void BtnSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr16 == null)
            {
                fr16 = new FrmSatis();
                fr16.MdiParent = this;
                fr16.Show();
            }
        }
    }
}
