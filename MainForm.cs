using Microsoft.Web.WebView2.Core;
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
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private async void MainForm_Load(object sender, EventArgs e)
        {
            await webView.EnsureCoreWebView2Async();  // Khởi tạo WebView2
            webView.CoreWebView2.Navigate("https://www.google.com");
            txtAddress.Text = "https://www.google.com";

            // Sự kiện thay đổi URL
            webView.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
        }

        private void NavigateToAddress()
        {
            string address = txtAddress.Text;

            if (!address.StartsWith("http://") && !address.StartsWith("https://"))
            {
                address = "https://" + address;
            }

            try
            {
                webView.CoreWebView2.Navigate(address);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải trang: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webView.CoreWebView2.CanGoBack)
            {
                webView.CoreWebView2.GoBack();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webView.CoreWebView2.CanGoForward)
            {
                webView.CoreWebView2.GoForward();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.Reload();
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                NavigateToAddress();
                e.Handled = true;
            }
        }

        private void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            txtAddress.Text = webView.Source.ToString();
        }

        private void btnMaxmin_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        
    }
}
