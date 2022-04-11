namespace CoinTrader.UI
{
    partial class F_QueryWindow
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
            this.ucQueryPaneComp = new CoinTrader.UI.ucQueryPane();
            this.SuspendLayout();
            // 
            // ucQueryPaneComp
            // 
            this.ucQueryPaneComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucQueryPaneComp.EndDate = new System.DateTime(2021, 4, 25, 13, 0, 6, 183);
            this.ucQueryPaneComp.Location = new System.Drawing.Point(0, 0);
            this.ucQueryPaneComp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucQueryPaneComp.Name = "ucQueryPaneComp";
            this.ucQueryPaneComp.SelectedRefSymbol = "BUSD";
            this.ucQueryPaneComp.Size = new System.Drawing.Size(1461, 690);
            this.ucQueryPaneComp.StartDate = new System.DateTime(2021, 4, 24, 13, 0, 6, 183);
            this.ucQueryPaneComp.TabIndex = 12;
            this.ucQueryPaneComp.URL = null;
            // 
            // F_QueryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 690);
            this.Controls.Add(this.ucQueryPaneComp);
            this.DoubleBuffered = true;
            this.Name = "F_QueryWindow";
            this.Text = "Sorgu Ekranı";
            this.ResumeLayout(false);

        }

        #endregion

        private ucQueryPane ucQueryPaneComp;
    }
}