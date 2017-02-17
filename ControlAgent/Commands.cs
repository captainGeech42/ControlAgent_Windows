using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ControlAgent
{
    class Commands
    {
        public static List<String> RunCommand(Command command)
        {
            Logger logger = new Logger();
            logger.LogCommand(command);
            switch (command)
            {
                case Command.Getproc:
                    return GetProcessList();
                case Command.Sleep:
                    return SleepComputer();
                case Command.Shutdown:
                    return ShutdownComputer();
                case Command.Restart:
                    return RestartComputer();
                default:
                    //execution won't get here, b/c exception is thrown parsing the command enum if it is invalid
                    return new List<string>() { "Command Not Found" };
            }
            
        }

        /// <summary>
        /// Put the computer to sleep
        /// </summary>
        /// <returns>List with status</returns>
        private static List<String> SleepComputer()
        {
            Application.SetSuspendState(PowerState.Suspend, true, true);
            return new List<string>() { "Sleep Command Executed Successfully" };
        }

        /// <summary>
        /// Shutdown the computer
        /// </summary>
        /// <returns>List with status</returns>
        private static List<String> ShutdownComputer()
        {
            Process.Start("timeout 3 > NUL && shutdown -s -t 0");
            return new List<string>() { "Shutdown Command Executed Successfully" };
        }

        /// <summary>
        /// Restart the computer
        /// </summary>
        /// <returns>List with status</returns>
        private static List<String> RestartComputer()
        {
            Process.Start("timeout 3 > NUL && shutdown -r -t 0");
            return new List<string>() { "Restart Command Executed Successfully" };
        }

        /// <summary>
        /// Get a list of all processes running on the computer
        /// </summary>
        /// <returns>List with status, and then process name and PID, delimited with a |</returns>
        private static List<string> GetProcessList()
        {
            List<string> processes = new List<string>() { "Getproc Command Executed Successfully" };
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
            Sleep,
            Shutdown,
            Restart,
            Getproc
        }
    }
}
