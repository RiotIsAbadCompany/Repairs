using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rep
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            label1.Text = "Repair";
            label2.Text = "Client_id";
            label3.Text = "Car_id";
            label4.Text = "In_date";
            label5.Text = "Return_date";
            label6.Text = "Paid";
            label7.Text = "Returned";
            label8.Text = "Repair_id";

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
            string mySelect = "select * from Repair";
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
            Repair repair = new Repair();
            repair.Client_id = textBox1.Text;
            repair.Car_id = textBox2.Text;
            repair.In_date = textBox3.Text;
            repair.Return_date = textBox4.Text;
            repair.Paid = textBox5.Text;
            repair.Returned = textBox6.Text;

            connect.insertRepair(repair);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Repair repair = new Repair();
            repair.Client_id = textBox1.Text;
            repair.Car_id = textBox2.Text;
            repair.In_date = textBox3.Text;
            repair.Return_date = textBox4.Text;
            repair.Paid = textBox5.Text;
            repair.Returned = textBox6.Text;
            repair.Repair_id = textBox7.Text;

            connect.updateRepair(repair);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Repair repair = new Repair();
            repair.Repair_id = textBox6.Text;
            connect.deleteRepair(repair);

        }
        void view()
        {

            string mySelect = "Select * from Repair Where Repair_id =" + textBox7.Text;
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
