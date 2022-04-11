namespace CoinTrader.UI
{
    partial class ucPortfolioRow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPortfolioRow));
            this.pictureBoxSymbolIcon = new System.Windows.Forms.PictureBox();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.lblSymbolName = new System.Windows.Forms.Label();
            this.lblTotalCurrentPrice = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblAverageCostInUSD = new System.Windows.Forms.Label();
            this.lblCurrentPriceInUSD = new System.Windows.Forms.Label();
            this.lblProfit = new System.Windows.Forms.Label();
            this.lblProfitPercent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSymbolIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSymbolIcon
            // 
            this.pictureBoxSymbolIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSymbolIcon.Image")));
            this.pictureBoxSymbolIcon.Location = new System.Drawing.Point(3, 4);
            this.pictureBoxSymbolIcon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxSymbolIcon.Name = "pictureBoxSymbolIcon";
            this.pictureBoxSymbolIcon.Size = new System.Drawing.Size(37, 34);
            this.pictureBoxSymbolIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSymbolIcon.TabIndex = 0;
            this.pictureBoxSymbolIcon.TabStop = false;
            this.pictureBoxSymbolIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ucPortfolioRow_MouseDoubleClick);
            this.pictureBoxSymbolIcon.MouseEnter += new System.EventHandler(this.ucPortfolioRow_MouseEnter);
            this.pictureBoxSymbolIcon.MouseLeave += new System.EventHandler(this.ucPortfolioRow_MouseLeave);
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSymbol.Location = new System.Drawing.Point(49, 5);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(29, 14);
            this.lblSymbol.TabIndex = 1;
            this.lblSymbol.Text = "VET";
            this.lblSymbol.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ucPortfolioRow_MouseDoubleClick);
            this.lblSymbol.MouseEnter += new System.EventHandler(this.ucPortfolioRow_MouseEnter);
            this.lblSymbol.MouseLeave += new System.EventHandler(this.ucPortfolioRow_MouseLeave);
            // 
            // lblSymbolName
            // 
            this.lblSymbolName.AutoSize = true;
            this.lblSymbolName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSymbolName.ForeColor = System.Drawing.Color.Gray;
            this.lblSymbolName.Location = new System.Drawing.Point(49, 24);
            this.lblSymbolName.Name = "lblSymbolName";
            this.lblSymbolName.Size = new System.Drawing.Size(46, 13);
            this.lblSymbolName.TabIndex = 2;
            this.lblSymbolName.Text = "VeChain";
            this.lblSymbolName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ucPortfolioRow_MouseDoubleClick);
            this.lblSymbolName.MouseEnter += new System.EventHandler(this.ucPortfolioRow_MouseEnter);
            this.lblSymbolName.MouseLeave += new System.EventHandler(this.ucPortfolioRow_MouseLeave);
            // 
            // lblTotalCurrentPrice
            // 
            this.lblTotalCurrentPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCurrentPrice.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalCurrentPrice.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalCurrentPrice.Location = new System.Drawing.Point(391, 24);
            this.lblTotalCurrentPrice.Name = "lblTotalCurrentPrice";
            this.lblTotalCurrentPrice.Size = new System.Drawing.Size(106, 14);
            this.lblTotalCurrentPrice.TabIndex = 5;
            this.lblTotalCurrentPrice.Text = "$ 999,86";
            this.lblTotalCurrentPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalCurrentPrice.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ucPortfolioRow_MouseDoubleClick);
            this.lblTotalCurrentPrice.MouseEnter += new System.EventHandler(this.ucPortfolioRow_MouseEnter);
            this.lblTotalCurrentPrice.MouseLeave += new System.EventHandler(this.ucPortfolioRow_MouseLeave);
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAmount.ForeColor = System.Drawing.Color.Gray;
            this.lblAmount.Location = new System.Drawing.Point(388, 5);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(109, 14);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "5.584,76";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAmount.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ucPortfolioRow_MouseDoubleClick);
            this.lblAmount.MouseEnter += new System.EventHandler(this.ucPortfolioRow_MouseEnter);
            this.lblAmount.MouseLeave += new System.EventHandler(this.ucPortfolioRow_MouseLeave);
            // 
            // lblAverageCostInUSD
            // 
            this.lblAverageCostInUSD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAverageCostInUSD.ForeColor = System.Drawing.Color.Gray;
            this.lblAverageCostInUSD.Location = new System.Drawing.Point(116, 23);
            this.lblAverageCostInUSD.Name = "lblAverageCostInUSD";
            this.lblAverageCostInUSD.Size = new System.Drawing.Size(125, 13);
            this.lblAverageCostInUSD.TabIndex = 6;
            this.lblAverageCostInUSD.Text = "$ 0,182873";
            this.lblAverageCostInUSD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAverageCostInUSD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ucPortfolioRow_MouseDoubleClick);
            this.lblAverageCostInUSD.MouseEnter += new System.EventHandler(this.ucPortfolioRow_MouseEnter);
            this.lblAverageCostInUSD.MouseLeave += new System.EventHandler(this.ucPortfolioRow_MouseLeave);
            // 
            // lblCurrentPriceInUSD
            // 
            this.lblCurrentPriceInUSD.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCurrentPriceInUSD.Location = new System.Drawing.Point(113, 4);
            this.lblCurrentPriceInUSD.Name = "lblCurrentPriceInUSD";
            this.lblCurrentPriceInUSD.Size = new System.Drawing.Size(128, 13);
            this.lblCurrentPriceInUSD.TabIndex = 8;
            this.lblCurrentPriceInUSD.Text = "$ 0,182873";
            this.lblCurrentPriceInUSD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCurrentPriceInUSD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ucPortfolioRow_MouseDoubleClick);
            this.lblCurrentPriceInUSD.MouseEnter += new System.EventHandler(this.ucPortfolioRow_MouseEnter);
            this.lblCurrentPriceInUSD.MouseLeave += new System.EventHandler(this.ucPortfolioRow_MouseLeave);
            // 
            // lblProfit
            // 
            this.lblProfit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProfit.ForeColor = System.Drawing.Color.Green;
            this.lblProfit.Location = new System.Drawing.Point(247, 23);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(84, 13);
            this.lblProfit.TabIndex = 10;
            this.lblProfit.Text = "+ $ 14,42";
            this.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProfit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ucPortfolioRow_MouseDoubleClick);
            this.lblProfit.MouseEnter += new System.EventHandler(this.ucPortfolioRow_MouseEnter);
            this.lblProfit.MouseLeave += new System.EventHandler(this.ucPortfolioRow_MouseLeave);
            // 
            // lblProfitPercent
            // 
            this.lblProfitPercent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProfitPercent.ForeColor = System.Drawing.Color.Green;
            this.lblProfitPercent.Location = new System.Drawing.Point(247, 4);
            this.lblProfitPercent.Name = "lblProfitPercent";
            this.lblProfitPercent.Size = new System.Drawing.Size(84, 13);
            this.lblProfitPercent.TabIndex = 11;
            this.lblProfitPercent.Text = "+ 5,43 %";
            this.lblProfitPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProfitPercent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ucPortfolioRow_MouseDoubleClick);
            this.lblProfitPercent.MouseEnter += new System.EventHandler(this.ucPortfolioRow_MouseEnter);
            this.lblProfitPercent.MouseLeave += new System.EventHandler(this.ucPortfolioRow_MouseLeave);
            // 
            // ucPortfolioRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblProfitPercent);
            this.Controls.Add(this.lblProfit);
            this.Controls.Add(this.lblCurrentPriceInUSD);
            this.Controls.Add(this.lblAverageCostInUSD);
            this.Controls.Add(this.lblTotalCurrentPrice);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblSymbolName);
            this.Controls.Add(this.lblSymbol);
            this.Controls.Add(this.pictureBoxSymbolIcon);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MinimumSize = new System.Drawing.Size(500, 40);
            this.Name = "ucPortfolioRow";
            this.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.Size = new System.Drawing.Size(498, 41);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ucPortfolioRow_MouseDoubleClick);
            this.MouseEnter += new System.EventHandler(this.ucPortfolioRow_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucPortfolioRow_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSymbolIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSymbolIcon;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.Label lblSymbolName;
        private System.Windows.Forms.Label lblTotalCurrentPrice;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblAverageCostInUSD;
        private System.Windows.Forms.Label lblCurrentPriceInUSD;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.Label lblProfitPercent;
    }
}
