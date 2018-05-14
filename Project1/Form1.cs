using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ShowResults()
        {
            BarcodeReaderLib.BarcodeList BarcodeList = axBarcodeDecoder1.Barcodes;

            for (int i = 0; i < BarcodeList.length; i++)
            {
                BarcodeReaderLib.Barcode barcode = BarcodeList.item(i);
                string sResult = string.Format("{0}\n{1}\n({2},{3}),({4},{5}),({6},{7}),({8},{9})\nPage: {10}", barcode.BarcodeType.ToString(), barcode.Text, barcode.x1, barcode.y1, barcode.x2, barcode.y2, barcode.x3, barcode.y3, barcode.x4, barcode.y4, barcode.PageNum);
                MessageBox.Show(sResult);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axBarcodeDecoder1.LinearFindBarcodes = 7;
            axBarcodeDecoder1.DecodeFile(textBox1.Text);
            ShowResults();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axBarcodeDecoder1.AboutBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String Version, LicenseInfo, hwID;
            int Edition, Symbology;
            DateTime buildDate, expDate;
            axBarcodeDecoder1.GetSDKInfo(out Version, out Edition, out Symbology, out buildDate, out LicenseInfo, out expDate, out hwID);

            string sSymbology="";
            if ((Symbology & 1) != 0)
                sSymbology = "Linear ";
            if ((Symbology & 2) != 0)
                sSymbology += "PDF417 ";
            if ((Symbology & 4) != 0)
                sSymbology += "DataMatrix ";

            string sResult = string.Format("Version: {0}\n\nEdition: {1} ({2})\n\nLicensed to: {3}\n\nBuild date: {4}\n\nExpire date: {5}", Version, (Edition == 1 ? "Standard" : "Professional"), sSymbology, LicenseInfo, buildDate, expDate);
            MessageBox.Show(sResult);
        }
    }
}
