namespace CoinTrader.UI
{
    partial class ucCandleTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxCandleTable = new System.Windows.Forms.GroupBox();
            this.dgvCandles = new System.Windows.Forms.DataGridView();
            this.gbxCandleTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandles)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxCandleTable
            // 
            this.gbxCandleTable.Controls.Add(this.dgvCandles);
            this.gbxCandleTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxCandleTable.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbxCandleTable.Location = new System.Drawing.Point(0, 0);
            this.gbxCandleTable.Name = "gbxCandleTable";
            this.gbxCandleTable.Size = new System.Drawing.Size(761, 454);
            this.gbxCandleTable.TabIndex = 0;
            this.gbxCandleTable.TabStop = false;
            // 
            // dgvCandles
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvCandles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCandles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCandles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCandles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCandles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCandles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCandles.GridColor = System.Drawing.Color.DodgerBlue;
            this.dgvCandles.Location = new System.Drawing.Point(3, 19);
            this.dgvCandles.Name = "dgvCandles";
            this.dgvCandles.RowHeadersVisible = false;
            this.dgvCandles.Size = new System.Drawing.Size(755, 432);
            this.dgvCandles.TabIndex = 1;
            this.dgvCandles.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCandles_CellFormatting);
            // 
            // ucCandleTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxCandleTable);
            this.Name = "ucCandleTable";
            this.Size = new System.Drawing.Size(761, 454);
            this.gbxCandleTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCandles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCandleTable;
        private System.Windows.Forms.DataGridView dgvCandles;
    }
}
