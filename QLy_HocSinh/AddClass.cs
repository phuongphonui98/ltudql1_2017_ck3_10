﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLy_HocSinh
{
    public partial class AddClass : Form
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnaddK.Visible = true;
            paneladdclass.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnaddK.Visible = false;
            paneladdclass.Visible = true;
        }
    }
}
