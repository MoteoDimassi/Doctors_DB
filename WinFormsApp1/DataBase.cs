//using MySql.Data.MySqlClient;
using System;
using MySqlConnector;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class DataBase
    {
        string _connString; 

        public DataBase(string host, int port, string database, string username, string password)
        {
            _connString = "Server=" + host + ";Database=" + database
           + ";port=" + port + ";User Id=" + username + ";password=" + password;
        }



        /*       public void insertData()
               {

                   using (MySqlConnection con = new MySqlConnection(conStr))
                   {
                       try
                       {
                           string sql = "INSERT INTO doctor (first_name, second_name, id_specialization, hire_date)" +
                                        "VALUES (@first_name, @second_name, @id_specialization, @hire_date);";
                           con.Open();
                           MySqlCommand cmd = new MySqlCommand(sql, con);
                           //создаем параметры и добавляем их в коллекцию
                           cmd.Parameters.AddWithValue("@first_name", "Pol");
                           cmd.Parameters.AddWithValue("@second_name", "Boal");
                           cmd.Parameters.AddWithValue("@id_specialization", 4);
                           cmd.Parameters.AddWithValue("@hire_date", "1987-04-05");
                           cmd.ExecuteNonQuery();
                           con.Close();
                       }
                       catch (Exception ex)
                       {
                           Console.WriteLine("Exception: " + ex);
                       }
                   }
               }

             
               }*/

        public void InsertData(string str, string key)
        {
            string sql = String.Empty; 
            using (MySqlConnection con = new MySqlConnection(_connString))
            {
                var strSplit = str.Split(";") ; 
                try
                {
                    
                    switch (key)
                    {
                        case "Pacient":
                            sql = "INSERT INTO medical.patient (id, fist_name, second_name, gender, birthday, address)" +
                            "VALUES (" + strSplit[0] + ", '" + strSplit[1] + "', '" + strSplit[2] + "' , '" + strSplit[3] + "', '" + strSplit[4] + "','" + strSplit[5] + "')";
                            break;
                        case "Recipe":
                            sql = "INSERT INTO medical.recipe(visit_id, medicine_id, mode_of_application) VALUES(" + strSplit[0] + ", " + strSplit[1] + ", '" + strSplit[2] + "')";
                            break;
                        case "Doctor":
                            sql = "INSERT INTO medical.doctor(first_name, second_name, id_specialization, hire_date, id_doctor) VALUES('"+strSplit[0]+ "', '" + strSplit[1] + "', " + strSplit[2] + ", '" + strSplit[3] + "', " + strSplit[4] + ")";
                            break;
                    }
                    
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные добавлены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

     

   
        //4;Nasya;Vlasova;f;1994-01-17;Lomonosova

        public void ShowInfoDoctor(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();        
            using (var connection = new MySqlConnection(_connString))
            {
                connection.Open();
                using (var command = new MySqlCommand("select * from doctor;", connection))
                using (var reader = command.ExecuteReader())

                    while (reader.Read())                
                        dataGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetInt32(2).ToString(), reader.GetDateTime(3), reader.GetInt32(4).ToString());                                                                         
            }     
        }

        public void ShowInfoPacient(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            using (var connection = new MySqlConnection(_connString))
            {
                connection.Open();

                using (var command = new MySqlCommand("select * from patient;", connection))
                using (var reader = command.ExecuteReader())

                    while (reader.Read())
                        dataGridView.Rows.Add(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5));
            }
        }
    }
}

