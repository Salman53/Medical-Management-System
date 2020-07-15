using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace pro
{
    public partial class Main : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TGV01ML;Initial Catalog=Medical_Store;Integrated Security=True");
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            textBox5.Text = "";       
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Focus();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-TGV01ML;Initial Catalog=Medical_Store;Integrated Security=True");

                con.Open();
                SqlCommand cmd1 = new SqlCommand(@"Insert into Products(Barcode,Product_Name,Product_Company,Product_Location,Price)
values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text +"')", con);

                cmd1.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Data Successfully Inserted");
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void display()
         {
             SqlConnection con = new SqlConnection("Data Source=DESKTOP-TGV01ML;Initial Catalog=Medical_Store;Integrated Security=True");
             con.Open();
             string query = "select *from Products"; 
             SqlDataAdapter sda= new SqlDataAdapter(query,con);
             DataTable dt= new DataTable();
             sda.Fill(dt);
             dataGridView1.DataSource = dt;
             
             con.Close();
         }
    
        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-TGV01ML;Initial Catalog=Medical_Store;Integrated Security=True");

                con.Open();
                SqlCommand cmd1 = new SqlCommand(@"Update Products set Product_Name='" + textBox2.Text + "',Product_Company='" + textBox3.Text + "',Product_Location='" + textBox4.Text + "',Price='" + textBox5.Text + "'where(Barcode='"+ textBox1.Text +"')", con);

                cmd1.ExecuteNonQuery();

                MessageBox.Show("Data Successfully Updated");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        

        private void View_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-TGV01ML;Initial Catalog=Medical_Store;Integrated Security=True");

            con.Open();
            string query = "select * from Products";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                
            }
            
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-TGV01ML;Initial Catalog=Medical_Store;Integrated Security=True");

                con.Open();
                
                SqlCommand cmd1 = new SqlCommand(@"Delete from Products 
               where (Barcode = '" + textBox1.Text + "')", con);
                cmd1.ExecuteNonQuery();
                
                con.Close();
                MessageBox.Show("Data Successfully Deleted");
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-TGV01ML;Initial Catalog=Medical_Store;Integrated Security=True");
                con.Open();
                string query = "select * from Products where Product_Name= '" + textBox7.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                foreach (DataRow item in dt.Rows)
                {
                    textBox1.Text = item["Barcode"].ToString();
                        textBox2.Text=item["Product_Name"].ToString();
                        textBox3.Text = item["Product_Company"].ToString();
                        textBox4.Text = item["Product_Location"].ToString();
                        textBox5.Text = item["Price"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }
    }
     
   
        


