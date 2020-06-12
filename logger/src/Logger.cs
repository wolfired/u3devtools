using System;
using System.IO;
using System.Collections.Generic;

using UnityEngine;

namespace u3devtools.logger
{
    public enum LogLevel
    {
        ON,
        DEBUG,
        INFO,
        WARN,
        ERROR,
        FATAL,
        OFF,
    }

    public class LoggerManager
    {
        private LogLevel _min_log_level;
        private readonly object _locker;
        private readonly StreamWriter _sw;
        private List<string> _waiting_logs;
        private List<string> _writing_logs;

        public LoggerManager(string log_file, LogLevel min_log_level = LogLevel.WARN)
        {
            _min_log_level = min_log_level;

            _locker = new object();

            _sw = new StreamWriter(new FileStream(log_file, FileMode.Create, FileAccess.Write, FileShare.Read));

            _waiting_logs = new List<string>();
            _writing_logs = new List<string>();

            Application.logMessageReceived += onLogMessageReceived;
        }

        public void log_debug(string log)
        {
            this.log(LogLevel.DEBUG, log);
        }

        public void log_info(string log)
        {
            this.log(LogLevel.INFO, log);
        }

        public void log_warn(string log)
        {
            this.log(LogLevel.WARN, log);
        }

        public void log_error(string log)
        {
            this.log(LogLevel.ERROR, log);
        }

        public void log_fatal(string log)
        {
            this.log(LogLevel.FATAL, log);
        }

        public void log_person(string log, LogLevel log_level = (LogLevel)100)
        {
            this.log(log_level, log);
        }

        public void log(LogLevel log_level, string log)
        {
            if (_min_log_level > log_level)
            {
                return;
            }

            lock (_locker)
            {
                _waiting_logs.Add(String.Format("[{0:HH:mm:ss fff}][{1,11}]{2}", DateTime.Now, log_level, log));
            }
        }

        public void print()
        {
            lock (_locker)
            {
                if (0 < _waiting_logs.Count)
                {
                    _writing_logs.AddRange(_waiting_logs);
                    _waiting_logs.Clear();
                }
            }

            if (null == _sw)
            {
                return;
            }

            try
            {
                if (0 < _writing_logs.Count)
                {
                    foreach (string log in _writing_logs)
                    {
                        _sw.WriteLine(log);
                    }
                    _sw.Flush();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                _writing_logs.Clear();
            }
        }

        private void onLogMessageReceived(string log, string stack_track, LogType type)
        {
            LogLevel log_level = LogLevel.OFF;
            switch (type)
            {
                case LogType.Error:
                    log_level = LogLevel.ERROR;
                    break;
                case LogType.Assert:
                    log_level = LogLevel.INFO;
                    break;
                case LogType.Warning:
                    log_level = LogLevel.WARN;
                    break;
                case LogType.Log:
                    log_level = LogLevel.DEBUG;
                    break;
                case LogType.Exception:
                    log_level = LogLevel.ERROR;
                    break;
            }
            string padding = String.Format("\n{0,14}[Stack Track]", "");
            this.log(log_level, String.Format("{0}{1}{2}", log, padding, stack_track.Trim().Replace("\n", padding)));
        }
    }
}
