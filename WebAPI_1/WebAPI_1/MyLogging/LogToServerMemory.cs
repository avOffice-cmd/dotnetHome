﻿namespace WebAPI_1.MyLogging
{
    public class LogToServerMemory  : IMyLogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine("LogToServerMemoryFile");
        }
    }
}
