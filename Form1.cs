using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace StaticWebServerManager
{
    public partial class Form1 : Form
    {
        private const string DataFilePath = "servers.json";
        private List<Server> servers = new List<Server>();
        private NotifyIcon notifyIcon;
        private bool isExiting = false; // 用于标记是否正在退出应用程序

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ForeColor = System.Drawing.Color.White;

            btnAddServer.Click += BtnAddServer_Click;
            LoadServers(); // 加载服务器数据

            // 初始化 NotifyIcon
            notifyIcon = new NotifyIcon
            {
                
                Icon = this.Icon, // 使用资源中的图标
                Visible = false // 初始时隐藏
            };

            // 添加托盘双击事件
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

            // 初始化右键菜单
            InitializeContextMenu();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDBLCLK = 0x00A3;
            const int HTCAPTION = 0x02;

            if (m.Msg == WM_NCLBUTTONDBLCLK && m.WParam.ToInt32() == HTCAPTION)
            {
                return;
            }

            base.WndProc(ref m);
        }

        private void LoadServers()
        {
            if (File.Exists(DataFilePath))
            {
                var json = File.ReadAllText(DataFilePath);
                servers = JsonConvert.DeserializeObject<List<Server>>(json) ?? new List<Server>();
                foreach (var server in servers)
                {
                    AddServerCard(server);
                }
            }
        }

        private void SaveServers()
        {
            var json = JsonConvert.SerializeObject(servers, Formatting.Indented);
            File.WriteAllText(DataFilePath, json);
        }

        private void BtnAddServer_Click(object sender, EventArgs e)
        {
            using (var form = new AddServerForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var server = form.Server;
                    servers.Add(server);
                    AddServerCard(server);
                    SaveServers(); // 保存服务器数据
                }
            }
        }

        private void AddServerCard(Server server)
        {
            var serverCard = new ServerCard
            {
                ServerName = server.Name,
                WebsiteDirectory = server.WebsiteDirectory,
                Port = server.Port,
                EntryPoint = server.EntryPoint,
                isScriptMode = server.isScriptMode,
                Cmd = server.Cmd,
            };

            serverCard.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            serverCard.ForeColor = System.Drawing.Color.White;

            serverCard.OnStartStopClicked += (s, e) => ToggleServer(server);
            serverCard.OnEditClicked += (s, e) => EditServer(server);
            serverCard.OnDeleteClicked += (s, e) => DeleteServer(server, serverCard);

            flpServers.Controls.Add(serverCard);
        }

        private void ToggleServer(Server server)
        {
            //MessageBox.Show(this, $"Toggled server: {server.Name}", "服务器状态", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EditServer(Server server)
        {
            using (var form = new AddServerForm())
            {
                form.SetServer(server);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    server.Name = form.Server.Name;
                    server.WebsiteDirectory = form.Server.WebsiteDirectory;
                    server.Port = form.Server.Port;
                    server.EntryPoint = form.Server.EntryPoint;

                    var serverCard = flpServers.Controls.OfType<ServerCard>().FirstOrDefault(card => card.ServerName == server.Name);
                    if (serverCard != null)
                    {
                        serverCard.ServerName = server.Name;
                        serverCard.EntryPoint = server.EntryPoint;
                        serverCard.Port = server.Port;
                        serverCard.Name = server.Name;
                    }
                }
            }
        }

        private void DeleteServer(Server server, ServerCard serverCard)
        {
            servers.Remove(server);
            flpServers.Controls.Remove(serverCard);
            SaveServers(); // 保存服务器数据
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Resize += Form1_Resize;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true; // 显示托盘图标
            }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show(); // 显示窗体
            this.WindowState = FormWindowState.Normal; // 恢复窗体状态
            notifyIcon.Visible = false; // 隐藏托盘图标
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExiting) // 如果不是通过托盘菜单退出，则取消关闭事件
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon.Visible = true; // 显示托盘图标
            }
        }

        private void InitializeContextMenu()
        {
            // 创建右键菜单
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // 创建“打开窗口”菜单项
            ToolStripMenuItem menuItemOpen = new ToolStripMenuItem("打开窗口");
            menuItemOpen.Click += MenuItemOpen_Click; // 绑定事件
            contextMenu.Items.Add(menuItemOpen);

            // 创建“关闭”菜单项
            ToolStripMenuItem menuItemExit = new ToolStripMenuItem("关闭");
            menuItemExit.Click += MenuItemExit_Click; // 绑定事件
            contextMenu.Items.Add(menuItemExit);

            // 将右键菜单分配给 NotifyIcon
            notifyIcon.ContextMenuStrip = contextMenu;
        }
        // 添加一个方法来恢复窗口
        public void RestoreWindow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal; // 恢复窗口状态
            notifyIcon.Visible = false; // 隐藏托盘图标
            this.Activate(); // 激活窗口
        }
        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            this.Show(); // 显示窗体
            this.WindowState = FormWindowState.Normal; // 恢复窗体状态
            notifyIcon.Visible = false; // 隐藏托盘图标
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            isExiting = true; // 设置标记为正在退出
            notifyIcon.Visible = false; // 隐藏托盘图标
            Application.Exit(); // 退出应用程序
        }
    }

    public class Server
    {
        public bool isScriptMode { get; set; }
        public string Name { get; set; }
        public string WebsiteDirectory { get; set; }
        public int Port { get; set; }
        public string EntryPoint { get; set; }

        public string Cmd { get; set; }
    }
}
