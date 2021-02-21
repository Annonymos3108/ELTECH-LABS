using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppFinal
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            loginFormLoad();
        }

        private void loginFormLoad()
        {
            logintextBox.Text = "Admin";
            passwdtextBox.Text = "admin";
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(logintextBox.Text) && !string.IsNullOrWhiteSpace(logintextBox.Text) &&
                !string.IsNullOrWhiteSpace(passwdtextBox.Text) && !string.IsNullOrWhiteSpace(passwdtextBox.Text))
            {
                if (logintextBox.Text == "Admin" && passwdtextBox.Text == "admin")
                {
                    this.Hide();
                    mainForm main = new mainForm();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин и/или пароль, проверьте правильность введенных данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Поля 'Логин' и 'Пароль' должны быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
