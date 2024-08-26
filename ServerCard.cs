using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace StaticWebServerManager
{
    public partial class ServerCard : UserControl
    {
        public event EventHandler OnEditClicked;
        public event EventHandler OnDeleteClicked;
        public event EventHandler OnStartStopClicked;

        private HttpListener httpListener;
        private bool isRunning;

        public string ServerName
        {
            get => lblServerName.Text;
            set => lblServerName.Text = value;
        }

        public string WebsiteDirectory { get; set; }
        public int Port { get; set; } = 8080; // 默认端口设置为8080
        public string EntryPoint { get; set; } = "index.html";

        public ServerCard()
        {
            InitializeComponent();
            // 设置ServerCard的背景颜色为稍微不同的暗色
            this.BackColor = System.Drawing.Color.FromArgb(50, 50, 50); // 稍微亮一点的深灰色
            this.ForeColor = System.Drawing.Color.White; // 文字颜色为白色

            btnStartStop.Click += (s, e) => ToggleServer();
            btnEdit.Click += (s, e) => OnEditClicked?.Invoke(this, e);
            btnDelete.Click += (s, e) => OnDeleteClicked?.Invoke(this, e);
            btnOpenInWebView.Click += (s, e) => OpenInWebView();
        }
        private void OpenInWebView()
        {
            if (!isRunning)
            {
                StartServer(); // 启动服务器
            }

            // 服务器启动后，构建 index.html 的 URL
            string url = $"http://localhost:{Port}/{EntryPoint}";

            // 打开新的 WebView 窗体
            WebViewForm webViewForm = new WebViewForm(url);
            webViewForm.Show(); // 显示新窗体
        }

        private void ToggleServer()
        {
            if (isRunning)
            {
                StopServer();
            }
            else
            {
                StartServer();
            }

            OnStartStopClicked?.Invoke(this, EventArgs.Empty);
        }

        private void RegisterUrlAcl(int port)
        {
            try
            {
                // 构建命令
                string command = $"http add urlacl url=http://+: {port}/ user=Everyone";

                // 创建进程启动信息
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = command,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Verb = "runas" // 以管理员身份运行
                };

                // 启动进程
                using (Process process = Process.Start(processStartInfo))
                {
                    process.WaitForExit();

                    // 获取输出
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    if (process.ExitCode == 0)
                    {
                        Logger.LogError($"URL 访问权限已成功注册。");
                    }
                    else
                    {
                        Logger.LogError($"注册 URL 访问权限时出错: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生异常: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartServer()
        {
            try
            {
                // 注册 URL 访问权限
                RegisterUrlAcl(Port);

                httpListener = new HttpListener();
                httpListener.Prefixes.Add($"http://*:{Port}/");
                httpListener.Start();
                isRunning = true;
                btnStartStop.Text = "停止";

                System.Threading.Thread listenerThread = new System.Threading.Thread(HandleRequests);
                listenerThread.Start();

                MessageBox.Show(this, $"服务器 {ServerName} 已启动，监听端口 {Port}。", "服务器启动", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (HttpListenerException httpEx)
            {
                MessageBox.Show(this, $"HTTP Listener 错误: {httpEx.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"启动服务器时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopServer()
        {
            if (httpListener != null)
            {
                httpListener.Stop();
                httpListener.Close();
                httpListener = null;
                isRunning = false;
                btnStartStop.Text = "启动";
                MessageBox.Show($"服务器 {ServerName} 已停止。", "服务器停止", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HandleRequests()
        {
            while (isRunning)
            {
                try
                {
                    var context = httpListener.GetContext();
                    var request = context.Request;
                    var response = context.Response;

                    string filePath = System.IO.Path.Combine(WebsiteDirectory, request.Url.AbsolutePath.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        byte[] buffer = System.IO.File.ReadAllBytes(filePath);
                        response.ContentLength64 = buffer.Length;

                        // 设置正确的MIME类型
                        string extension = System.IO.Path.GetExtension(filePath).ToLowerInvariant();
                        switch (extension)
                        {
                            case ".html":
                                response.ContentType = "text/html";
                                break;
                            case ".css":
                                response.ContentType = "text/css";
                                break;
                            case ".js":
                                response.ContentType = "application/javascript";
                                break;
                            case ".mjs":
                                response.ContentType = "application/javascript";
                                break;
                            case ".json":
                                response.ContentType = "application/json";
                                break;
                            case ".png":
                                response.ContentType = "image/png";
                                break;
                            case ".jpg":
                            case ".jpeg":
                                response.ContentType = "image/jpeg";
                                break;
                            case ".gif":
                                response.ContentType = "image/gif";
                                break;
                            case ".ico":
                                response.ContentType = "image/x-icon";
                                break;
                            // 添加其他需要的MIME类型
                            default:
                                response.ContentType = "application/octet-stream"; // 默认类型
                                break;
                        }

                        response.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                    }
                    response.Close();
                }
                catch (HttpListenerException) { }
                catch (Exception ex)
                {
                    MessageBox.Show($"处理请求时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
