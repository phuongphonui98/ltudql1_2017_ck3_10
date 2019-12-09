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
    
    public partial class Addhstoclass : Form
    {
        HocSinhBUS HSB = new HocSinhBUS();
        public Addhstoclass()
        {
            InitializeComponent();
        }

       

        private void Addhstoclass_Load(object sender, EventArgs e)
        {
            HSB.Load();
            List<string> kl = new List<string>();
            foreach (var s in ClassDTO.khoilop)
            {
                kl.Add(s.TenK1);
            }
            
            KLcombo.DataSource = kl.ToList();

            foreach (var s in HocSinhDTO.lisths)
            {
                string gt = "";
                if (s.Gioitinh == true)
                {
                    gt = "Nam";
                }
                else
                    gt = "Nữ";
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewCell cell = new DataGridViewTextBoxCell();
                cell.Value = s.Name;
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = gt;
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = s.Ngsinh;
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = s.Diachi;
                row.Cells.Add(cell);
                cell = new DataGridViewTextBoxCell();
                cell.Value = s.Email;
                row.Cells.Add(cell);

                DShsgridview.Rows.Add(row);

            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KLcombo.SelectedItem != null)
            {
                List<string> l = new List<string>();
                foreach (var s in clasDTO.lop)
                {
                    string tk = KLcombo.SelectedItem.ToString();
                    char[] ar = s.TenL1.ToCharArray();
                    string test = ar[0].ToString() + ar[1].ToString();
                    if(tk == test)
                    {
                        l.Add(s.TenL1);
                    }
                    
                }
                
                Classcombo.DataSource = l.ToList();
                
                if (l.Count() == 0)
                {
                    Classcombo.Text = null;
                }

            }
            
        }
    }
}
