using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com");
            txtAddress.Text = "https://www.google.com";
        }
        private void NavigateToAddress()
        {
            string address = txtAddress.Text;

            // Thêm "http://" nếu không có
            if (!address.StartsWith("http://") && !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }

            try
            {
                webBrowser1.Navigate(address);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải trang: " + ex.Message, "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                NavigateToAddress();
                e.Handled = true;
            }
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtAddress.Text = webBrowser1.Url.ToString();
        }
    }
}
