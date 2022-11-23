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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            button1.Text = "1";
            button2.Text = "2";
            button3.Text = "3";
            button4.Text = "4";
            button5.Text = "5";
            button6.Text = "6";
            
        }
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\TCP\repairs.accdb";
        OleDbConnection dbConnect = new OleDbConnection();
        void view1()
        {

            string mySelect = "Select [Repair].Client_id,[Client].Client_name,[Repair].Repair_id,[Repair].Car_id,Car.Car_make,Car.Reg_number,[Repair].In_date FROM( [Repair] INNER JOIN" +
                " Client " +
                "ON [Client].Client_id = [Repair].Client_id" +
                ") INNER JOIN" +
                " Car" +
                " ON Car.Car_id = [Repair].Car_id" +
                " WHERE In_date >= (Now - 1)" +
                " ORDER BY Car_make, Reg_number ASC";
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, dbConnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbConnect.Close();

        }
        void view2()
        {

            string mySelect = "SELECT Car.Car_id, Car.Car_make, Car.Repair_price FROM Car" +
                " WHERE Repair_price = ( SELECT MAX(Repair_price) FROM Car)" +
                " union all" +
                " SELECT Car.Car_id, Car.Car_make, Car.Repair_price FROM Car" +
                " WHERE Repair_price = ( SELECT MIN(Repair_price) FROM Car)" +
                " ORDER BY Car_make";
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, dbConnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbConnect.Close();

        }
        void view3()
        {

            string mySelect = "SELECT Car.Car_id, [Repair].Repair_id, [Repair].Paid, Car.Reg_number, Car.Car_make FROM [Repair]" +
                " INNER JOIN Car ON Car.Car_id = [Repair].Car_id" +
                " WHERE Paid = FALSE";
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, dbConnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbConnect.Close();

        }
        void view4()
        {

            string mySelect = "SELECT Car.Car_id, [Repair].Repair_id, [Repair].Paid, Car.Reg_number, Car.Car_make FROM [Repair]" +
                " INNER JOIN Car ON Car.Car_id = [Repair].Car_id" +
                " WHERE Paid = TRUE";
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, dbConnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbConnect.Close();

        }
        void view5()
        {

            string mySelect = "SELECT TOP 3 [Repair].Car_id, COUNT([Repair].Car_id) AS MOST_FREQUENT FROM [Repair]" +
                " GROUP BY [Repair].Car_id" +
                " ORDER BY COUNT([Repair].Car_id) DESC";
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, dbConnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbConnect.Close();

        }
        void view6()
        {

            string mySelect = "SELECT TOP 1 Client.Client_id, SUM(Car.Repair_price) AS Repair_Sum" +
                " FROM([Repair] INNER JOIN [Client] ON [Client].Client_id = [Repair].Client_id )" +
                " INNER JOIN Car ON Car.Car_id = [Repair].Car_id" +
                " GROUP BY [Client].Client_id" +
                " ORDER BY SUM(Car.Repair_price) DESC";
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, dbConnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbConnect.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            view1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            view2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            view3();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            view4();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            view5();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            view6();
        }
    }
}
