using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using BUS;
using DTO;
using System.Text.RegularExpressions;


namespace QLy_HocSinh
{
    public partial class QDf : Form
    {
        HocSinhBUS HSB = new HocSinhBUS();
        public QDf()
        {
            InitializeComponent();
        }
        public class CheckNumber : BaseValidator
        {
            public bool IsNumber(string pText)
            {
                Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                return regex.IsMatch(pText);
            }
            public CheckNumber()
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
                    if (IsNumber(ControlToValidate.Text) == false)
                    {
                        ErrorMessage = " phải là số ";
                        return false;
                    }
                   
                }
                ErrorMessage = null;
                return true;

            }
        }


        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "Nhập tuổi tối thiểu";
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
                textBox2.Text = "Nhập tuổi tối đa";
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            if (textBox3.Text == "")
                textBox3.Text = "Nhập sỉ số tối đa mới";
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {

            if (textBox4.Text == "")
                textBox4.Text = "Nhập điểm đạt mới";
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbltoithieu_Click(object sender, EventArgs e)
        {

        }

        private void QDf_Load(object sender, EventArgs e)
        {
            HSB.getSS();
            HSB.Load();
            HSB.TLSL();
            lbltoithieu.Text = HocSinhDTO.toithieu.ToString();
            lbltoida.Text = HocSinhDTO.toida.ToString();
            lblsstoida.Text = clasDTO.SS.ToString();
            lbldiemdat.Text = CTMonHoc.DiemDat.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string toida = textBox2.Text;
            string toithieu = textBox1.Text;
            int td = int.Parse(toida);
            int tt = int.Parse(toithieu);
            string ss = textBox3.Text;
            string d = textBox4.Text;
            int sstd = int.Parse(ss);
            float diem = float.Parse(d);
          

            if(checkNumber1.ErrorMessage == null && checkNumber2.ErrorMessage == null && checkNumber3.ErrorMessage == null && checkNumber4.ErrorMessage == null)
            {
                if(tt < td)
                {
                    if(sstd >0)
                    {
                       if(diem >=0)
                        {
                            HSB.ChangeQD(tt, td, sstd, diem);
                            MessageBox.Show("cập nhật thành công");
                            QDf_Load(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("điểm phải là số dương");
                        }

                    }
                    else
                    {
                        MessageBox.Show("sĩ số phải lớn hơn 0");
                    }
                }
                else
                {
                    MessageBox.Show("tối thiểu phải nhỏ hơn tối đa");
                }
            }
        }
    }
}
