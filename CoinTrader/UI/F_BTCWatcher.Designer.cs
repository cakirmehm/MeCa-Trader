namespace CoinTrader.UI
{
    partial class F_BTCWatcher
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
            this.ucBTCWatcherComp = new CoinTrader.UI.ucBTCWatcher();
            this.SuspendLayout();
            // 
            // ucBTCWatcherComp
            // 
            this.ucBTCWatcherComp.BackColor = System.Drawing.Color.LightGray;
            this.ucBTCWatcherComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBTCWatcherComp.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ucBTCWatcherComp.Location = new System.Drawing.Point(0, 0);
            this.ucBTCWatcherComp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucBTCWatcherComp.Name = "ucBTCWatcherComp";
            this.ucBTCWatcherComp.Size = new System.Drawing.Size(1405, 139);
            this.ucBTCWatcherComp.TabIndex = 8;
            // 
            // F_BTCWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 139);
            this.Controls.Add(this.ucBTCWatcherComp);
            this.DoubleBuffered = true;
            this.Name = "F_BTCWatcher";
            this.Text = "Binance Watcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_BTCWatcher_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ucBTCWatcher ucBTCWatcherComp;
    }
}