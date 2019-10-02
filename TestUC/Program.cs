using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using usercontrol;

namespace TestUC
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestForm1());
            //Application.Run(new HSUCLib.TestUSUCForm());

        }
    }
}
