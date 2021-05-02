﻿//using MySql.Data.MySqlClient;
using System;
using MySqlConnector;

namespace WinFormsApp1
{
    class DataBase
    {
        private const string conStr = "server=localhost3306;user=syper_olao;" +
                                      "database=medical;password=123456;"; /*+
                                      "verifyServerCertificate=false;useSSL=" +
                                       "false;serverTimezone=UTC;allowPublicKeyRetrieval=true;" +
                                       "zeroDateTimeBehavior=CONVERT_TO_NULL";*/

        String connString = "Server=" + "localhost" + ";Database=" + "medical"
           + ";port=" + 3306 + ";User Id=" + "syper_olao" + ";password=" + "123456";

        /* public void showInfo()
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
         }*/

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

        public string connSql()
        {
            string data1 = "a";
            using (var connection = new MySqlConnection("Server=localhost;User ID=syper_olao;Password=123456;Database=medical"))
            {
                connection.Open();

                using (var command = new MySqlCommand("select * from doctor;", connection))
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        data1 += reader.GetString(0);
                        Console.WriteLine(reader.GetString(0));
                    }
                
             
            }
            return data1;
        }
    }
}

