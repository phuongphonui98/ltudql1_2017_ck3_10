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
    public partial class PhanQuyenf : Form
    {
        HocSinhBUS HSB = new HocSinhBUS();
        public PhanQuyenf()
        {
            InitializeComponent();
        }

        private void PhanQuyenf_Load(object sender, EventArgs e)
        {
            HSB.listAC();

        }
    }
}
