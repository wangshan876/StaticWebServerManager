using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace StaticWebServerManager
{
    public partial class WebViewForm : Form
    {
        private WebView2 webView;

        public WebViewForm(string url)
        {
            InitializeComponent();
            InitializeWebView(url);
        }

        private void InitializeWebView(string url)
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(webView);
            webView.Source = new Uri(url);
        }

        private void WebViewForm_Load(object sender, EventArgs e)
        {

        }
    }
}
