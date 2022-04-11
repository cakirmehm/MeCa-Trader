namespace CoinTrader.UI
{
    partial class F_Portfolio
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
            this.ucPortfolioManagerComp = new CoinTrader.UI.ucPortfolioManager();
            this.SuspendLayout();
            // 
            // ucPortfolioManagerComp
            // 
            this.ucPortfolioManagerComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPortfolioManagerComp.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ucPortfolioManagerComp.Location = new System.Drawing.Point(0, 0);
            this.ucPortfolioManagerComp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucPortfolioManagerComp.Name = "ucPortfolioManagerComp";
            this.ucPortfolioManagerComp.Size = new System.Drawing.Size(760, 536);
            this.ucPortfolioManagerComp.TabIndex = 13;
            // 
            // F_Portfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 536);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.ucPortfolioManagerComp);
            this.DoubleBuffered = true;
            this.Name = "F_Portfolio";
            this.Text = "Portföy";
            this.ResumeLayout(false);

        }

        #endregion

        private ucPortfolioManager ucPortfolioManagerComp;
    }
}