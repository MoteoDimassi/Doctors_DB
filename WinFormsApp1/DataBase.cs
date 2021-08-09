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
                        case "Medications":
                            sql = "INSERT INTO medical.medications(id, name, mode_of_application, healing, side_effect) VALUES(" + strSplit[0] + ", '" + strSplit[1] + "', '" + strSplit[2] + "', '" + strSplit[3] + "', '" + strSplit[4] + "')";
                            break;
                        case "Visit":
                            DateTime theDate = DateTime.Now;
                           // theDate.ToString("yyyy-MM-dd H:mm:ss");
                            sql = "INSERT INTO medical.visit (visit_id, id_doctor, date, place, symptoms, diagnosis, recommendations, id_patient) VALUES (" + strSplit[0] + ", " + strSplit[1] + ", '" + theDate.ToString("yyyy-MM-dd H:mm:ss") + "', '" + strSplit[2] + "', '" + strSplit[3] + "', '" + strSplit[4] + "', '" + strSplit[5] + "', " + strSplit[6] + ")";
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

        // 2;Perezetamol;arainst tempetature;effective;possible food disorders
        //4;Nasya;Vlasova;f;1994-01-17;Lomonosova
        // 2;3;В болинце;галлюцинации;шизофрения; пить воду;4;
        public void ShowInfoDoctor(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();        
            using (var connection = new MySqlConnection(_connString))
            {
                connection.Open();
                using (var command = new MySqlCommand("select * from doctor;", connection))
                using (var reader = command.ExecuteReader())

                    while (reader.Read())                
                        dataGridView.Rows.Add(reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetInt32(3).ToString(), reader.GetDateTime(4));                                                                         
            }     
        }

        public void ShowInfoVisit(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            using (var connection = new MySqlConnection(_connString))
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM visit;", connection))
                using (var reader = command.ExecuteReader())

                    while (reader.Read())
                        dataGridView.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetInt32(7));
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
                        dataGridView.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5));
            }
        }
    
        public void ShowInfoMedicals(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            using (var connection = new MySqlConnection(_connString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM medications; ", connection))
                using (var reader = command.ExecuteReader())

                    while (reader.Read())
                        dataGridView.Rows.Add(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetValue(3), reader.GetValue(4));
            }
        }
    }
}

