using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTrader.Indicator;
using System.Globalization;
using System.Reflection;
using BtcAnalyisTool.Source;

namespace CoinTrader.UI
{
    public partial class ucCandleTable : UserControl
    {
        public List<Ohlc> CandleList { get; set; } = new List<Ohlc>();

        public ucCandleTable()
        {
            InitializeComponent();

            dgvCandles.DoubleBuffered(true);
        }

        public void updateUI()
        {
            if (CandleList.Count == 0) return;

            DateTime dtStart = CandleList.First().Date;
            DateTime dtEnd = CandleList.Last().Date;

            gbxCandleTable.Text = $"Candles between {dtStart} and {dtEnd}.";

            dgvCandles.DataSource = CandleList.ToList();
            dgvCandles.Update();

   
            dgvCandles.Columns["AdjClose"].Visible = false;

            for (int i = 1; i < dgvCandles.Rows.Count; i++)
            {
                double volCurr = (double)dgvCandles["Close", i].Value;
                double volPrev = (double)dgvCandles["Open", i - 1].Value;

                if (volCurr > volPrev)
                {
                    dgvCandles.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                }
                else
                {
                    dgvCandles.Rows[i].DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        private void dgvCandles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            if (e.ColumnIndex >= 1 && e.ColumnIndex <= 4)
            {
                e.CellStyle.Format = "c8";
                e.CellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            }
            else if (e.ColumnIndex == 0)
            {
                e.CellStyle.Format = "yyyy.MM.dd HH:mm";
            }
            else
            {
                e.CellStyle.Format = "n3";
            }

        }
    }
}
