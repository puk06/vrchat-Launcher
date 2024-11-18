using System;
using System.Diagnostics;
using System.Windows.Forms;
using vrchat_launcher.Forms;

namespace vrchat_launcher
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                // Check if the program is already running
                var currentProcess = Process.GetCurrentProcess();
                if (Process.GetProcessesByName(currentProcess.ProcessName).Length > 1)
                {
                    Helper.ShowErrorMessage("VRChat Launcher is already running.");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Program could not be launched. The reasons are as follows.\n" + ex, "Error",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
