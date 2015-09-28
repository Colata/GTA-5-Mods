using System;
using System.IO;

public static class Logger
{
    public static void Log(object message)
    {
        File.AppendAllText(@"C:\Users\samuel\Desktop\GTA5Logs\CoordsLogger.txt", DateTime.Now + " : " + message + Environment.NewLine);
    }
}
