using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HSUCLib
{
    public partial class TestUSUCForm : Form
    {
        public TestUSUCForm()
        {
            InitializeComponent();
        }

        private void TestUSUCForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            hsucax1.WindowClosing(sender, e);
        }
    }
}
