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
            this.BackColor = System.Drawing.Color.FromArgb(50, 60, 50);
            this.ForeColor = System.Drawing.Color.White;
            btnCreate.Click += BtnCreate_Click;
            btnBrowse.Click += BtnBrowse_Click;
            btnDelete.Click += BtnDelete_Click;
            txtPort.KeyPress += TxtPort_KeyPress;

            // 设置窗体的启动位置为中心
            this.StartPosition = FormStartPosition.CenterParent;

            // 初始化复选框状态
            chkScriptMode.CheckedChanged += ChkScriptMode_CheckedChanged;
            chkScriptMode.Checked = false; // 默认为未选中
            ChkScriptMode_CheckedChanged(null, null); // 初始化控件可见性
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            // 如果是脚本模式
            if (chkScriptMode.Checked)
            {
                // 校验启动命令是否填写
                if (string.IsNullOrWhiteSpace(txtCmd.Text))
                {
                    MessageBox.Show("请填写有效的启动命令。", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 创建 Server 对象，设置脚本模式相关属性
                Server = new Server
                {
                    isScriptMode = true,
                    Name = txtServerName.Text,
                    Cmd = txtCmd.Text // 只保存启动命令
                };
            }
            else
            {
                // 校验其他输入
                if (string.IsNullOrWhiteSpace(txtServerName.Text) ||
                    string.IsNullOrWhiteSpace(txtWebsiteDirectory.Text) ||
                    !int.TryParse(txtPort.Text, out int port) || port <= 0 ||
                    string.IsNullOrWhiteSpace(txtEntryPoint.Text))
                {
                    MessageBox.Show("请填写有效的服务器名、网站目录和端口。", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 创建 Server 对象，设置常规模式相关属性
                Server = new Server
                {
                    isScriptMode = false,
                    Name = txtServerName.Text,
                    WebsiteDirectory = txtWebsiteDirectory.Text,
                    Port = port,
                    EntryPoint = txtEntryPoint.Text,
                    Cmd = null // 非脚本模式下，命令为 null
                };
            }

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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ChkScriptMode_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = chkScriptMode.Checked;

            // 根据复选框的状态控制控件的可见性
            txtWebsiteDirectory.Visible = !isChecked;
            txtPort.Visible = !isChecked;
            txtEntryPoint.Visible = !isChecked;
            lblWebsiteDirectory.Visible = !isChecked;
            lblPort.Visible = !isChecked;
            lblEntryPoint.Visible = !isChecked;

            txtCmd.Visible = isChecked;
            lblCmd.Visible = isChecked;

            // 隐藏或显示“浏览”按钮
            btnBrowse.Visible = !isChecked;
        }



        public void SetServer(Server server)
        {
            txtServerName.Text = server.Name;
            txtWebsiteDirectory.Text = server.WebsiteDirectory;
            txtPort.Text = server.Port.ToString();
            txtCmd.Text = server.Cmd; // 设置命令
            chkScriptMode.Checked = server.isScriptMode == true; // 设置脚本模式
            ChkScriptMode_CheckedChanged(null, null); // 更新控件可见性
        }
    }
}
