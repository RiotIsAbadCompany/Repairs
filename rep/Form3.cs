using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace rep
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Client_name";
            label2.Text = "Personal_id";
            label3.Text = "City";
            label4.Text = "Adress";
            label5.Text = "Phone_number";
            label6.Text = "Client_id";
            label7.Text = "Client";
            
            button1.Text = "Insert";
            button2.Text = "Update";
            button3.Text = "Delete";
            button4.Text = "Report";
            button5.Text = "Refresh";
            DisplayData();
        }
        Connection connect = new Connection();
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\TCP\repairs.accdb";
        OleDbConnection dbConnect = new OleDbConnection();
        private void DisplayData()
        {
            string mySelect = "select * from Client";
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, dbConnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbConnect.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Client_name = textBox1.Text;
            client.Personal_id = textBox2.Text;
            client.City = textBox3.Text;
            client.Adress = textBox4.Text;
            client.Phone_number = textBox5.Text;

            connect.insertClient(client);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Client_name = textBox1.Text;
            client.Personal_id = textBox2.Text;
            client.City = textBox3.Text;
            client.Adress = textBox4.Text;
            client.Phone_number = textBox5.Text;
            client.Client_id = textBox6.Text;


            connect.updateClient(client);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Client_id = textBox6.Text;
            connect.deleteClient(client);
        }
        void view()
        {

            string mySelect = "Select * from Client Where Client_id =" + textBox6.Text;
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, dbConnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbConnect.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            view();
        }
    }
}
