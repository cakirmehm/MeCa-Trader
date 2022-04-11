namespace CoinTrader.UI
{
    partial class ucOrder
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ntxtLimit = new System.Windows.Forms.NumericUpDown();
            this.ntxtStop = new System.Windows.Forms.NumericUpDown();
            this.rbtnStopLimit = new System.Windows.Forms.RadioButton();
            this.rbtnPiyasa = new System.Windows.Forms.RadioButton();
            this.dgvOrderList = new System.Windows.Forms.DataGridView();
            this.ntxQuantity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOrderSell = new System.Windows.Forms.Button();
            this.btnOrderBuy = new System.Windows.Forms.Button();
            this.cnbOrderSymbol = new System.Windows.Forms.ComboBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.numericUpDown1);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.ntxtLimit);
            this.groupBox4.Controls.Add(this.ntxtStop);
            this.groupBox4.Controls.Add(this.rbtnStopLimit);
            this.groupBox4.Controls.Add(this.rbtnPiyasa);
            this.groupBox4.Controls.Add(this.dgvOrderList);
            this.groupBox4.Controls.Add(this.ntxQuantity);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnOrderSell);
            this.groupBox4.Controls.Add(this.btnOrderBuy);
            this.groupBox4.Controls.Add(this.cnbOrderSymbol);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(630, 302);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Emirler";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton1.Location = new System.Drawing.Point(159, 143);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 17);
            this.radioButton1.TabIndex = 33;
            this.radioButton1.Text = "OCO";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 8;
            this.numericUpDown1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.Gray;
            this.numericUpDown1.Location = new System.Drawing.Point(57, 101);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(150, 26);
            this.numericUpDown1.TabIndex = 32;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 26);
            this.label5.TabIndex = 31;
            this.label5.Text = "USD";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ntxtLimit
            // 
            this.ntxtLimit.DecimalPlaces = 8;
            this.ntxtLimit.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ntxtLimit.ForeColor = System.Drawing.Color.DarkRed;
            this.ntxtLimit.Location = new System.Drawing.Point(57, 195);
            this.ntxtLimit.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.ntxtLimit.Name = "ntxtLimit";
            this.ntxtLimit.Size = new System.Drawing.Size(150, 26);
            this.ntxtLimit.TabIndex = 30;
            this.ntxtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ntxtLimit.ThousandsSeparator = true;
            // 
            // ntxtStop
            // 
            this.ntxtStop.DecimalPlaces = 8;
            this.ntxtStop.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ntxtStop.ForeColor = System.Drawing.Color.DarkRed;
            this.ntxtStop.Location = new System.Drawing.Point(57, 166);
            this.ntxtStop.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.ntxtStop.Name = "ntxtStop";
            this.ntxtStop.Size = new System.Drawing.Size(150, 26);
            this.ntxtStop.TabIndex = 29;
            this.ntxtStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ntxtStop.ThousandsSeparator = true;
            // 
            // rbtnStopLimit
            // 
            this.rbtnStopLimit.AutoSize = true;
            this.rbtnStopLimit.Checked = true;
            this.rbtnStopLimit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnStopLimit.Location = new System.Drawing.Point(81, 143);
            this.rbtnStopLimit.Name = "rbtnStopLimit";
            this.rbtnStopLimit.Size = new System.Drawing.Size(72, 17);
            this.rbtnStopLimit.TabIndex = 28;
            this.rbtnStopLimit.TabStop = true;
            this.rbtnStopLimit.Text = "Stop-Limit";
            this.rbtnStopLimit.UseVisualStyleBackColor = true;
            // 
            // rbtnPiyasa
            // 
            this.rbtnPiyasa.AutoSize = true;
            this.rbtnPiyasa.Enabled = false;
            this.rbtnPiyasa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnPiyasa.Location = new System.Drawing.Point(9, 143);
            this.rbtnPiyasa.Name = "rbtnPiyasa";
            this.rbtnPiyasa.Size = new System.Drawing.Size(56, 17);
            this.rbtnPiyasa.TabIndex = 27;
            this.rbtnPiyasa.Text = "Piyasa";
            this.rbtnPiyasa.UseVisualStyleBackColor = true;
            // 
            // dgvOrderList
            // 
            this.dgvOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderList.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvOrderList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderList.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvOrderList.Location = new System.Drawing.Point(232, 23);
            this.dgvOrderList.Name = "dgvOrderList";
            this.dgvOrderList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dgvOrderList.RowTemplate.Height = 16;
            this.dgvOrderList.RowTemplate.ReadOnly = true;
            this.dgvOrderList.Size = new System.Drawing.Size(392, 272);
            this.dgvOrderList.TabIndex = 25;
            this.dgvOrderList.VirtualMode = true;
            // 
            // ntxQuantity
            // 
            this.ntxQuantity.DecimalPlaces = 8;
            this.ntxQuantity.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ntxQuantity.ForeColor = System.Drawing.Color.DarkRed;
            this.ntxQuantity.Location = new System.Drawing.Point(57, 69);
            this.ntxQuantity.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.ntxQuantity.Name = "ntxQuantity";
            this.ntxQuantity.Size = new System.Drawing.Size(150, 26);
            this.ntxQuantity.TabIndex = 24;
            this.ntxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ntxQuantity.ThousandsSeparator = true;
            this.ntxQuantity.ValueChanged += new System.EventHandler(this.ntxQuantity_ValueChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 26);
            this.label4.TabIndex = 23;
            this.label4.Text = "Miktar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(6, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "Limit";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "Stop";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOrderSell
            // 
            this.btnOrderSell.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnOrderSell.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnOrderSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderSell.Location = new System.Drawing.Point(115, 247);
            this.btnOrderSell.Name = "btnOrderSell";
            this.btnOrderSell.Size = new System.Drawing.Size(98, 48);
            this.btnOrderSell.TabIndex = 17;
            this.btnOrderSell.Text = "SAT";
            this.btnOrderSell.UseVisualStyleBackColor = true;
            this.btnOrderSell.Click += new System.EventHandler(this.btnOrderSell_Click);
            // 
            // btnOrderBuy
            // 
            this.btnOrderBuy.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnOrderBuy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOrderBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderBuy.Location = new System.Drawing.Point(9, 247);
            this.btnOrderBuy.Name = "btnOrderBuy";
            this.btnOrderBuy.Size = new System.Drawing.Size(94, 48);
            this.btnOrderBuy.TabIndex = 16;
            this.btnOrderBuy.Text = "AL";
            this.btnOrderBuy.UseVisualStyleBackColor = true;
            this.btnOrderBuy.Click += new System.EventHandler(this.btnOrderBuy_Click);
            // 
            // cnbOrderSymbol
            // 
            this.cnbOrderSymbol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cnbOrderSymbol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cnbOrderSymbol.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cnbOrderSymbol.FormattingEnabled = true;
            this.cnbOrderSymbol.Items.AddRange(new object[] {
            "BTCBUSD",
            "ETHBUSD",
            "BNBBUSD",
            "VETBUSD"});
            this.cnbOrderSymbol.Location = new System.Drawing.Point(9, 23);
            this.cnbOrderSymbol.Name = "cnbOrderSymbol";
            this.cnbOrderSymbol.Size = new System.Drawing.Size(198, 26);
            this.cnbOrderSymbol.TabIndex = 15;
            // 
            // ucOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Name = "ucOrder";
            this.Size = new System.Drawing.Size(630, 302);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxtStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ntxQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbtnStopLimit;
        private System.Windows.Forms.RadioButton rbtnPiyasa;
        private System.Windows.Forms.DataGridView dgvOrderList;
        private System.Windows.Forms.NumericUpDown ntxQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOrderSell;
        private System.Windows.Forms.Button btnOrderBuy;
        private System.Windows.Forms.ComboBox cnbOrderSymbol;
        private System.Windows.Forms.NumericUpDown ntxtLimit;
        private System.Windows.Forms.NumericUpDown ntxtStop;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}
