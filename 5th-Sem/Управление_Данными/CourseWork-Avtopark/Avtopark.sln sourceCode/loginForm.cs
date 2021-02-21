using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtopark
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            //автозагрузка логина и пароля))
            comboBox1.Text = "Диспетчер";
            textBox2.Text = "dispetcher";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text)) &&
                (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                if (Convert.ToString(comboBox1.Text) == "Диспетчер")
                {
                    if (Convert.ToString(textBox2.Text) == "dispetcher")
                    {
                        this.Hide();
                        mainForm form = new mainForm();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Oшибка, неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Oшибка, поля 'Логин' и 'Пароль' не должны быть пустыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
