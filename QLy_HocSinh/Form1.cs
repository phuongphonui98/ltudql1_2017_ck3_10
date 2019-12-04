using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLy_HocSinh
{
    public partial class Form1 : Form
    {
        HocSinhBUS HSB = new HocSinhBUS();
        public Form1()
        {
            InitializeComponent();
        }
        public class RequiredFieldValidator2 : BaseValidator
        {
            public static bool issEmail(string inputEmail)
            {
                inputEmail = inputEmail ?? string.Empty;
                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(strRegex);
                if (re.IsMatch(inputEmail))
                    return (true);
                else
                    return (false);
            }
            public RequiredFieldValidator2()
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
                    if (issEmail(ControlToValidate.Text) == false)
                    {
                        ErrorMessage = "cần nhập đúng định dạng email";
                        return false;
                    }
                }
                ErrorMessage = null;
                return true;
            }

        }
        public class CheckName : BaseValidator
        {
            public CheckName()
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
                    char kq = ar[0];
                    if ((kq >= 97 && kq <= 122) || (kq >= 65 && kq <= 90))
                    {

                    }
                    else
                    {
                        ErrorMessage = "tên không được bắt đầu bằng ký tự đặt biệt";
                        return false;
                    }
                }
                ErrorMessage = null;
                return true;

            }
        }

        public class CheckDate : BaseValidator
        {
          
            public override bool Validate()
            {
                DateTime now = DateTime.Now;
                DateTime oDate = Convert.ToDateTime(ControlToValidate.Text);
                TimeSpan okk = now.Subtract(oDate);
               
                if (okk.Days / 365 > 15 && okk.Days / 365 < 20)
                {
                    ErrorMessage = null;
                    return true;
                }
                else
                {
                    ErrorMessage = "Tuổi học sinh phải từ 15 đến 20 tuổi ";
                    return false;

                }
             


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool x;
            if (checkboy.Checked == true)
            {
                x = true;

            }
            else
            {
                x = false;
            }

            if (checkName1.ErrorMessage == null && checkName2.ErrorMessage == null&& requiredFieldValidator21.ErrorMessage == null && checkDate1.ErrorMessage == null )
            {
                if(txtname.Text != ""  && txtmail.Text != "" && txtdc.Text != "" )
                {
                    MessageBox.Show("ok");
                    HocSinhDTO hs = new HocSinhDTO(txtname.Text, txtmail.Text, txtdc.Text, x, dateTimePicker1.Value);
                    if (HSB.Insert(hs))
                        MessageBox.Show("successfull");
                }
               
            }
            else
            {
              
                MessageBox.Show("nhập đúng và đầy đủ các dòng trên");
            }
        }
    }
}
