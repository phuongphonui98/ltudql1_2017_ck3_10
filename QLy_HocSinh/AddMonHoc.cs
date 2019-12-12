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
    public partial class AddMonHoc : Form
    {
        HocSinhBUS HSB = new HocSinhBUS();
        public AddMonHoc()
        {
            InitializeComponent();
        }
        public static string VietHoa(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            string result = "";

            //lấy danh sách các từ  

            string[] words = s.Split(' ');

            foreach (string word in words)
            {
                // từ nào là các khoảng trắng thừa thì bỏ  
                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    else
                        result += word.ToUpper() + " ";
                }

            }
            return result.Trim();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string c = txtnamemh.Text.ToLower();
            string d = VietHoa(c);
            if (txtnamemh.Text != "" && checkNameMH1.ErrorMessage == null)
            {

                string ma = "MH" + d;
                CTMonHoc chitiet = new CTMonHoc(ma,d);
                HSB.AddMH(chitiet);
                MessageBox.Show("successfull");
            }
           else
            {
                MessageBox.Show("vui lòng nhập đúng tên môn học");
            }
        }
    }
}
