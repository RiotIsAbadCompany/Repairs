using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace rep
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Car";
            label2.Text = "Reg_number";
            label3.Text = "Car_make";
            label4.Text = "Car_color";
            label5.Text = "Car_year ";
            label6.Text = "Car_seats";
            label7.Text = "Repair_price";
            label8.Text = "Car_model";
            label9.Text = "Car_id";
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
            string mySelect = "select * from Car";
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
            Car car = new Car();
            car.Reg_number = textBox1.Text;
            car.Car_make = textBox2.Text;
            car.Car_color = textBox3.Text;
            car.Car_year = textBox4.Text;
            car.Car_seats = textBox5.Text;
            car.Repair_price = textBox6.Text;
            car.Car_model = textBox7.Text;
            connect.insert(car);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.Reg_number = textBox1.Text;
            car.Car_make = textBox2.Text;
            car.Car_color = textBox3.Text;
            car.Car_year = textBox4.Text;
            car.Car_seats = textBox5.Text;
            car.Repair_price = textBox6.Text;
            car.Car_model = textBox7.Text;
            car.Car_id = textBox8.Text;
            connect.updateCar(car);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Car car = new Car();
            car.Car_id = textBox8.Text;
            connect.deleteCar(car);
        }
        void view()
        {
            
            string mySelect = "Select * from Car Where Car_id =" + textBox8.Text;
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
