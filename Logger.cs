using System;
using System.IO;

public static class Logger
{
    private static readonly string logFilePath = "application_log.txt"; // 日志文件路径

    public static void LogError(string message)
    {
        WriteLog("ERROR", message);
    }

    public static void LogInfo(string message)
    {
        WriteLog("INFO", message);
    }

    private static void WriteLog(string logLevel, string message)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {message}");
            }
        }
        catch (Exception ex)
        {
            // 如果写入日志失败，可以选择在控制台输出或其他处理
            Console.WriteLine($"日志记录失败: {ex.Message}");
        }
    }
}
