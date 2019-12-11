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
        HocSinhBUS HSB = new HocSinhBUS();
        public DSclass()
        {
            InitializeComponent();
        }

        private void DSclass_Load(object sender, EventArgs e)
        {
            HSB.Load();
            List<string> kl = new List<string>();
            foreach (var s in ClassDTO.khoilop)
            {
                kl.Add(s.TenK1);
            }

            kLcombo.DataSource = kl.ToList();
        }

        private void kLcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kLcombo.SelectedItem != null)
            {
                List<string> l = new List<string>();
                foreach (var s in clasDTO.lop)
                {
                    string tk = kLcombo.SelectedItem.ToString();
                    char[] ar = s.TenL1.ToCharArray();
                    string test = ar[0].ToString() + ar[1].ToString();
                    if (tk == test)
                    {
                        l.Add(s.TenL1);
                    }

                }

                classcombo.DataSource = l.ToList();

                if (l.Count() == 0)
                {
                   classcombo.Text = null;
                }
                if(KL.Checked == true)
                {
                    dshsgrid.Rows.Clear();
                    HSB.Loadhsk(kLcombo.SelectedItem.ToString());
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
                        cell.Value = s.Clas;
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
                        cell = new DataGridViewTextBoxCell();
                        cell.Value = s.HK11;
                        row.Cells.Add(cell);
                        cell = new DataGridViewTextBoxCell();
                        cell.Value = s.HK21;
                        row.Cells.Add(cell);

                        dshsgrid.Rows.Add(row);

                    }
                }
                else
                {
                    dshsgrid.Rows.Clear();
                   
                }

            }
            

        }

        private void KL_CheckedChanged(object sender, EventArgs e)
        {
           if(KL.Checked==true)
            {
                dshsgrid.Rows.Clear();
                HSB.Loadhsk(kLcombo.SelectedItem.ToString());
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
                    cell.Value = s.Clas;
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
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = s.HK11;
                    row.Cells.Add(cell);
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = s.HK21;
                    row.Cells.Add(cell);

                    dshsgrid.Rows.Add(row);

                }
            }
        }

        private void classcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (classcombo.SelectedItem != null)
            {
                if (Lop.Checked == true)
            {
                dshsgrid.Rows.Clear();
                HSB.Loadhsl(classcombo.SelectedItem.ToString());
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
                    cell.Value = s.Clas;
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
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = s.HK11;
                    row.Cells.Add(cell);
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = s.HK21;
                    row.Cells.Add(cell);

                    dshsgrid.Rows.Add(row);

                }
            }
            }
        }

        private void Lop_CheckedChanged(object sender, EventArgs e)
        {
            if(Lop.Checked== true)
            {
                dshsgrid.Rows.Clear();
                HSB.Loadhsl(classcombo.SelectedItem.ToString());
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
                    cell.Value = s.Clas;
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
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = s.HK11;
                    row.Cells.Add(cell);
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = s.HK21;
                    row.Cells.Add(cell);

                    dshsgrid.Rows.Add(row);

                }
            }
        }

        private void dshsgrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dshsgrid.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dshsgrid.SelectedRows[0];
                txtht.Text = row.Cells[0].Value.ToString();
                txtclass.Text = row.Cells[1].Value.ToString();
                txtdate.Text = row.Cells[3].Value.ToString();
                txtaddr.Text = row.Cells[4].Value.ToString();
                txtmail.Text = row.Cells[5].Value.ToString();
                txthk1.Text = row.Cells[6].Value.ToString();
                txthk2.Text = row.Cells[7].Value.ToString();

                if (row.Cells[2].Value.ToString() == "Nam")
                {
                    namradio.Checked = true;
                }
                else
                {
                    nuradio.Checked = true;
                }
                HSB.GetMaHS(row.Cells[5].Value.ToString());
                txtma.Text = HocSinhDTO.id.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime oDate = Convert.ToDateTime(txtdate.Text);
            bool kt;
            if (namradio.Checked == true)
            {
                kt = true;
            }
            else { kt = false; }
            HocSinhDTO k = new HocSinhDTO(txtht.Text, txtmail.Text, txtaddr.Text,kt,oDate,txtclass.Text);
            int x = int.Parse(txtma.Text);
            HSB.UpdateHS(k, x);
            MessageBox.Show("successfull");
         

           
        }
    }
}
