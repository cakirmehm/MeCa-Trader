using BtcAnalyisTool.Source;
using CoinTrader.Source;
using NetTrader.Indicator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CoinTrader.UI
{
    public partial class F_GeneralView : DockContent
    {
        private List<CRowInfo> RowList = new List<CRowInfo>();
        private CBinanceDataController DataController;

        private static F_GeneralView instance;
        private int ClickedColumnIndex;
        private List<ESortStatus> ColumnSortStatus = new List<ESortStatus>();
        private List<string> SelectedRows = new List<string>();

        public static F_GeneralView getInstance()
        {
            if (instance == null)
                instance = new F_GeneralView();
            return instance;
        }

        private F_GeneralView()
        {
            InitializeComponent();

            dgvSymbolPairs.DoubleBuffered(true);

            instance = this;
        }

        public void initialize()
        {
            RowList.Clear();
            foreach (string symbolPair in DataController.readAllSymbols("USDT", CUtils.RootFolderPath))
            {
                List<Ohlc> OhlcListLastMonth = DataController.getCandles(
                    symbolPair,
                    Binance.Net.Enums.KlineInterval.OneDay,
                    DateTime.Now.AddDays(-30),
                    DateTime.Now);


                if (OhlcListLastMonth.Count > 0)
                {
                    CRowInfo ri = new CRowInfo()
                    {
                        Symbol = symbolPair,
                        Price = OhlcListLastMonth.Last().Close,
                        Close_Price = OhlcListLastMonth.Last().Close,
                        Open_Price = OhlcListLastMonth.Last().Open,
                        High_Price = OhlcListLastMonth.Last().High,
                        Low_Price = OhlcListLastMonth.Last().Low,

                        //Volume_1h = OhlcListLastHour.Average(o => o.Volume),
                        Volume_24h = OhlcListLastMonth.Last().Volume,
                        Volume_7d = OhlcListLastMonth.Skip(Math.Max(0, OhlcListLastMonth.Count() - 7)).Average(o => o.Volume),
                        Volume_30d = OhlcListLastMonth.Average(o => o.Volume),

                        //Percent_Change_1h = -100 + (OhlcListLastHour.Last().Close * 100.0 / OhlcListLastHour.First().Close),
                        Percent_Change_24h = -100 + (OhlcListLastMonth.Last().Close * 100.0 / OhlcListLastMonth.Last().Open),
                        Percent_Change_7d = -100 + (OhlcListLastMonth.Last().Close * 100.0 / (OhlcListLastMonth.Skip(Math.Max(0, OhlcListLastMonth.Count() - 7)).First().Close)),
                        Percent_Change_30d = -100 + (OhlcListLastMonth.First().Close * 100.0 / OhlcListLastMonth.Last().Open),
                    };

                    RowList.Add(ri);
                }

               
            }
        }


        public void updateUI()
        {
            dgvSymbolPairs.DataSource = RowList.OrderByDescending(r => r.Percent_Change_24h).ToList();
            dgvSymbolPairs.Refresh();


            dgvSymbolPairs.Columns["Symbol"].DisplayIndex = 0;
            dgvSymbolPairs.Columns["Price"].DisplayIndex = 1;

            ColumnSortStatus.Clear();
            foreach (DataGridViewColumn column in dgvSymbolPairs.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                ColumnSortStatus.Add(ESortStatus.DEFAULT);
            }

            sortData(ClickedColumnIndex);
        }


   
        public void setDataController(CBinanceDataController dataController)
        {
            DataController = dataController;
        }

        private void F_GeneralView_Load(object sender, EventArgs e)
        {
          

        }

        private void dgvSymbolPairs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            CRowInfo ri = new CRowInfo();

            // Percent formatting
            if (dgvSymbolPairs.Columns[e.ColumnIndex].Name.ToLower().Contains("percent"))
            {
                e.CellStyle.Format = "0.00\\%";
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (e.Value != null)
                {
                    double dVal = (double)e.Value;
                    if (dVal > 0) e.CellStyle.ForeColor = Color.Green;
                    else e.CellStyle.ForeColor = Color.Red;
                }

            }

            else if (dgvSymbolPairs.Columns[e.ColumnIndex].Name.ToLower().Contains("price"))
            {
                e.CellStyle.Format = "C8" +
                    "";
                e.CellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            else
            {
                e.CellStyle.Format = "N2";
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void sortData(int columnIndex)
        {

            ClickedColumnIndex = columnIndex;

            // Def -> Desc
            // Desc -> Asc
            // Asc -> Desc

            if (ColumnSortStatus[columnIndex] == ESortStatus.DEFAULT)
                ColumnSortStatus[columnIndex] = ESortStatus.SORTED_DESC;
            else if (ColumnSortStatus[columnIndex] == ESortStatus.SORTED_DESC)
                ColumnSortStatus[columnIndex] = ESortStatus.SORTED_ASC;
            else if (ColumnSortStatus[columnIndex] == ESortStatus.SORTED_ASC)
                ColumnSortStatus[columnIndex] = ESortStatus.SORTED_DESC;

            for (int i = 0; i < ColumnSortStatus.Count && i != columnIndex; i++)
            {
                ColumnSortStatus[i] = ESortStatus.DEFAULT;
            }

            ESortStatus sortStatus = ColumnSortStatus[columnIndex];


            if (columnIndex == (int)EColumn.COL_0_SYMBOL)
            {
                dgvSymbolPairs.DataSource = sortStatus == ESortStatus.SORTED_ASC
                    ? RowList.OrderBy(r => r.Symbol).ToList()
                    : RowList.OrderByDescending(r => r.Symbol).ToList();
            }
            else if (columnIndex == (int)EColumn.COL_1_PRICE)
            {
                dgvSymbolPairs.DataSource = sortStatus == ESortStatus.SORTED_ASC
                    ? RowList.OrderBy(r => r.Price).ToList()
                    : RowList.OrderByDescending(r => r.Price).ToList();
            }

            else if (columnIndex == (int)EColumn.COL_2_VOLUME24H)
            {
                dgvSymbolPairs.DataSource = sortStatus == ESortStatus.SORTED_ASC
                    ? RowList.OrderBy(r => r.Volume_24h).ToList()
                    : RowList.OrderByDescending(r => r.Volume_24h).ToList();
            }
            else if (columnIndex == (int)EColumn.COL_3_VOLUME7D)
            {
                dgvSymbolPairs.DataSource = sortStatus == ESortStatus.SORTED_ASC
                    ? RowList.OrderBy(r => r.Volume_7d).ToList()
                    : RowList.OrderByDescending(r => r.Volume_7d).ToList();
            }
            else if (columnIndex == (int)EColumn.COL_4_VOLUME30D)
            {
                dgvSymbolPairs.DataSource = sortStatus == ESortStatus.SORTED_ASC
                    ? RowList.OrderBy(r => r.Volume_30d).ToList()
                    : RowList.OrderByDescending(r => r.Volume_30d).ToList();
            }
            else if (columnIndex == (int)EColumn.COL_5_PERCENT24H)
            {
                dgvSymbolPairs.DataSource = sortStatus == ESortStatus.SORTED_ASC
                    ? RowList.OrderBy(r => r.Percent_Change_24h).ToList()
                    : RowList.OrderByDescending(r => r.Percent_Change_24h).ToList();
            }
            else if (columnIndex == (int)EColumn.COL_6_PERCENT7D)
            {
                dgvSymbolPairs.DataSource = sortStatus == ESortStatus.SORTED_ASC
                    ? RowList.OrderBy(r => r.Percent_Change_7d).ToList()
                    : RowList.OrderByDescending(r => r.Percent_Change_7d).ToList();
            }
            else if (columnIndex == (int)EColumn.COL_7_PERCENT30D)
            {
                dgvSymbolPairs.DataSource = sortStatus == ESortStatus.SORTED_ASC
                    ? RowList.OrderBy(r => r.Percent_Change_30d).ToList()
                    : RowList.OrderByDescending(r => r.Percent_Change_30d).ToList();
            }
           

            dgvSymbolPairs.Columns[columnIndex].HeaderCell.SortGlyphDirection =
                ColumnSortStatus[columnIndex] == ESortStatus.SORTED_DESC
                ? SortOrder.Descending
                : SortOrder.Ascending;

        }

        private void dgvSymbolPairs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sortData(e.ColumnIndex);

                dgvSymbolPairs.ClearSelection();
                foreach (DataGridViewRow dRow in dgvSymbolPairs.Rows)
                {
                    if (SelectedRows.Any(s => s.Equals(dRow.Cells[(int)EColumn.COL_0_SYMBOL].Value.ToString())))
                    {
                        dgvSymbolPairs.Rows[dRow.Index].Selected = true;
                    }
                }

            }
            else if (e.Button == MouseButtons.Right)
            {

            }
        }

        public enum ESortStatus
        {
            DEFAULT = 0,
            SORTED_ASC,
            SORTED_DESC
        }

        public enum EColumn
        {
            COL_0_SYMBOL,
            COL_1_PRICE,
            COL_2_VOLUME24H,
            COL_3_VOLUME7D,
            COL_4_VOLUME30D,
            COL_5_PERCENT24H,
            COL_6_PERCENT7D,
            COL_7_PERCENT30D,
        }

        private void tsbtnIncreasingVolume_Click(object sender, EventArgs e)
        {
            dgvSymbolPairs.DataSource = RowList
                .Where(r => r.Volume_24h > r.Volume_7d && r.Volume_7d > r.Volume_30d)
                .OrderByDescending(r => r.Volume_24h)
                .ToList();
            dgvSymbolPairs.Refresh();
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            for (int i=0; i< RowList.Count; i++)
            {
                CRowInfo ri = RowList[i];

                List<Ohlc> OhlcListLastMonth = DataController.getCandles(
                    ri.Symbol,
                    Binance.Net.Enums.KlineInterval.OneDay,
                    DateTime.Now.AddDays(-30),
                    DateTime.Now);


                if (OhlcListLastMonth.Count > 0)
                {
                    CRowInfo riNew = new CRowInfo()
                    {
                        Symbol = ri.Symbol,
                        Price = OhlcListLastMonth.Last().Close,
                        Close_Price = OhlcListLastMonth.Last().Close,
                        Open_Price = OhlcListLastMonth.Last().Open,
                        High_Price = OhlcListLastMonth.Last().High,
                        Low_Price = OhlcListLastMonth.Last().Low,

                        //Volume_1h = OhlcListLastHour.Average(o => o.Volume),
                        Volume_24h = OhlcListLastMonth.Last().Volume,
                        Volume_7d = OhlcListLastMonth.Skip(Math.Max(0, OhlcListLastMonth.Count() - 7)).Average(o => o.Volume),
                        Volume_30d = OhlcListLastMonth.Average(o => o.Volume),

                        //Percent_Change_1h = -100 + (OhlcListLastHour.Last().Close * 100.0 / OhlcListLastHour.First().Close),
                        Percent_Change_24h = -100 + (OhlcListLastMonth.Last().Close * 100.0 / OhlcListLastMonth.Last().Open),
                        Percent_Change_7d = -100 + (OhlcListLastMonth.Last().Close * 100.0 / (OhlcListLastMonth.Skip(Math.Max(0, OhlcListLastMonth.Count() - 7)).First().Close)),
                        Percent_Change_30d = -100 + (OhlcListLastMonth.First().Close * 100.0 / OhlcListLastMonth.Last().Open),
                    };


                    RowList[i] = riNew;

                }

            }

            dgvSymbolPairs.DataSource = RowList.OrderByDescending(r => r.Percent_Change_24h).ToList();
            dgvSymbolPairs.Refresh();
        }

        private void tsbtnIncreasingPercent_Click(object sender, EventArgs e)
        {
            dgvSymbolPairs.DataSource = RowList
                .Where(r => r.Percent_Change_24h > r.Percent_Change_7d && r.Percent_Change_7d > r.Percent_Change_30d)
                .OrderByDescending(r => r.Percent_Change_24h)
                .ToList();
            dgvSymbolPairs.Refresh();
        }


    }
}
