namespace CoinTrader.UI
{
    partial class ucSignalRow
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
            this.lblCurrentPriceInUSD = new System.Windows.Forms.Label();
            this.lblSignalReason = new System.Windows.Forms.Label();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCurrentPriceInUSD
            // 
            this.lblCurrentPriceInUSD.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCurrentPriceInUSD.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrentPriceInUSD.Location = new System.Drawing.Point(88, 3);
            this.lblCurrentPriceInUSD.Name = "lblCurrentPriceInUSD";
            this.lblCurrentPriceInUSD.Size = new System.Drawing.Size(158, 16);
            this.lblCurrentPriceInUSD.TabIndex = 11;
            this.lblCurrentPriceInUSD.Text = "$ 0,182873";
            this.lblCurrentPriceInUSD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSignalReason
            // 
            this.lblSignalReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSignalReason.BackColor = System.Drawing.SystemColors.Control;
            this.lblSignalReason.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSignalReason.Location = new System.Drawing.Point(250, 2);
            this.lblSignalReason.Name = "lblSignalReason";
            this.lblSignalReason.Size = new System.Drawing.Size(232, 18);
            this.lblSignalReason.TabIndex = 10;
            this.lblSignalReason.Text = "Direnç-1 Yaklaşıldı";
            this.lblSignalReason.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSymbol.Location = new System.Drawing.Point(13, 4);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(29, 14);
            this.lblSymbol.TabIndex = 9;
            this.lblSymbol.Text = "VET";
            // 
            // ucSignalRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblCurrentPriceInUSD);
            this.Controls.Add(this.lblSignalReason);
            this.Controls.Add(this.lblSymbol);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(487, 22);
            this.Name = "ucSignalRow";
            this.Size = new System.Drawing.Size(485, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentPriceInUSD;
        private System.Windows.Forms.Label lblSignalReason;
        private System.Windows.Forms.Label lblSymbol;
    }
}
