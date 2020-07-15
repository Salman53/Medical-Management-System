using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pro
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            string Username = "Salman";
            string Password = "123";
            if (Username == textBox1.Text && Password == textBox2.Text)
            {
                MessageBox.Show("Login Successfully");
                this.Hide();
                Main s = new Main();
                s.Show();
            }
            else

                MessageBox.Show("Incorrect!!");
           
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
