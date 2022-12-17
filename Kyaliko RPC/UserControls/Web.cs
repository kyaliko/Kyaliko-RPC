using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kyaliko_RPC.UserControls
{
    public partial class Web : UserControl
    {
        public Web()
        {
            InitializeComponent();
            webView21.ZoomFactor = 0.75;
            webView21.ZoomFactorChanged += uwu;
        }

        private void Web_Load(object sender, EventArgs e)
        {
            
        }

        private void webView21_Click(object sender, EventArgs e)
        {
            
        }
        private void uwu(object sender, EventArgs e)
        {
            webView21.ZoomFactor = 0.75;
        }
    }
}
