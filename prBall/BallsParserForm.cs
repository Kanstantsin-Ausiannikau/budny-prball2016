using prBall.Code;
using scanner.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace prBall
{
    public partial class BallsParserForm : Form
    {

        List<BallsParsingItem> list;

        public BallsParserForm()
        {
            InitializeComponent();
        }

        private void btnLoadBalls_Click(object sender, EventArgs e)
        {
            if (ofdLoadExcel.ShowDialog()==DialogResult.OK)
            {
                var list = ExcelData.LoadFromExcel(ofdLoadExcel.FileName);
                dgvViewBalls.DataSource = list;

                Data.SetDataGridProperty(dgvViewBalls);
            }
        }

        private void btnLoadExternalData_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtParseAddress.Text))
            {
                HtmlAgilityPack.HtmlDocument doc = Downloader.DownloadPage(txtParseAddress.Text);

                list = BallsParser.Parse(doc);

                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (list != null)
            {
                if (saveToExcel.ShowDialog() == DialogResult.OK)
                {
                    ExcelData.SaveToExcel((List<CFData2016>)dgvViewBalls.DataSource, list, saveToExcel.FileName);
                }
            }
        }
    }
}
