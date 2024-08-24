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
        // ����һ��������
        static Mutex mutex = null;

        [STAThread]
        static void Main()
        {
            const string appName = "StaticWebServerManagerUnique"; // ȷ�����������Ψһ��
            bool createdNew;

            // ���Դ���һ���µĻ�����
            mutex = new Mutex(true, appName, out createdNew);

            // ����������Ѿ����ڣ�˵�������Ѿ�������
            if (!createdNew)
            {
                MessageBox.Show("�����Ѿ������С�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // �˳�����
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
