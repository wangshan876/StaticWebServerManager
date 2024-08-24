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
        private bool isExiting = false; // ���ڱ���Ƿ������˳�Ӧ�ó���

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ForeColor = System.Drawing.Color.White;

            btnAddServer.Click += BtnAddServer_Click;
            LoadServers(); // ���ط���������

            // ��ʼ�� NotifyIcon
            notifyIcon = new NotifyIcon
            {
                
                Icon = this.Icon, // ʹ����Դ�е�ͼ��
                Visible = false // ��ʼʱ����
            };

            // �������˫���¼�
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

            // ��ʼ���Ҽ��˵�
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
                    SaveServers(); // �������������
                }
            }
        }

        private void AddServerCard(Server server)
        {
            var serverCard = new ServerCard
            {
                ServerName = server.Name,
                WebsiteDirectory = server.WebsiteDirectory,
                Port = server.Port
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
            MessageBox.Show(this, $"Toggled server: {server.Name}", "������״̬", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    var serverCard = flpServers.Controls.OfType<ServerCard>().FirstOrDefault(card => card.ServerName == server.Name);
                    if (serverCard != null)
                    {
                        serverCard.ServerName = server.Name;
                    }
                }
            }
        }

        private void DeleteServer(Server server, ServerCard serverCard)
        {
            servers.Remove(server);
            flpServers.Controls.Remove(serverCard);
            SaveServers(); // �������������
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
                notifyIcon.Visible = true; // ��ʾ����ͼ��
            }
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show(); // ��ʾ����
            this.WindowState = FormWindowState.Normal; // �ָ�����״̬
            notifyIcon.Visible = false; // ��������ͼ��
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExiting) // �������ͨ�����̲˵��˳�����ȡ���ر��¼�
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon.Visible = true; // ��ʾ����ͼ��
            }
        }

        private void InitializeContextMenu()
        {
            // �����Ҽ��˵�
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // �������򿪴��ڡ��˵���
            ToolStripMenuItem menuItemOpen = new ToolStripMenuItem("�򿪴���");
            menuItemOpen.Click += MenuItemOpen_Click; // ���¼�
            contextMenu.Items.Add(menuItemOpen);

            // �������رա��˵���
            ToolStripMenuItem menuItemExit = new ToolStripMenuItem("�ر�");
            menuItemExit.Click += MenuItemExit_Click; // ���¼�
            contextMenu.Items.Add(menuItemExit);

            // ���Ҽ��˵������ NotifyIcon
            notifyIcon.ContextMenuStrip = contextMenu;
        }

        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            this.Show(); // ��ʾ����
            this.WindowState = FormWindowState.Normal; // �ָ�����״̬
            notifyIcon.Visible = false; // ��������ͼ��
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            isExiting = true; // ���ñ��Ϊ�����˳�
            notifyIcon.Visible = false; // ��������ͼ��
            Application.Exit(); // �˳�Ӧ�ó���
        }
    }

    public class Server
    {
        public string Name { get; set; }
        public string WebsiteDirectory { get; set; }
        public int Port { get; set; }
    }
}
