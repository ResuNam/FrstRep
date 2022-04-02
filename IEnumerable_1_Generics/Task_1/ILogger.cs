using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    interface ILogger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);
    }
}
