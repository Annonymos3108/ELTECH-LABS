using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avtopark
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = "О программе Автопарк";
            this.labelProductName.Text = "Название продукта: Автопарк";
            this.labelVersion.Text = "Версия 1.0.0.0";
            this.labelCopyright.Text = "Авторские права: (c) Артур Нерсисян 2020";
            this.labelCompanyName.Text = "Название организации: СПбГЭТУ 'ЛЭТИ'";
            this.textBoxDescription.Text = "Описание \n Данная программа была разработана в рамках курсового проекта по дисциплине 'Управление данными' в 2020 году.";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
