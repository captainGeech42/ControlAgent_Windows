using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ControlAgent
{
    class Logger
    {
        private string _sSource = "ControlAgent";
        private string _sLog = "Application";

        public Logger()
        {
            if (!EventLog.SourceExists(_sSource))
            {
                EventLog.CreateEventSource(_sSource, _sLog);
            }
        }

        /// <summary>
        /// Add a log entry for starting the Control Agent
        /// </summary>
        /// <param name="s">Logger.STATE enum value</param>
        /// <param name="ip">IP Address agent is running on (required for ENABLED)</param>
        /// <param name="port">Port agent is running on (required for ENABLED)</param>
        public void LogState(State s, string ip = null, Int32 port = 0)
        {
            String username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            switch (s)
            {
                case State.Enabled:
                    EventLog.WriteEntry(_sSource, "ControlAgent enabled by " + username + ", running on " + ip + ":" + port, EventLogEntryType.Information);
                    break;
                case State.Disabled:
                    EventLog.WriteEntry(_sSource, "ControlAgent disabled by " + username, EventLogEntryType.Information);
                    break;
            }
        }

        public void LogCommand(Commands.Command c)
        {
            switch (c)
            {
                case Commands.Command.Sleep:
                    EventLog.WriteEntry(_sSource, "Received SLEEP command from remote device", EventLogEntryType.Information);
                    break;
                case Commands.Command.Shutdown:
                    EventLog.WriteEntry(_sSource, "Received SHUTDOWN command from remote device", EventLogEntryType.Information);
                    break;
                case Commands.Command.Restart:
                    EventLog.WriteEntry(_sSource, "Received RESTART command from remote device", EventLogEntryType.Information);
                    break;
                case Commands.Command.Getproc:
                    EventLog.WriteEntry(_sSource, "Received GETPROC command from remote device", EventLogEntryType.Information);
                    break;
            }
        }

        public void LogError(string s)
        {
            EventLog.WriteEntry(_sSource, s);
        }

        public enum State
        {
            Enabled,
            Disabled
        }
    }
}
