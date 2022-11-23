using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace rep
{
    internal class Connection
    {
        OleDbConnection connect;
        OleDbCommand command;
        private void connectionTo()
        {
            //connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\TCP PROJECT\repairs.accdb");
            connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\TCP\repairs.accdb");
            command = connect.CreateCommand();
        }
        public Connection()
        {
            connectionTo();
            //('1', '1', '1', 1, 1, 1, '1')";;

        }
        public void insert(Car car)
        {
            try
            {
                command.CommandText = "Insert into Car([Reg_number], [Car_make], [Car_color], Car_year, Car_seats, Repair_price, [Car_model]) Values('" +
                    car.Reg_number + "','" + car.Car_make + "','" + car.Car_color + "'," + car.Car_year + "," + car.Car_seats + "," + car.Repair_price + ",'" +car.Car_model  + 
                  "')";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect data.");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }
        public void insertClient(Client client)
        {
            try
            {
                command.CommandText = "Insert into Client([Client_name], [Personal_id], [City], [Adress], [Phone_number]) Values('" +
                    client.Client_name + "','" + client.Personal_id + "','" + client.City + "','" + client.Adress + "','" + client.Phone_number  +
                  "')";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect data.");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }
        public void insertRepair(Repair repair)
        {
            try
            {
                command.CommandText = "Insert into Repair(Client_id, Car_id, [In_date], [Return_date], [Paid], [Returned]) Values(" +
                    repair.Client_id + "," + repair.Car_id + ",'" + repair.In_date + "','" + repair.Return_date + "','" + repair.Paid + "','" + repair.Returned +
                  "')";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect data.");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }
        public void updateCar(Car car)
        {
            try
            {
                command.CommandText = "UPDATE Car SET Reg_number = '" + car.Reg_number+ "', Car_make = '" + car.Car_color + "', Car_year = '" + car.Car_year +
                  "', Car_seats = '" + car.Car_seats+ "', Repair_price = '" + car.Repair_price + "', Car_model = '" + car.Car_model +  "' Where Car_id=" + car.Car_id;
                // command.CommandText =  "UPDATE Car SET Reg_number = '" + car.Reg_number + "' WHERE Car_id = " + car.Car_id;
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect data.");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }

        }
        public void updateClient(Client client)
        {
            try
            {
                command.CommandText = "UPDATE Client SET Client_name = '" + client.Client_name + "', Personal_id = '" + client.Personal_id + "', [City] = '" + client.City +
                  "', Adress = '" + client.Adress + "', Phone_number = '" + client.Phone_number + "' Where Client_id=" + client.Client_id;
                // command.CommandText =  "UPDATE Car SET Reg_number = '" + car.Reg_number + "' WHERE Car_id = " + car.Car_id;
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect data.");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }

        }
        public void updateRepair(Repair repair)
        {
            try
            {
                command.CommandText = "UPDATE Repair SET Client_id = '" + repair.Client_id + "', Car_id = '" + repair.Car_id + "', In_date = '" + repair.In_date +
                  "', Return_date = '" + repair.Return_date + "', Paid = '" + repair.Paid + "', Returned = '" + repair.Returned + "' Where Repair_id=" + repair.Repair_id;
                // command.CommandText =  "UPDATE Car SET Reg_number = '" + car.Reg_number + "' WHERE Car_id = " + car.Car_id;
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect data.");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }

        }
        public void deleteCar(Car car)
        {

            try
            {
                command.CommandText = "Delete  From Car WHERE  Car_id=" + car.Car_id;
                // command.CommandText =  "UPDATE Car SET Reg_number = '" + car.Reg_number + "' WHERE Car_id = " + car.Car_id;
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect data.");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }

        }
        public void deleteClient(Client client)
        {

            try
            {
                command.CommandText = "Delete  From Client WHERE  Client_id=" + client.Client_id;
                // command.CommandText =  "UPDATE Car SET Reg_number = '" + car.Reg_number + "' WHERE Car_id = " + car.Car_id;
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect data.");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }

        }
        public void deleteRepair(Repair repair)
        {

            try
            {
                command.CommandText = "Delete  From Repair WHERE  Repair_id=" + repair.Repair_id;
                // command.CommandText =  "UPDATE Car SET Reg_number = '" + car.Reg_number + "' WHERE Car_id = " + car.Car_id;
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Incorrect data.");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }

        }
    }
}
