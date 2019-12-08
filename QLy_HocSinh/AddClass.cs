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
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
                    
    }
}
