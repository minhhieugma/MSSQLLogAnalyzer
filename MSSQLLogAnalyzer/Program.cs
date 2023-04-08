using MSSQLLogAnalyzer;
using System.Text;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(FThreadException);
            Application.Run(new Form1());
        }

        public static void FThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex;
            StringBuilder sb;

            ex = e.Exception;
            sb = new StringBuilder();
            sb.AppendLine("Exception Type: " + ex.GetType().Name).AppendLine();
            sb.AppendLine("Message: " + ex.Message).AppendLine();
            sb.AppendLine("Stack Trace: " + ex.StackTrace).AppendLine();

            MessageBox.Show(sb.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}