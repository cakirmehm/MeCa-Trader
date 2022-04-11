namespace CoinTrader.UI
{
    partial class ucPriceLabel
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
            this.lblResistance2 = new System.Windows.Forms.Label();
            this.lblSupport2 = new System.Windows.Forms.Label();
            this.lblSupport1 = new System.Windows.Forms.Label();
            this.lblResistance1 = new System.Windows.Forms.Label();
            this.lblCurrentPriceInUSD = new System.Windows.Forms.Label();
            this.lblIndicatorMA = new System.Windows.Forms.Label();
            this.lblIndicatorRSI = new System.Windows.Forms.Label();
            this.lblIndicatorFIB = new System.Windows.Forms.Label();
            this.lblIndicatorMACD = new System.Windows.Forms.Label();
            this.lblMinVal = new System.Windows.Forms.Label();
            this.lblMaxVal = new System.Windows.Forms.Label();
            this.cartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.btnCLose = new System.Windows.Forms.Button();
            this.lblVolumeIndicator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResistance2
            // 
            this.lblResistance2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResistance2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblResistance2.ForeColor = System.Drawing.Color.Gray;
            this.lblResistance2.Location = new System.Drawing.Point(81, 4);
            this.lblResistance2.Name = "lblResistance2";
            this.lblResistance2.Size = new System.Drawing.Size(189, 13);
            this.lblResistance2.TabIndex = 25;
            this.lblResistance2.Text = "61.119,34 $";
            this.lblResistance2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSupport2
            // 
            this.lblSupport2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupport2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSupport2.ForeColor = System.Drawing.Color.Gray;
            this.lblSupport2.Location = new System.Drawing.Point(81, 59);
            this.lblSupport2.Name = "lblSupport2";
            this.lblSupport2.Size = new System.Drawing.Size(189, 10);
            this.lblSupport2.TabIndex = 24;
            this.lblSupport2.Text = "56.119,34 $";
            this.lblSupport2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSupport1
            // 
            this.lblSupport1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupport1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSupport1.ForeColor = System.Drawing.Color.DimGray;
            this.lblSupport1.Location = new System.Drawing.Point(81, 44);
            this.lblSupport1.Name = "lblSupport1";
            this.lblSupport1.Size = new System.Drawing.Size(189, 13);
            this.lblSupport1.TabIndex = 23;
            this.lblSupport1.Text = "57.043,34 $";
            this.lblSupport1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResistance1
            // 
            this.lblResistance1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResistance1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblResistance1.ForeColor = System.Drawing.Color.DimGray;
            this.lblResistance1.Location = new System.Drawing.Point(81, 17);
            this.lblResistance1.Name = "lblResistance1";
            this.lblResistance1.Size = new System.Drawing.Size(189, 13);
            this.lblResistance1.TabIndex = 22;
            this.lblResistance1.Text = "58.119,34 $";
            this.lblResistance1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentPriceInUSD
            // 
            this.lblCurrentPriceInUSD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentPriceInUSD.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCurrentPriceInUSD.Location = new System.Drawing.Point(81, 28);
            this.lblCurrentPriceInUSD.Name = "lblCurrentPriceInUSD";
            this.lblCurrentPriceInUSD.Size = new System.Drawing.Size(189, 17);
            this.lblCurrentPriceInUSD.TabIndex = 21;
            this.lblCurrentPriceInUSD.Text = "57.989,23 $";
            this.lblCurrentPriceInUSD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCurrentPriceInUSD.TextChanged += new System.EventHandler(this.lblCurrentPriceInUSD_TextChanged);
            // 
            // lblIndicatorMA
            // 
            this.lblIndicatorMA.BackColor = System.Drawing.Color.Transparent;
            this.lblIndicatorMA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIndicatorMA.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIndicatorMA.ForeColor = System.Drawing.Color.Gray;
            this.lblIndicatorMA.Location = new System.Drawing.Point(3, 3);
            this.lblIndicatorMA.Name = "lblIndicatorMA";
            this.lblIndicatorMA.Size = new System.Drawing.Size(70, 16);
            this.lblIndicatorMA.TabIndex = 26;
            this.lblIndicatorMA.Text = "MA";
            this.lblIndicatorMA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndicatorRSI
            // 
            this.lblIndicatorRSI.BackColor = System.Drawing.Color.Transparent;
            this.lblIndicatorRSI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIndicatorRSI.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIndicatorRSI.ForeColor = System.Drawing.Color.Gray;
            this.lblIndicatorRSI.Location = new System.Drawing.Point(3, 21);
            this.lblIndicatorRSI.Name = "lblIndicatorRSI";
            this.lblIndicatorRSI.Size = new System.Drawing.Size(70, 16);
            this.lblIndicatorRSI.TabIndex = 27;
            this.lblIndicatorRSI.Text = "RSI";
            this.lblIndicatorRSI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndicatorFIB
            // 
            this.lblIndicatorFIB.BackColor = System.Drawing.Color.Transparent;
            this.lblIndicatorFIB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIndicatorFIB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIndicatorFIB.ForeColor = System.Drawing.Color.Gray;
            this.lblIndicatorFIB.Location = new System.Drawing.Point(3, 56);
            this.lblIndicatorFIB.Name = "lblIndicatorFIB";
            this.lblIndicatorFIB.Size = new System.Drawing.Size(70, 16);
            this.lblIndicatorFIB.TabIndex = 30;
            this.lblIndicatorFIB.Text = "FIB";
            this.lblIndicatorFIB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndicatorMACD
            // 
            this.lblIndicatorMACD.BackColor = System.Drawing.Color.Transparent;
            this.lblIndicatorMACD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIndicatorMACD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblIndicatorMACD.ForeColor = System.Drawing.Color.Gray;
            this.lblIndicatorMACD.Location = new System.Drawing.Point(3, 39);
            this.lblIndicatorMACD.Name = "lblIndicatorMACD";
            this.lblIndicatorMACD.Size = new System.Drawing.Size(70, 16);
            this.lblIndicatorMACD.TabIndex = 29;
            this.lblIndicatorMACD.Text = "MACD";
            this.lblIndicatorMACD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinVal
            // 
            this.lblMinVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinVal.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMinVal.ForeColor = System.Drawing.Color.Gray;
            this.lblMinVal.Location = new System.Drawing.Point(337, 60);
            this.lblMinVal.Name = "lblMinVal";
            this.lblMinVal.Size = new System.Drawing.Size(72, 13);
            this.lblMinVal.TabIndex = 31;
            this.lblMinVal.Text = "61.119,34 $";
            this.lblMinVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinVal.Visible = false;
            this.lblMinVal.TextChanged += new System.EventHandler(this.lblMinVal_TextChanged);
            // 
            // lblMaxVal
            // 
            this.lblMaxVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxVal.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMaxVal.ForeColor = System.Drawing.Color.Gray;
            this.lblMaxVal.Location = new System.Drawing.Point(340, 3);
            this.lblMaxVal.Name = "lblMaxVal";
            this.lblMaxVal.Size = new System.Drawing.Size(72, 13);
            this.lblMaxVal.TabIndex = 32;
            this.lblMaxVal.Text = "61.119,34 $";
            this.lblMaxVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxVal.Visible = false;
            this.lblMaxVal.TextChanged += new System.EventHandler(this.lblMaxVal_TextChanged);
            // 
            // cartesianChart
            // 
            this.cartesianChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesianChart.BackColor = System.Drawing.Color.LightGray;
            this.cartesianChart.Location = new System.Drawing.Point(276, 3);
            this.cartesianChart.Name = "cartesianChart";
            this.cartesianChart.Size = new System.Drawing.Size(133, 87);
            this.cartesianChart.TabIndex = 33;
            // 
            // lblSymbol
            // 
            this.lblSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSymbol.BackColor = System.Drawing.Color.LightGray;
            this.lblSymbol.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSymbol.ForeColor = System.Drawing.Color.Blue;
            this.lblSymbol.Location = new System.Drawing.Point(83, 74);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(187, 17);
            this.lblSymbol.TabIndex = 34;
            this.lblSymbol.Text = "SYMBOL";
            this.lblSymbol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCLose
            // 
            this.btnCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCLose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCLose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCLose.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCLose.Location = new System.Drawing.Point(389, 2);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(20, 20);
            this.btnCLose.TabIndex = 35;
            this.btnCLose.Text = "x";
            this.btnCLose.UseVisualStyleBackColor = true;
            this.btnCLose.Click += new System.EventHandler(this.btnCLose_Click);
            // 
            // lblVolumeIndicator
            // 
            this.lblVolumeIndicator.BackColor = System.Drawing.Color.Transparent;
            this.lblVolumeIndicator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblVolumeIndicator.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVolumeIndicator.ForeColor = System.Drawing.Color.Gray;
            this.lblVolumeIndicator.Location = new System.Drawing.Point(3, 73);
            this.lblVolumeIndicator.Name = "lblVolumeIndicator";
            this.lblVolumeIndicator.Size = new System.Drawing.Size(70, 16);
            this.lblVolumeIndicator.TabIndex = 36;
            this.lblVolumeIndicator.Text = "VOL";
            this.lblVolumeIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPriceLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblVolumeIndicator);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.lblSymbol);
            this.Controls.Add(this.cartesianChart);
            this.Controls.Add(this.lblMaxVal);
            this.Controls.Add(this.lblMinVal);
            this.Controls.Add(this.lblIndicatorFIB);
            this.Controls.Add(this.lblIndicatorMACD);
            this.Controls.Add(this.lblIndicatorRSI);
            this.Controls.Add(this.lblIndicatorMA);
            this.Controls.Add(this.lblResistance2);
            this.Controls.Add(this.lblSupport2);
            this.Controls.Add(this.lblSupport1);
            this.Controls.Add(this.lblResistance1);
            this.Controls.Add(this.lblCurrentPriceInUSD);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(414, 93);
            this.Name = "ucPriceLabel";
            this.Size = new System.Drawing.Size(412, 91);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblResistance2;
        private System.Windows.Forms.Label lblSupport2;
        private System.Windows.Forms.Label lblSupport1;
        private System.Windows.Forms.Label lblResistance1;
        private System.Windows.Forms.Label lblCurrentPriceInUSD;
        private System.Windows.Forms.Label lblIndicatorMA;
        private System.Windows.Forms.Label lblIndicatorRSI;
        private System.Windows.Forms.Label lblIndicatorFIB;
        private System.Windows.Forms.Label lblIndicatorMACD;
        private System.Windows.Forms.Label lblMinVal;
        private System.Windows.Forms.Label lblMaxVal;
        private LiveCharts.WinForms.CartesianChart cartesianChart;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.Button btnCLose;
        private System.Windows.Forms.Label lblVolumeIndicator;
    }
}
