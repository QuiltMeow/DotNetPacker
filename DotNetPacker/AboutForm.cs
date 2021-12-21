using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DotNetPacker
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void pbProfile_Click(object sender, EventArgs e)
        {
            Process.Start("https://intro.quilt.idv.tw/");
        }

        private void AboutForm_Click(object sender, EventArgs e)
        {
            wbMedia.Url = new Uri("https://smallquilt.quilt.idv.tw:8923/webVideo/resource.php");
            wbMedia.Visible = true;
        }
    }
}