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
    public partial class DSclass : Form
    {
        public DSclass()
        {
            InitializeComponent();
        }

        private void DSclass_Load(object sender, EventArgs e)
        {
            List<string> l = new List<string>();
            foreach (var s in clasDTO.lop)
            {

                l.Add(s.TenL1);
            }
            classcombo.DataSource = l.ToList();
        }
    }
}
