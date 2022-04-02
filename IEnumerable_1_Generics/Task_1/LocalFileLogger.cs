using System;
using System.Collections.Generic;
using System.IO;

namespace Task_1
{
    class LocalFileLogger<T> : ILogger
    {
        string path;

        public LocalFileLogger(string filepath)
        {
            path = filepath;
        }
        public void LogError(string message, Exception ex)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"[Error] : [{typeof(T).Name}] : {message}. {ex.Message}");
            }    
        }

        public void LogInfo(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"[Info]: [{typeof(T).Name}] : {message}");
            }
        }

        public void LogWarning(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"[Warning] : [{typeof(T).Name}] : {message}");
            }
        }
    }
}
