using System.Collections.Generic;
using System.Linq;
using Library.Models;
using System;

namespace Library.Functions
{
    public class LogFunctions
    {
        private readonly File File;
        private List<Log> Logs;
        public LogFunctions()
        {
            this.File = new File();
            this.Logs = new List<Log>();
        }

        public void GetLogs()
        {
            this.Logs = this.File.GetLogs();
        }

        public void SetLogs()
        {
            this.File.SetLogs(this.Logs);
        }

        public void AddLogs(Log log)
        {
            GetLogs();
            this.Logs.Add(log);
            SetLogs();
        }
    }
}