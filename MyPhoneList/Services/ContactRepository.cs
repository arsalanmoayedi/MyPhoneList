using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyPhoneList
{
    class ContactRepository : IContactRepository
    {
        private string ConnectionString = "Data Source=.;Initial catalog=Contact_DB;Integrated security=true";
        public bool Add(string name, string family, int age, string phonenumber, string email, string addres)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                string query = "insert into MyPhoneList (Name,Family,Phone,Age,Email,Address) Values (@Name,@Family,@Phone,@Age,@Email,@Address)";
                
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@family", family);
                sqlCommand.Parameters.AddWithValue("@age", age);
                sqlCommand.Parameters.AddWithValue("@phone", phonenumber);
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@address", addres);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public bool Delete(int contactID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                string query = "delete from MyPhoneList where ContactID=@ID";
                SqlCommand command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("@ID", contactID);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
                
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
            
        }

        public DataTable search(string parameter)
        {
            string query = "select * from MyPhoneList where name like @parameter or family like @parameter";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%"+ parameter+ "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;

        }

        public DataTable SellectAll()
        {
            string query = "select * from MyPhoneList";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;


        }


        public DataTable SellectRow(int contactID)
        {
            string query = "select * from MyPhoneList where contactID="+contactID;
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(int contactID, string name, string family, int age, string phonenumber, string email, string addres)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                string query = "update MyPhoneList set Name=@name,Family=@family,Phone=@phone,Age=@age,Email=@email,Address=@address where ContactID=@contactID" ;
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@contactID", contactID);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@family", family);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@phone", phonenumber);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@address", addres);
                
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
