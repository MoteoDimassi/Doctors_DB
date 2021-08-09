using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DataBase database = new DataBase("localhost", 3306, "medical", "root", "345218");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            database.ShowInfoDoctor(dataGridView1);
            database.ShowInfoPacient(dataGridView2);
            database.ShowInfoMedicals(dataGridView3);
            database.ShowInfoVisit(dataGridView4);
        }

        private void PacientBtn_Click(object sender, EventArgs e)
        {
            database.InsertData(textBox1.Text, "Pacient");
            database.ShowInfoPacient(dataGridView2); 
        }

 
        // Добавить доктора
        private void button1_Click(object sender, EventArgs e)
        {
            database.InsertData(textBox1.Text, "Doctor");
            database.ShowInfoDoctor(dataGridView1);
        }

        // Добавить лекартсво 
        private void button2_Click(object sender, EventArgs e)
        {
            database.InsertData(textBox1.Text, "Medications");
            database.ShowInfoMedicals(dataGridView3);
        }
        // добавить прием 
        private void button3_Click(object sender, EventArgs e)
        {
            database.InsertData(textBox1.Text, "Visit");
            database.ShowInfoVisit(dataGridView4);
        }

        private void buttonToExel_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application app = new Excel.Application();
                app.Visible = true;
                Excel.Workbook book = app.Workbooks.Add();

                Excel.Worksheet sheet1 = app.Worksheets.Add();
                sheet1.Name = "Таблица врачей";
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                       
                        if (dataGridView1.Rows[i].Cells[j].Value!=null)
                            sheet1.Cells[i+1, j+1] = dataGridView1.Rows[i].Cells[j].Value.ToString();

                    }

                Excel.Worksheet sheet2 = app.Worksheets.Add();
                sheet2.Name = "Таблица пациентов";
                for (int i = 0; i < dataGridView2.RowCount; i++)
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {

                        if (dataGridView2.Rows[i].Cells[j].Value != null)
                            sheet2.Cells[i + 1, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();

                    }

                Excel.Worksheet sheet3 = app.Worksheets.Add();
                sheet3.Name = "Таблица лекарств";
                for (int i = 0; i < dataGridView3.RowCount; i++)
                    for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    {

                        if (dataGridView3.Rows[i].Cells[j].Value != null)
                            sheet3.Cells[i + 1, j + 1] = dataGridView3.Rows[i].Cells[j].Value.ToString();

                    }

                Excel.Worksheet sheet4 = app.Worksheets.Add();
                sheet4.Name = "Таблица приёмов";
                for (int i = 0; i < dataGridView4.RowCount; i++)
                    for (int j = 0; j < dataGridView4.ColumnCount; j++)
                    {

                        if (dataGridView4.Rows[i].Cells[j].Value != null)
                            sheet4.Cells[i + 1, j + 1] = dataGridView4.Rows[i].Cells[j].Value.ToString();

                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

    }
}
