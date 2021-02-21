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

namespace Conference
{
    public partial class DeleteDoklad : Form
    {
        SqlConnection sqlConnection;
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                    @"C:\Users\arthu\source\repos\Conference\Conference.mdf;Integrated Security=True";
        public DeleteDoklad()
        {
            InitializeComponent();
        }

        //кнопка удаления доклада
        private async void удалить_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();


            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                string cmd = "DELETE FROM Доклады WHERE id_участник=@id_участник";
                SqlCommand command = new SqlCommand(cmd, sqlConnection);
                command.Parameters.AddWithValue("id_участник", textBox1.Text);
                
                try
                {
                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("Удалено!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ошибка!\n\nПоле 'id_участника' должен быть заполнен.", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sqlConnection.Close();
        }
    }
}
