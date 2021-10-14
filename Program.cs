using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marvin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            FormMarvin formMarvin = null;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formMarvin = new FormMarvin();
            if ((args.Length == 1) && (args[0].ToUpper().Equals("NOALERT")))
                formMarvin.setShowAlertMsg();
            Application.Run(formMarvin);
        }
    }
}
