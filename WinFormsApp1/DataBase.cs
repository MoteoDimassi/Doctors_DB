using MySql.Data.MySqlClient;
using System;

namespace WinFormsApp1
{
    class DataBase
    {
        private const string conStr = "server=127.0.0.1;user=syper_olao;" +
                                      "database=medical;password=123456;"; /*+
                                      "verifyServerCertificate=false;useSSL=" +
                                       "false;serverTimezone=UTC;allowPublicKeyRetrieval=true;" +
                                       "zeroDateTimeBehavior=CONVERT_TO_NULL";*/

        public void showInfo()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;

            conn = new MySql.Data.MySqlClient.MySqlConnection();
            cmd = new MySql.Data.MySqlClient.MySqlCommand();

            conn.ConnectionString = conStr;

            try
            {
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO doctor (first_name, second_name, id_specialization, hire_date)" +
                                  "VALUES (@first_name, @second_name, @id_specialization, @hire_date);";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@first_name", "Pol");
                cmd.Parameters.AddWithValue("@second_name", "Boal");
                cmd.Parameters.AddWithValue("@id_specialization", 4);
                cmd.Parameters.AddWithValue("@hire_date", "1987-04-05");

                for (int i = 1; i <= 1000; i++)
                {
                    cmd.Parameters["@number"].Value = i;
                    cmd.Parameters["@text"].Value = "A string value";

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

       /* public void insertData()
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
                MySqlConnection conn = new MySqlConnection(conStr);
                // устанавливаем соединение с БД
                conn.Open();
                // запрос
                string sql = "SELECT * FROM doctor";
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(sql, conn);
                // выполняем запрос и получаем ответ
                var s = command.ExecuteScalar();
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

    }
}

