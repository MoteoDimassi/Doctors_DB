﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
           
            database.ShowInfoDoctor(dataGridView1);
            database.ShowInfoPacient(dataGridView2);
        }
    }
}
