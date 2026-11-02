using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Econtact.econtactclasses
{

    internal class contactclass
    {
        connection db = new connection();
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public DataTable select()
        {
            MySqlConnection con = db.GetConnection();
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from Contact";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                con.Open();
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { }

            return dt;
        }
        public bool insert(contactclass s)
        {
            bool isSuccess = false;
            MySqlConnection con = db.GetConnection();
            try
            {
                string sql = "insert into Contact(FirstName,LastName,ContactNo,Address,Gender) " +
                    "Values(@FirstName,@LastName,@ContactNo,@Address,@Gender)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FirstName", s.FirstName);
                cmd.Parameters.AddWithValue("@LastName", s.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", s.ContactNo);
                cmd.Parameters.AddWithValue("@Address", s.Address);
                cmd.Parameters.AddWithValue("@Gender", s.Gender);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();

            }
            return isSuccess;

        }
        public bool Update(contactclass s)
        {
            bool isSuccess = false;
            MySqlConnection con = db.GetConnection();
            try
            {
                string sql = "update Contact set " +
                    "FirstName=@FirstName," +
                    "LastName=@LastName," +
                    "ContactNo=@ContactNo," +
                    "Address=@Address," +
                    "Gender=@Gender where ContactID=@ContactID";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@FirstName", s.FirstName);
                cmd.Parameters.AddWithValue("@LastName", s.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", s.ContactNo);
                cmd.Parameters.AddWithValue("@Address", s.Address);
                cmd.Parameters.AddWithValue("@Gender", s.Gender);
                cmd.Parameters.AddWithValue("@ContactID", s.ContactID);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();

            }
            return isSuccess;

        }

        public bool Delete(contactclass s)
        {
            bool isSuccess = false;
            MySqlConnection con = db.GetConnection();
            try
            {
                string sql = "Delete from Contact where ContactID=@ContactID";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ContactID", s.ContactID);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();

            }
            return isSuccess;

        }


        public DataTable Search(string keyword)
        {
            DataTable dt = new DataTable();

            MySqlConnection con = db.GetConnection();

            try
            {
                string sql = @"SELECT * FROM Contact
                       WHERE FirstName LIKE @keyword
                       OR LastName LIKE @keyword
                       OR ContactNo LIKE @keyword
                       OR Address LIKE @keyword
                       OR Gender LIKE @keyword";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

    }
}
