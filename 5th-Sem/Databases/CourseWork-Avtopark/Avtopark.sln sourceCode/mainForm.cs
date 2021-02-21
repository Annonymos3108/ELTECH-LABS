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

namespace Avtopark
{
    public partial class mainForm : Form
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                @"C:\winformsDB\Avtopark\Database1.mdf;Integrated Security=True";
        string masterConnString = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                @"C:\winformsDB\Avtopark\Database1.mdf; Initial Catalog = master; Integrated Security = True";
        public mainForm()
        {
            InitializeComponent();
        }

        //загрузка интерфейса программы
        private async void Form1_Load(object sender, EventArgs e)
        {
            this.водятTableAdapter.Fill(this.database1DataSet.Водят);
            this.списанные_автобусыTableAdapter.Fill(this.database1DataSet1.Списанные_автобусы);
            this.маршрутыTableAdapter.Fill(this.database1DataSet.Маршруты);
            this.тип_вместимостьTableAdapter.Fill(this.database1DataSet.Тип_вместимость);
            this.автобусыTableAdapter.Fill(this.database1DataSet.Автобусы);
            this.водителиTableAdapter.Fill(this.database1DataSet.Водители);

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

        }

        //поиск водителя по паспорт
        private void поискВодителяПоПаспортуToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.водителиTableAdapter.ПоискВодителяПоПаспорту(this.database1DataSet.Водители, паспортToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        //поиск водителя по ФИО
        private void поискВодителяПоФИОToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.водителиTableAdapter.ПоискВодителяПоФИО(this.database1DataSet.Водители, фИОToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        //добавить водителя
        private async void button1_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(паспортTextBox.Text) && !string.IsNullOrWhiteSpace(паспортTextBox.Text) &&
                !string.IsNullOrEmpty(фИОTextBox.Text) && !string.IsNullOrWhiteSpace(фИОTextBox.Text) &&
                !string.IsNullOrEmpty(классTextBox.Text) && !string.IsNullOrWhiteSpace(классTextBox.Text) &&
                !string.IsNullOrEmpty(стажTextBox.Text) && !string.IsNullOrWhiteSpace(стажTextBox.Text))
            {
                string cmd = "INSERT INTO [Водители] (Паспорт, ФИО, Оклад, Класс, Стаж) " +
                    "VALUES(@Паспорт, @ФИО, @Оклад, @Класс, @Стаж)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("Паспорт", паспортTextBox.Text);
                command.Parameters.AddWithValue("ФИО", фИОTextBox.Text);

                int staj = Convert.ToInt32(стажTextBox.Text);
                int klass = 0;
                if (классTextBox.Text == "A") klass = 10000;
                if (классTextBox.Text == "B") klass = 15000;
                if (классTextBox.Text == "C") klass = 20000;
                int oklad = (staj * 1000) + klass;
                string Oklad = Convert.ToString(oklad);

                command.Parameters.AddWithValue("Оклад", Oklad);
                command.Parameters.AddWithValue("Класс", классTextBox.Text);
                command.Parameters.AddWithValue("Стаж", стажTextBox.Text);

                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные водителя были успешно добавлены в базу данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Oшибка, водитель с данным паспортом уже есть в базе. Проверьте введенные данные.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Поля 'id_Водителя', 'ФИО', 'Класс' и " +
                    "'Стаж_работы' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            this.водителиTableAdapter.Fill(this.database1DataSet.Водители);

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            Application.Exit();
        }

        //показать водителей не на маршрутах
        private void button20_Click(object sender, EventArgs e)
        {
            VoditeliNeVodyat netNeVodyat = new VoditeliNeVodyat();
            netNeVodyat.Show();
        }

        //показать автобусы не на маршрутах
        private void button21_Click(object sender, EventArgs e)
        {
            AvtobusiNeEzdyat netNeEzdyat = new AvtobusiNeEzdyat();
            netNeEzdyat.Show();
        }

        //уволить водителя
        private async void button2_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(паспортTextBox.Text) && !string.IsNullOrWhiteSpace(паспортTextBox.Text))
            {
                if (MessageBox.Show("Вы действительно хотите удалить данные выбранного водителя?", "Внимание", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string cmd = "DELETE FROM [Водители] WHERE [Паспорт] = @Паспорт";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Паспорт", паспортTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        toolStripStatusLabel1.Text = "Данные водителя были успешно удалены.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Oшибка, сниминте водителя с маршрута. Это можно делать во вкладке 'Автобусы на маршруте'",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Oшибка! Полe 'Паспорт' должен быть заполнен.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Полe 'Паспорт' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
            this.водителиTableAdapter.Fill(this.database1DataSet.Водители);
        }

        //кнопка обновить
        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //
            this.водителиTableAdapter.Fill(this.database1DataSet.Водители);
            //this.водителиTableAdapter.Update(this.database1DataSet.Водители);
            this.автобусыTableAdapter.Fill(this.database1DataSet.Автобусы);
            this.тип_вместимостьTableAdapter.Fill(this.database1DataSet.Тип_вместимость);
            this.маршрутыTableAdapter.Fill(this.database1DataSet.Маршруты);
            this.списанные_автобусыTableAdapter.Fill(this.database1DataSet1.Списанные_автобусы);
        }

        //окно о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 form2 = new AboutBox1();
            form2.Show();
        }

        //удалить автобус
        private async void button3_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(автобусTextBox.Text) && !string.IsNullOrWhiteSpace(автобусTextBox.Text))
            {
                string cmd1 = "SELECT * FROM [Автобусы] WHERE Автобус = @Автобус";
                SqlCommand command0 = new SqlCommand(cmd1, sqlConnection);
                SqlDataReader sdaReader;

                command0.Parameters.AddWithValue("Автобус", автобусTextBox.Text);
                sdaReader = await command0.ExecuteReaderAsync();
                string avtobusType = "";

                while (sdaReader.Read())
                    avtobusType = sdaReader["Тип"].ToString();
                sdaReader.Close();



                string cmd2 = "INSERT INTO [Списанные_автобусы] (Автобус, Тип, Дата)" +
                    "VALUES(@Автобус, @Тип, @Дата)";
                SqlCommand command1 = new SqlCommand(cmd2, sqlConnection);

                command1.Parameters.AddWithValue("Автобус", автобусTextBox.Text);
                command1.Parameters.AddWithValue("Тип", avtobusType);
                command1.Parameters.AddWithValue("Дата", DateTime.Now.Date);

                try
                {
                    await command1.ExecuteNonQueryAsync();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string cmd3 = "DELETE FROM [Автобусы] WHERE [Автобус] = @Автобус";
                SqlCommand command2 = new SqlCommand(cmd3, sqlConnection);

                command2.Parameters.AddWithValue("Автобус", автобусTextBox.Text);

                try
                {
                    await command2.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные автобуса были успешно удалены из базы данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Oшибка, сниминте автобус с маршрута. Это можно делать во вкладке 'Автобусы на маршруте'",
                         "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Полe 'Автобус' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
            this.автобусыTableAdapter.Fill(this.database1DataSet.Автобусы);
        }

        private void поискАвтобусаToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.автобусыTableAdapter.ПоискАвтобуса(this.database1DataSet.Автобусы, автобусToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(автобусTextBox.Text) && !string.IsNullOrWhiteSpace(автобусTextBox.Text) &&
               !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                string cmd = "INSERT INTO [Автобусы] (Автобус, Тип) VALUES(@Автобус, @Тип)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("Автобус", автобусTextBox.Text);
                command.Parameters.AddWithValue("Тип", comboBox1.Text);
                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные автобуса были успешно добавлены в базу данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch
                {
                    MessageBox.Show("Oшибка! Значения поля 'Автобус' не может повторятся. Значение поля 'Тип' выберите из выпадающего списка. \n Проверьте правильность введенных данных",
                       "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel1.Text = "Oшибка! Значения поля 'Автобус' не может повторятся. Значение поля 'Тип' выберите из выпадающего списка.";
                    toolStripStatusLabel1.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Oшибка, Поля 'Автобус' и 'Тип' должны быть заполнены.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Поля 'Автобус' и 'Тип' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            this.автобусыTableAdapter.Fill(this.database1DataSet.Автобусы);
        }

        //=================================================================================

        //маршруты
        //==================================================================================
        //создать новый маршрут
        private async void button6_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            // если непусты и не состоят из пробелов, а правильность введенных данных проверит сама форма и БД
            if (!string.IsNullOrEmpty(маршрутTextBox.Text) && !string.IsNullOrWhiteSpace(маршрутTextBox.Text) &&
               !string.IsNullOrEmpty(начальный_пунктTextBox.Text) && !string.IsNullOrWhiteSpace(начальный_пунктTextBox.Text) &&
               !string.IsNullOrEmpty(конечный_пунктTextBox.Text) && !string.IsNullOrWhiteSpace(конечный_пунктTextBox.Text) &&
               !string.IsNullOrEmpty(время_начала_движенияTextBox.Text) && !string.IsNullOrWhiteSpace(время_начала_движенияTextBox.Text) &&
               !string.IsNullOrEmpty(время_окончания_движенияTextBox.Text) && !string.IsNullOrWhiteSpace(время_окончания_движенияTextBox.Text) &&
               !string.IsNullOrEmpty(интервал_мин_TextBox.Text) && !string.IsNullOrWhiteSpace(интервал_мин_TextBox.Text) &&
               !string.IsNullOrEmpty(протяженность_мин_TextBox.Text) && !string.IsNullOrWhiteSpace(протяженность_мин_TextBox.Text))
            {
                string cmd = "INSERT INTO [Маршруты] (Маршрут, Начальный_пункт, Конечный_пункт, Время_начала_движения, " +
                    "Время_окончания_движения, [Интервал(мин)], [Протяженность(мин)]) VALUES(@Маршрут, @Начальный_пункт," +
                    " @Конечный_пункт, @Время_начала_движения, @Время_окончания_движения, @Интервал, @Протяженность)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("Маршрут", маршрутTextBox.Text);
                command.Parameters.AddWithValue("Начальный_пункт", начальный_пунктTextBox.Text);
                command.Parameters.AddWithValue("Конечный_пункт", конечный_пунктTextBox.Text);
                command.Parameters.AddWithValue("Время_начала_движения", время_начала_движенияTextBox.Text);
                command.Parameters.AddWithValue("Время_окончания_движения", время_окончания_движенияTextBox.Text);
                command.Parameters.AddWithValue("Интервал", интервал_мин_TextBox.Text);
                command.Parameters.AddWithValue("Протяженность", протяженность_мин_TextBox.Text);

                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные маршрута были успешно добавлены в базу данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Oшибка! Поля 'Маршрут', 'Начальный пункт', 'Конечный пункт', 'Время начала движения', " +
                    "'Время окончания движения', 'Интервал(мин)' и 'Протяженность(мин)' должны быть заполнены.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Поля 'Маршрут', 'Начальный пункт', 'Конечный пункт', 'Время начала движения', " +
                    "'Время окончания движения', 'Интервал(мин)' и 'Протяженность(мин)' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            this.маршрутыTableAdapter.Fill(this.database1DataSet.Маршруты);
        }

        //изменить протяженность маршрута
        private async void button5_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            // если непусты и не состоят из пробелов, а правильность введенных данных проверит сама форма и БД
            if (!string.IsNullOrEmpty(маршрутTextBox.Text) && !string.IsNullOrWhiteSpace(маршрутTextBox.Text) &&
               !string.IsNullOrEmpty(протяженность_мин_TextBox.Text) && !string.IsNullOrWhiteSpace(протяженность_мин_TextBox.Text))
            {
                string cmd = "UPDATE [Маршруты] SET [Протяженность(мин)]=@Протяженность WHERE Маршрут=@Маршрут";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("Маршрут", маршрутTextBox.Text);
                command.Parameters.AddWithValue("Протяженность", протяженность_мин_TextBox.Text);

                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Протяженность маршрута была успешно изменена.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
            else
            {
                toolStripStatusLabel1.Text = "Поля 'Маршрут' и 'Протяженность(мин)' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
            this.маршрутыTableAdapter.Fill(this.database1DataSet.Маршруты);
        }

        private void поискМаршрутаToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.маршрутыTableAdapter.ПоискМаршрута(this.database1DataSet.Маршруты, ((int)(System.Convert.ChangeType(маршрутToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //удалить маршрут
        private async void button7_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(маршрутTextBox.Text) && !string.IsNullOrWhiteSpace(маршрутTextBox.Text))
            {
                if (MessageBox.Show("Вы действительно хотите удалить выбранный маршрут?", "Внимание", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string cmd = "DELETE FROM [Маршруты] WHERE [Маршрут] = @Маршрут";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Маршрут", маршрутTextBox.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        toolStripStatusLabel1.Text = "Маршрут был успешно удален из базы данных.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Oшибка, сниминте все автобусы с данного маршрута. Это можно делать во вкладке 'Автобусы на маршруте'",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Полe 'Маршрут' должен быть заполнен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Полe 'Маршрут' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
            this.маршрутыTableAdapter.Fill(this.database1DataSet.Маршруты);
        }

        //вернуть автобус
        private async void button8_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(автобусTextBox1.Text) && !string.IsNullOrWhiteSpace(автобусTextBox1.Text))
            {
                string cmd1 = "SELECT * FROM [Списанные_автобусы] WHERE Автобус = @Автобус";
                SqlCommand command0 = new SqlCommand(cmd1, sqlConnection);
                SqlDataReader sdaReader;

                command0.Parameters.AddWithValue("Автобус", автобусTextBox1.Text);
                sdaReader = await command0.ExecuteReaderAsync();
                string avtobusType = "";

                while (sdaReader.Read())
                    avtobusType = sdaReader["Тип"].ToString();
                sdaReader.Close();



                string cmd2 = "INSERT INTO [Автобусы] (Автобус, Тип) VALUES(@Автобус, @Тип)";
                SqlCommand command1 = new SqlCommand(cmd2, sqlConnection);

                command1.Parameters.AddWithValue("Автобус", автобусTextBox1.Text);
                command1.Parameters.AddWithValue("Тип", avtobusType);

                try
                {
                    await command1.ExecuteNonQueryAsync();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string cmd3 = "DELETE FROM [Списанные_автобусы] WHERE [Автобус] = @Автобус";
                SqlCommand command2 = new SqlCommand(cmd3, sqlConnection);

                command2.Parameters.AddWithValue("Автобус", автобусTextBox1.Text);

                try
                {
                    await command2.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные автобуса были восстановлены.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Полe 'Автобус' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
            this.списанные_автобусыTableAdapter.Fill(this.database1DataSet1.Списанные_автобусы);
        }

        //удалить навсегда
        private async void button9_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(автобусTextBox1.Text) && !string.IsNullOrWhiteSpace(автобусTextBox1.Text))
            {
                if (MessageBox.Show("Вы действительно хотите удалить выбранный элемент?", "Внимание", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string cmd = "DELETE FROM [Списанные_автобусы] WHERE [Автобус] = @Автобус";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Автобус", автобусTextBox1.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        toolStripStatusLabel1.Text = "Автобус успешно удален из базы данных.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Oшибка! Полe 'Автобус' должен быть заполнен.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                this.маршрутыTableAdapter.Fill(this.database1DataSet.Маршруты);
            }
            else
            {
                toolStripStatusLabel1.Text = "Полe 'Автобус' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        //Снять водителя с маршрута
        private async void button11_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(паспортTextBox1.Text) && !string.IsNullOrWhiteSpace(паспортTextBox1.Text))
            {
                if (MessageBox.Show("Вы действительно снять водителя с данного маршрута?", "Внимание", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string cmd = "DELETE FROM [Водят] WHERE [Паспорт] = @Паспорт";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Паспорт", паспортTextBox1.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        toolStripStatusLabel1.Text = "Автобус и водитель сняты выбранного маршрута.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Oшибка! Проверьте правильность введенных данных.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Oшибка! Полe 'Паспорт' должен быть заполнен.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Полe 'Паспорт' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
            this.водятTableAdapter.Fill(this.database1DataSet.Водят);
        }

        //Снять автобус с маршрута
        private async void button12_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(автобусTextBox2.Text) && !string.IsNullOrWhiteSpace(автобусTextBox2.Text))
            {
                if (MessageBox.Show("Вы действительно снять автобус с данного маршрута?", "Внимание", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string cmd = "DELETE FROM [Водят] WHERE [Автобус] = @Автобус";
                    SqlCommand command = new SqlCommand(cmd, sqlConnection);
                    command.Parameters.AddWithValue("Автобус", автобусTextBox2.Text);

                    try
                    {
                        await command.ExecuteNonQueryAsync();

                        toolStripStatusLabel1.Text = "Автобус и водитель сняты выбранного маршрута.";
                        toolStripStatusLabel1.Visible = true;
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Oшибка! Проверьте правильность введенных данных.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Oшибка! Полe 'Автобус' должен быть заполнен.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Полe 'Автобус' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
            this.водятTableAdapter.Fill(this.database1DataSet.Водят);
        }

        //Новый автобус на маршруте
        private async void button10_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(паспортTextBox1.Text) && !string.IsNullOrWhiteSpace(паспортTextBox1.Text) &&
                !string.IsNullOrEmpty(фИОTextBox1.Text) && !string.IsNullOrWhiteSpace(фИОTextBox1.Text) &&
                !string.IsNullOrEmpty(автобусTextBox2.Text) && !string.IsNullOrWhiteSpace(автобусTextBox2.Text) &&
                !string.IsNullOrEmpty(маршрутTextBox1.Text) && !string.IsNullOrWhiteSpace(маршрутTextBox1.Text) &&
                !string.IsNullOrEmpty(датаDateTimePicker.Text) && !string.IsNullOrWhiteSpace(датаDateTimePicker.Text))
            {
                string cmd = "INSERT INTO [Водят] (Паспорт, Автобус, ФИО, Маршрут, Дата) " +
                    "VALUES(@Паспорт, @Автобус, @ФИО, @Маршрут, @Дата)";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("Паспорт", паспортTextBox1.Text);
                command.Parameters.AddWithValue("Автобус", автобусTextBox2.Text);
                command.Parameters.AddWithValue("ФИО", фИОTextBox1.Text);
                command.Parameters.AddWithValue("Маршрут", маршрутTextBox1.Text);
                command.Parameters.AddWithValue("Дата", DateTime.Parse(датаDateTimePicker.Text));

                try
                {
                    await command.ExecuteNonQueryAsync();

                    toolStripStatusLabel1.Text = "Данные маршрута были успешно добавлены в базу данных.";
                    toolStripStatusLabel1.Visible = true;
                }
                catch (System.Exception ex)
                {
                    string errMsg = "Oшибка! Водитель и/или автобус с такими данными в базе не найдено." +
                        " Проверьте правильность введенных данных. Прежде чем добавить новый автобус на маршруте," +
                        " убедитесь что водитель и автобус добавлены в базу.";
                    MessageBox.Show(errMsg + "\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Oшибка! Поля 'Паспорт', 'ФИО', 'Автобус', 'Маршрут' и 'Дата' должны быть заполнены.",
                           "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Поля 'Паспорт', 'ФИО', 'Автобус', 'Маршрут' и 'Дата' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        //==============ОТЧЕТЫ===ЗАПРОСЫ===СПРАВКИ=========================
        //=================================================================
        private void button13_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                VoditeliMarshruta newVod = new VoditeliMarshruta(textBox1.Text);
                newVod.Show();
            }
            else
            {
                MessageBox.Show("Oшибка! Полe '№ маршрута' должен быть заполнен.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Полe '№ маршрута' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                AvtobusiMarshruta newAvt = new AvtobusiMarshruta(textBox2.Text);
                newAvt.Show();
            }
            else
            {
                MessageBox.Show("Oшибка! Полe '№ маршрута' должен быть заполнен.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Полe '№ маршрута' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(comboBox4.Text) && !string.IsNullOrWhiteSpace(comboBox4.Text))
            {
                if (Convert.ToString(comboBox4.Text) == "всех")
                {
                    MarshrutProtejennost newMarsh = new MarshrutProtejennost();
                    newMarsh.Show();
                }
                else
                {
                    string query = "SELECT [Протяженность(мин)] " +
                    "FROM [Маршруты] " +
                    "WHERE [Маршрут] = @Маршрут";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("Маршрут", comboBox4.Text);

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
                        MessageBox.Show("Протяженность маршрута №" + Convert.ToString(comboBox4.Text) +
                            " составляет " + data[0][0] + " минут.", "Протяженность маршрута",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ;
                    // вывести для одного в месидж боксе
                }
            }
            else
            {
                MessageBox.Show("Oшибка! Полe '№ маршрута' должен быть заполнен.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Полe '№ маршрута' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                string query = "SELECT [Автобус], [ФИО] " +
                            "FROM [Водят] " +
                            "WHERE [Паспорт] = @Паспорт";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("Паспорт", textBox3.Text);

                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    List<string[]> data = new List<string[]>();

                    while (reader.Read())
                    {
                        data.Add(new string[2]);

                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                    }

                    reader.Close();
                    MessageBox.Show("Водитель с паспортом " + Convert.ToString(textBox3.Text) +
                        " " + data[0][1] + " водит автобус номером " + data[0][0], "Водител - Автобус",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Oшибка! Полe 'Паспорт' должен быть заполнен.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Полe 'Паспорт' должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if ((!string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text) &&
                !string.IsNullOrEmpty(comboBox3.Text) && !string.IsNullOrWhiteSpace(comboBox3.Text)))
            {
                if (Convert.ToString(comboBox2.Text) == "всех" &&
                    Convert.ToString(comboBox3.Text) == "начинается и заканчивается")
                {
                    DvijCombo newCombo = new DvijCombo();
                    newCombo.Show();
                }

                if (Convert.ToString(comboBox2.Text) == "всех" &&
                Convert.ToString(comboBox3.Text) == "начинается")
                {
                    DvijenieStart newStartDvij = new DvijenieStart();
                    newStartDvij.Show();
                }

                if (Convert.ToString(comboBox2.Text) == "всех" &&
                    Convert.ToString(comboBox3.Text) == "заканчивается")
                {
                    DvijenieEnd newEndDvij = new DvijenieEnd();
                    newEndDvij.Show();
                }

                if (Convert.ToString(comboBox2.Text) != "всех" &&
                    Convert.ToString(comboBox3.Text) == "заканчивается")
                {
                    string query = "SELECT [Время_окончания_движения] " +
                            "FROM [Маршруты] " +
                            "WHERE [Маршрут] = @Маршрут";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("Маршрут", comboBox2.Text);

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
                        MessageBox.Show("Движение автобусов на маршруте №" + Convert.ToString(comboBox2.Text) +
                            " заканчивается в " + data[0][0], "Информация о маршруте", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (Convert.ToString(comboBox2.Text) != "всех" &&
                    Convert.ToString(comboBox3.Text) == "начинается")
                {
                    string query = "SELECT [Время_начала_движения] " +
                            "FROM [Маршруты] " +
                            "WHERE [Маршрут] = @Маршрут";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("Маршрут", comboBox2.Text);

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
                        MessageBox.Show("Движение автобусов на маршруте №" + Convert.ToString(comboBox2.Text) +
                            " начинается в " + data[0][0], "Информация о маршруте", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (Convert.ToString(comboBox2.Text) != "всех" &&
                    Convert.ToString(comboBox3.Text) == "начинается и заканчивается")
                {
                    string query = "SELECT [Время_начала_движения], [Время_окончания_движения] " +
                                "FROM [Маршруты] " +
                                "WHERE [Маршрут] = @Маршрут";

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    command.Parameters.AddWithValue("Маршрут", comboBox2.Text);

                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        List<string[]> data = new List<string[]>();

                        while (reader.Read())
                        {
                            data.Add(new string[2]);

                            data[data.Count - 1][0] = reader[0].ToString();
                            data[data.Count - 1][1] = reader[1].ToString();
                        }

                        reader.Close();
                        MessageBox.Show("Движение автобусов на маршруте №" + Convert.ToString(comboBox2.Text) +
                            " начинается в " + data[0][0] + " и заканчивается в " + data[0][1],
                            "Информация о маршруте", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            else
            {
                MessageBox.Show("Oшибка! Поля '№ маршрута' 'начало/конец' и  должны быть заполнены.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Поля '№ маршрута' 'начало/конец' должны быть заполнены.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        //справка о протяженности маршрута
        private void button18_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel1.Visible)
                toolStripStatusLabel1.Visible = false;
            if (!string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                string query = "SELECT [Протяженность(мин)] " +
                        "FROM [Маршруты] " +
                        "WHERE Маршрут=@Маршрут";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("Маршрут", textBox4.Text);

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

                    //Start Word and create a new document.
                    Word._Application oWord;
                    Word._Document oDoc;
                    oWord = new Word.Application();
                    oWord.Visible = true;
                    oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);

                    //Insert a paragraph at the beginning of the document.
                    Word.Paragraph oPara1;
                    oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                    oPara1.Range.Text = "ООО \"АВТОПАРК ПРИКОЛОВ\"";
                    oPara1.Range.Font.Bold = 1;
                    oPara1.Format.SpaceAfter = 6;    //24 pt spacing after paragraph.
                    oPara1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    oPara1.Range.InsertParagraphAfter();


                    //Insert a paragraph at the end of the document.
                    Word.Paragraph oPara2;
                    object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
                    oPara2.Range.Text = "С П Р А В К А";
                    oPara2.Range.Font.Bold = 1;
                    oPara2.Format.SpaceAfter = 40;
                    oPara2.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    oPara2.Range.InsertParagraphAfter();

                    //Insert another paragraph.
                    Word.Paragraph oPara3;
                    oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
                    oPara3.Range.Text = "Протяженность маршрута № " + textBox4.Text + " составляет " + data[0][0] + " минут.";
                    oPara3.Range.Font.Bold = 0;
                    oPara3.Format.SpaceAfter = 30;
                    oPara3.Range.InsertParagraphAfter();


                    //Insert another paragraph.
                    Word.Paragraph oPara4;
                    oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                    oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
                    oPara4.Range.Text = "Диспетчер автопарка\t\t\tФИЛИППОВ А.Г.";
                    oPara4.Range.Font.Bold = 0;
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
                MessageBox.Show("Oшибка! Поле '№ маршрута'  должен быть заполнен.",
                                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Поле '№ маршрута'  должен быть заполнен.";
                toolStripStatusLabel1.Visible = true;
            }
        }

        //полный отчет
        private async void button19_Click(object sender, EventArgs e)
        {
            int i = 0, avtobusCount = 0;
            int[] typesCount = new int[5];
            string[] types = new string[5];
            types[0] = "малый"; types[1] = "средний"; types[2] = "большой";
            types[3] = "сочлененный большой"; types[4] = "большой двухъярусный";

            foreach (string vs in types)
            {
                string query2 = "SELECT [Автобус], [Тип] " +
                        "FROM [Автобусы] " +
                        "WHERE Тип = @Тип";

                SqlCommand command1 = new SqlCommand(query2, sqlConnection);
                command1.Parameters.AddWithValue("Тип", vs);

                try
                {
                    SqlDataReader reader = await command1.ExecuteReaderAsync();

                    List<string[]> data = new List<string[]>();

                    while (reader.Read())
                    {
                        data.Add(new string[2]);

                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                    }

                    reader.Close();
                    typesCount[i] = data.Count();
                    i++;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //считать количество автобусов //всех
            foreach (int vs in typesCount)
            {
                avtobusCount += vs;
            }


            //номера маршрутов, время начала движения и интервал
            string query = "SELECT [Маршрут], [Время_начала_движения], [Интервал(мин)] " +
                        "FROM [Маршруты]";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            List<string[]> dataMarshruts = new List<string[]>();
            try
            {
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    dataMarshruts.Add(new string[3]);

                    dataMarshruts[dataMarshruts.Count - 1][0] = reader[0].ToString();
                    dataMarshruts[dataMarshruts.Count - 1][1] = reader[1].ToString();
                    dataMarshruts[dataMarshruts.Count - 1][2] = reader[2].ToString();
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //ФИО Водителей и их класс
            string query1 = "SELECT [ФИО], [Класс] FROM [Водители]";

            SqlCommand command3 = new SqlCommand(query1, sqlConnection);
            List<string[]> dataDrivers = new List<string[]>();
            try
            {
                SqlDataReader reader = await command3.ExecuteReaderAsync();

                while (reader.Read())
                {
                    dataDrivers.Add(new string[2]);

                    dataDrivers[dataDrivers.Count - 1][0] = reader[0].ToString();
                    dataDrivers[dataDrivers.Count - 1][1] = reader[1].ToString();
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Oшибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = "ООО \"АВТОПАРК ПРИКОЛОВ\"";
            oPara1.Range.Font.Bold = 1;
            oPara1.Format.SpaceAfter = 6;    //6 pt spacing after paragraph.
            oPara1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oPara1.Range.InsertParagraphAfter();


            //Insert a paragraph at the end of the document.
            Word.Paragraph oPara2;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara2.Range.Text = "ПОЛНЫЙ ОТЧЕТ";
            oPara2.Range.Font.Bold = 1;
            oPara2.Format.SpaceAfter = 40;
            oPara2.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            oPara2.Range.InsertParagraphAfter();

            //Insert another paragraph.
            Word.Paragraph oPara3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara3.Range.Text = "Автобусов всего: " + avtobusCount + " из которых:";
            oPara3.Range.Font.Bold = 0;
            oPara3.Format.SpaceAfter = 0;
            oPara3.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            oPara3.Range.InsertParagraphAfter();


            //Insert another paragraph.
            Word.Paragraph oPara4;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara4.Range.Text = typesCount[0] + " " + types[0] + ";";
            oPara4.Range.Font.Bold = 0;
            oPara4.Format.SpaceAfter = 0;
            oPara4.Range.InsertParagraphAfter();


            //Insert another paragraph.
            Word.Paragraph oPara5;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara5 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara5.Range.Text = typesCount[1] + " " + types[1] + ";";
            oPara5.Range.Font.Bold = 0;
            oPara5.Format.SpaceAfter = 0;
            oPara5.Range.InsertParagraphAfter();

            //Insert another paragraph.
            Word.Paragraph oPara6;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara6 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara6.Range.Text = typesCount[2] + " " + types[2] + ";";
            oPara6.Range.Font.Bold = 0;
            oPara6.Format.SpaceAfter = 0;
            oPara6.Range.InsertParagraphAfter();


            //Insert another paragraph.
            Word.Paragraph oPara7;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara7 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara7.Range.Text = typesCount[3] + " " + types[3] + ";";
            oPara7.Range.Font.Bold = 0;
            oPara7.Format.SpaceAfter = 0;
            oPara7.Range.InsertParagraphAfter();

            //Insert another paragraph.
            Word.Paragraph oPara8;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara8 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara8.Range.Text = typesCount[4] + " " + types[4] + ";";
            oPara8.Range.Font.Bold = 0;
            oPara8.Format.SpaceAfter = 24;
            oPara8.Range.InsertParagraphAfter();


            //Insert another paragraph.
            Word.Paragraph oPara9;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara9 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara9.Range.Text = "Парк обслуживает всего " + dataMarshruts.Count() + " маршрутов. " +
                "Номера маршрутов, время начала движения и интервал в таблице ниже.";
            oPara9.Range.Font.Bold = 0;
            oPara9.Format.SpaceAfter = 6;
            oPara9.Range.InsertParagraphAfter();


            //маршруты таблица
            //Insert a table, fill it with data, and make the first row
            //bold.

            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, dataMarshruts.Count() + 1, dataMarshruts[0].Count(), ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 0;
            oTable.Cell(1, 1).Range.Text = "Номер маршрута";
            oTable.Cell(1, 2).Range.Text = "Время начала движения";
            oTable.Cell(1, 3).Range.Text = "Интервал(мин)";
            int r, c;
            string strText;
            for (r = 1; r <= dataMarshruts.Count(); r++)
                for (c = 1; c <= dataMarshruts[0].Count(); c++)
                {
                    strText = dataMarshruts[r - 1][c - 1].ToString();
                    oTable.Cell(r + 1, c).Range.Text = strText;
                }
            oTable.Rows[1].Range.Font.Bold = 1;


            //ФИО Водителей и их класс
            //Insert another paragraph.
            Word.Paragraph oPara10;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara10 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara10.Range.Text = "\nВ парке работают " + dataDrivers.Count() + " водителей. " +
                "Данные водителей в таблице ниже.";
            oPara10.Range.Font.Bold = 0;
            oPara10.Format.SpaceAfter = 6;
            oPara10.Range.InsertParagraphAfter();


            //водители таблица
            //Insert a table, fill it with data, and make the first row
            //bold.

            Word.Table oTable1;
            Word.Range wrdRng1 = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable1 = oDoc.Tables.Add(wrdRng1, dataDrivers.Count() + 1, dataDrivers[0].Count(), ref oMissing, ref oMissing);
            oTable1.Range.ParagraphFormat.SpaceAfter = 0;
            oTable1.Cell(1, 1).Range.Text = "ФИО водителя";
            oTable1.Cell(1, 2).Range.Text = "Класс";
            int r1, c1;
            string strText1;
            for (r1 = 1; r1 <= dataDrivers.Count(); r1++)
                for (c1 = 1; c1 <= dataDrivers[0].Count(); c1++)
                {
                    strText1 = dataDrivers[r1 - 1][c1 - 1].ToString();
                    oTable1.Cell(r1 + 1, c1).Range.Text = strText1;
                }
            oTable1.Rows[1].Range.Font.Bold = 1;

            MessageBox.Show("Полный отчет по автопарку готов!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }

        private void выполнитьРезервноеКопированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string name = "Avtopark-BackUP";
                string path = @"C:\SQLdata\BACKUPS\";
                // если каталог не существует то создать
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    Directory.CreateDirectory(path);
                }

                // задаем имя для резервной копии
                var backupFileName = String.Format("{0}{1}-{2}.bak",
                    path, name, DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));

                var query = String.Format("BACKUP DATABASE [master] TO DISK = '{0}'",
                     backupFileName);

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.ExecuteNonQuery();

                MessageBox.Show("Резервное копирование базы данных успешно выполнено.",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripStatusLabel1.Text = "Резервное копирование базы данных успешно выполнено.";
                toolStripStatusLabel1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void восстановитьДанныеИзРезервнойКопииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Тут откроется форма и если будет нажата кнопка ОК 
            // тогда путь запишется в переменную path, а имя файла в backupFileName. 
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string mainPath = sqlConnection.Database;
                
                try
                {
                    sqlConnection.Close();
                    SqlConnection masterConn = new SqlConnection(masterConnString);
                    masterConn.Open();
                    string backupFileName = openFile.FileName;
                    string path = openFile.InitialDirectory;

                    //"собираем" запрос //WITH REPLACE \?
                    var query = String.Format("RESTORE DATABASE [Database1] FROM DISK = '{0}{1}'",
                         path, backupFileName);
                                        
                    SqlCommand command = new SqlCommand(query, masterConn);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Восстановление базы данных успешно выполнено.",
                                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripStatusLabel1.Text = "Восстановление базы данных успешно выполнено.";
                    toolStripStatusLabel1.Visible = true;
                    await sqlConnection.OpenAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}