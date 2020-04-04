using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace DesktopClient
{
    public static class Log
    {
        #region vars and properties
        // vars
        private static TextBox logTextBox;
        private static string currentLogMessage;

        // properties

        /// <summary>
        /// Gets or sets the TextBox object where the Log messages are to be displayed.
        /// </summary>
        public static TextBox LogTextBox
        {
            get
            {
                return logTextBox;
            }
            set
            {
                logTextBox = value;
            }
        }
            
        /// <summary>
        /// Gets or sets the display message for the Log TextBox in the Addon form.
        /// This property is set to blanks "" every time Display() is called.
        /// </summary>
        public static string CurrentLogMessage
        {
            get
            {
                return currentLogMessage;
            }
            set
            {
                currentLogMessage = value;
                // any Property Notification function here
            }
        }

        #endregion

        #region Public functions
        /// <summary>
        /// Prompts CurrentLogMessage to be displayed in the Log window in the Addon form.
        /// CurrnetLogMessage is cleared after it has been displayed.
        /// </summary>
        public static void Display()
        {
            LogTextBox.Text += "\n" + CurrentLogMessage;
            CurrentLogMessage = "";
        }

        /// <summary>
        /// Clears the current content in the Log window in the Addon form.
        /// </summary>
        public static void ClearLogWindow()
        {
            LogTextBox.Clear();
        }

        /// <summary>
        /// Catches information about an exception and displays info about it in the Log window in the Addon form.
        /// </summary>
        /// <param name="e">The exception thrown that is to be displayed</param>
        public static void DisplayException(Exception e)
        {
            CurrentLogMessage += "Exception thrown by " + e.Source + " at " + e.StackTrace + ".\n";
            CurrentLogMessage += "Exception message : " + e.Message + "\n.";
            CurrentLogMessage += "Data : " + "\n";

            foreach (KeyValuePair<string,string> data in e.Data)
            {
                CurrentLogMessage += data.Key + " : " + data.Value + "\n";
            }

            Display();
        }

        #endregion
    }
}
