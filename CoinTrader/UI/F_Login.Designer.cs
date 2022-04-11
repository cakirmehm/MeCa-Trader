namespace CoinTrader.UI
{
    partial class F_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Login));
            this.ucConnectComp = new CoinTrader.UI.ucConnect();
            this.SuspendLayout();
            // 
            // ucConnectComp
            // 
            this.ucConnectComp.BackColor = System.Drawing.Color.LightGray;
            this.ucConnectComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucConnectComp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ucConnectComp.Location = new System.Drawing.Point(0, 0);
            this.ucConnectComp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucConnectComp.Name = "ucConnectComp";
            this.ucConnectComp.Size = new System.Drawing.Size(889, 115);
            this.ucConnectComp.TabIndex = 7;
            this.ucConnectComp.Tag = "";
            this.ucConnectComp.EnabledChanged += new System.EventHandler(this.ucConnectComp_EnabledChanged);
            // 
            // F_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 115);
            this.Controls.Add(this.ucConnectComp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "F_Login";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login to Binance...";
            this.ResumeLayout(false);

        }

        #endregion

        private ucConnect ucConnectComp;
    }
}