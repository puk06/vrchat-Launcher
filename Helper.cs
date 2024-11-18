using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace vrchat_launcher
{
    internal class Helper
    {
        public static void SetControlText(Control control, string text, string defaultText = "")
        {
            control.Text = text ?? defaultText;
        }

        public static void InitializeCefSharp()
        {
            var settings = new CefSettings
            {
                RootCachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };
            Cef.Initialize(settings);
        }

        public static void ValidateRequiredFiles()
        {
            if (!File.Exists("./src/Fonts/Quicksand-Light.ttf") || !File.Exists("./src/Fonts/NotoSansJP-Light.ttf"))
            {
                ShowErrorMessage("The font file was not found. Download this software again.");
                Environment.Exit(1);
            }

            if (!File.Exists("./src/data.json"))
            {
                ShowErrorMessage("The data file was not found. Download this software again.");
                Environment.Exit(1);
            }
        }

        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void AddValueToArray<T>(ref IEnumerable<T> array, T value)
        {
            array = array.Append(value).ToArray();
        }

        public static bool IsEnglish(string text)
        {
            return text.All(c => c < 128);
        }
    }
}
