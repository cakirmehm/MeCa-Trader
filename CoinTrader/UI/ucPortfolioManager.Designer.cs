namespace CoinTrader.UI
{
    partial class ucPortfolioManager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxPortfolio = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalBudgetInUSD = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBudgetInSatoshi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlPortfolio = new System.Windows.Forms.TabControl();
            this.tabPageSpotWallet = new System.Windows.Forms.TabPage();
            this.tabPageHistory = new System.Windows.Forms.TabPage();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.lblTotalProfitTitle = new System.Windows.Forms.Label();
            this.lblAverageCost = new System.Windows.Forms.Label();
            this.lblAverageCostTitle = new System.Windows.Forms.Label();
            this.lblSell = new System.Windows.Forms.Label();
            this.lblBuyLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSymbolSelection = new System.Windows.Forms.ComboBox();
            this.dataGridViewTransactionHistory = new System.Windows.Forms.DataGridView();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.gbxPortfolio.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControlPortfolio.SuspendLayout();
            this.tabPageHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxPortfolio
            // 
            this.gbxPortfolio.Controls.Add(this.tabControlPortfolio);
            this.gbxPortfolio.Controls.Add(this.panel1);
            this.gbxPortfolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxPortfolio.Location = new System.Drawing.Point(0, 0);
            this.gbxPortfolio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbxPortfolio.Name = "gbxPortfolio";
            this.gbxPortfolio.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbxPortfolio.Size = new System.Drawing.Size(617, 655);
            this.gbxPortfolio.TabIndex = 0;
            this.gbxPortfolio.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblTotalBudgetInUSD);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblBudgetInSatoshi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 80);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(501, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 22);
            this.label6.TabIndex = 6;
            this.label6.Text = "0,00";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Green;
            this.label7.Location = new System.Drawing.Point(474, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 23);
            this.label7.TabIndex = 5;
            this.label7.Text = "$ ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kâr / Zarar";
            // 
            // lblTotalBudgetInUSD
            // 
            this.lblTotalBudgetInUSD.AutoSize = true;
            this.lblTotalBudgetInUSD.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalBudgetInUSD.Location = new System.Drawing.Point(198, 40);
            this.lblTotalBudgetInUSD.Name = "lblTotalBudgetInUSD";
            this.lblTotalBudgetInUSD.Size = new System.Drawing.Size(37, 18);
            this.lblTotalBudgetInUSD.TabIndex = 3;
            this.lblTotalBudgetInUSD.Text = "0,00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(159, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = " = ";
            // 
            // lblBudgetInSatoshi
            // 
            this.lblBudgetInSatoshi.AutoSize = true;
            this.lblBudgetInSatoshi.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBudgetInSatoshi.Location = new System.Drawing.Point(20, 37);
            this.lblBudgetInSatoshi.Name = "lblBudgetInSatoshi";
            this.lblBudgetInSatoshi.Size = new System.Drawing.Size(124, 23);
            this.lblBudgetInSatoshi.TabIndex = 1;
            this.lblBudgetInSatoshi.Text = "0,00000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Net Değer (BTC)";
            // 
            // tabControlPortfolio
            // 
            this.tabControlPortfolio.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlPortfolio.Controls.Add(this.tabPageSpotWallet);
            this.tabControlPortfolio.Controls.Add(this.tabPageHistory);
            this.tabControlPortfolio.Controls.Add(this.tabPageSummary);
            this.tabControlPortfolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPortfolio.HotTrack = true;
            this.tabControlPortfolio.Location = new System.Drawing.Point(3, 100);
            this.tabControlPortfolio.Name = "tabControlPortfolio";
            this.tabControlPortfolio.SelectedIndex = 0;
            this.tabControlPortfolio.Size = new System.Drawing.Size(611, 551);
            this.tabControlPortfolio.TabIndex = 2;
            this.tabControlPortfolio.SelectedIndexChanged += new System.EventHandler(this.tabControlPortfolio_SelectedIndexChanged);
            // 
            // tabPageSpotWallet
            // 
            this.tabPageSpotWallet.AutoScroll = true;
            this.tabPageSpotWallet.Location = new System.Drawing.Point(4, 4);
            this.tabPageSpotWallet.Name = "tabPageSpotWallet";
            this.tabPageSpotWallet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpotWallet.Size = new System.Drawing.Size(603, 522);
            this.tabPageSpotWallet.TabIndex = 0;
            this.tabPageSpotWallet.Text = "Spot Cüzdan";
            this.tabPageSpotWallet.UseVisualStyleBackColor = true;
            // 
            // tabPageHistory
            // 
            this.tabPageHistory.Controls.Add(this.lblTotalProfit);
            this.tabPageHistory.Controls.Add(this.lblTotalProfitTitle);
            this.tabPageHistory.Controls.Add(this.lblAverageCost);
            this.tabPageHistory.Controls.Add(this.lblAverageCostTitle);
            this.tabPageHistory.Controls.Add(this.lblSell);
            this.tabPageHistory.Controls.Add(this.lblBuyLabel);
            this.tabPageHistory.Controls.Add(this.label2);
            this.tabPageHistory.Controls.Add(this.cmbSymbolSelection);
            this.tabPageHistory.Controls.Add(this.dataGridViewTransactionHistory);
            this.tabPageHistory.Location = new System.Drawing.Point(4, 4);
            this.tabPageHistory.Name = "tabPageHistory";
            this.tabPageHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHistory.Size = new System.Drawing.Size(603, 602);
            this.tabPageHistory.TabIndex = 1;
            this.tabPageHistory.Text = "Geçmiş";
            this.tabPageHistory.UseVisualStyleBackColor = true;
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalProfit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalProfit.ForeColor = System.Drawing.Color.Black;
            this.lblTotalProfit.Location = new System.Drawing.Point(509, 41);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(78, 17);
            this.lblTotalProfit.TabIndex = 11;
            this.lblTotalProfit.Text = "0";
            this.lblTotalProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalProfitTitle
            // 
            this.lblTotalProfitTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalProfitTitle.AutoSize = true;
            this.lblTotalProfitTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalProfitTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTotalProfitTitle.Location = new System.Drawing.Point(391, 41);
            this.lblTotalProfitTitle.Name = "lblTotalProfitTitle";
            this.lblTotalProfitTitle.Size = new System.Drawing.Size(104, 14);
            this.lblTotalProfitTitle.TabIndex = 10;
            this.lblTotalProfitTitle.Text = "Toplam Kâr/Zarar:";
            // 
            // lblAverageCost
            // 
            this.lblAverageCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAverageCost.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAverageCost.ForeColor = System.Drawing.Color.Black;
            this.lblAverageCost.Location = new System.Drawing.Point(509, 17);
            this.lblAverageCost.Name = "lblAverageCost";
            this.lblAverageCost.Size = new System.Drawing.Size(78, 17);
            this.lblAverageCost.TabIndex = 9;
            this.lblAverageCost.Text = "0";
            this.lblAverageCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAverageCostTitle
            // 
            this.lblAverageCostTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAverageCostTitle.AutoSize = true;
            this.lblAverageCostTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAverageCostTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAverageCostTitle.Location = new System.Drawing.Point(425, 17);
            this.lblAverageCostTitle.Name = "lblAverageCostTitle";
            this.lblAverageCostTitle.Size = new System.Drawing.Size(78, 14);
            this.lblAverageCostTitle.TabIndex = 8;
            this.lblAverageCostTitle.Text = "Ort. Maliyet: ";
            // 
            // lblSell
            // 
            this.lblSell.AutoSize = true;
            this.lblSell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSell.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSell.Location = new System.Drawing.Point(197, 44);
            this.lblSell.Name = "lblSell";
            this.lblSell.Size = new System.Drawing.Size(75, 14);
            this.lblSell.TabIndex = 7;
            this.lblSell.Text = "7 adet satım";
            // 
            // lblBuyLabel
            // 
            this.lblBuyLabel.AutoSize = true;
            this.lblBuyLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBuyLabel.ForeColor = System.Drawing.Color.Green;
            this.lblBuyLabel.Location = new System.Drawing.Point(111, 44);
            this.lblBuyLabel.Name = "lblBuyLabel";
            this.lblBuyLabel.Size = new System.Drawing.Size(67, 14);
            this.lblBuyLabel.TabIndex = 6;
            this.lblBuyLabel.Text = "9 adet alım";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sembol Seçimi:";
            // 
            // cmbSymbolSelection
            // 
            this.cmbSymbolSelection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSymbolSelection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSymbolSelection.FormattingEnabled = true;
            this.cmbSymbolSelection.Location = new System.Drawing.Point(110, 14);
            this.cmbSymbolSelection.Name = "cmbSymbolSelection";
            this.cmbSymbolSelection.Size = new System.Drawing.Size(162, 24);
            this.cmbSymbolSelection.TabIndex = 1;
            // 
            // dataGridViewTransactionHistory
            // 
            this.dataGridViewTransactionHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTransactionHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactionHistory.GridColor = System.Drawing.Color.RosyBrown;
            this.dataGridViewTransactionHistory.Location = new System.Drawing.Point(7, 64);
            this.dataGridViewTransactionHistory.Name = "dataGridViewTransactionHistory";
            this.dataGridViewTransactionHistory.RowHeadersVisible = false;
            this.dataGridViewTransactionHistory.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataGridViewTransactionHistory.RowTemplate.Height = 20;
            this.dataGridViewTransactionHistory.RowTemplate.ReadOnly = true;
            this.dataGridViewTransactionHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTransactionHistory.Size = new System.Drawing.Size(597, 533);
            this.dataGridViewTransactionHistory.TabIndex = 0;
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.Location = new System.Drawing.Point(4, 4);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSummary.Size = new System.Drawing.Size(603, 602);
            this.tabPageSummary.TabIndex = 2;
            this.tabPageSummary.Text = "Özet";
            this.tabPageSummary.UseVisualStyleBackColor = true;
            // 
            // ucPortfolioManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxPortfolio);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucPortfolioManager";
            this.Size = new System.Drawing.Size(617, 655);
            this.gbxPortfolio.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlPortfolio.ResumeLayout(false);
            this.tabPageHistory.ResumeLayout(false);
            this.tabPageHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPortfolio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalBudgetInUSD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBudgetInSatoshi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlPortfolio;
        private System.Windows.Forms.TabPage tabPageSpotWallet;
        private System.Windows.Forms.TabPage tabPageHistory;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.Label lblTotalProfitTitle;
        private System.Windows.Forms.Label lblAverageCost;
        private System.Windows.Forms.Label lblAverageCostTitle;
        private System.Windows.Forms.Label lblSell;
        private System.Windows.Forms.Label lblBuyLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSymbolSelection;
        private System.Windows.Forms.DataGridView dataGridViewTransactionHistory;
        private System.Windows.Forms.TabPage tabPageSummary;
    }
}
