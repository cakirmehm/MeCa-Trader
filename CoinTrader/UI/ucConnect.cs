using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoinTrader.Source;

namespace CoinTrader.UI
{
    public partial class ucConnect : UserControl
    {
        private CBinanceDataController DataController;

        public ucConnect()
        {
            InitializeComponent();
        }

        private async void btnConnect_ClickAsync(object sender, EventArgs e)
        {
            if (txtAPIKey.Text.Length > 0 && txtAPISecretKey.Text.Length > 0)
            {
                await Login();
            }

        }

        public async Task Login()
        {
            DataController = new CBinanceDataController(
                Environment.GetEnvironmentVariable("API_KEY", EnvironmentVariableTarget.User),
                Environment.GetEnvironmentVariable("API_SECRET_KEY", EnvironmentVariableTarget.User));

            btnConnect.Enabled = false;
            pictureBoxLoading.Visible = true;
            lblConnection.Visible = true;
            lblConnection.BringToFront();

            await Task.Run(() => DataController.Start());

            pictureBoxLoading.Visible = false;
            lblConnection.Visible = false;
            btnConnect.FlatAppearance.BorderColor = Color.Green;
            this.Enabled = false;
        }

        public CBinanceDataController getDataController()
        {
            return DataController;
        }
    }
}
