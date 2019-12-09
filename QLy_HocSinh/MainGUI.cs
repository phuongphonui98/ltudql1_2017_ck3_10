using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
    public partial class MainGUI : Form
    {
        
        HocSinhBUS HSB = new HocSinhBUS();
        public MainGUI()
        {
            
            InitializeComponent();
            menu.Width = 70;
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hmd, int wmsg, int wparam, int lparam);
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            
            f.ShowDialog();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void MainGUI_Load(object sender, EventArgs e)
        {
           
            HSB.Loadkl();
            List<string> l = new List<string>();
           foreach(var s in clasDTO.lop)
            {

                l.Add(s.TenL1);
            }
            dslopcbox.DataSource = l.ToList();
          
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if(menu.Width == 250 )
            {
                menu.Width = 70;

            }
            else
            {
                menu.Width = 250;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
           if( this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        private void showinpanel(object fom)
        {
            if (this.mainpn.Controls.Count > 0)
                this.mainpn.Controls.RemoveAt(0);
            Form f = fom as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpn.Controls.Add(f);
            this.mainpn.Tag = f;
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showinpanel(new Form1());
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void mainpn_Paint(object sender, PaintEventArgs e)
        {
          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showinpanel(new AddClass());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showinpanel(new Addhstoclass());
        }
    }
}
