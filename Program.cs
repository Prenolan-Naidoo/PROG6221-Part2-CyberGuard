using System;
using System.Windows.Forms;
using CyberGuardChatbot.Forms;

namespace CyberGuardChatbot
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Launch the GUI version (Part 2)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            // Note: The console version from Part 1 still exists,
            // but now the GUI launches by default!
        }
    }
}