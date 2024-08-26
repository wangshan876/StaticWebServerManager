using System;
using System.Windows.Forms;

namespace StaticWebServerManager
{
    public partial class AddServerForm : Form
    {
        public Server Server { get; private set; }

        public AddServerForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            // 设置Form1的背景颜色为暗色
            this.BackColor = System.Drawing.Color.FromArgb(50, 60, 50); 
            this.ForeColor = System.Drawing.Color.White; // 文字颜色为白色
            btnCreate.Click += BtnCreate_Click;
            btnBrowse.Click += BtnBrowse_Click;
            btnDelete.Click += BtnDelete_Click;
            txtPort.KeyPress += TxtPort_KeyPress; // 限制端口输入

            // 设置窗体的启动位置为中心
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            this.Close(); // 关闭当前窗体
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServerName.Text) ||
                string.IsNullOrWhiteSpace(txtWebsiteDirectory.Text) ||
                !int.TryParse(txtPort.Text, out int port) || port <= 0 ||
                string.IsNullOrWhiteSpace(txtEntryPoint.Text))
            {
                MessageBox.Show("请填写有效的服务器名、网站目录和端口。", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Server = new Server
            {
                Name = txtServerName.Text,
                WebsiteDirectory = txtWebsiteDirectory.Text,
                Port = port,
                EntryPoint = txtEntryPoint.Text
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    txtWebsiteDirectory.Text = folderBrowser.SelectedPath;
                }
            }
        }

        private void TxtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 只允许输入数字
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // 新增的属性，用于在编辑时填充数据
        public void SetServer(Server server)
        {
            txtServerName.Text = server.Name;
            txtWebsiteDirectory.Text = server.WebsiteDirectory;
            txtPort.Text = server.Port.ToString();
        }
    }
}
