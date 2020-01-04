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
    public partial class AddClass : Form
    {
        HocSinhBUS HSB = new HocSinhBUS();
        public AddClass()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtmk.Text != "" && txttk.Text != "" && checkMaK1.ErrorMessage == null && checkTenK1.ErrorMessage == null)
            {
                ClassDTO kl = new ClassDTO(txtmk.Text, txttk.Text);
                HSB.InsertKL(kl);
                HSB.Loadkl();
                MessageBox.Show("successfull");
            }
            else
            {
                MessageBox.Show("vui lòng nhập đúng và đủ ");
            }
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

        public class CheckTenK : BaseValidator
        {
            public CheckTenK()
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
                  
                    if (x=="10" || x=="11" || x== "12")
                    {
                        if(ClassDTO.TonTai == true)
                        {
                            foreach (var n in ClassDTO.khoilop)
                            {
                                if (x == n.TenK1)
                                {
                                    ErrorMessage = "tên khối đã tồn tại";
                                    return false;


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
                ErrorMessage = null;
                return true;

            }
        }
        public class CheckMaK : BaseValidator
        {
            public CheckMaK()
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
                    
                  if (ClassDTO.TonTai == true)
                    {
                        foreach (var n in ClassDTO.khoilop)
                        {
                            if (x == n.MaK1)
                            {
                                ErrorMessage = "Mã khối đã tồn tại";
                                return false;

                            }
                        }
                    }
                       
                    
                   
                }
                ErrorMessage = null;
                return true;

            }
        }
        public class CheckTenL : BaseValidator
        {
            public CheckTenL()
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

                    
                    if (ar.Length > 4 || ar.Length < 4 )
                    {
                        ErrorMessage = "cần nhập đúng tên lớp vd : 10A1";
                        return false;

                    }
                    else
                    {
                        string so = ar[0].ToString() + ar[1].ToString();
                        string chu = ar[2].ToString();
                       
                        int so2 = int.Parse(ar[3].ToString());
                       
                        if (chu=="A")
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
                                                    ErrorMessage = "tên lớp đã tồn tại";
                                                    return false;


                                                }

                                            }
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
                                                        ErrorMessage = "tên lớp đã tồn tại";
                                                        return false;


                                                    }

                                                }
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
                                                            ErrorMessage = "tên lớp đã tồn tại";
                                                            return false;


                                                        }

                                                    }
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
                ErrorMessage = null;
                return true;

            }
        }
        public class CheckMaL : BaseValidator
        {
            public CheckMaL()
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

                    if (clasDTO.TonTail == true)
                    {
                        foreach (var n in clasDTO.lop)
                        {
                            if (x == n.MaL1)
                            {
                                ErrorMessage = "Mã lớp đã tồn tại";
                                return false;

                            }
                        }
                    }



                }
                ErrorMessage = null;
                return true;

            }
        }
        public class CheckSS : BaseValidator
        {
            public CheckSS()
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
                    int siso = int.Parse(x);
                    if( siso > clasDTO.SS || siso<1)
                    {
                        ErrorMessage = "sỉ số nhỏ nhất là 1 và lớn nhất là "+clasDTO.SS;
                        return false;
                    }
                   



                }
                ErrorMessage = null;
                return true;

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string mk = mkcombo.SelectedItem.ToString();
            MessageBox.Show(mk);
            char[] ar = mk.ToCharArray();
            string test = ar[1].ToString() + ar[2].ToString();
            if(txtml.Text!= "" && txtlop.Text != "" && txtss.Text != "" && checkMaL1.ErrorMessage == null && checkTenL1.ErrorMessage == null)
            {
                char[] ar2 = txtlop.Text.ToCharArray();
                string test2 = ar2[0].ToString() + ar2[1].ToString();
                
                if(test != test2)
                {
                    MessageBox.Show("vui lòng nhập tên lớp phù hợp với  khối");
                }
                else
                {
                    clasDTO lopp = new clasDTO(txtml.Text,txtlop.Text,int.Parse(txtss.Text),mk);
                    HSB.InsertL(lopp);
                    HSB.Loadkl();
                    MessageBox.Show("successfull");
                   
                }
            }
            else
            {
                MessageBox.Show("vui lòng nhập đầy đủ ");
            }
        }

        private void AddClass_Load(object sender, EventArgs e)
        {
            HSB.getSS();
            List<string> tl = new List<string>();
            foreach(var i in ClassDTO.khoilop)
            {
                tl.Add(i.MaK1);
            }
            mkcombo.DataSource = tl.ToList();
            
        }
    }
}
