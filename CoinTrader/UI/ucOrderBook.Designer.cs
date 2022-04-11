namespace CoinTrader.UI
{
    partial class ucOrderBook
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
            this.dgvOrderBook = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderBook)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrderBook
            // 
            this.dgvOrderBook.AllowUserToAddRows = false;
            this.dgvOrderBook.AllowUserToDeleteRows = false;
            this.dgvOrderBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderBook.GridColor = System.Drawing.Color.LightSkyBlue;
            this.dgvOrderBook.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderBook.Name = "dgvOrderBook";
            this.dgvOrderBook.ReadOnly = true;
            this.dgvOrderBook.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvOrderBook.Size = new System.Drawing.Size(642, 481);
            this.dgvOrderBook.TabIndex = 0;
            // 
            // ucOrderBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvOrderBook);
            this.Name = "ucOrderBook";
            this.Size = new System.Drawing.Size(642, 481);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderBook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrderBook;
    }
}
