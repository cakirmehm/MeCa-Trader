namespace CoinTrader.UI
{
    partial class F_GeneralView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_GeneralView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnUSDT = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnBUSD = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnBTC = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnIncreasingVolume = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnIncreasingPercent = new System.Windows.Forms.ToolStripButton();
            this.dgvSymbolPairs = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbolPairs)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnUSDT,
            this.toolStripSeparator1,
            this.tsbtnBUSD,
            this.toolStripSeparator2,
            this.tsbtnBTC,
            this.toolStripSeparator3,
            this.tsbtnRefresh,
            this.toolStripSeparator4,
            this.tsbtnIncreasingVolume,
            this.toolStripSeparator5,
            this.tsbtnIncreasingPercent});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1082, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
    
            // 
            // tsbtnUSDT
            // 
            this.tsbtnUSDT.Checked = true;
            this.tsbtnUSDT.CheckOnClick = true;
            this.tsbtnUSDT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbtnUSDT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnUSDT.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUSDT.Image")));
            this.tsbtnUSDT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUSDT.Name = "tsbtnUSDT";
            this.tsbtnUSDT.Size = new System.Drawing.Size(38, 22);
            this.tsbtnUSDT.Text = "USDT";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnBUSD
            // 
            this.tsbtnBUSD.CheckOnClick = true;
            this.tsbtnBUSD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnBUSD.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnBUSD.Image")));
            this.tsbtnBUSD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnBUSD.Name = "tsbtnBUSD";
            this.tsbtnBUSD.Size = new System.Drawing.Size(40, 22);
            this.tsbtnBUSD.Text = "BUSD";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnBTC
            // 
            this.tsbtnBTC.CheckOnClick = true;
            this.tsbtnBTC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnBTC.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnBTC.Image")));
            this.tsbtnBTC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnBTC.Name = "tsbtnBTC";
            this.tsbtnBTC.Size = new System.Drawing.Size(30, 22);
            this.tsbtnBTC.Text = "BTC";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefresh.Image")));
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(42, 22);
            this.tsbtnRefresh.Text = "Yenile";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnIncreasingVolume
            // 
            this.tsbtnIncreasingVolume.CheckOnClick = true;
            this.tsbtnIncreasingVolume.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnIncreasingVolume.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnIncreasingVolume.Image")));
            this.tsbtnIncreasingVolume.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnIncreasingVolume.Name = "tsbtnIncreasingVolume";
            this.tsbtnIncreasingVolume.Size = new System.Drawing.Size(78, 22);
            this.tsbtnIncreasingVolume.Text = "Artan Hacim";
            this.tsbtnIncreasingVolume.Click += new System.EventHandler(this.tsbtnIncreasingVolume_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnIncreasingPercent
            // 
            this.tsbtnIncreasingPercent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnIncreasingPercent.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnIncreasingPercent.Image")));
            this.tsbtnIncreasingPercent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnIncreasingPercent.Name = "tsbtnIncreasingPercent";
            this.tsbtnIncreasingPercent.Size = new System.Drawing.Size(83, 22);
            this.tsbtnIncreasingPercent.Text = "Atak Yapanlar";
            this.tsbtnIncreasingPercent.Click += new System.EventHandler(this.tsbtnIncreasingPercent_Click);
            // 
            // dgvSymbolPairs
            // 
            this.dgvSymbolPairs.AllowUserToAddRows = false;
            this.dgvSymbolPairs.AllowUserToDeleteRows = false;
            this.dgvSymbolPairs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSymbolPairs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSymbolPairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSymbolPairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSymbolPairs.GridColor = System.Drawing.Color.LightSkyBlue;
            this.dgvSymbolPairs.Location = new System.Drawing.Point(0, 25);
            this.dgvSymbolPairs.Name = "dgvSymbolPairs";
            this.dgvSymbolPairs.ReadOnly = true;
            this.dgvSymbolPairs.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvSymbolPairs.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dgvSymbolPairs.RowTemplate.Height = 20;
            this.dgvSymbolPairs.RowTemplate.ReadOnly = true;
            this.dgvSymbolPairs.Size = new System.Drawing.Size(1082, 623);
            this.dgvSymbolPairs.TabIndex = 1;
            this.dgvSymbolPairs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSymbolPairs_CellFormatting);
            this.dgvSymbolPairs.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSymbolPairs_ColumnHeaderMouseClick);
            // 
            // F_GeneralView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 648);
            this.Controls.Add(this.dgvSymbolPairs);
            this.Controls.Add(this.toolStrip1);
            this.Name = "F_GeneralView";
            this.Text = "Genel Görünüm";
            this.Load += new System.EventHandler(this.F_GeneralView_Load);
   
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbolPairs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgvSymbolPairs;
        private System.Windows.Forms.ToolStripButton tsbtnUSDT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnBUSD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnBTC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnIncreasingVolume;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbtnIncreasingPercent;
    }
}