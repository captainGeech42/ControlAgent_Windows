using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ControlAgent
{
    class Commands
    {

        public static List<String> runCommand(Command command)
        {
            Logger logger = new Logger();
            logger.LogCommand(command);
            switch (command)
            {
                case Command.GETPROC:
                    return getProcessList();
                case Command.SLEEP:
                    return sleepComputer();
                case Command.SHUTDOWN:
                    return shutdownComputer();
                case Command.RESTART:
                    return restartComputer();
                default:
                    return new List<string>() { "Command Not Found" };
            }
            
        }

        /// <summary>
        /// Put the computer to sleep
        /// </summary>
        /// <returns>List with status</returns>
        private static List<String> sleepComputer()
        {
            //Application.SetSuspendState(PowerState.Suspend, true, true);
            return new List<string>() { "SLEEP Command Executed Successfully" };
        }

        /// <summary>
        /// Shutdown the computer
        /// </summary>
        /// <returns>List with status</returns>
        private static List<String> shutdownComputer()
        {
            Process.Start("timeout 3 > NUL && shutdown -s -t 0");
            return new List<string>() { "SHUTDOWN Command Executed Successfully" };
        }

        /// <summary>
        /// Restart the computer
        /// </summary>
        /// <returns>List with status</returns>
        private static List<String> restartComputer()
        {
            Process.Start("timeout 3 > NUL && shutdown -r -t 0");
            return new List<string>() { "RESTART Command Executed Successfully" };
        }

        /// <summary>
        /// Get a list of all processes running on the computer
        /// </summary>
        /// <returns>List with status, and then process name and PID, delimited with a |</returns>
        private static List<string> getProcessList()
        {
            List<string> processes = new List<string>() { "GETPROC Command Executed Successfully" };
            Process[] processArray = Process.GetProcesses();
            foreach (Process proc in processArray)
            {
                processes.Add(proc.Id + "|" + proc.Handle);
            }
            return processes;
            //This list has only one item with spaces in it (status), so filter list in Swift for spaces (those without are processes)
        }

        public enum Command
        {
            SLEEP,
            SHUTDOWN,
            RESTART,
            GETPROC
        }
    }
}
