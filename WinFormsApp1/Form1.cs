using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DataBase database = new DataBase("localhost", 3306, "medical", "syper_olao", "123456");
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
    }
}
