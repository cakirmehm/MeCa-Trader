namespace CoinTrader.UI
{
    partial class F_OrderManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_OrderManagement));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPgOrderCreate = new System.Windows.Forms.TabPage();
            this.ucOrderComp = new CoinTrader.UI.ucOrder();
            this.tbPgOrderBook = new System.Windows.Forms.TabPage();
            this.ucOrderBook1 = new CoinTrader.UI.ucOrderBook();
            this.ucOrderBook2 = new CoinTrader.UI.ucOrderBook();
            this.ucOrderBook3 = new CoinTrader.UI.ucOrderBook();
            this.ucOrderBook4 = new CoinTrader.UI.ucOrderBook();
            this.tabControl1.SuspendLayout();
            this.tbPgOrderCreate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbPgOrderCreate);
            this.tabControl1.Controls.Add(this.tbPgOrderBook);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(933, 554);
            this.tabControl1.TabIndex = 12;
            // 
            // tbPgOrderCreate
            // 
            this.tbPgOrderCreate.Controls.Add(this.ucOrderComp);
            this.tbPgOrderCreate.Location = new System.Drawing.Point(4, 25);
            this.tbPgOrderCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPgOrderCreate.Name = "tbPgOrderCreate";
            this.tbPgOrderCreate.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPgOrderCreate.Size = new System.Drawing.Size(925, 525);
            this.tbPgOrderCreate.TabIndex = 0;
            this.tbPgOrderCreate.Text = "Emir Girişi";
            this.tbPgOrderCreate.UseVisualStyleBackColor = true;
            // 
            // ucOrderComp
            // 
            this.ucOrderComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOrderComp.Location = new System.Drawing.Point(3, 4);
            this.ucOrderComp.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucOrderComp.Name = "ucOrderComp";
            this.ucOrderComp.Size = new System.Drawing.Size(919, 517);
            this.ucOrderComp.TabIndex = 11;
            // 
            // tbPgOrderBook
            // 
            this.tbPgOrderBook.Location = new System.Drawing.Point(4, 25);
            this.tbPgOrderBook.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPgOrderBook.Name = "tbPgOrderBook";
            this.tbPgOrderBook.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPgOrderBook.Size = new System.Drawing.Size(925, 525);
            this.tbPgOrderBook.TabIndex = 1;
            this.tbPgOrderBook.Text = "Emir Defteri";
            this.tbPgOrderBook.UseVisualStyleBackColor = true;
            // 
            // F_OrderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "F_OrderManagement";
            this.Text = "Emir Yönetimi";
            this.tabControl1.ResumeLayout(false);
            this.tbPgOrderCreate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ucOrder ucOrderComp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbPgOrderCreate;
        private System.Windows.Forms.TabPage tbPgOrderBook;
        private ucOrderBook ucOrderBook1;
        private ucOrderBook ucOrderBook2;
        private ucOrderBook ucOrderBook3;
        private ucOrderBook ucOrderBook4;
    }
}