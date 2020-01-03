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
using System.Globalization;
namespace QLy_HocSinh
{
    public partial class TongKetMon : Form
    {
        HocSinhBUS HSB = new HocSinhBUS();
        public TongKetMon()
        {
            InitializeComponent();
        }

        private void TongKetMon_Load(object sender, EventArgs e)
        {
            HSB.Loadkl();
            HSB.loadnohk();
            HSB.loadBCM();
            List<string> NH = new List<string>();
            foreach (var s in HocKi.HK)
            {
                int k = 1;
                string x = s.MaHK1.ToString();
                char[] ar = x.ToCharArray();
                string nam = ar[1].ToString() + ar[2].ToString() + ar[3].ToString() + ar[4].ToString();
                for (int o = 0; o < NH.Count(); o++)
                {
                    if (nam == NH[o])
                    {
                        k = 0;
                    }
                }
                if (k == 1)
                    NH.Add(nam);


            }

            namhoccombo.DataSource = NH.ToList();

        }

        private void namhoccombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> hocki = new List<string>();
            if (namhoccombo.SelectedItem != null)
            {

                foreach (var kq in HocKi.HK)
                {
                    string x = kq.MaHK1.ToString();
                    char[] ar = x.ToCharArray();
                    string nam = ar[1].ToString() + ar[2].ToString() + ar[3].ToString() + ar[4].ToString();
                    if (nam == namhoccombo.SelectedItem.ToString())
                    {
                        if (ar[0].ToString() == "1")
                        {
                            hocki.Add("HK1");
                        }
                        else
                            hocki.Add("HK2");
                    }

                }
                HKcombo.DataSource = hocki.ToList();

            }
        }
    }
}
