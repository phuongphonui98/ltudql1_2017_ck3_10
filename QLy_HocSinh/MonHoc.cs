using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLy_HocSinh
{
    public partial class MonHoc : Form
    {
        HocSinhBUS HSB = new HocSinhBUS();
        public MonHoc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void MonHoc_Load(object sender, EventArgs e)
        {
           bool i = HSB.Checkhk();
            if (i == true)
            {
                panel1.Visible = true;
                label1.Visible = false;
                button1.Visible = false;
            }

        }

        private void a_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          
        }
    }
}
