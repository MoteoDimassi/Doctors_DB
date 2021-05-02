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

               public string showData()
               {
                   // строка подключения к БД
                   // создаём объект для подключения к БД
                   string name = "bm,..,/";
                   try
                   {
                       MySqlConnection conn = new MySqlConnection(connString);
                       // устанавливаем соединение с БД
                       conn.Open();
                       // запрос
                       string sql = "SELECT * FROM doctor";
                       // объект для выполнения SQL-запроса
                       MySqlCommand command = new MySqlCommand(sql, conn);
                       // выполняем запрос и получаем ответ
                       var s = command.ExecuteScalar();
                       name = s.ToString(); 
                       // выводим ответ в консоль
                       Console.WriteLine("dsfdsffds");
                       Console.WriteLine(s);

                       // закрываем соединение с БД
                       conn.Close();

                   }
                   catch (Exception ex)
                   {
                       name = "yyyy";
                       Console.WriteLine("Exception: " + ex);
                   }
                   return name;
               }*/

        public void ShowInfoDoctor(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();        
            using (var connection = new MySqlConnection(_connString))
            {
                connection.Open();
                using (var command = new MySqlCommand("select * from doctor;", connection))
                using (var reader = command.ExecuteReader())

                    while (reader.Read())                
                        dataGridView.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetInt32(2).ToString(), reader.GetDateTime(3));                                                                         
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

