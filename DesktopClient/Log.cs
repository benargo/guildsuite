using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace DesktopClient
{
    public static class Log
    {
        #region Properties
        private static bool DebugMode = Properties.Settings.Default.debugMode;

        /// <summary>
        /// Gets or sets the TextBox object where the Log messages are to be displayed.
        /// </summary>
        public static TextBox LogTextBox { get; set; }

        /// <summary>
        /// Gets or sets the display message for the Log TextBox in the Addon form.
        /// This property is set to blanks "" every time Display() is called.
        /// </summary>
        public static string Message { get; set; }
        #endregion

        #region Public methods
        public static void Debug(string message)
        {
            Message = $"[Debug][{DateTime.Now:G}]: {message}";

            if (DebugMode)
            {
                UpdateLogTextBox();
            }
        }

        public static void Event(string message)
        {
            Message += $"[Event][{DateTime.Now:G}]: {message}";

            UpdateLogTextBox();
        }

        public static void Info(string message)
        {
            Message += $"[Info][{DateTime.Now:G}]: {message}";

            UpdateLogTextBox();
        }

        public static void Warn(string message)
        {
            Message += $"[Warning][{DateTime.Now:G}]: {message}";

            if (DebugMode)
            {
                UpdateLogTextBox();
            }
        }

        public static void Warn(Exception e)
        {
            Message += $"[Warning][{DateTime.Now:G}]: Non-fatal exception thrown by {e.Source}.\r\n";
            Message += $"Message: {e.Message}\r\n";
            Message += $"Target site: {e.TargetSite}\r\n";
            Message += $"Stack trace: {e.StackTrace}\r\n";

            if (e.Data.Count > 0)
            {
                Message += "Data : " + "\r\n";

                foreach (DictionaryEntry data in e.Data)
                {
                    Message += $"{data.Key.ToString()}: {data.Value.ToString()}\r\n";
                }
            }

            if (DebugMode)
            {
                UpdateLogTextBox();
            }
        }

        /// <summary>
        /// Catches information about an exception and displays info about it in the Log window in the Addon form.
        /// </summary>
        /// <param name="e">The exception thrown that is to be displayed</param>
        public static void Error(Exception e)
        {
            Message += $"[Error][{DateTime.Now:G}]: Fatal exception thrown by {e.Source}.\r\n";
            Message += $"Message: {e.Message}\r\n";
            Message += $"Target site: {e.TargetSite}\r\n";
            Message += $"Stack trace: {e.StackTrace}\r\n";

            if (e.Data.Count > 0)
            {
                Message += "Data : " + "\r\n";

                foreach (DictionaryEntry data in e.Data)
                {
                    Message += data.Key.ToString() + " : " + data.Value.ToString() + "\r\n";
                }

            }

            UpdateLogTextBox();
        }

        /// <summary>
        /// Prompts Message to be displayed in the Log window in the Addon form.
        /// Message is cleared after it has been displayed.
        /// </summary>
        public static void UpdateLogTextBox()
        {
            if (LogTextBox.InvokeRequired)
            {
                LogTextBox.Invoke(new Action(AddLogEntry));
                return;
            }

            AddLogEntry();
        }

        private static void AddLogEntry()
        {
            LogTextBox.Text += $"{Message}\r\n\r\n";
            Message = "";
        }

        /// <summary>
        /// Clears the current content in the Log window in the Addon form.
        /// </summary>
        public static void ClearLogWindow()
        {
            LogTextBox.Clear();
        }

        #endregion
    }
}
