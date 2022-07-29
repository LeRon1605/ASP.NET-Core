using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private async void btnFetch_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient() {
                BaseAddress = new Uri("https://vue-ytb-form-58caa-default-rtdb.firebaseio.com")
            };
            var a = await DoSomething();
            data.Text = a;
        }

        private async Task<string> DoSomething()
        {
            var a = await Task.Run(() =>
            {
                for (long i = 0; i < 500000000; i++)
                {

                }
                return "data.json";
            });
            MessageBox.Show("Access do something");
            txtNum.Text = "data.json";
            return a;
        }

        private async Task<string> DoSomething2()
        {
            var a = await Task.Run(() =>
            {
                for (long i = 0; i < 900000000; i++)
                {

                }
                return "data.json";
            });
            MessageBox.Show("Access dosomething 2");
            data.Text = "data.json";
            return a;
        }

        private async void btnLog_Click(object sender, EventArgs e)
        {
            _ = Task.Run(async () =>
            {
                await DoSomething2();
            });
            btnLog.Text = "Log changed";
            await DoSomething();
            btnLog.Text = "Log";
        }
    }
}
