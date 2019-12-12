using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class MonHoc : Form
    {
        HocSinhBUS HSB = new HocSinhBUS();
        public MonHoc()
        {
            InitializeComponent();
        }
       
        public class CheckNH : BaseValidator
        {
            public bool IsNumber(string pText)
            {
                Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                return regex.IsMatch(pText);
            }
            public CheckNH()
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
                    if(IsNumber(ControlToValidate.Text)==false)
                    {
                        ErrorMessage = "năm học phải là số ";
                        return false;
                    }
                    else
                    {
                        int x = int.Parse(ControlToValidate.Text);
                        if(x<DateTime.Now.Year || x >2030)
                        {
                            ErrorMessage = "năm học phải trong khoảng từ "+DateTime.Now.Year+" đến 2030 vd:2019";
                            return false;
                        }
                        else
                        {
                            
                        }
                    }
                }
                ErrorMessage = null;
                return true;

            }
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
