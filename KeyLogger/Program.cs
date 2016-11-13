using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KeyLogger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD

=======
>>>>>>> de3253b... Refactoring source code
            Application.Run(new MainForm());
        }
    }
}
