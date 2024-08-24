using System;
using System.Threading;
using System.Windows.Forms;

namespace StaticWebServerManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        // 创建一个互斥体
        static Mutex mutex = null;

        [STAThread]
        static void Main()
        {
            const string appName = "StaticWebServerManagerUnique"; // 确保这个名字是唯一的
            bool createdNew;

            // 尝试创建一个新的互斥体
            mutex = new Mutex(true, appName, out createdNew);

            // 如果互斥体已经存在，说明程序已经在运行
            if (!createdNew)
            {
                MessageBox.Show("程序已经在运行。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 退出程序
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
