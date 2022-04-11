namespace CoinTrader.UI
{
    partial class ucSignals
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
            this.gbxSignals = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // gbxSignals
            // 
            this.gbxSignals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxSignals.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbxSignals.Location = new System.Drawing.Point(0, 0);
            this.gbxSignals.Name = "gbxSignals";
            this.gbxSignals.Size = new System.Drawing.Size(582, 308);
            this.gbxSignals.TabIndex = 0;
            this.gbxSignals.TabStop = false;
            this.gbxSignals.Text = "Signals";
            // 
            // ucSignals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxSignals);
            this.DoubleBuffered = true;
            this.Name = "ucSignals";
            this.Size = new System.Drawing.Size(582, 308);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSignals;
    }
}
