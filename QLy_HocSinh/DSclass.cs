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
            if(dshsgrid.SelectedRows.Count <0)
            {
                button1.Visible = false;
            }
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

        public class CheckTenL2 : BaseValidator
        {
            public CheckTenL2()
            {

            }
            public override bool Validate()
            {

                if (ControlToValidate.Text.Length <= 0)
                {
                    ErrorMessage = "không được để trống";
                    return false;

                }

                else
                {
                    string x = ControlToValidate.Text;
                    char[] ar = x.ToCharArray();


                    if (ar.Length > 4 || ar.Length < 4)
                    {
                        ErrorMessage = "cần nhập đúng tên lớp vd : 10A1";
                        return false;

                    }
                    else
                    {
                        string so = ar[0].ToString() + ar[1].ToString();
                        string chu = ar[2].ToString();

                        int so2 = int.Parse(ar[3].ToString());

                        if (chu == "A")
                        {
                            if (so == "10" || so == "11" || so == "12")
                            {
                                if (so == "10")
                                {

                                    if (so2 < 1 || so2 > 4)
                                    {
                                        ErrorMessage = "khối 10 chỉ có (10A1 - > 10A4)";
                                        return false;
                                    }
                                    else
                                    {
                                        if (ClassDTO.TonTai == true)
                                        {
                                            foreach (var n in clasDTO.lop)
                                            {
                                                if (x == n.TenL1)
                                                {
                                                    
                                                    return true;


                                                }

                                            }
                                            ErrorMessage = "tên lớp không tồn tại";
                                            return false;

                                        }
                                    }

                                }
                                else
                                {
                                    if (so == "11")
                                    {
                                        if (so2 < 1 || so2 > 3)
                                        {
                                            ErrorMessage = "khối 11 chỉ có (11A1 - > 11A3)";
                                            return false;
                                        }
                                        else
                                        {
                                            if (ClassDTO.TonTai == true)
                                            {
                                                foreach (var n in clasDTO.lop)
                                                {
                                                    if (x == n.TenL1)
                                                    {
                                                        
                                                        return true;


                                                    }

                                                }
                                                ErrorMessage = "tên lớp không tồn tại";
                                                return false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (so == "12")
                                        {
                                            if (so2 < 1 || so2 > 2)
                                            {
                                                ErrorMessage = "khối 12 chỉ có (12A1 - > 12A2)";
                                                return false;
                                            }
                                            else
                                            {
                                                if (ClassDTO.TonTai == true)
                                                {
                                                    foreach (var n in clasDTO.lop)
                                                    {
                                                        if (x == n.TenL1)
                                                        {
                                                            
                                                            return true;


                                                        }

                                                    }
                                                    ErrorMessage = "tên lớp không tồn tại";
                                                    return false;
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                ErrorMessage = "Chỉ được thêm 3 khối lớp (10, 11 ,12)";
                                return false;
                            }

                        }
                        else
                        {
                            ErrorMessage = "cần nhập đúng tên lớp vd : 10A1";
                            return false;
                        }


                    }

                }
                ErrorMessage = "tên lớp phải tồn tại";
                return false;

            }
        }
        private void dshsgrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dshsgrid.SelectedRows.Count > 0)
            {
                button1.Visible = true;
                button2.Visible = true;
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
            if(KL.Checked ==true)
            {
                kLcombo_SelectedIndexChanged(sender, e);
            }
            else
                if(Lop.Checked==true)
            {
                classcombo_SelectedIndexChanged(sender, e);
            }
         

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtma.Text);
            DialogResult result = MessageBox.Show("Đồng Ý Sẽ Không Khôi Phục Được", "Xóa Học Sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.Abort:
                    break;
                case DialogResult.Yes:
                    {
                        HSB.DeleteHS(x);
                        MessageBox.Show("Seccessfull");
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
