namespace CoinTrader.UI
{
    partial class ucBTCWatcher
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbAddNew = new System.Windows.Forms.ComboBox();
            this.ucPriceLabelComp1 = new CoinTrader.UI.ucPriceLabel();
            this.ucPriceLabelComp2 = new CoinTrader.UI.ucPriceLabel();
            this.ucPriceLabelComp3 = new CoinTrader.UI.ucPriceLabel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.ucPriceLabelComp1);
            this.flowLayoutPanel1.Controls.Add(this.ucPriceLabelComp2);
            this.flowLayoutPanel1.Controls.Add(this.ucPriceLabelComp3);
            this.flowLayoutPanel1.Controls.Add(this.cmbAddNew);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1415, 112);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // cmbAddNew
            // 
            this.cmbAddNew.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAddNew.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAddNew.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.cmbAddNew.FormattingEnabled = true;
            this.cmbAddNew.Location = new System.Drawing.Point(1243, 3);
            this.cmbAddNew.Name = "cmbAddNew";
            this.cmbAddNew.Size = new System.Drawing.Size(126, 26);
            this.cmbAddNew.TabIndex = 19;
            this.cmbAddNew.Text = "<Add New>";
            this.cmbAddNew.SelectedIndexChanged += new System.EventHandler(this.cmbAddNew_SelectedIndexChanged);
            // 
            // ucPriceLabelComp1
            // 
            this.ucPriceLabelComp1.AutoTrade = false;
            this.ucPriceLabelComp1.BackColor = System.Drawing.Color.LightGray;
            this.ucPriceLabelComp1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucPriceLabelComp1.CurrPrice = 0D;
            this.ucPriceLabelComp1.Location = new System.Drawing.Point(3, 3);
            this.ucPriceLabelComp1.MaxVal = 0D;
            this.ucPriceLabelComp1.MinimumSize = new System.Drawing.Size(300, 73);
            this.ucPriceLabelComp1.MinVal = 0D;
            this.ucPriceLabelComp1.Name = "ucPriceLabelComp1";
            this.ucPriceLabelComp1.PrevPrice = 0D;
            this.ucPriceLabelComp1.Resistance1 = 0D;
            this.ucPriceLabelComp1.Resistance2 = 0D;
            this.ucPriceLabelComp1.Size = new System.Drawing.Size(400, 97);
            this.ucPriceLabelComp1.Support1 = 0D;
            this.ucPriceLabelComp1.Support2 = 0D;
            this.ucPriceLabelComp1.TabIndex = 16;
            this.ucPriceLabelComp1.Trend = CoinTrader.UI.ETrend.HORIZONTAL;
            // 
            // ucPriceLabelComp2
            // 
            this.ucPriceLabelComp2.AutoTrade = false;
            this.ucPriceLabelComp2.BackColor = System.Drawing.Color.LightGray;
            this.ucPriceLabelComp2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucPriceLabelComp2.CurrPrice = 0D;
            this.ucPriceLabelComp2.Location = new System.Drawing.Point(409, 3);
            this.ucPriceLabelComp2.MaxVal = 0D;
            this.ucPriceLabelComp2.MinimumSize = new System.Drawing.Size(300, 73);
            this.ucPriceLabelComp2.MinVal = 0D;
            this.ucPriceLabelComp2.Name = "ucPriceLabelComp2";
            this.ucPriceLabelComp2.PrevPrice = 0D;
            this.ucPriceLabelComp2.Resistance1 = 0D;
            this.ucPriceLabelComp2.Resistance2 = 0D;
            this.ucPriceLabelComp2.Size = new System.Drawing.Size(422, 96);
            this.ucPriceLabelComp2.Support1 = 0D;
            this.ucPriceLabelComp2.Support2 = 0D;
            this.ucPriceLabelComp2.TabIndex = 17;
            this.ucPriceLabelComp2.Trend = CoinTrader.UI.ETrend.HORIZONTAL;
            // 
            // ucPriceLabelComp3
            // 
            this.ucPriceLabelComp3.AutoTrade = true;
            this.ucPriceLabelComp3.BackColor = System.Drawing.Color.LightGray;
            this.ucPriceLabelComp3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucPriceLabelComp3.CurrPrice = 0D;
            this.ucPriceLabelComp3.Location = new System.Drawing.Point(837, 3);
            this.ucPriceLabelComp3.MaxVal = 0D;
            this.ucPriceLabelComp3.MinimumSize = new System.Drawing.Size(300, 73);
            this.ucPriceLabelComp3.MinVal = 0D;
            this.ucPriceLabelComp3.Name = "ucPriceLabelComp3";
            this.ucPriceLabelComp3.PrevPrice = 0D;
            this.ucPriceLabelComp3.Resistance1 = 0D;
            this.ucPriceLabelComp3.Resistance2 = 0D;
            this.ucPriceLabelComp3.Size = new System.Drawing.Size(400, 97);
            this.ucPriceLabelComp3.Support1 = 0D;
            this.ucPriceLabelComp3.Support2 = 0D;
            this.ucPriceLabelComp3.TabIndex = 18;
            this.ucPriceLabelComp3.Trend = CoinTrader.UI.ETrend.HORIZONTAL;
            // 
            // ucBTCWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "ucBTCWatcher";
            this.Size = new System.Drawing.Size(1415, 112);
            this.Load += new System.EventHandler(this.ucBTCWatcher_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ucPriceLabel ucPriceLabelComp1;
        private ucPriceLabel ucPriceLabelComp2;
        private ucPriceLabel ucPriceLabelComp3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbAddNew;
    }
}
