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

namespace Conference
{
    public partial class mainForm : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public mainForm()
        {
            InitializeComponent();
        }

        //при загрузке программы
        private void mainForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Visible = false;
            UpdateAll();

            textBox5.Text = "Компания Google приглашает " +
                "Вас принять участие в международной научно-технической конференции " +
                "«Искусственных интеллект и актуальные проблемы в плане SKYNET по захвату мира». " +
                "\n\tСроки проведения конференции - 20 - 24 января 2021 года. " +
                "\n\tПросим подтвердить участие в конференции и выслать тему доклада " +
                "до 1 матра 2021 года. \n\tЗаявки принимаются по электронной почте. " +
                "\n\tАдрес: fan-fan-2021@gmail.com";

        }

        //кнопка Файл->Обновить
        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e) => UpdateAll();

        //при закрытии программы (всеми способами), сначало закрыть связь с БД, потом выйти из программы
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
            Application.Exit();
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqlConnection.Close();
            Application.Exit();
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlConnection.Close();
            Application.Exit();
        }

        //загрузка и обновление данных в таблицах программы
        private async void UpdateAll()
        {
            //если есть хотя бы один запись в любом из таблиц то очистка
            if (dataGridView1.Rows.Count != 0 || dataGridView3.Rows.Count != 0 ||
                dataGridView3.Rows.Count != 0 || dataGridView4.Rows.Count != 0 ||
                dataGridView5.Rows.Count != 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();
                dataGridView5.Rows.Clear();
            }

            //установка связи с БД и заполнение таблиц
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

            //заполнение таблицы конференции
            string cmd = "SELECT * FROM Конференции";
            SqlCommand command = new SqlCommand(cmd, sqlConnection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[6]);
                    for (int i = 0; i < 6; i++)
                        data[data.Count - 1][i] = reader[i].ToString();
                }
                reader.Close();

                foreach (string[] s in data)
                    dataGridView2.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //заполнение таблицы Авторы
            string cmd2 = "SELECT Авторы.id_автор, Авторы.Фамилия, Авторы.Имя, Авторы.Отчество, Авторы.Адрес, " +
                "Авторы.Почтовой_индекс, Авторы.Рабочий_телефон, Авторы.Домашний_телефон, Авторы.e_mail, " +
                "Авторы.Ученая_степень, Авторы.Ученое_звание, Авторы.Научное_направлвние, Авторы.Кафедра, " +
                "Авторы.Место_работы, Авторы.Должность, Локация.Страна, Локация.Город " +
                "FROM Авторы INNER JOIN Локация ON Авторы.id_локация = Локация.id_локация";
            SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
            try
            {
                SqlDataReader reader2 = command2.ExecuteReader();

                List<string[]> data2 = new List<string[]>();
                while (reader2.Read())
                {
                    data2.Add(new string[17]);
                    for (int i = 0; i < 17; i++)
                        data2[data2.Count - 1][i] = reader2[i].ToString();                    
                }
                reader2.Close();

                foreach (string[] s in data2)
                    dataGridView1.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //заполнение таблицы участники
            string cmd3 = "SELECT * FROM Участники";
            SqlCommand command3 = new SqlCommand(cmd3, sqlConnection);
            try
            {
                SqlDataReader reader3 = command3.ExecuteReader();

                List<string[]> data3 = new List<string[]>();
                while (reader3.Read())
                {
                    data3.Add(new string[13]);
                    for (int i = 0; i < 13; i++)
                        data3[data3.Count - 1][i] = reader3[i].ToString();

                }
                reader3.Close();

                foreach (string[] s in data3)
                    dataGridView3.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //Заполнение таблицы Доклады
            string cmd4 = "SELECT * FROM Доклады";
            SqlCommand command4 = new SqlCommand(cmd4, sqlConnection);
            try
            {
                SqlDataReader reader4 = command4.ExecuteReader();

                List<string[]> data4 = new List<string[]>();
                while (reader4.Read())
                {
                    data4.Add(new string[5]);
                    for (int i = 0; i < 5; i++)
                        data4[data4.Count - 1][i] = reader4[i].ToString();
                }
                reader4.Close();

                foreach (string[] s in data4)
                    dataGridView4.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //заполнение таблицы Гостиницы  
            string cmd5 = "SELECT Гостиницы.id_гостиница, Гостиницы.Название, Гостиницы.Адрес, " +
                "Локация.Страна, Локация.Город, Гостиницы.Стоимость_номера " +
                "FROM Гостиницы INNER JOIN Локация ON Гостиницы.id_локация = Локация.id_локация";
            SqlCommand command5 = new SqlCommand(cmd5, sqlConnection);
            try
            {
                SqlDataReader reader5 = command5.ExecuteReader();

                List<string[]> data5 = new List<string[]>();
                while (reader5.Read())
                {
                    data5.Add(new string[6]);
                    for (int i = 0; i < 6; i++)
                        data5[data5.Count - 1][i] = reader5[i].ToString();
                }
                reader5.Close();

                foreach (string[] s in data5)
                    dataGridView5.Rows.Add(s);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
           
        //добавить конференцию
        private async void button4_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(названиеTextBox.Text) && !string.IsNullOrWhiteSpace(названиеTextBox.Text) &&
               !string.IsNullOrEmpty(организаторTextBox.Text) && !string.IsNullOrWhiteSpace(организаторTextBox.Text) &&
               !string.IsNullOrEmpty(статусTextBox.Text) && !string.IsNullOrWhiteSpace(статусTextBox.Text) &&
               !string.IsNullOrEmpty(оргвзносTextBox.Text) && !string.IsNullOrWhiteSpace(оргвзносTextBox.Text))
            {
                string cmd = "INSERT INTO Конференции(Название, Организатор, Статус, Дата_начало, Оргвзнос) " +
                    "VALUES(@Название, @Организатор, @Статус, @Дата_начало, @Оргвзнос)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("Название", названиеTextBox.Text);
                command.Parameters.AddWithValue("Организатор", организаторTextBox.Text);
                command.Parameters.AddWithValue("Статус", статусTextBox.Text);
                command.Parameters.AddWithValue("Оргвзнос", оргвзносTextBox.Text);
                command.Parameters.AddWithValue("Дата_начало", дата_началоDateTimePicker.Value);

                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные конференции успешно добавлени в базу данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПоля 'Название', 'Организатор', 'Статус', 'Дата_начало' и" +
                    " 'Оргвзнос' должны быть заполнены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabel1.Text = "Поля 'Название', 'Организатор', 'Статус', 'Дата_начало' и" +
                    " 'Оргвзнос' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            UpdateAll(); 
        }
    
        //удалить конференцию
        private void button3_Click(object sender, EventArgs e)
        {
            DeleteConference del = new DeleteConference();
            del.ShowDialog();
            UpdateAll();
        }

        //добавить автора
        private async void button1_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            //если все поля заполнены
            if (!string.IsNullOrEmpty(фамилияTextBox.Text) && !string.IsNullOrWhiteSpace(фамилияTextBox.Text) &&
               !string.IsNullOrEmpty(имяTextBox.Text) && !string.IsNullOrWhiteSpace(имяTextBox.Text) &&
               !string.IsNullOrEmpty(отчествоTextBox.Text) && !string.IsNullOrWhiteSpace(отчествоTextBox.Text) &&
               !string.IsNullOrEmpty(ученая_степеньTextBox.Text) && !string.IsNullOrWhiteSpace(ученая_степеньTextBox.Text) &&
               !string.IsNullOrEmpty(ученое_званиеTextBox.Text) && !string.IsNullOrWhiteSpace(ученое_званиеTextBox.Text) &&
               !string.IsNullOrEmpty(научное_направлвниеTextBox.Text) && !string.IsNullOrWhiteSpace(научное_направлвниеTextBox.Text) &&
               !string.IsNullOrEmpty(адресTextBox.Text) && !string.IsNullOrWhiteSpace(адресTextBox.Text) &&
               !string.IsNullOrEmpty(почтовой_индексTextBox.Text) && !string.IsNullOrWhiteSpace(почтовой_индексTextBox.Text) &&
               !string.IsNullOrEmpty(рабочий_телефонTextBox.Text) && !string.IsNullOrWhiteSpace(рабочий_телефонTextBox.Text) &&
               !string.IsNullOrEmpty(домашний_телефонTextBox.Text) && !string.IsNullOrWhiteSpace(домашний_телефонTextBox.Text) &&
               !string.IsNullOrEmpty(e_mailTextBox.Text) && !string.IsNullOrWhiteSpace(e_mailTextBox.Text) &&
               !string.IsNullOrEmpty(кафедраTextBox.Text) && !string.IsNullOrWhiteSpace(кафедраTextBox.Text) &&
               !string.IsNullOrEmpty(место_работыTextBox.Text) && !string.IsNullOrWhiteSpace(место_работыTextBox.Text) &&
               !string.IsNullOrEmpty(должностьTextBox.Text) && !string.IsNullOrWhiteSpace(должностьTextBox.Text) &&
               !string.IsNullOrEmpty(странаTextBox.Text) && !string.IsNullOrWhiteSpace(странаTextBox.Text) &&
               !string.IsNullOrEmpty(городTextBox.Text) && !string.IsNullOrWhiteSpace(городTextBox.Text))
            {           
                int id_location = 0;
                while (id_location == 0)
                {
                    string searchCity = "SELECT id_локация, COUNT(id_локация) " +
                                        "FROM Локация " +
                                        "WHERE Город = @Город " +
                                        "GROUP BY id_локация";
                    SqlCommand commandCity = new SqlCommand(searchCity, sqlConnection);
                    commandCity.Parameters.AddWithValue("Город", городTextBox.Text);
                    List<string[]> data = new List<string[]>();
                    try
                    {
                        SqlDataReader sqlDataReader = await commandCity.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            data.Add(new string[2]);
                            for (int i = 0; i < 2; i++)
                            {
                                data[data.Count - 1][i] = sqlDataReader[i].ToString();
                            }
                        }
                        sqlDataReader.Close();
                        if (data.Count != 0)
                        {
                            id_location = Convert.ToInt32(data[0][0].ToString());
                            break;
                        }
                            
                        else
                        {
                            string cityInsert = "INSERT INTO Локация(Страна, Город) VALUES(@Страна, @Город)";
                            SqlCommand CityInsertCmd = new SqlCommand(cityInsert, sqlConnection);
                            CityInsertCmd.Parameters.AddWithValue("Страна", странаTextBox.Text);
                            CityInsertCmd.Parameters.AddWithValue("Город", городTextBox.Text);
                            try
                            {
                                await CityInsertCmd.ExecuteNonQueryAsync();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                string cmd = "INSERT INTO Авторы(Фамилия, Имя, Отчество, Адрес, Почтовой_индекс, " +
                    "Рабочий_телефон, Домашний_телефон, e_mail, Ученая_степень, Ученое_звание, " +
                    "Научное_направлвние, Кафедра, Место_работы, Должность, id_локация) " +
                    "VALUES(@Фамилия, @Имя, @Отчество, @Адрес, @Почтовой_индекс, " +
                    "@Рабочий_телефон, @Домашний_телефон, @e_mail, @Ученая_степень, @Ученое_звание, " +
                    "@Научное_направлвние, @Кафедра, @Место_работы, @Должность, @id_локация)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("Фамилия", фамилияTextBox.Text);
                command.Parameters.AddWithValue("Имя", имяTextBox.Text);
                command.Parameters.AddWithValue("Отчество", отчествоTextBox.Text);
                command.Parameters.AddWithValue("Адрес", адресTextBox.Text);
                command.Parameters.AddWithValue("Почтовой_индекс", почтовой_индексTextBox.Text);
                command.Parameters.AddWithValue("Рабочий_телефон", рабочий_телефонTextBox.Text);
                command.Parameters.AddWithValue("Домашний_телефон", домашний_телефонTextBox.Text);
                command.Parameters.AddWithValue("e_mail", e_mailTextBox.Text);
                command.Parameters.AddWithValue("Ученая_степень", ученая_степеньTextBox.Text);
                command.Parameters.AddWithValue("Ученое_звание", ученое_званиеTextBox.Text);
                command.Parameters.AddWithValue("Научное_направлвние", научное_направлвниеTextBox.Text);
                command.Parameters.AddWithValue("Кафедра", кафедраTextBox.Text);
                command.Parameters.AddWithValue("Место_работы", место_работыTextBox.Text);
                command.Parameters.AddWithValue("Должность", должностьTextBox.Text);
                command.Parameters.AddWithValue("id_локация", id_location);

                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные автора успешно добавлени в базу данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПоля 'Фамилия', 'Имя', 'Отчество', 'Адрес', 'Почтовой_индекс', " +
                    "'Рабочий_телефон', 'Домашний_телефон', 'e_mail', 'Ученая_степень', 'Ученое_звание', " +
                    "'Научное_направлвние', 'Кафедра', 'Место_работы', 'Должность', 'Город' и 'Страна' " +
                    "должны быть заполнены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabel1.Text = "Ошибка! Все поля должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            UpdateAll();
        }

        //удалить автора
        private void button2_Click(object sender, EventArgs e)
        {
            DeleteAutor del = new DeleteAutor();
            del.ShowDialog();
            UpdateAll();
        }

        //добавить участника
        private async void button6_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            //если все нужные поля заполнены
            if (!string.IsNullOrEmpty(id_конференцияTextBox.Text) && !string.IsNullOrWhiteSpace(id_конференцияTextBox.Text) &&
                !string.IsNullOrEmpty(размер_оргвзносаTextBox.Text) && !string.IsNullOrWhiteSpace(размер_оргвзносаTextBox.Text) &&
                (потребность_в_гостиницеCheckBox.Checked && !string.IsNullOrEmpty(textBox2.Text) || 
                    (!потребность_в_гостиницеCheckBox.Checked && string.IsNullOrEmpty(textBox2.Text))))
            {
                string cmd = "INSERT INTO Участники(id_автор, id_конференция, id_гостиница, " +
                    "Дата_поступления_оргвзноса, Дата_поступления_заявки, " +
                    "Дата_рассылки_1_ого_приглашения, Дата_рассылки_2_ого_приглашения, " +
                    "Дата_приезда, Дата_отезда, Докладчик_участник, Потребность_в_гостинице, Размер_оргвзноса) " +
                    "VALUES(@id_автор, @id_конференция, @id_гостиница, " +
                    "@Дата_поступления_оргвзноса, @Дата_поступления_заявки, " +
                    "@Дата_рассылки_1_ого_приглашения, @Дата_рассылки_2_ого_приглашения, " +
                    "@Дата_приезда, @Дата_отезда, @Докладчик_участник, @Потребность_в_гостинице, @Размер_оргвзноса)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("id_автор", textBox1.Text);
                command.Parameters.AddWithValue("id_конференция", id_конференцияTextBox.Text);
                command.Parameters.AddWithValue("Дата_поступления_оргвзноса", дата_поступления_оргвзносаDateTimePicker.Value);
                command.Parameters.AddWithValue("Дата_поступления_заявки", дата_поступления_заявкиDateTimePicker.Value);
                command.Parameters.AddWithValue("Дата_рассылки_1_ого_приглашения", дата_рассылки_1_ого_приглашенияDateTimePicker.Value);
                command.Parameters.AddWithValue("Дата_рассылки_2_ого_приглашения", дата_рассылки_2_ого_приглашенияDateTimePicker.Value);
                command.Parameters.AddWithValue("Дата_приезда", дата_приездаDateTimePicker.Value);
                command.Parameters.AddWithValue("Дата_отезда", дата_отездаDateTimePicker.Value);
                command.Parameters.AddWithValue("Докладчик_участник", докладчик_участникCheckBox.Checked);
                command.Parameters.AddWithValue("Потребность_в_гостинице", потребность_в_гостиницеCheckBox.Checked);
                command.Parameters.AddWithValue("Размер_оргвзноса", размер_оргвзносаTextBox.Text);
                string id_hotel = "";
                if (потребность_в_гостиницеCheckBox.Checked)
                {
                    string cmd2 = "SELECT id_гостиница FROM Гостиницы WHERE id_гостиница=@id_гостиница";
                    SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
                    command2.Parameters.AddWithValue("id_гостиница", textBox2.Text);
                    SqlDataReader sdaReader;
                   
                    try
                    {
                        sdaReader = await command2.ExecuteReaderAsync();
                        while (sdaReader.Read())
                            id_hotel = sdaReader[0].ToString();
                        sdaReader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //если гостиница есть в базе, то продолжаем
                    if (id_hotel != "")
                    {   
                        command.Parameters.AddWithValue("id_гостиница", textBox2.Text);
                        try
                        {
                            await command.ExecuteNonQueryAsync();

                            toolStripStatusLabel1.Text = "Данные участника успешно добавлени в базу данных.";
                            toolStripStatusLabel1.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка!\n\nТакой гостиницы нет в базе данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        toolStripStatusLabel1.Text = "Ошибка! Такой гостиницы нет в базе данных.";
                        toolStripStatusLabel1.Visible = true;
                    }
                }
                if (!потребность_в_гостиницеCheckBox.Checked)
                {
                    textBox2.Text = "";
                    command.Parameters.AddWithValue("id_гостиница", textBox2.Text);
                    try
                    {
                        await command.ExecuteNonQueryAsync();
                        toolStripStatusLabel1.Text = "Данные участника успешно добавлени в базу данных.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПоля 'id_конференция' и 'Размер_оргвзноса' " +
                    "должны быть заполнены." +
                    "\n\nИли поле 'id_гостиница' должен быть заполнен если " +
                    "установлен checkBox 'Гостиница'" +
                    "\n\nИли такой автор уже есть среди участников той же конференции.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabel1.Text = "Ошибка! Поля 'id_конференция' и 'Размер_оргвзноса' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            UpdateAll();
        }

        //удалить участника
        private void button5_Click(object sender, EventArgs e)
        {
            DeleteUchastnik del = new DeleteUchastnik();
            del.ShowDialog();
            UpdateAll();
        }

        //добавить доклад
        private async void button7_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            //если все нужные поля заполнены
            if (!string.IsNullOrEmpty(id_участникTextBox1.Text) && !string.IsNullOrWhiteSpace(id_участникTextBox1.Text) &&
                !string.IsNullOrEmpty(тема_докладаTextBox.Text) && !string.IsNullOrWhiteSpace(тема_докладаTextBox.Text) &&
                !string.IsNullOrEmpty(количество_страницTextBox.Text) && !string.IsNullOrWhiteSpace(количество_страницTextBox.Text))
            {
                string cmd = "INSERT INTO Доклады(id_участник, Тема_доклада, Отметка_о_поступлении_тезисов, Количество_страниц, Соавторы) " +
                    "VALUES(@id_участник, @Тема_доклада, @Отметка_о_поступлении_тезисов, @Количество_страниц, @Соавторы)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("id_участник", id_участникTextBox1.Text);
                command.Parameters.AddWithValue("Тема_доклада", тема_докладаTextBox.Text);
                command.Parameters.AddWithValue("Отметка_о_поступлении_тезисов", тезисcheckBox.Checked);
                command.Parameters.AddWithValue("Количество_страниц", количество_страницTextBox.Text);
                command.Parameters.AddWithValue("Соавторы", соавторыTextBox.Text);
                
                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные доклада успешно добавлени в базу данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПоля 'id_участник', 'Тема_доклада' и 'Количество_страниц' " +
                    "должны быть заполнены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabel1.Text = "Ошибка! Поля 'id_участник', 'Тема_доклада' " +
                    "и 'Количество_страниц' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            UpdateAll();
        }

        //удалить доклад
        private void button8_Click(object sender, EventArgs e)
        {
            DeleteDoklad del = new DeleteDoklad();
            del.ShowDialog();
            UpdateAll();
        }

        //добавить гостиницу
        private async void button9_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            //если все нужные поля заполнены
            if (!string.IsNullOrEmpty(названиеTextBox1.Text) && !string.IsNullOrWhiteSpace(названиеTextBox1.Text) &&
                !string.IsNullOrEmpty(адресTextBox1.Text) && !string.IsNullOrWhiteSpace(адресTextBox1.Text) &&
                !string.IsNullOrEmpty(стоимость_номераTextBox.Text) && !string.IsNullOrWhiteSpace(стоимость_номераTextBox.Text) &&
                !string.IsNullOrEmpty(городTextBox1.Text) && !string.IsNullOrWhiteSpace(городTextBox1.Text) &&
                !string.IsNullOrEmpty(странаTextBox1.Text) && !string.IsNullOrWhiteSpace(странаTextBox1.Text))
            {
                int id_location = 0;
                while (id_location == 0)
                {
                    string searchCity = "SELECT id_локация, COUNT(id_локация) " +
                                        "FROM Локация " +
                                        "WHERE Город = @Город " +
                                        "GROUP BY id_локация";
                    SqlCommand commandCity = new SqlCommand(searchCity, sqlConnection);
                    commandCity.Parameters.AddWithValue("Город", городTextBox1.Text);
                    List<string[]> data = new List<string[]>();
                    try
                    {
                        SqlDataReader sqlDataReader = await commandCity.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            data.Add(new string[2]);
                            for (int i = 0; i < 2; i++)
                            {
                                data[data.Count - 1][i] = sqlDataReader[i].ToString();
                            }
                        }
                        sqlDataReader.Close();
                        if (data.Count != 0)
                        {
                            id_location = Convert.ToInt32(data[0][0].ToString());
                            break;
                        }

                        else
                        {
                            string cityInsert = "INSERT INTO Локация(Страна, Город) VALUES(@Страна, @Город)";
                            SqlCommand CityInsertCmd = new SqlCommand(cityInsert, sqlConnection);
                            CityInsertCmd.Parameters.AddWithValue("Страна", странаTextBox1.Text);
                            CityInsertCmd.Parameters.AddWithValue("Город", городTextBox1.Text);
                            try
                            {
                                await CityInsertCmd.ExecuteNonQueryAsync();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                string cmd = "INSERT INTO Гостиницы(Название, id_локация, Адрес, Стоимость_номера) " +
                    "VALUES(@Название, @id_локация, @Адрес, @Стоимость_номера)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("Название", названиеTextBox1.Text);
                command.Parameters.AddWithValue("id_локация", id_location);
                command.Parameters.AddWithValue("Адрес", адресTextBox1.Text);
                command.Parameters.AddWithValue("Стоимость_номера", стоимость_номераTextBox.Text);

                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные гостиницы успешно добавлени в базу данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПоля 'Название', 'Адрес', 'Стоимость_номера', 'Страна' и " +
                    "'Город' должны быть заполнены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabel1.Text = "Ошибка! Поля 'Название', 'Адрес', 'Стоимость_номера', " +
                    "'Страна' и 'Город' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            UpdateAll();
        }

        //удалить гостиницу
        private void button10_Click(object sender, EventArgs e)
        {
            DeleteHotel del = new DeleteHotel();
            del.ShowDialog();
            UpdateAll();
        }

        //о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        //для указанной даты 1-ой рассылки вывести список приглашенных и посчитать их количество
        private void button11_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(idConference.Text) && !string.IsNullOrWhiteSpace(idConference.Text))
            {
                PervoePriglashenie f = new PervoePriglashenie(dateTimePicker3.Value, idConference.Text);
                f.Show();
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПолe 'id_конференция' должен быть заполнен.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabel1.Text = "Ошибка! Полe 'id_конференция' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        //вывести список приглашенных, с указанием даты об уплате оргвзноса
        private void button12_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                OrgVznosDateSpisok f = new OrgVznosDateSpisok(textBox3.Text);
                f.Show();
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПолe 'id_конференция' должен быть заполнен.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabel1.Text = "Ошибка! Полe 'id_конференция' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        //для указанной интервала дат, вывести список участников, уплативших оргвзнос в этом диапазоне
        private void button13_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                //если дата "с" не позже даты "до", то все ок, продолжаем
                if (dateTimePicker1.Value <= dateTimePicker2.Value)
                {
                    OrgVznosDateInterval f = new OrgVznosDateInterval(textBox4.Text, 
                        dateTimePicker1.Value, dateTimePicker2.Value);
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Ошибка!\n\nНеправильно выставлены даты \"с\" и \"до\".",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    toolStripStatusLabel1.Text = "Ошибка! Неправильно выставлены даты \"с\" и \"до\".";
                    toolStripStatusLabel1.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПолe 'id_конференция' должен быть заполнен.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabel1.Text = "Ошибка! Полe 'id_конференция' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        //для указанного города вывести название тезисов докладов, поступивших из этого города
        private void button14_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(gorodtextbox.Text) && !string.IsNullOrWhiteSpace(gorodtextbox.Text) &&
                !string.IsNullOrEmpty(idconfertextbox.Text) && !string.IsNullOrWhiteSpace(idconfertextbox.Text))
            {
                TeseusDokladus f = new TeseusDokladus(gorodtextbox.Text, idconfertextbox.Text);
                f.Show();
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПоля 'id_конференция' и 'Город' должены быть заполнены.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabel1.Text = "Ошибка! Поля 'id_конференция' и 'Город' должены быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        //для указанного города, вывести список нуждающихся в гостинице
        private void button15_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(город2textbox.Text) && !string.IsNullOrWhiteSpace(город2textbox.Text) &&
                !string.IsNullOrEmpty(idconference12.Text) && !string.IsNullOrWhiteSpace(idconference12.Text))
            {
                TrueHotel f = new TrueHotel(город2textbox.Text, idconference12.Text);
                f.Show();
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПоля 'id_конференция' и 'Город' должены быть заполнены.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabel1.Text = "Ошибка! Поля 'id_конференция' и 'Город' должены быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        //приглашение
        private void button16_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {

                string cmd2 = "SELECT Авторы.Фамилия, Авторы.Имя, Авторы.Отчество " +
                          "FROM Участники INNER JOIN Авторы ON Участники.id_автор = Авторы.id_автор " +
                          "WHERE Участники.id_конференция = @id_конференция";

                SqlCommand command2 = new SqlCommand(cmd2, sqlConnection);
                command2.Parameters.AddWithValue("id_конференция", textBox6.Text);
                List<string[]> data2 = new List<string[]>();
                try
                {
                    SqlDataReader reader2 = command2.ExecuteReader();


                    while (reader2.Read())
                    {
                        data2.Add(new string[3]);
                        for (int i = 0; i < 3; i++)
                        {
                            data2[data2.Count - 1][i] = reader2[i].ToString();
                        }
                    }
                    reader2.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //название конференции
                string cmd = "SELECT Название FROM Конференции " +
                    "WHERE id_конференция = @id_конференция";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("id_конференция", textBox6.Text);
                List<string[]> data = new List<string[]>();
                try
                {
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        data.Add(new string[1]);
                        data[data.Count - 1][0] = reader[0].ToString();
                    }
                    reader.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                // Создаем документ Word.
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                //Start Word and create a new document.
                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = true;
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);

                foreach (string[] fio in data2)
                {
                    //Insert a paragraph at the beginning of the document.
                    Word.Paragraph oPara1;
                    oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    oPara1.Range.Text = "П Р И Г Л А Ш Е Н И Е";
                    oPara1.Range.Font.Size = 24;
                    oPara1.Range.Font.Bold = 1;
                    oPara1.Format.SpaceAfter = 6;    //6 pt spacing after paragraph.
                    oPara1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    oPara1.Range.InsertParagraphAfter();

                    //Insert a paragraph at the end of the document.
                    Word.Paragraph oPara2;
                    object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
                    oPara2.Range.Text = "на конфернцию " + data[0][0].ToString();
                    oPara1.Range.Font.Size = 16;
                    oPara2.Range.Font.Bold = 1;
                    oPara2.Format.SpaceAfter = 20;
                    oPara2.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    oPara2.Range.InsertParagraphAfter();

                    //Insert another paragraph.
                    Word.Paragraph oPara3;
                    oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
                    if (fio[2][fio[2].Count() - 1].ToString() == "ч")
                    {
                        oPara3.Range.Text = "Уважаемый " + fio[0].ToString() + " " + fio[1].ToString() + " " + fio[2].ToString();
                    }
                    if (fio[2][fio[2].Count() - 1].ToString() == "а")
                    {
                        oPara3.Range.Text = "Уважаемая " + fio[0].ToString() + " " + fio[1].ToString() + " " + fio[2].ToString();
                    }
                    oPara3.Range.Font.Bold = 1;
                    oPara3.Format.SpaceAfter = 12;
                    oPara3.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    oPara3.Range.InsertParagraphAfter();

                    Word.Paragraph oPara7;
                    oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara7 = oDoc.Content.Paragraphs.Add(ref oRng);
                    oPara7.Range.Text = " ";
                    oPara7.Range.Font.Bold = 0;
                    oPara7.Format.SpaceAfter = 0;
                    oPara7.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    oPara7.Range.InsertParagraphAfter();

                    //Insert another paragraph.
                    Word.Paragraph oPara4;
                    oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
                    oPara4.Range.Text = "\t" + textBox5.Text;
                    oPara4.Range.Font.Bold = 0;
                    oPara4.Format.SpaceAfter = 0;
                    oPara4.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    //разрыв страницы
                    oDoc.Words.Last.InsertBreak(Word.WdBreakType.wdPageBreak);
                }
                MessageBox.Show("Приглашения созданы!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПолe 'id_конференция' должен быть заполнен.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                toolStripStatusLabel1.Text = "Ошибка! Полe 'id_конференция' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        //изменить конференцию
        private void button17_Click(object sender, EventArgs e)
        {
            UpdateConference f = new UpdateConference();
            f.ShowDialog();
            UpdateAll();
        }

        //изменить автора
        private void button18_Click(object sender, EventArgs e)
        {
            UpdateAutor f = new UpdateAutor();
            f.ShowDialog();
            UpdateAll();
        }

        //изменить участника
        private void button19_Click(object sender, EventArgs e)
        {
            UpdateUchastnik f = new UpdateUchastnik();
            f.ShowDialog();
            UpdateAll();
        }

        //изменить доклад
        private void button20_Click(object sender, EventArgs e)
        {
            UpdateDoklad f = new UpdateDoklad();
            f.ShowDialog();
            UpdateAll();
        }

        //изменить гостиницу
        private void button21_Click(object sender, EventArgs e)
        {
            UpdateHotel f = new UpdateHotel();
            f.ShowDialog();
            UpdateAll();
        }
    }
}
