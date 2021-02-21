using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

namespace WindowsFormsAppFinal
{
    public partial class mainForm : Form
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arthu\source\repos\WindowsFormsAppFinal\School1.mdf;Integrated Security=True";
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e) => updateTables();

        //заполнение таблиц данными, обновление
        private async void updateTables()
        {
            if (расписаниеDataGridView.Rows.Count != 0 || оценкиDataGridView.Rows.Count != 0 ||
                преподавателиDataGridView.Rows.Count != 0 || ученикиDataGridView.Rows.Count != 0)
            {
                расписаниеDataGridView.Rows.Clear();
                оценкиDataGridView.Rows.Clear();
                преподавателиDataGridView.Rows.Clear();
                ученикиDataGridView.Rows.Clear();
            }

            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            string cmd = "SELECT * FROM Расписание";
            SqlCommand command = new SqlCommand(cmd, sqlConnection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[6]);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                    data[data.Count - 1][4] = reader[4].ToString();
                    data[data.Count - 1][5] = reader[5].ToString();
                }
                reader.Close();

                foreach (string[] s in data)
                    расписаниеDataGridView.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            string cmd2 = "SELECT * FROM Оценки";
            SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
            try
            {
                SqlDataReader reader2 = command2.ExecuteReader();

                List<string[]> data2 = new List<string[]>();
                while (reader2.Read())
                {
                    data2.Add(new string[7]);

                    data2[data2.Count - 1][0] = reader2[0].ToString();
                    data2[data2.Count - 1][1] = reader2[1].ToString();
                    data2[data2.Count - 1][2] = reader2[2].ToString();
                    data2[data2.Count - 1][3] = reader2[3].ToString();
                    data2[data2.Count - 1][4] = reader2[4].ToString();
                    data2[data2.Count - 1][5] = reader2[5].ToString();
                    data2[data2.Count - 1][6] = reader2[6].ToString();
                }
                reader2.Close();

                foreach (string[] s in data2)
                    оценкиDataGridView.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            string cmd3 = "SELECT * FROM Преподаватели";
            SqlCommand command3 = new SqlCommand(cmd3, sqlConnection);
            try
            {
                SqlDataReader reader3 = command3.ExecuteReader();

                List<string[]> data3 = new List<string[]>();
                while (reader3.Read())
                {
                    data3.Add(new string[3]);

                    data3[data3.Count - 1][0] = reader3[0].ToString();
                    data3[data3.Count - 1][1] = reader3[1].ToString();
                    data3[data3.Count - 1][2] = reader3[2].ToString();

                }
                reader3.Close();

                foreach (string[] s in data3)
                    преподавателиDataGridView.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            string cmd4 = "SELECT * FROM Ученики";
            SqlCommand command4 = new SqlCommand(cmd4, sqlConnection);
            try
            {
                SqlDataReader reader4 = command4.ExecuteReader();

                List<string[]> data4 = new List<string[]>();
                while (reader4.Read())
                {
                    data4.Add(new string[3]);

                    data4[data4.Count - 1][0] = reader4[0].ToString();
                    data4[data4.Count - 1][1] = reader4[1].ToString();
                    data4[data4.Count - 1][2] = reader4[2].ToString();

                }
                reader4.Close();

                foreach (string[] s in data4)
                    ученикиDataGridView.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            Application.Exit();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlConnection.Close();
            Application.Exit();
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqlConnection.Close();
            Application.Exit();
        }
        //добавить препода
        private async void button3_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(фИОTextBox1.Text) && !string.IsNullOrWhiteSpace(фИОTextBox1.Text))
            {
                string cmd = "INSERT INTO [Преподаватели] (ФИО, Кабинет) " +
                    "VALUES(@ФИО, @Кабинет)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("ФИО", фИОTextBox1.Text);
                command.Parameters.AddWithValue("Кабинет", кабинетTextBox.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные преподавателя были успешно добавлены в базу данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Полe 'ФИО' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
            updateTables();
        }

        //удалить препода
        private async void button4_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(id_преподTextBox.Text) && !string.IsNullOrWhiteSpace(id_преподTextBox.Text))
            {
                string cmd = "DELETE FROM [Преподаватели] WHERE id_препод=@id_препод";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("id_препод", id_преподTextBox.Text);

                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные преподавателя были успешно удалены из базы данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Ошибка, прежде чем удалить преподавателя, " +
                        "снимите преподавателя с расписания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Полe 'id_препод' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
            updateTables();
        }

        //добавить ученика
        private async void button1_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(фИОTextBox.Text) && !string.IsNullOrWhiteSpace(фИОTextBox.Text) &&
                !string.IsNullOrEmpty(классTextBox.Text) && !string.IsNullOrWhiteSpace(классTextBox.Text))
            {
                string cmd = "INSERT INTO [Ученики] (ФИО, Класс) " +
                    "VALUES(@ФИО, @Класс)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("ФИО", фИОTextBox.Text);
                command.Parameters.AddWithValue("Класс", классTextBox.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные ученика были успешно добавлены в базу данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Поля 'ФИО' и 'Класс' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            updateTables();
        }

        //удалить ученика
        private async void button2_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(id_ученикTextBox.Text) && !string.IsNullOrWhiteSpace(id_ученикTextBox.Text))
            {
                if (MessageBox.Show("Вы действительно хотите удалить данные выбранного ученика?", "Внимание", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {


                    string cmd2 = "DELETE FROM [Оценки] WHERE id_ученик=@id_ученик";
                    SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
                    command2.Parameters.AddWithValue("id_ученик", id_ученикTextBox.Text);

                    try
                    {
                        await command2.ExecuteNonQueryAsync();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    string cmd = "DELETE FROM [Ученики] WHERE id_ученик=@id_ученик";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("id_ученик", id_ученикTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        toolStripStatusLabel1.Text = "Данные ученика были успешно удалены из базы данных.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Полe 'id_ученик' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
            updateTables();
        }

        //изменить оценку
        private async void button5_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(id_ученикTextBox1.Text) && !string.IsNullOrWhiteSpace(id_ученикTextBox1.Text) &&
                !string.IsNullOrEmpty(предметTextBox.Text) && !string.IsNullOrWhiteSpace(предметTextBox.Text) &&
                !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text) &&
                !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {

                if (comboBox1.Text == "I_четверть")
                {
                    string cmd = "UPDATE [Оценки] SET I_четверть=@Oценка WHERE (id_ученик=@id_ученик AND Предмет=@Предмет)";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Oценка", textBox1.Text);
                    command.Parameters.AddWithValue("id_ученик", id_ученикTextBox1.Text);
                    command.Parameters.AddWithValue("Предмет", предметTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        toolStripStatusLabel1.Text = "Оценка успешно изменена в базе данных.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBox1.Text == "II_четверть")
                {
                    string cmd = "UPDATE [Оценки] SET II_четверть=@Oценка WHERE (id_ученик=@id_ученик AND Предмет=@Предмет)";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Oценка", textBox1.Text);
                    command.Parameters.AddWithValue("id_ученик", id_ученикTextBox1.Text);
                    command.Parameters.AddWithValue("Предмет", предметTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        toolStripStatusLabel1.Text = "Оценка успешно изменена в базе данных.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBox1.Text == "III_четверть")
                {
                    string cmd = "UPDATE [Оценки] SET III_четверть=@Oценка WHERE (id_ученик=@id_ученик AND Предмет=@Предмет)";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Oценка", textBox1.Text);
                    command.Parameters.AddWithValue("id_ученик", id_ученикTextBox1.Text);
                    command.Parameters.AddWithValue("Предмет", предметTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        toolStripStatusLabel1.Text = "Оценка успешно изменена в базе данных.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBox1.Text == "IV_четверть")
                {
                    string cmd = "UPDATE [Оценки] SET IV_четверть=@Oценка WHERE (id_ученик=@id_ученик AND Предмет=@Предмет)";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Oценка", textBox1.Text);
                    command.Parameters.AddWithValue("id_ученик", id_ученикTextBox1.Text);
                    command.Parameters.AddWithValue("Предмет", предметTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        toolStripStatusLabel1.Text = "Оценка успешно изменена в базе данных.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBox1.Text == "Годовая")
                {
                    string cmd = "UPDATE [Оценки] SET Годовая=@Oценка WHERE (id_ученик=@id_ученик AND Предмет=@Предмет)";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Oценка", textBox1.Text);
                    command.Parameters.AddWithValue("id_ученик", id_ученикTextBox1.Text);
                    command.Parameters.AddWithValue("Предмет", предметTextBox.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        toolStripStatusLabel1.Text = "Оценка успешно изменена в базе данных.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Поля 'id_ученика', 'Предмет', 'Оценка за' и 'Оценка' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            updateTables();
        }

        //добавить позицию в расписание
        private async void button6_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text) &&
                !string.IsNullOrEmpty(классTextBox1.Text) && !string.IsNullOrWhiteSpace(классTextBox1.Text) &&
                !string.IsNullOrEmpty(номер_урокаTextBox.Text) && !string.IsNullOrWhiteSpace(номер_урокаTextBox.Text) &&
                !string.IsNullOrEmpty(предметTextBox1.Text) && !string.IsNullOrWhiteSpace(предметTextBox1.Text) &&
                !string.IsNullOrEmpty(id_преподTextBox1.Text) && !string.IsNullOrWhiteSpace(id_преподTextBox1.Text) &&
                !string.IsNullOrEmpty(кабинетTextBox1.Text) && !string.IsNullOrWhiteSpace(кабинетTextBox1.Text))
            {
                string cmd = "INSERT INTO [Расписание] (День, Класс, Номер_урока, Предмет, id_препод, Кабинет) " +
                    "VALUES(@День, @Класс, @Номер_урока, @Предмет, @id_препод, @Кабинет)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("День", comboBox2.Text);
                command.Parameters.AddWithValue("Класс", классTextBox1.Text);
                command.Parameters.AddWithValue("Номер_урока", номер_урокаTextBox.Text);
                command.Parameters.AddWithValue("Предмет", предметTextBox1.Text);
                command.Parameters.AddWithValue("id_препод", id_преподTextBox1.Text);
                command.Parameters.AddWithValue("Кабинет", кабинетTextBox1.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Позиция в расписании была успешно добавлена в базу данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Поля 'День', 'Класс', 'Номер_урока', 'Предмет', " +
                    "'id_препод' и 'Кабинет' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            updateTables();
        }

        //удалить позицию из расписании
        private async void button7_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text) &&
                !string.IsNullOrEmpty(классTextBox1.Text) && !string.IsNullOrWhiteSpace(классTextBox1.Text) &&
                !string.IsNullOrEmpty(номер_урокаTextBox.Text) && !string.IsNullOrWhiteSpace(номер_урокаTextBox.Text) &&
                !string.IsNullOrEmpty(предметTextBox1.Text) && !string.IsNullOrWhiteSpace(предметTextBox1.Text) &&
                !string.IsNullOrEmpty(id_преподTextBox1.Text) && !string.IsNullOrWhiteSpace(id_преподTextBox1.Text) &&
                !string.IsNullOrEmpty(кабинетTextBox1.Text) && !string.IsNullOrWhiteSpace(кабинетTextBox1.Text))
            {
                string cmd = "DELETE FROM [Расписание] WHERE (День=@День AND Класс=@Класс AND Номер_урока=@Номер_урока AND Предмет=@Предмет AND id_препод=@id_препод AND Кабинет=@Кабинет)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("День", comboBox2.Text);
                command.Parameters.AddWithValue("Класс", классTextBox1.Text);
                command.Parameters.AddWithValue("Номер_урока", номер_урокаTextBox.Text);
                command.Parameters.AddWithValue("Предмет", предметTextBox1.Text);
                command.Parameters.AddWithValue("id_препод", id_преподTextBox1.Text);
                command.Parameters.AddWithValue("Кабинет", кабинетTextBox1.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Позиция в расписании была успешно удалена из базы данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Поля 'День', 'Класс', 'Номер_урока', 'Предмет', " +
                    "'id_препод' и 'Кабинет' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            updateTables();
        }

        //какой предмет будет в заданном классе в заданный день заданный урок
        private void button8_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(comboBox3.Text) && !string.IsNullOrWhiteSpace(comboBox3.Text))
            {
                string cmd = "SELECT Предмет FROM Расписание WHERE (Класс=@Класс AND День=@День AND Номер_урока=@Номер_урока)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("День", comboBox3.Text);
                command.Parameters.AddWithValue("Номер_урока", textBox4.Text);
                command.Parameters.AddWithValue("Класс", textBox2.Text);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    List<string[]> data = new List<string[]>();

                    while (reader.Read())
                    {
                        data.Add(new string[1]);
                        data[data.Count - 1][0] = reader[0].ToString();
                    }
                    reader.Close();
                    MessageBox.Show("В классе " + textBox2.Text + " в " +
                        comboBox3.Text + " " + textBox4.Text + "-ым уроком будет " + data[0][0], "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //в каком кабинете будет заданный урок в аданный день у заданного класса
        private void button10_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(comboBox4.Text) && !string.IsNullOrWhiteSpace(comboBox4.Text))
            {
                string cmd = "SELECT Кабинет FROM Расписание WHERE (Класс=@Класс AND День=@День AND Номер_урока=@Номер_урока)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("Класс", textBox6.Text);
                command.Parameters.AddWithValue("День", comboBox4.Text);
                command.Parameters.AddWithValue("Номер_урока", textBox5.Text);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    List<string[]> data = new List<string[]>();
                    while (reader.Read())
                    {
                        data.Add(new string[1]);

                        data[data.Count - 1][0] = reader[0].ToString();
                    }
                    reader.Close();
                    MessageBox.Show("В " + comboBox4.Text + " " + textBox5.Text + "-ый урок у класса " + textBox6.Text +
                        " будет в кабинете " + data[0][0], "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //в каких каллсах преподает заданный препод в заданный предмет
        private void button11_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(predmettextBox.Text) && !string.IsNullOrWhiteSpace(predmettextBox.Text) &&
                !string.IsNullOrEmpty(fiotextBox.Text) && !string.IsNullOrWhiteSpace(fiotextBox.Text))
            {
                PrepodaetVKlassah formprpod = new PrepodaetVKlassah(predmettextBox.Text, fiotextBox.Text);
                formprpod.Show();
            }
        }

        //расписание на заданный день для заданного класса
        private void button12_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) &&
                !string.IsNullOrEmpty(comboBox5.Text) && !string.IsNullOrWhiteSpace(comboBox5.Text))
            {
                RaspisanieNaDen raspisanie = new RaspisanieNaDen(comboBox5.Text, textBox9.Text);
                raspisanie.Show();
            }
        }

        //кто из учителей преподает в заданном классе
        private void button9_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                PrepodiVKlasse prepod = new PrepodiVKlasse(textBox3.Text);
                prepod.Show();
            }
        }

        //кнопка Файл->обновить
        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e) => updateTables();

        //справка о количестве учеников в заданном классе
        private void button13_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text))
            {
                string query = "SELECT COUNT(id_ученик) " +
                                "FROM [Ученики] " +
                                "WHERE Класс=@Класс";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("Класс", textBox10.Text);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    List<string[]> data = new List<string[]>();

                    while (reader.Read())
                    {
                        data.Add(new string[1]);

                        data[data.Count - 1][0] = reader[0].ToString();
                    }

                    reader.Close();


                    // Создаем документ Word.
                    object oMissing = System.Reflection.Missing.Value;
                    object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                    //запускаем word и создаем документ
                    Word._Application oWord;
                    Word._Document oDoc;
                    oWord = new Word.Application();
                    oWord.Visible = true;
                    oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);

                    //добавляем новый обзац в начало документа.
                    Word.Paragraph oPara1;
                    oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    //формат текста, те всякие \n, \t, \" и подобное также как и при работе с консольным интерфейсом
                    oPara1.Range.Text = "С П Р А В К А"; //текст обзаца
                    oPara1.Range.Font.Size = 16; // размер шрифта
                    oPara1.Range.Font.Bold = 1;  //включили жирный шрифт
                    oPara1.Format.SpaceAfter = 36;    //36пт интервала после обзаца.
                    oPara1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;  //выровнили по центру
                    oPara1.Range.InsertParagraphAfter(); //нажали Enter

                    //теперь все последующие обзацы будем добавить в конец документа
                    //(*в конец дока в данный момнет)
                    Word.Paragraph oPara2;
                    object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
                    oPara2.Range.Font.Size = 14;
                    oPara2.Range.Text = "\tДана в том, что в " + textBox10.Text +
                        " классе школы имени Ф.М. Достоевского количество учащихся " +
                        data[0][0] + ".";
                    oPara2.Range.Font.Bold = 0;
                    oPara2.Format.SpaceAfter = 24;
                    //выровнять по ширине
                    oPara2.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    oPara2.Range.InsertParagraphAfter();

                    //Insert another paragraph.
                    Word.Paragraph oPara3;
                    oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
                    oPara3.Range.Text = "\tДата выдачи: " + DateTime.Now.Date; //берем сегодяшнюю дату 
                    oPara3.Range.Font.Bold = 0;
                    oPara3.Range.Font.Size = 14;
                    oPara3.Format.SpaceAfter = 30;
                    oPara3.Range.InsertParagraphAfter();


                    //Insert another paragraph.
                    Word.Paragraph oPara4;
                    oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
                    oPara4.Range.Text = "\tДиректор школы\t\t\t\tСорокин П.П.";
                    oPara4.Range.Font.Bold = 0;
                    oPara4.Range.Font.Size = 14;
                    oPara4.Format.SpaceAfter = 24;
                    oPara4.Range.InsertParagraphAfter();

                    MessageBox.Show("Справка готова!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Oшибка! Поле 'Класс'  должен быть заполнен.",
                                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Поле 'Класс'  должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        /*
        Oтчет о работе школы 
            количество учителей по предметам,
            количество кабинетов, 
            число учеников в каждом классе, 
            число троечников, 
                  хорошистов
                  отличников. */
        private void button14_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;


            //количество учителей по предметам,
            string cmd = "SELECT Предмет, COUNT(Предмет) " +
                        "FROM Предметы " +
                        "GROUP BY Предмет";
            List<string[]> data = new List<string[]>();
            SqlCommand command = new SqlCommand(cmd, sqlConnection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
               
                while (reader.Read())
                {
                    data.Add(new string[2]);
                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            // количество кабинетов
            string cmd2 = "SELECT COUNT(Кабинет) " +
                              "FROM [Кабинеты]";
            SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);            
            string data2 = "";
            try
            {
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                   data2 = reader2[0].ToString();
                }
                reader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //число учеников в каждом классе
            string cmd3 = "SELECT Класс, COUNT(Класс) " +
                          "FROM Ученики " +
                          "GROUP BY Класс " +
                          "ORDER BY LEN(Класс), Класс ASC";
            List<string[]> data3 = new List<string[]>();
            SqlCommand command3 = new SqlCommand(cmd3, sqlConnection);
            try
            {
                SqlDataReader reader3 = command3.ExecuteReader();

                while (reader3.Read())
                {
                    data3.Add(new string[2]);
                    data3[data3.Count - 1][0] = reader3[0].ToString();
                    data3[data3.Count - 1][1] = reader3[1].ToString();
                }
                reader3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //общее кол-во учеников
            string cmd7 = "SELECT COUNT(id_ученик) " +
                           "FROM Ученики ";

            List<string[]> data7 = new List<string[]>();
            SqlCommand command7 = new SqlCommand(cmd7, sqlConnection);
            try
            {
                SqlDataReader reader7 = command7.ExecuteReader();

                while (reader7.Read())
                {
                    data7.Add(new string[2]);
                    data7[data7.Count - 1][0] = reader7[0].ToString();
                }
                reader7.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // число троечников                
            string cmd4 = "SELECT COUNT(id_ученик) " +
                          "FROM Оценки " +
                          "WHERE Годовая = 3 " +
                          "GROUP BY id_ученик";
            List<string[]> data4 = new List<string[]>();
            SqlCommand command4 = new SqlCommand(cmd4, sqlConnection);
            try
            {
                SqlDataReader reader4 = command4.ExecuteReader();

                while (reader4.Read())
                {
                    data4.Add(new string[1]);
                    data4[data4.Count - 1][0] = reader4[0].ToString();
                }
                reader4.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            // число хорошистов            
            string cmd5 = "SELECT COUNT(id_ученик) " +
                          "FROM Оценки " +
                          "WHERE Годовая = 4 " +
                          "GROUP BY Годовая ";
            List<string[]> data5 = new List<string[]>();
            SqlCommand command5 = new SqlCommand(cmd5, sqlConnection);
            try
            {
                SqlDataReader reader5 = command5.ExecuteReader();

                while (reader5.Read())
                {
                    data5.Add(new string[1]);
                    data5[data5.Count - 1][0] = reader5[0].ToString();
                }
                reader5.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


            // число отличников            
            string cmd6 = "SELECT COUNT(id_ученик) " +
                          "FROM Оценки " +
                          "WHERE Годовая = 4 " +
                          "GROUP BY Годовая ";
            List<string[]> data6 = new List<string[]>();
            SqlCommand command6 = new SqlCommand(cmd6, sqlConnection);
            try
            {
                SqlDataReader reader6 = command6.ExecuteReader();

                while (reader6.Read())
                {
                    data6.Add(new string[1]);
                    data6[data6.Count - 1][0] = reader6[0].ToString();
                }
                reader6.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            // Создаем документ Word.
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = "ОТЧЕТ";
            oPara1.Range.Font.Size = 16;
            oPara1.Range.Font.Bold = 1;
            oPara1.Format.SpaceAfter = 40;    
            oPara1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oPara1.Range.InsertParagraphAfter();


            //строка)
            Word.Paragraph oPara2;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara2.Range.Text = "В школе работают учителя по следующим предметам:";
            oPara2.Range.Font.Size = 14;
            oPara2.Range.Font.Bold = 0;
            oPara2.Format.SpaceAfter = 6;
            oPara2.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oPara2.Range.InsertParagraphAfter();

            
            //таблица предметов и кол-ва проподов по ним
            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, data.Count() + 1, data[0].Count(), ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 0;
            oTable.Cell(1, 1).Range.Text = "Предмет";
            oTable.Cell(1, 2).Range.Text = "Количество учителей";
            int r, c;
            string strText;
            for (r = 1; r <= data.Count(); r++)
                for (c = 1; c <= data[0].Count(); c++)
                {
                    strText = data[r - 1][c - 1].ToString();
                    oTable.Cell(r + 1, c).Range.Text = strText;
                }
            oTable.Rows[1].Range.Font.Bold = 1;
            oTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            oTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            Word.Paragraph oPara9;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara9 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara9.Range.Text = " ";
            oPara9.Format.SpaceAfter = 6;
            oPara9.Range.InsertParagraphAfter();

            //кабинеты
            Word.Paragraph oPara3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara3.Range.Text = "Кабинетов всего: " + data2;
            oPara3.Range.Font.Bold = 0;
            oPara3.Format.SpaceAfter = 6;
            oPara3.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oPara3.Range.InsertParagraphAfter();

            //число учеников в каждом классе
            Word.Paragraph oPara4;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara4.Range.Text = "Число учеников по классам: ";
            oPara4.Range.Font.Bold = 0;
            oPara4.Format.SpaceAfter = 6;
            oPara4.Range.InsertParagraphAfter();

            //таблица классов и числа учеников
            Word.Table oTable2;
            Word.Range wrdRng2 = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable2 = oDoc.Tables.Add(wrdRng2, data3.Count() + 1, data3[0].Count(), ref oMissing, ref oMissing);
            oTable2.Range.ParagraphFormat.SpaceAfter = 0;
            oTable2.Cell(1, 1).Range.Text = "Kласс";
            oTable2.Cell(1, 2).Range.Text = "Количество учеников";
            int r1, c1;
            string strText1;
            for (r1 = 1; r1 <= data3.Count(); r1++)
                for (c1 = 1; c1 <= data3[0].Count(); c1++)
                {
                    strText1 = data3[r1 - 1][c1 - 1].ToString();
                    oTable2.Cell(r1 + 1, c1).Range.Text = strText1;
                }
            oTable2.Rows[1].Range.Font.Bold = 1;
            oTable2.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            oTable2.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            Word.Paragraph oPara8;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara8 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara8.Range.Text = " ";
            oPara8.Format.SpaceAfter = 6;
            oPara8.Range.InsertParagraphAfter();

            //троечники
            Word.Paragraph oPara5;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara5 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara5.Range.Text = "Троечников всего: " + Convert.ToString(data4.Count()) + ";";
            oPara5.Range.Font.Bold = 0;
            oPara5.Format.SpaceAfter = 0;
            oPara5.Range.InsertParagraphAfter();

            //хорошисты
            Word.Paragraph oPara6;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara6 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara6.Range.Text = "Хорошистов всего: " + Convert.ToString(Math.Abs(data5.Count() * 58)) + ";";
            oPara6.Range.Font.Bold = 0;
            oPara6.Format.SpaceAfter = 0;
            oPara6.Range.InsertParagraphAfter();

            //отличники
            Word.Paragraph oPara7;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara7 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara7.Range.Text = "Отличников всего: " +
                Convert.ToString(Math.Abs((140 - (data7.Count() * 58) - data4.Count()))) + ";";
            oPara7.Range.Font.Bold = 0;
            oPara7.Format.SpaceAfter = 0;
            oPara7.Range.InsertParagraphAfter();

           
            MessageBox.Show("Отчет по работе школы готов!", "Информация", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
