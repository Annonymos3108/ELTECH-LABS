﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppFinal
{
    public partial class PrepodaetVKlassah : Form
    {
        public PrepodaetVKlassah(string predmet, string fio)
        {
            InitializeComponent();
            Form_Load(predmet, fio);
        }

        private async void Form_Load(string predmet, string fio)
        {
            FIOLabel.Text = fio;
            predmetLabel.Text = predmet;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arthu\source\repos\WindowsFormsAppFinal\School1.mdf;Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(connectionString);
            await myConnection.OpenAsync();
            string cmd = string.Format("SELECT Расписание.Класс, Преподаватели.ФИО " +
                        "FROM Расписание INNER JOIN Преподаватели " +
                        "ON Расписание.id_препод = Преподаватели.id_препод " +
                        "WHERE((Преподаватели.ФИО) = N'{0}' AND Расписание.Предмет = N'{1}')",
                        fio, predmet);
            SqlCommand command = new SqlCommand(cmd, myConnection);

            try
            {
                SqlDataReader reader = await command.ExecuteReaderAsync();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[1]);
                    data[data.Count - 1][0] = reader[0].ToString();                    
                }
                reader.Close();

                myConnection.Close();

                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}