﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usercontrol
{
    public partial class TestForm1 : Form
    {
        UserControl1 myuc = null;
        public TestForm1()
        {
            InitializeComponent();
        }

        private void TestForm1_Load(object sender, EventArgs e)
        {
            myuc = new UserControl1();
            myuc.Width = 640;
            myuc.Height = 480;
            this.Controls.Add(myuc);
            
        }

        private void TestForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myuc != null)
            {
                myuc.WindowClosing(sender, e);
            }
        }
    }
}
