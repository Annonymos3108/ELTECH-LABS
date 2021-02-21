
namespace Conference
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label странаLabel;
            System.Windows.Forms.Label фамилияLabel;
            System.Windows.Forms.Label городLabel;
            System.Windows.Forms.Label имяLabel;
            System.Windows.Forms.Label должностьLabel;
            System.Windows.Forms.Label отчествоLabel;
            System.Windows.Forms.Label место_работыLabel;
            System.Windows.Forms.Label адресLabel;
            System.Windows.Forms.Label кафедраLabel;
            System.Windows.Forms.Label почтовой_индексLabel;
            System.Windows.Forms.Label научное_направлвниеLabel;
            System.Windows.Forms.Label рабочий_телефонLabel;
            System.Windows.Forms.Label ученое_званиеLabel;
            System.Windows.Forms.Label домашний_телефонLabel;
            System.Windows.Forms.Label ученая_степеньLabel;
            System.Windows.Forms.Label e_mailLabel;
            System.Windows.Forms.Label названиеLabel;
            System.Windows.Forms.Label организаторLabel;
            System.Windows.Forms.Label статусLabel;
            System.Windows.Forms.Label дата_началоLabel;
            System.Windows.Forms.Label оргвзносLabel;
            System.Windows.Forms.Label id_авторLabel;
            System.Windows.Forms.Label id_конференцияLabel;
            System.Windows.Forms.Label id_гостиницаLabel;
            System.Windows.Forms.Label дата_поступления_оргвзносаLabel;
            System.Windows.Forms.Label дата_поступления_заявкиLabel;
            System.Windows.Forms.Label дата_приездаLabel;
            System.Windows.Forms.Label дата_отездаLabel;
            System.Windows.Forms.Label id_участникLabel1;
            System.Windows.Forms.Label тема_докладаLabel;
            System.Windows.Forms.Label количество_страницLabel;
            System.Windows.Forms.Label соавторыLabel;
            System.Windows.Forms.Label названиеLabel1;
            System.Windows.Forms.Label адресLabel1;
            System.Windows.Forms.Label стоимость_номераLabel;
            System.Windows.Forms.Label странаLabel1;
            System.Windows.Forms.Label городLabel1;
            System.Windows.Forms.Label размер_оргвзносаLabel;
            System.Windows.Forms.Label дата_рассылки_1_ого_приглашенияLabel;
            System.Windows.Forms.Label дата_рассылки_2_ого_приглашенияLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label18;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_автор = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Фамилия = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Имя = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Отчество = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Адрес = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Почтовой_индекс = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Рабочий_телефон = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Домашний_телефон = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.e_mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ученая_степень = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ученое_звание = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Научное_направление = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Кафедра = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Место_работы = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Должность = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Страна = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Город = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.странаTextBox = new System.Windows.Forms.TextBox();
            this.локацияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conferenceDataSet = new Conference.ConferenceDataSet();
            this.фамилияTextBox = new System.Windows.Forms.TextBox();
            this.авторыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.городTextBox = new System.Windows.Forms.TextBox();
            this.должностьTextBox = new System.Windows.Forms.TextBox();
            this.имяTextBox = new System.Windows.Forms.TextBox();
            this.место_работыTextBox = new System.Windows.Forms.TextBox();
            this.отчествоTextBox = new System.Windows.Forms.TextBox();
            this.кафедраTextBox = new System.Windows.Forms.TextBox();
            this.адресTextBox = new System.Windows.Forms.TextBox();
            this.научное_направлвниеTextBox = new System.Windows.Forms.TextBox();
            this.почтовой_индексTextBox = new System.Windows.Forms.TextBox();
            this.ученое_званиеTextBox = new System.Windows.Forms.TextBox();
            this.рабочий_телефонTextBox = new System.Windows.Forms.TextBox();
            this.ученая_степеньTextBox = new System.Windows.Forms.TextBox();
            this.домашний_телефонTextBox = new System.Windows.Forms.TextBox();
            this.e_mailTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Conferences = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.id_конференция = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Название = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Организатор = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Статус = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата_начала = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Оргвзнос = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.названиеTextBox = new System.Windows.Forms.TextBox();
            this.конференцииBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.организаторTextBox = new System.Windows.Forms.TextBox();
            this.статусTextBox = new System.Windows.Forms.TextBox();
            this.дата_началоDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.оргвзносTextBox = new System.Windows.Forms.TextBox();
            this.Autors = new System.Windows.Forms.TabPage();
            this.Uchastniki = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.дата_рассылки_1_ого_приглашенияDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.участникиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.дата_рассылки_2_ого_приглашенияDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.размер_оргвзносаTextBox = new System.Windows.Forms.TextBox();
            this.участникиBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.conferenceDataSet1 = new Conference.ConferenceDataSet1();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.id_участник = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_автор1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_конференции3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_гостиница1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата_поступления_оргвзноса = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Размер_оргвзноса = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата_поступления_заявки = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата_рассылки_1_ого_приглашения3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата_рассылки_2_ого_приглашения3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата_приезда = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Дата_отезда = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Докладчик_участник = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Потребность_в_гостинице = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.id_конференцияTextBox = new System.Windows.Forms.TextBox();
            this.дата_поступления_оргвзносаDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.дата_поступления_заявкиDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.дата_приездаDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.дата_отездаDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.докладчик_участникCheckBox = new System.Windows.Forms.CheckBox();
            this.потребность_в_гостиницеCheckBox = new System.Windows.Forms.CheckBox();
            this.Doklad = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.тезисcheckBox = new System.Windows.Forms.CheckBox();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.id_участник2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Тема_доклада = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Отметка_о_поступлении_тезисов = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Количество_страниц = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Соавторы = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.id_участникTextBox1 = new System.Windows.Forms.TextBox();
            this.докладыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.тема_докладаTextBox = new System.Windows.Forms.TextBox();
            this.количество_страницTextBox = new System.Windows.Forms.TextBox();
            this.соавторыTextBox = new System.Windows.Forms.TextBox();
            this.Hotels = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.id_гостиница = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Название3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Адрес3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Страна3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Город3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Стоимость_номера = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.странаTextBox1 = new System.Windows.Forms.TextBox();
            this.городTextBox1 = new System.Windows.Forms.TextBox();
            this.названиеTextBox1 = new System.Windows.Forms.TextBox();
            this.гостиницыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.адресTextBox1 = new System.Windows.Forms.TextBox();
            this.стоимость_номераTextBox = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button15 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.город2textbox = new System.Windows.Forms.TextBox();
            this.idconference12 = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button14 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gorodtextbox = new System.Windows.Forms.TextBox();
            this.idconfertextbox = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.idConference = new System.Windows.Forms.TextBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.участникиTableAdapter1 = new Conference.ConferenceDataSet1TableAdapters.УчастникиTableAdapter();
            this.tableAdapterManager1 = new Conference.ConferenceDataSet1TableAdapters.TableAdapterManager();
            this.авторыTableAdapter = new Conference.ConferenceDataSetTableAdapters.АвторыTableAdapter();
            this.tableAdapterManager = new Conference.ConferenceDataSetTableAdapters.TableAdapterManager();
            this.гостиницыTableAdapter = new Conference.ConferenceDataSetTableAdapters.ГостиницыTableAdapter();
            this.докладыTableAdapter = new Conference.ConferenceDataSetTableAdapters.ДокладыTableAdapter();
            this.конференцииTableAdapter = new Conference.ConferenceDataSetTableAdapters.КонференцииTableAdapter();
            this.локацияTableAdapter = new Conference.ConferenceDataSetTableAdapters.ЛокацияTableAdapter();
            this.участникиTableAdapter = new Conference.ConferenceDataSetTableAdapters.УчастникиTableAdapter();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            странаLabel = new System.Windows.Forms.Label();
            фамилияLabel = new System.Windows.Forms.Label();
            городLabel = new System.Windows.Forms.Label();
            имяLabel = new System.Windows.Forms.Label();
            должностьLabel = new System.Windows.Forms.Label();
            отчествоLabel = new System.Windows.Forms.Label();
            место_работыLabel = new System.Windows.Forms.Label();
            адресLabel = new System.Windows.Forms.Label();
            кафедраLabel = new System.Windows.Forms.Label();
            почтовой_индексLabel = new System.Windows.Forms.Label();
            научное_направлвниеLabel = new System.Windows.Forms.Label();
            рабочий_телефонLabel = new System.Windows.Forms.Label();
            ученое_званиеLabel = new System.Windows.Forms.Label();
            домашний_телефонLabel = new System.Windows.Forms.Label();
            ученая_степеньLabel = new System.Windows.Forms.Label();
            e_mailLabel = new System.Windows.Forms.Label();
            названиеLabel = new System.Windows.Forms.Label();
            организаторLabel = new System.Windows.Forms.Label();
            статусLabel = new System.Windows.Forms.Label();
            дата_началоLabel = new System.Windows.Forms.Label();
            оргвзносLabel = new System.Windows.Forms.Label();
            id_авторLabel = new System.Windows.Forms.Label();
            id_конференцияLabel = new System.Windows.Forms.Label();
            id_гостиницаLabel = new System.Windows.Forms.Label();
            дата_поступления_оргвзносаLabel = new System.Windows.Forms.Label();
            дата_поступления_заявкиLabel = new System.Windows.Forms.Label();
            дата_приездаLabel = new System.Windows.Forms.Label();
            дата_отездаLabel = new System.Windows.Forms.Label();
            id_участникLabel1 = new System.Windows.Forms.Label();
            тема_докладаLabel = new System.Windows.Forms.Label();
            количество_страницLabel = new System.Windows.Forms.Label();
            соавторыLabel = new System.Windows.Forms.Label();
            названиеLabel1 = new System.Windows.Forms.Label();
            адресLabel1 = new System.Windows.Forms.Label();
            стоимость_номераLabel = new System.Windows.Forms.Label();
            странаLabel1 = new System.Windows.Forms.Label();
            городLabel1 = new System.Windows.Forms.Label();
            размер_оргвзносаLabel = new System.Windows.Forms.Label();
            дата_рассылки_1_ого_приглашенияLabel = new System.Windows.Forms.Label();
            дата_рассылки_2_ого_приглашенияLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.локацияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conferenceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.авторыBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Conferences.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.конференцииBindingSource)).BeginInit();
            this.Autors.SuspendLayout();
            this.Uchastniki.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.участникиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.участникиBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conferenceDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.Doklad.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.докладыBindingSource)).BeginInit();
            this.Hotels.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.гостиницыBindingSource)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // странаLabel
            // 
            странаLabel.AutoSize = true;
            странаLabel.Location = new System.Drawing.Point(702, 83);
            странаLabel.Name = "странаLabel";
            странаLabel.Size = new System.Drawing.Size(46, 13);
            странаLabel.TabIndex = 67;
            странаLabel.Text = "Страна:";
            // 
            // фамилияLabel
            // 
            фамилияLabel.AutoSize = true;
            фамилияLabel.Location = new System.Drawing.Point(15, 28);
            фамилияLabel.Name = "фамилияLabel";
            фамилияLabel.Size = new System.Drawing.Size(59, 13);
            фамилияLabel.TabIndex = 39;
            фамилияLabel.Text = "Фамилия:";
            // 
            // городLabel
            // 
            городLabel.AutoSize = true;
            городLabel.Location = new System.Drawing.Point(702, 109);
            городLabel.Name = "городLabel";
            городLabel.Size = new System.Drawing.Size(40, 13);
            городLabel.TabIndex = 69;
            городLabel.Text = "Город:";
            // 
            // имяLabel
            // 
            имяLabel.AutoSize = true;
            имяLabel.Location = new System.Drawing.Point(15, 54);
            имяLabel.Name = "имяLabel";
            имяLabel.Size = new System.Drawing.Size(32, 13);
            имяLabel.TabIndex = 41;
            имяLabel.Text = "Имя:";
            // 
            // должностьLabel
            // 
            должностьLabel.AutoSize = true;
            должностьLabel.Location = new System.Drawing.Point(702, 57);
            должностьLabel.Name = "должностьLabel";
            должностьLabel.Size = new System.Drawing.Size(68, 13);
            должностьLabel.TabIndex = 65;
            должностьLabel.Text = "Должность:";
            // 
            // отчествоLabel
            // 
            отчествоLabel.AutoSize = true;
            отчествоLabel.Location = new System.Drawing.Point(15, 80);
            отчествоLabel.Name = "отчествоLabel";
            отчествоLabel.Size = new System.Drawing.Size(57, 13);
            отчествоLabel.TabIndex = 43;
            отчествоLabel.Text = "Отчество:";
            // 
            // место_работыLabel
            // 
            место_работыLabel.AutoSize = true;
            место_работыLabel.Location = new System.Drawing.Point(702, 28);
            место_работыLabel.Name = "место_работыLabel";
            место_работыLabel.Size = new System.Drawing.Size(82, 13);
            место_работыLabel.TabIndex = 63;
            место_работыLabel.Text = "Место работы:";
            // 
            // адресLabel
            // 
            адресLabel.AutoSize = true;
            адресLabel.Location = new System.Drawing.Point(365, 28);
            адресLabel.Name = "адресLabel";
            адресLabel.Size = new System.Drawing.Size(41, 13);
            адресLabel.TabIndex = 45;
            адресLabel.Text = "Адрес:";
            // 
            // кафедраLabel
            // 
            кафедраLabel.AutoSize = true;
            кафедраLabel.Location = new System.Drawing.Point(365, 158);
            кафедраLabel.Name = "кафедраLabel";
            кафедраLabel.Size = new System.Drawing.Size(55, 13);
            кафедраLabel.TabIndex = 61;
            кафедраLabel.Text = "Кафедра:";
            // 
            // почтовой_индексLabel
            // 
            почтовой_индексLabel.AutoSize = true;
            почтовой_индексLabel.Location = new System.Drawing.Point(365, 54);
            почтовой_индексLabel.Name = "почтовой_индексLabel";
            почтовой_индексLabel.Size = new System.Drawing.Size(97, 13);
            почтовой_индексLabel.TabIndex = 47;
            почтовой_индексLabel.Text = "Почтовой индекс:";
            // 
            // научное_направлвниеLabel
            // 
            научное_направлвниеLabel.AutoSize = true;
            научное_направлвниеLabel.Location = new System.Drawing.Point(15, 158);
            научное_направлвниеLabel.Name = "научное_направлвниеLabel";
            научное_направлвниеLabel.Size = new System.Drawing.Size(121, 13);
            научное_направлвниеLabel.TabIndex = 59;
            научное_направлвниеLabel.Text = "Научное направлвние:";
            // 
            // рабочий_телефонLabel
            // 
            рабочий_телефонLabel.AutoSize = true;
            рабочий_телефонLabel.Location = new System.Drawing.Point(365, 80);
            рабочий_телефонLabel.Name = "рабочий_телефонLabel";
            рабочий_телефонLabel.Size = new System.Drawing.Size(98, 13);
            рабочий_телефонLabel.TabIndex = 49;
            рабочий_телефонLabel.Text = "Рабочий телефон:";
            // 
            // ученое_званиеLabel
            // 
            ученое_званиеLabel.AutoSize = true;
            ученое_званиеLabel.Location = new System.Drawing.Point(15, 132);
            ученое_званиеLabel.Name = "ученое_званиеLabel";
            ученое_званиеLabel.Size = new System.Drawing.Size(86, 13);
            ученое_званиеLabel.TabIndex = 57;
            ученое_званиеLabel.Text = "Ученое звание:";
            // 
            // домашний_телефонLabel
            // 
            домашний_телефонLabel.AutoSize = true;
            домашний_телефонLabel.Location = new System.Drawing.Point(365, 106);
            домашний_телефонLabel.Name = "домашний_телефонLabel";
            домашний_телефонLabel.Size = new System.Drawing.Size(111, 13);
            домашний_телефонLabel.TabIndex = 51;
            домашний_телефонLabel.Text = "Домашний телефон:";
            // 
            // ученая_степеньLabel
            // 
            ученая_степеньLabel.AutoSize = true;
            ученая_степеньLabel.Location = new System.Drawing.Point(15, 106);
            ученая_степеньLabel.Name = "ученая_степеньLabel";
            ученая_степеньLabel.Size = new System.Drawing.Size(91, 13);
            ученая_степеньLabel.TabIndex = 55;
            ученая_степеньLabel.Text = "Ученая степень:";
            // 
            // e_mailLabel
            // 
            e_mailLabel.AutoSize = true;
            e_mailLabel.Location = new System.Drawing.Point(365, 132);
            e_mailLabel.Name = "e_mailLabel";
            e_mailLabel.Size = new System.Drawing.Size(37, 13);
            e_mailLabel.TabIndex = 53;
            e_mailLabel.Text = "e mail:";
            // 
            // названиеLabel
            // 
            названиеLabel.AutoSize = true;
            названиеLabel.Location = new System.Drawing.Point(15, 33);
            названиеLabel.Name = "названиеLabel";
            названиеLabel.Size = new System.Drawing.Size(60, 13);
            названиеLabel.TabIndex = 2;
            названиеLabel.Text = "Название:";
            // 
            // организаторLabel
            // 
            организаторLabel.AutoSize = true;
            организаторLabel.Location = new System.Drawing.Point(15, 59);
            организаторLabel.Name = "организаторLabel";
            организаторLabel.Size = new System.Drawing.Size(76, 13);
            организаторLabel.TabIndex = 4;
            организаторLabel.Text = "Организатор:";
            // 
            // статусLabel
            // 
            статусLabel.AutoSize = true;
            статусLabel.Location = new System.Drawing.Point(336, 33);
            статусLabel.Name = "статусLabel";
            статусLabel.Size = new System.Drawing.Size(44, 13);
            статусLabel.TabIndex = 6;
            статусLabel.Text = "Статус:";
            // 
            // дата_началоLabel
            // 
            дата_началоLabel.AutoSize = true;
            дата_началоLabel.Location = new System.Drawing.Point(624, 62);
            дата_началоLabel.Name = "дата_началоLabel";
            дата_началоLabel.Size = new System.Drawing.Size(74, 13);
            дата_началоLabel.TabIndex = 8;
            дата_началоLabel.Text = "Дата начало:";
            // 
            // оргвзносLabel
            // 
            оргвзносLabel.AutoSize = true;
            оргвзносLabel.Location = new System.Drawing.Point(624, 32);
            оргвзносLabel.Name = "оргвзносLabel";
            оргвзносLabel.Size = new System.Drawing.Size(59, 13);
            оргвзносLabel.TabIndex = 10;
            оргвзносLabel.Text = "Оргвзнос:";
            // 
            // id_авторLabel
            // 
            id_авторLabel.AutoSize = true;
            id_авторLabel.Location = new System.Drawing.Point(697, 27);
            id_авторLabel.Name = "id_авторLabel";
            id_авторLabel.Size = new System.Drawing.Size(50, 13);
            id_авторLabel.TabIndex = 2;
            id_авторLabel.Text = "id автор:";
            // 
            // id_конференцияLabel
            // 
            id_конференцияLabel.AutoSize = true;
            id_конференцияLabel.Location = new System.Drawing.Point(697, 82);
            id_конференцияLabel.Name = "id_конференцияLabel";
            id_конференцияLabel.Size = new System.Drawing.Size(89, 13);
            id_конференцияLabel.TabIndex = 4;
            id_конференцияLabel.Text = "id конференция:";
            // 
            // id_гостиницаLabel
            // 
            id_гостиницаLabel.AutoSize = true;
            id_гостиницаLabel.Location = new System.Drawing.Point(697, 53);
            id_гостиницаLabel.Name = "id_гостиницаLabel";
            id_гостиницаLabel.Size = new System.Drawing.Size(73, 13);
            id_гостиницаLabel.TabIndex = 6;
            id_гостиницаLabel.Text = "id гостиница:";
            // 
            // дата_поступления_оргвзносаLabel
            // 
            дата_поступления_оргвзносаLabel.AutoSize = true;
            дата_поступления_оргвзносаLabel.Location = new System.Drawing.Point(17, 26);
            дата_поступления_оргвзносаLabel.Name = "дата_поступления_оргвзносаLabel";
            дата_поступления_оргвзносаLabel.Size = new System.Drawing.Size(159, 13);
            дата_поступления_оргвзносаLabel.TabIndex = 8;
            дата_поступления_оргвзносаLabel.Text = "Дата поступления оргвзноса:";
            // 
            // дата_поступления_заявкиLabel
            // 
            дата_поступления_заявкиLabel.AutoSize = true;
            дата_поступления_заявкиLabel.Location = new System.Drawing.Point(17, 53);
            дата_поступления_заявкиLabel.Name = "дата_поступления_заявкиLabel";
            дата_поступления_заявкиLabel.Size = new System.Drawing.Size(142, 13);
            дата_поступления_заявкиLabel.TabIndex = 10;
            дата_поступления_заявкиLabel.Text = "Дата поступления заявки:";
            // 
            // дата_приездаLabel
            // 
            дата_приездаLabel.AutoSize = true;
            дата_приездаLabel.Location = new System.Drawing.Point(17, 82);
            дата_приездаLabel.Name = "дата_приездаLabel";
            дата_приездаLabel.Size = new System.Drawing.Size(81, 13);
            дата_приездаLabel.TabIndex = 16;
            дата_приездаLabel.Text = "Дата приезда:";
            // 
            // дата_отездаLabel
            // 
            дата_отездаLabel.AutoSize = true;
            дата_отездаLabel.Location = new System.Drawing.Point(17, 108);
            дата_отездаLabel.Name = "дата_отездаLabel";
            дата_отездаLabel.Size = new System.Drawing.Size(74, 13);
            дата_отездаLabel.TabIndex = 18;
            дата_отездаLabel.Text = "Дата отезда:";
            // 
            // id_участникLabel1
            // 
            id_участникLabel1.AutoSize = true;
            id_участникLabel1.Location = new System.Drawing.Point(19, 25);
            id_участникLabel1.Name = "id_участникLabel1";
            id_участникLabel1.Size = new System.Drawing.Size(66, 13);
            id_участникLabel1.TabIndex = 0;
            id_участникLabel1.Text = "id участник:";
            // 
            // тема_докладаLabel
            // 
            тема_докладаLabel.AutoSize = true;
            тема_докладаLabel.Location = new System.Drawing.Point(19, 51);
            тема_докладаLabel.Name = "тема_докладаLabel";
            тема_докладаLabel.Size = new System.Drawing.Size(82, 13);
            тема_докладаLabel.TabIndex = 2;
            тема_докладаLabel.Text = "Тема доклада:";
            // 
            // количество_страницLabel
            // 
            количество_страницLabel.AutoSize = true;
            количество_страницLabel.Location = new System.Drawing.Point(299, 25);
            количество_страницLabel.Name = "количество_страницLabel";
            количество_страницLabel.Size = new System.Drawing.Size(113, 13);
            количество_страницLabel.TabIndex = 4;
            количество_страницLabel.Text = "Количество страниц:";
            // 
            // соавторыLabel
            // 
            соавторыLabel.AutoSize = true;
            соавторыLabel.Location = new System.Drawing.Point(299, 51);
            соавторыLabel.Name = "соавторыLabel";
            соавторыLabel.Size = new System.Drawing.Size(60, 13);
            соавторыLabel.TabIndex = 6;
            соавторыLabel.Text = "Соавторы:";
            // 
            // названиеLabel1
            // 
            названиеLabel1.AutoSize = true;
            названиеLabel1.Location = new System.Drawing.Point(20, 23);
            названиеLabel1.Name = "названиеLabel1";
            названиеLabel1.Size = new System.Drawing.Size(60, 13);
            названиеLabel1.TabIndex = 2;
            названиеLabel1.Text = "Название:";
            // 
            // адресLabel1
            // 
            адресLabel1.AutoSize = true;
            адресLabel1.Location = new System.Drawing.Point(20, 49);
            адресLabel1.Name = "адресLabel1";
            адресLabel1.Size = new System.Drawing.Size(41, 13);
            адресLabel1.TabIndex = 6;
            адресLabel1.Text = "Адрес:";
            // 
            // стоимость_номераLabel
            // 
            стоимость_номераLabel.AutoSize = true;
            стоимость_номераLabel.Location = new System.Drawing.Point(488, 75);
            стоимость_номераLabel.Name = "стоимость_номераLabel";
            стоимость_номераLabel.Size = new System.Drawing.Size(106, 13);
            стоимость_номераLabel.TabIndex = 8;
            стоимость_номераLabel.Text = "Стоимость номера:";
            // 
            // странаLabel1
            // 
            странаLabel1.AutoSize = true;
            странаLabel1.Location = new System.Drawing.Point(488, 23);
            странаLabel1.Name = "странаLabel1";
            странаLabel1.Size = new System.Drawing.Size(46, 13);
            странаLabel1.TabIndex = 11;
            странаLabel1.Text = "Страна:";
            // 
            // городLabel1
            // 
            городLabel1.AutoSize = true;
            городLabel1.Location = new System.Drawing.Point(488, 49);
            городLabel1.Name = "городLabel1";
            городLabel1.Size = new System.Drawing.Size(40, 13);
            городLabel1.TabIndex = 13;
            городLabel1.Text = "Город:";
            // 
            // размер_оргвзносаLabel
            // 
            размер_оргвзносаLabel.AutoSize = true;
            размер_оргвзносаLabel.Location = new System.Drawing.Point(345, 82);
            размер_оргвзносаLabel.Name = "размер_оргвзносаLabel";
            размер_оргвзносаLabel.Size = new System.Drawing.Size(105, 13);
            размер_оргвзносаLabel.TabIndex = 26;
            размер_оргвзносаLabel.Text = "Размер оргвзноса:";
            // 
            // дата_рассылки_1_ого_приглашенияLabel
            // 
            дата_рассылки_1_ого_приглашенияLabel.AutoSize = true;
            дата_рассылки_1_ого_приглашенияLabel.Location = new System.Drawing.Point(345, 26);
            дата_рассылки_1_ого_приглашенияLabel.Name = "дата_рассылки_1_ого_приглашенияLabel";
            дата_рассылки_1_ого_приглашенияLabel.Size = new System.Drawing.Size(188, 13);
            дата_рассылки_1_ого_приглашенияLabel.TabIndex = 28;
            дата_рассылки_1_ого_приглашенияLabel.Text = "Дата рассылки 1 ого приглашения:";
            // 
            // дата_рассылки_2_ого_приглашенияLabel
            // 
            дата_рассылки_2_ого_приглашенияLabel.AutoSize = true;
            дата_рассылки_2_ого_приглашенияLabel.Location = new System.Drawing.Point(345, 56);
            дата_рассылки_2_ого_приглашенияLabel.Name = "дата_рассылки_2_ого_приглашенияLabel";
            дата_рассылки_2_ого_приглашенияLabel.Size = new System.Drawing.Size(188, 13);
            дата_рассылки_2_ого_приглашенияLabel.TabIndex = 30;
            дата_рассылки_2_ого_приглашенияLabel.Text = "Дата рассылки 2 ого приглашения:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.Location = new System.Drawing.Point(797, 23);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(121, 18);
            label2.TabIndex = 6;
            label2.Text = "id конференция:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label4.Location = new System.Drawing.Point(797, 23);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(121, 18);
            label4.TabIndex = 6;
            label4.Text = "id конференция:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label8.Location = new System.Drawing.Point(797, 43);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(121, 18);
            label8.TabIndex = 6;
            label8.Text = "id конференция:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label11.Location = new System.Drawing.Point(797, 43);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(121, 18);
            label11.TabIndex = 6;
            label11.Text = "id конференция:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label15.Location = new System.Drawing.Point(797, 26);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(121, 18);
            label15.TabIndex = 6;
            label15.Text = "id конференция:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label18.Location = new System.Drawing.Point(709, 85);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(121, 18);
            label18.TabIndex = 8;
            label18.Text = "id конференция:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.button18);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(странаLabel);
            this.groupBox1.Controls.Add(this.странаTextBox);
            this.groupBox1.Controls.Add(фамилияLabel);
            this.groupBox1.Controls.Add(городLabel);
            this.groupBox1.Controls.Add(this.фамилияTextBox);
            this.groupBox1.Controls.Add(this.городTextBox);
            this.groupBox1.Controls.Add(имяLabel);
            this.groupBox1.Controls.Add(this.должностьTextBox);
            this.groupBox1.Controls.Add(this.имяTextBox);
            this.groupBox1.Controls.Add(должностьLabel);
            this.groupBox1.Controls.Add(отчествоLabel);
            this.groupBox1.Controls.Add(this.место_работыTextBox);
            this.groupBox1.Controls.Add(this.отчествоTextBox);
            this.groupBox1.Controls.Add(место_работыLabel);
            this.groupBox1.Controls.Add(адресLabel);
            this.groupBox1.Controls.Add(this.кафедраTextBox);
            this.groupBox1.Controls.Add(this.адресTextBox);
            this.groupBox1.Controls.Add(кафедраLabel);
            this.groupBox1.Controls.Add(почтовой_индексLabel);
            this.groupBox1.Controls.Add(this.научное_направлвниеTextBox);
            this.groupBox1.Controls.Add(this.почтовой_индексTextBox);
            this.groupBox1.Controls.Add(научное_направлвниеLabel);
            this.groupBox1.Controls.Add(рабочий_телефонLabel);
            this.groupBox1.Controls.Add(this.ученое_званиеTextBox);
            this.groupBox1.Controls.Add(this.рабочий_телефонTextBox);
            this.groupBox1.Controls.Add(ученое_званиеLabel);
            this.groupBox1.Controls.Add(домашний_телефонLabel);
            this.groupBox1.Controls.Add(this.ученая_степеньTextBox);
            this.groupBox1.Controls.Add(this.домашний_телефонTextBox);
            this.groupBox1.Controls.Add(ученая_степеньLabel);
            this.groupBox1.Controls.Add(e_mailLabel);
            this.groupBox1.Controls.Add(this.e_mailTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1250, 437);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные автора";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_автор,
            this.Фамилия,
            this.Имя,
            this.Отчество,
            this.Адрес,
            this.Почтовой_индекс,
            this.Рабочий_телефон,
            this.Домашний_телефон,
            this.e_mail,
            this.Ученая_степень,
            this.Ученое_звание,
            this.Научное_направление,
            this.Кафедра,
            this.Место_работы,
            this.Должность,
            this.Страна,
            this.Город});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(3, 194);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1244, 240);
            this.dataGridView1.TabIndex = 72;
            // 
            // id_автор
            // 
            this.id_автор.HeaderText = "id_автор";
            this.id_автор.Name = "id_автор";
            // 
            // Фамилия
            // 
            this.Фамилия.HeaderText = "Фамилия";
            this.Фамилия.Name = "Фамилия";
            // 
            // Имя
            // 
            this.Имя.HeaderText = "Имя";
            this.Имя.Name = "Имя";
            // 
            // Отчество
            // 
            this.Отчество.HeaderText = "Отчество";
            this.Отчество.Name = "Отчество";
            // 
            // Адрес
            // 
            this.Адрес.HeaderText = "Адрес";
            this.Адрес.Name = "Адрес";
            // 
            // Почтовой_индекс
            // 
            this.Почтовой_индекс.HeaderText = "Почтовой_индекс";
            this.Почтовой_индекс.Name = "Почтовой_индекс";
            // 
            // Рабочий_телефон
            // 
            this.Рабочий_телефон.HeaderText = "Рабочий_телефон";
            this.Рабочий_телефон.Name = "Рабочий_телефон";
            // 
            // Домашний_телефон
            // 
            this.Домашний_телефон.HeaderText = "Домашний_телефон";
            this.Домашний_телефон.Name = "Домашний_телефон";
            // 
            // e_mail
            // 
            this.e_mail.HeaderText = "e_mail";
            this.e_mail.Name = "e_mail";
            // 
            // Ученая_степень
            // 
            this.Ученая_степень.HeaderText = "Ученая_степень";
            this.Ученая_степень.Name = "Ученая_степень";
            // 
            // Ученое_звание
            // 
            this.Ученое_звание.HeaderText = "Ученое_звание";
            this.Ученое_звание.Name = "Ученое_звание";
            // 
            // Научное_направление
            // 
            this.Научное_направление.HeaderText = "Научное_направление";
            this.Научное_направление.Name = "Научное_направление";
            // 
            // Кафедра
            // 
            this.Кафедра.HeaderText = "Кафедра";
            this.Кафедра.Name = "Кафедра";
            // 
            // Место_работы
            // 
            this.Место_работы.HeaderText = "Место_работы";
            this.Место_работы.Name = "Место_работы";
            // 
            // Должность
            // 
            this.Должность.HeaderText = "Должность";
            this.Должность.Name = "Должность";
            // 
            // Страна
            // 
            this.Страна.HeaderText = "Страна";
            this.Страна.Name = "Страна";
            // 
            // Город
            // 
            this.Город.HeaderText = "Город";
            this.Город.Name = "Город";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1057, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 30);
            this.button2.TabIndex = 71;
            this.button2.Text = "Удалить данные автора";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1057, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 30);
            this.button1.TabIndex = 71;
            this.button1.Text = "Добавить данные автора";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // странаTextBox
            // 
            this.странаTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.локацияBindingSource, "Страна", true));
            this.странаTextBox.Location = new System.Drawing.Point(829, 80);
            this.странаTextBox.Name = "странаTextBox";
            this.странаTextBox.Size = new System.Drawing.Size(176, 20);
            this.странаTextBox.TabIndex = 68;
            // 
            // локацияBindingSource
            // 
            this.локацияBindingSource.DataMember = "Локация";
            this.локацияBindingSource.DataSource = this.conferenceDataSet;
            // 
            // conferenceDataSet
            // 
            this.conferenceDataSet.DataSetName = "ConferenceDataSet";
            this.conferenceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // фамилияTextBox
            // 
            this.фамилияTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Фамилия", true));
            this.фамилияTextBox.Location = new System.Drawing.Point(142, 25);
            this.фамилияTextBox.Name = "фамилияTextBox";
            this.фамилияTextBox.Size = new System.Drawing.Size(176, 20);
            this.фамилияTextBox.TabIndex = 40;
            // 
            // авторыBindingSource
            // 
            this.авторыBindingSource.DataMember = "Авторы";
            this.авторыBindingSource.DataSource = this.conferenceDataSet;
            // 
            // городTextBox
            // 
            this.городTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.локацияBindingSource, "Город", true));
            this.городTextBox.Location = new System.Drawing.Point(829, 106);
            this.городTextBox.Name = "городTextBox";
            this.городTextBox.Size = new System.Drawing.Size(176, 20);
            this.городTextBox.TabIndex = 70;
            // 
            // должностьTextBox
            // 
            this.должностьTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Должность", true));
            this.должностьTextBox.Location = new System.Drawing.Point(829, 54);
            this.должностьTextBox.Name = "должностьTextBox";
            this.должностьTextBox.Size = new System.Drawing.Size(176, 20);
            this.должностьTextBox.TabIndex = 66;
            // 
            // имяTextBox
            // 
            this.имяTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Имя", true));
            this.имяTextBox.Location = new System.Drawing.Point(142, 51);
            this.имяTextBox.Name = "имяTextBox";
            this.имяTextBox.Size = new System.Drawing.Size(176, 20);
            this.имяTextBox.TabIndex = 42;
            // 
            // место_работыTextBox
            // 
            this.место_работыTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Место_работы", true));
            this.место_работыTextBox.Location = new System.Drawing.Point(829, 25);
            this.место_работыTextBox.Name = "место_работыTextBox";
            this.место_работыTextBox.Size = new System.Drawing.Size(176, 20);
            this.место_работыTextBox.TabIndex = 64;
            // 
            // отчествоTextBox
            // 
            this.отчествоTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Отчество", true));
            this.отчествоTextBox.Location = new System.Drawing.Point(142, 77);
            this.отчествоTextBox.Name = "отчествоTextBox";
            this.отчествоTextBox.Size = new System.Drawing.Size(176, 20);
            this.отчествоTextBox.TabIndex = 44;
            // 
            // кафедраTextBox
            // 
            this.кафедраTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Кафедра", true));
            this.кафедраTextBox.Location = new System.Drawing.Point(492, 155);
            this.кафедраTextBox.Name = "кафедраTextBox";
            this.кафедраTextBox.Size = new System.Drawing.Size(176, 20);
            this.кафедраTextBox.TabIndex = 62;
            // 
            // адресTextBox
            // 
            this.адресTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Адрес", true));
            this.адресTextBox.Location = new System.Drawing.Point(492, 25);
            this.адресTextBox.Name = "адресTextBox";
            this.адресTextBox.Size = new System.Drawing.Size(176, 20);
            this.адресTextBox.TabIndex = 46;
            // 
            // научное_направлвниеTextBox
            // 
            this.научное_направлвниеTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Научное_направлвние", true));
            this.научное_направлвниеTextBox.Location = new System.Drawing.Point(142, 155);
            this.научное_направлвниеTextBox.Name = "научное_направлвниеTextBox";
            this.научное_направлвниеTextBox.Size = new System.Drawing.Size(176, 20);
            this.научное_направлвниеTextBox.TabIndex = 60;
            // 
            // почтовой_индексTextBox
            // 
            this.почтовой_индексTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Почтовой_индекс", true));
            this.почтовой_индексTextBox.Location = new System.Drawing.Point(492, 51);
            this.почтовой_индексTextBox.Name = "почтовой_индексTextBox";
            this.почтовой_индексTextBox.Size = new System.Drawing.Size(176, 20);
            this.почтовой_индексTextBox.TabIndex = 48;
            // 
            // ученое_званиеTextBox
            // 
            this.ученое_званиеTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Ученое_звание", true));
            this.ученое_званиеTextBox.Location = new System.Drawing.Point(142, 129);
            this.ученое_званиеTextBox.Name = "ученое_званиеTextBox";
            this.ученое_званиеTextBox.Size = new System.Drawing.Size(176, 20);
            this.ученое_званиеTextBox.TabIndex = 58;
            // 
            // рабочий_телефонTextBox
            // 
            this.рабочий_телефонTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Рабочий_телефон", true));
            this.рабочий_телефонTextBox.Location = new System.Drawing.Point(492, 77);
            this.рабочий_телефонTextBox.Name = "рабочий_телефонTextBox";
            this.рабочий_телефонTextBox.Size = new System.Drawing.Size(176, 20);
            this.рабочий_телефонTextBox.TabIndex = 50;
            // 
            // ученая_степеньTextBox
            // 
            this.ученая_степеньTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Ученая_степень", true));
            this.ученая_степеньTextBox.Location = new System.Drawing.Point(142, 103);
            this.ученая_степеньTextBox.Name = "ученая_степеньTextBox";
            this.ученая_степеньTextBox.Size = new System.Drawing.Size(176, 20);
            this.ученая_степеньTextBox.TabIndex = 56;
            // 
            // домашний_телефонTextBox
            // 
            this.домашний_телефонTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "Домашний_телефон", true));
            this.домашний_телефонTextBox.Location = new System.Drawing.Point(492, 103);
            this.домашний_телефонTextBox.Name = "домашний_телефонTextBox";
            this.домашний_телефонTextBox.Size = new System.Drawing.Size(176, 20);
            this.домашний_телефонTextBox.TabIndex = 52;
            // 
            // e_mailTextBox
            // 
            this.e_mailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.авторыBindingSource, "e_mail", true));
            this.e_mailTextBox.Location = new System.Drawing.Point(492, 129);
            this.e_mailTextBox.Name = "e_mailTextBox";
            this.e_mailTextBox.Size = new System.Drawing.Size(176, 20);
            this.e_mailTextBox.TabIndex = 54;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Conferences);
            this.tabControl1.Controls.Add(this.Autors);
            this.tabControl1.Controls.Add(this.Uchastniki);
            this.tabControl1.Controls.Add(this.Doklad);
            this.tabControl1.Controls.Add(this.Hotels);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1264, 476);
            this.tabControl1.TabIndex = 3;
            // 
            // Conferences
            // 
            this.Conferences.AutoScroll = true;
            this.Conferences.Controls.Add(this.groupBox2);
            this.Conferences.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Conferences.Location = new System.Drawing.Point(4, 29);
            this.Conferences.Name = "Conferences";
            this.Conferences.Padding = new System.Windows.Forms.Padding(3);
            this.Conferences.Size = new System.Drawing.Size(1256, 443);
            this.Conferences.TabIndex = 2;
            this.Conferences.Text = "Конференции";
            this.Conferences.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button17);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(названиеLabel);
            this.groupBox2.Controls.Add(this.названиеTextBox);
            this.groupBox2.Controls.Add(организаторLabel);
            this.groupBox2.Controls.Add(this.организаторTextBox);
            this.groupBox2.Controls.Add(статусLabel);
            this.groupBox2.Controls.Add(this.статусTextBox);
            this.groupBox2.Controls.Add(дата_началоLabel);
            this.groupBox2.Controls.Add(this.дата_началоDateTimePicker);
            this.groupBox2.Controls.Add(оргвзносLabel);
            this.groupBox2.Controls.Add(this.оргвзносTextBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1250, 437);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные конференции";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_конференция,
            this.Название,
            this.Организатор,
            this.Статус,
            this.Дата_начала,
            this.Оргвзнос});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView2.Location = new System.Drawing.Point(3, 106);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1244, 328);
            this.dataGridView2.TabIndex = 13;
            // 
            // id_конференция
            // 
            this.id_конференция.HeaderText = "id_конференция";
            this.id_конференция.Name = "id_конференция";
            // 
            // Название
            // 
            this.Название.HeaderText = "Название";
            this.Название.Name = "Название";
            // 
            // Организатор
            // 
            this.Организатор.HeaderText = "Организатор";
            this.Организатор.Name = "Организатор";
            // 
            // Статус
            // 
            this.Статус.HeaderText = "Статус";
            this.Статус.Name = "Статус";
            // 
            // Дата_начала
            // 
            this.Дата_начала.HeaderText = "Дата_начала";
            this.Дата_начала.Name = "Дата_начала";
            // 
            // Оргвзнос
            // 
            this.Оргвзнос.HeaderText = "Оргвзнос";
            this.Оргвзнос.Name = "Оргвзнос";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(886, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 33);
            this.button4.TabIndex = 12;
            this.button4.Text = "Добавить конференцию";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1056, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 33);
            this.button3.TabIndex = 12;
            this.button3.Text = "Удалить конференцию";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // названиеTextBox
            // 
            this.названиеTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.конференцииBindingSource, "Название", true));
            this.названиеTextBox.Location = new System.Drawing.Point(110, 30);
            this.названиеTextBox.Name = "названиеTextBox";
            this.названиеTextBox.Size = new System.Drawing.Size(200, 20);
            this.названиеTextBox.TabIndex = 3;
            // 
            // конференцииBindingSource
            // 
            this.конференцииBindingSource.DataMember = "Конференции";
            this.конференцииBindingSource.DataSource = this.conferenceDataSet;
            // 
            // организаторTextBox
            // 
            this.организаторTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.конференцииBindingSource, "Организатор", true));
            this.организаторTextBox.Location = new System.Drawing.Point(110, 56);
            this.организаторTextBox.Name = "организаторTextBox";
            this.организаторTextBox.Size = new System.Drawing.Size(200, 20);
            this.организаторTextBox.TabIndex = 5;
            // 
            // статусTextBox
            // 
            this.статусTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.конференцииBindingSource, "Статус", true));
            this.статусTextBox.Location = new System.Drawing.Point(386, 30);
            this.статусTextBox.Name = "статусTextBox";
            this.статусTextBox.Size = new System.Drawing.Size(200, 20);
            this.статусTextBox.TabIndex = 7;
            // 
            // дата_началоDateTimePicker
            // 
            this.дата_началоDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.конференцииBindingSource, "Дата_начало", true));
            this.дата_началоDateTimePicker.Location = new System.Drawing.Point(719, 59);
            this.дата_началоDateTimePicker.Name = "дата_началоDateTimePicker";
            this.дата_началоDateTimePicker.Size = new System.Drawing.Size(127, 20);
            this.дата_началоDateTimePicker.TabIndex = 9;
            // 
            // оргвзносTextBox
            // 
            this.оргвзносTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.конференцииBindingSource, "Оргвзнос", true));
            this.оргвзносTextBox.Location = new System.Drawing.Point(719, 29);
            this.оргвзносTextBox.Name = "оргвзносTextBox";
            this.оргвзносTextBox.Size = new System.Drawing.Size(127, 20);
            this.оргвзносTextBox.TabIndex = 11;
            // 
            // Autors
            // 
            this.Autors.Controls.Add(this.groupBox1);
            this.Autors.Location = new System.Drawing.Point(4, 29);
            this.Autors.Name = "Autors";
            this.Autors.Padding = new System.Windows.Forms.Padding(3);
            this.Autors.Size = new System.Drawing.Size(1256, 443);
            this.Autors.TabIndex = 0;
            this.Autors.Text = "Авторы";
            this.Autors.UseVisualStyleBackColor = true;
            // 
            // Uchastniki
            // 
            this.Uchastniki.Controls.Add(this.groupBox3);
            this.Uchastniki.Location = new System.Drawing.Point(4, 29);
            this.Uchastniki.Name = "Uchastniki";
            this.Uchastniki.Padding = new System.Windows.Forms.Padding(3);
            this.Uchastniki.Size = new System.Drawing.Size(1256, 443);
            this.Uchastniki.TabIndex = 1;
            this.Uchastniki.Text = "Участники";
            this.Uchastniki.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(дата_рассылки_1_ого_приглашенияLabel);
            this.groupBox3.Controls.Add(this.дата_рассылки_1_ого_приглашенияDateTimePicker);
            this.groupBox3.Controls.Add(дата_рассылки_2_ого_приглашенияLabel);
            this.groupBox3.Controls.Add(this.дата_рассылки_2_ого_приглашенияDateTimePicker);
            this.groupBox3.Controls.Add(размер_оргвзносаLabel);
            this.groupBox3.Controls.Add(this.размер_оргвзносаTextBox);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.dataGridView3);
            this.groupBox3.Controls.Add(this.button19);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(id_авторLabel);
            this.groupBox3.Controls.Add(id_конференцияLabel);
            this.groupBox3.Controls.Add(this.id_конференцияTextBox);
            this.groupBox3.Controls.Add(id_гостиницаLabel);
            this.groupBox3.Controls.Add(дата_поступления_оргвзносаLabel);
            this.groupBox3.Controls.Add(this.дата_поступления_оргвзносаDateTimePicker);
            this.groupBox3.Controls.Add(дата_поступления_заявкиLabel);
            this.groupBox3.Controls.Add(this.дата_поступления_заявкиDateTimePicker);
            this.groupBox3.Controls.Add(дата_приездаLabel);
            this.groupBox3.Controls.Add(this.дата_приездаDateTimePicker);
            this.groupBox3.Controls.Add(дата_отездаLabel);
            this.groupBox3.Controls.Add(this.дата_отездаDateTimePicker);
            this.groupBox3.Controls.Add(this.докладчик_участникCheckBox);
            this.groupBox3.Controls.Add(this.потребность_в_гостиницеCheckBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1250, 437);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Данные участника";
            // 
            // дата_рассылки_1_ого_приглашенияDateTimePicker
            // 
            this.дата_рассылки_1_ого_приглашенияDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.участникиBindingSource, "Дата_рассылки_1_ого_приглашения", true));
            this.дата_рассылки_1_ого_приглашенияDateTimePicker.Location = new System.Drawing.Point(539, 22);
            this.дата_рассылки_1_ого_приглашенияDateTimePicker.Name = "дата_рассылки_1_ого_приглашенияDateTimePicker";
            this.дата_рассылки_1_ого_приглашенияDateTimePicker.Size = new System.Drawing.Size(140, 20);
            this.дата_рассылки_1_ого_приглашенияDateTimePicker.TabIndex = 29;
            // 
            // участникиBindingSource
            // 
            this.участникиBindingSource.DataMember = "FK_Участники_Конференции";
            this.участникиBindingSource.DataSource = this.конференцииBindingSource;
            // 
            // дата_рассылки_2_ого_приглашенияDateTimePicker
            // 
            this.дата_рассылки_2_ого_приглашенияDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.участникиBindingSource, "Дата_рассылки_2_ого_приглашения", true));
            this.дата_рассылки_2_ого_приглашенияDateTimePicker.Location = new System.Drawing.Point(539, 53);
            this.дата_рассылки_2_ого_приглашенияDateTimePicker.Name = "дата_рассылки_2_ого_приглашенияDateTimePicker";
            this.дата_рассылки_2_ого_приглашенияDateTimePicker.Size = new System.Drawing.Size(140, 20);
            this.дата_рассылки_2_ого_приглашенияDateTimePicker.TabIndex = 31;
            // 
            // размер_оргвзносаTextBox
            // 
            this.размер_оргвзносаTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.участникиBindingSource1, "Размер_оргвзноса", true));
            this.размер_оргвзносаTextBox.Location = new System.Drawing.Point(539, 82);
            this.размер_оргвзносаTextBox.Name = "размер_оргвзносаTextBox";
            this.размер_оргвзносаTextBox.Size = new System.Drawing.Size(140, 20);
            this.размер_оргвзносаTextBox.TabIndex = 27;
            // 
            // участникиBindingSource1
            // 
            this.участникиBindingSource1.DataMember = "Участники";
            this.участникиBindingSource1.DataSource = this.conferenceDataSet1;
            // 
            // conferenceDataSet1
            // 
            this.conferenceDataSet1.DataSetName = "ConferenceDataSet1";
            this.conferenceDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(791, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 20);
            this.textBox2.TabIndex = 26;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(791, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 26;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_участник,
            this.id_автор1,
            this.id_конференции3,
            this.id_гостиница1,
            this.Дата_поступления_оргвзноса,
            this.Размер_оргвзноса,
            this.Дата_поступления_заявки,
            this.Дата_рассылки_1_ого_приглашения3,
            this.Дата_рассылки_2_ого_приглашения3,
            this.Дата_приезда,
            this.Дата_отезда,
            this.Докладчик_участник,
            this.Потребность_в_гостинице});
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView3.Location = new System.Drawing.Point(3, 140);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(1244, 294);
            this.dataGridView3.TabIndex = 25;
            // 
            // id_участник
            // 
            this.id_участник.HeaderText = "id_участник";
            this.id_участник.Name = "id_участник";
            // 
            // id_автор1
            // 
            this.id_автор1.HeaderText = "id_автор";
            this.id_автор1.Name = "id_автор1";
            // 
            // id_конференции3
            // 
            this.id_конференции3.HeaderText = "id_конференции";
            this.id_конференции3.Name = "id_конференции3";
            // 
            // id_гостиница1
            // 
            this.id_гостиница1.HeaderText = "id_гостиница";
            this.id_гостиница1.Name = "id_гостиница1";
            // 
            // Дата_поступления_оргвзноса
            // 
            this.Дата_поступления_оргвзноса.HeaderText = "Дата_поступления_оргвзноса";
            this.Дата_поступления_оргвзноса.Name = "Дата_поступления_оргвзноса";
            // 
            // Размер_оргвзноса
            // 
            this.Размер_оргвзноса.HeaderText = "Размер_оргвзноса";
            this.Размер_оргвзноса.Name = "Размер_оргвзноса";
            // 
            // Дата_поступления_заявки
            // 
            this.Дата_поступления_заявки.HeaderText = "Дата_поступления_заявки";
            this.Дата_поступления_заявки.Name = "Дата_поступления_заявки";
            // 
            // Дата_рассылки_1_ого_приглашения3
            // 
            this.Дата_рассылки_1_ого_приглашения3.HeaderText = "Дата_рассылки_1_ого_приглашения";
            this.Дата_рассылки_1_ого_приглашения3.Name = "Дата_рассылки_1_ого_приглашения3";
            // 
            // Дата_рассылки_2_ого_приглашения3
            // 
            this.Дата_рассылки_2_ого_приглашения3.HeaderText = "Дата_рассылки_2_ого_приглашения";
            this.Дата_рассылки_2_ого_приглашения3.Name = "Дата_рассылки_2_ого_приглашения3";
            // 
            // Дата_приезда
            // 
            this.Дата_приезда.HeaderText = "Дата_приезда";
            this.Дата_приезда.Name = "Дата_приезда";
            // 
            // Дата_отезда
            // 
            this.Дата_отезда.HeaderText = "Дата_отезда";
            this.Дата_отезда.Name = "Дата_отезда";
            // 
            // Докладчик_участник
            // 
            this.Докладчик_участник.HeaderText = "Докладчик/Участник";
            this.Докладчик_участник.Name = "Докладчик_участник";
            // 
            // Потребность_в_гостинице
            // 
            this.Потребность_в_гостинице.HeaderText = "Потребность_в_гостинице";
            this.Потребность_в_гостинице.Name = "Потребность_в_гостинице";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1021, 21);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(196, 30);
            this.button6.TabIndex = 24;
            this.button6.Text = "Добавить данные участника";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1022, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(195, 30);
            this.button5.TabIndex = 24;
            this.button5.Text = "Удалить данные участника";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // id_конференцияTextBox
            // 
            this.id_конференцияTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.участникиBindingSource, "id_конференция", true));
            this.id_конференцияTextBox.Location = new System.Drawing.Point(791, 79);
            this.id_конференцияTextBox.Name = "id_конференцияTextBox";
            this.id_конференцияTextBox.Size = new System.Drawing.Size(71, 20);
            this.id_конференцияTextBox.TabIndex = 5;
            // 
            // дата_поступления_оргвзносаDateTimePicker
            // 
            this.дата_поступления_оргвзносаDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.участникиBindingSource, "Дата_поступления_оргвзноса", true));
            this.дата_поступления_оргвзносаDateTimePicker.Location = new System.Drawing.Point(182, 24);
            this.дата_поступления_оргвзносаDateTimePicker.Name = "дата_поступления_оргвзносаDateTimePicker";
            this.дата_поступления_оргвзносаDateTimePicker.Size = new System.Drawing.Size(140, 20);
            this.дата_поступления_оргвзносаDateTimePicker.TabIndex = 9;
            // 
            // дата_поступления_заявкиDateTimePicker
            // 
            this.дата_поступления_заявкиDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.участникиBindingSource, "Дата_поступления_заявки", true));
            this.дата_поступления_заявкиDateTimePicker.Location = new System.Drawing.Point(182, 50);
            this.дата_поступления_заявкиDateTimePicker.Name = "дата_поступления_заявкиDateTimePicker";
            this.дата_поступления_заявкиDateTimePicker.Size = new System.Drawing.Size(140, 20);
            this.дата_поступления_заявкиDateTimePicker.TabIndex = 11;
            // 
            // дата_приездаDateTimePicker
            // 
            this.дата_приездаDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.участникиBindingSource, "Дата_приезда", true));
            this.дата_приездаDateTimePicker.Location = new System.Drawing.Point(182, 76);
            this.дата_приездаDateTimePicker.Name = "дата_приездаDateTimePicker";
            this.дата_приездаDateTimePicker.Size = new System.Drawing.Size(140, 20);
            this.дата_приездаDateTimePicker.TabIndex = 17;
            // 
            // дата_отездаDateTimePicker
            // 
            this.дата_отездаDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.участникиBindingSource, "Дата_отезда", true));
            this.дата_отездаDateTimePicker.Location = new System.Drawing.Point(182, 102);
            this.дата_отездаDateTimePicker.Name = "дата_отездаDateTimePicker";
            this.дата_отездаDateTimePicker.Size = new System.Drawing.Size(140, 20);
            this.дата_отездаDateTimePicker.TabIndex = 19;
            // 
            // докладчик_участникCheckBox
            // 
            this.докладчик_участникCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.участникиBindingSource, "Докладчик_участник", true));
            this.докладчик_участникCheckBox.Location = new System.Drawing.Point(894, 25);
            this.докладчик_участникCheckBox.Name = "докладчик_участникCheckBox";
            this.докладчик_участникCheckBox.Size = new System.Drawing.Size(84, 24);
            this.докладчик_участникCheckBox.TabIndex = 21;
            this.докладчик_участникCheckBox.Text = "Докладчик";
            this.докладчик_участникCheckBox.UseVisualStyleBackColor = true;
            // 
            // потребность_в_гостиницеCheckBox
            // 
            this.потребность_в_гостиницеCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.участникиBindingSource, "Потребность_в_гостинице", true));
            this.потребность_в_гостиницеCheckBox.Location = new System.Drawing.Point(894, 51);
            this.потребность_в_гостиницеCheckBox.Name = "потребность_в_гостиницеCheckBox";
            this.потребность_в_гостиницеCheckBox.Size = new System.Drawing.Size(84, 24);
            this.потребность_в_гостиницеCheckBox.TabIndex = 23;
            this.потребность_в_гостиницеCheckBox.Text = "Гостиница";
            this.потребность_в_гостиницеCheckBox.UseVisualStyleBackColor = true;
            // 
            // Doklad
            // 
            this.Doklad.Controls.Add(this.groupBox4);
            this.Doklad.Location = new System.Drawing.Point(4, 29);
            this.Doklad.Name = "Doklad";
            this.Doklad.Padding = new System.Windows.Forms.Padding(3);
            this.Doklad.Size = new System.Drawing.Size(1256, 443);
            this.Doklad.TabIndex = 3;
            this.Doklad.Text = "Доклады";
            this.Doklad.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.тезисcheckBox);
            this.groupBox4.Controls.Add(this.dataGridView4);
            this.groupBox4.Controls.Add(this.button20);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(id_участникLabel1);
            this.groupBox4.Controls.Add(this.id_участникTextBox1);
            this.groupBox4.Controls.Add(тема_докладаLabel);
            this.groupBox4.Controls.Add(this.тема_докладаTextBox);
            this.groupBox4.Controls.Add(количество_страницLabel);
            this.groupBox4.Controls.Add(this.количество_страницTextBox);
            this.groupBox4.Controls.Add(соавторыLabel);
            this.groupBox4.Controls.Add(this.соавторыTextBox);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1250, 437);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Данные доклада";
            // 
            // тезисcheckBox
            // 
            this.тезисcheckBox.Location = new System.Drawing.Point(550, 20);
            this.тезисcheckBox.Name = "тезисcheckBox";
            this.тезисcheckBox.Size = new System.Drawing.Size(121, 24);
            this.тезисcheckBox.TabIndex = 24;
            this.тезисcheckBox.Text = "Тезисы поступили";
            this.тезисcheckBox.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_участник2,
            this.Тема_доклада,
            this.Отметка_о_поступлении_тезисов,
            this.Количество_страниц,
            this.Соавторы});
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView4.Location = new System.Drawing.Point(3, 86);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(1244, 348);
            this.dataGridView4.TabIndex = 9;
            // 
            // id_участник2
            // 
            this.id_участник2.HeaderText = "id_участник";
            this.id_участник2.Name = "id_участник2";
            // 
            // Тема_доклада
            // 
            this.Тема_доклада.HeaderText = "Тема_доклада";
            this.Тема_доклада.Name = "Тема_доклада";
            // 
            // Отметка_о_поступлении_тезисов
            // 
            this.Отметка_о_поступлении_тезисов.HeaderText = "Отметка_о_поступлении_тезисов";
            this.Отметка_о_поступлении_тезисов.Name = "Отметка_о_поступлении_тезисов";
            // 
            // Количество_страниц
            // 
            this.Количество_страниц.HeaderText = "Количество_страниц";
            this.Количество_страниц.Name = "Количество_страниц";
            // 
            // Соавторы
            // 
            this.Соавторы.HeaderText = "Соавторы";
            this.Соавторы.Name = "Соавторы";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(989, 22);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(126, 46);
            this.button8.TabIndex = 8;
            this.button8.Text = "Удалить доклад";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(725, 22);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(126, 46);
            this.button7.TabIndex = 8;
            this.button7.Text = "Добавить доклад";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // id_участникTextBox1
            // 
            this.id_участникTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.докладыBindingSource, "id_участник", true));
            this.id_участникTextBox1.Location = new System.Drawing.Point(138, 22);
            this.id_участникTextBox1.Name = "id_участникTextBox1";
            this.id_участникTextBox1.Size = new System.Drawing.Size(100, 20);
            this.id_участникTextBox1.TabIndex = 1;
            // 
            // докладыBindingSource
            // 
            this.докладыBindingSource.DataMember = "Доклады";
            this.докладыBindingSource.DataSource = this.conferenceDataSet;
            // 
            // тема_докладаTextBox
            // 
            this.тема_докладаTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.докладыBindingSource, "Тема_доклада", true));
            this.тема_докладаTextBox.Location = new System.Drawing.Point(138, 48);
            this.тема_докладаTextBox.Name = "тема_докладаTextBox";
            this.тема_докладаTextBox.Size = new System.Drawing.Size(100, 20);
            this.тема_докладаTextBox.TabIndex = 3;
            // 
            // количество_страницTextBox
            // 
            this.количество_страницTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.докладыBindingSource, "Количество_страниц", true));
            this.количество_страницTextBox.Location = new System.Drawing.Point(418, 22);
            this.количество_страницTextBox.Name = "количество_страницTextBox";
            this.количество_страницTextBox.Size = new System.Drawing.Size(100, 20);
            this.количество_страницTextBox.TabIndex = 5;
            // 
            // соавторыTextBox
            // 
            this.соавторыTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.докладыBindingSource, "Соавторы", true));
            this.соавторыTextBox.Location = new System.Drawing.Point(418, 48);
            this.соавторыTextBox.Name = "соавторыTextBox";
            this.соавторыTextBox.Size = new System.Drawing.Size(100, 20);
            this.соавторыTextBox.TabIndex = 7;
            // 
            // Hotels
            // 
            this.Hotels.Controls.Add(this.groupBox5);
            this.Hotels.Location = new System.Drawing.Point(4, 29);
            this.Hotels.Name = "Hotels";
            this.Hotels.Padding = new System.Windows.Forms.Padding(3);
            this.Hotels.Size = new System.Drawing.Size(1256, 443);
            this.Hotels.TabIndex = 4;
            this.Hotels.Text = "Гостиницы";
            this.Hotels.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridView5);
            this.groupBox5.Controls.Add(this.button21);
            this.groupBox5.Controls.Add(this.button10);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Controls.Add(странаLabel1);
            this.groupBox5.Controls.Add(this.странаTextBox1);
            this.groupBox5.Controls.Add(городLabel1);
            this.groupBox5.Controls.Add(this.городTextBox1);
            this.groupBox5.Controls.Add(названиеLabel1);
            this.groupBox5.Controls.Add(this.названиеTextBox1);
            this.groupBox5.Controls.Add(адресLabel1);
            this.groupBox5.Controls.Add(this.адресTextBox1);
            this.groupBox5.Controls.Add(стоимость_номераLabel);
            this.groupBox5.Controls.Add(this.стоимость_номераTextBox);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1250, 437);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Данные гостиницы";
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_гостиница,
            this.Название3,
            this.Адрес3,
            this.Страна3,
            this.Город3,
            this.Стоимость_номера});
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView5.Location = new System.Drawing.Point(3, 109);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(1244, 325);
            this.dataGridView5.TabIndex = 16;
            // 
            // id_гостиница
            // 
            this.id_гостиница.HeaderText = "id_гостиница";
            this.id_гостиница.Name = "id_гостиница";
            // 
            // Название3
            // 
            this.Название3.HeaderText = "Название";
            this.Название3.Name = "Название3";
            // 
            // Адрес3
            // 
            this.Адрес3.HeaderText = "Адрес";
            this.Адрес3.Name = "Адрес3";
            // 
            // Страна3
            // 
            this.Страна3.HeaderText = "Страна";
            this.Страна3.Name = "Страна3";
            // 
            // Город3
            // 
            this.Город3.HeaderText = "Город";
            this.Город3.Name = "Город3";
            // 
            // Стоимость_номера
            // 
            this.Стоимость_номера.HeaderText = "Стоимость_номера";
            this.Стоимость_номера.Name = "Стоимость_номера";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1047, 57);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(181, 34);
            this.button10.TabIndex = 15;
            this.button10.Text = "Удалить гостиницу";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(860, 20);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(181, 34);
            this.button9.TabIndex = 15;
            this.button9.Text = "Добавить гостиницу";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // странаTextBox1
            // 
            this.странаTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.локацияBindingSource, "Страна", true));
            this.странаTextBox1.Location = new System.Drawing.Point(600, 20);
            this.странаTextBox1.Name = "странаTextBox1";
            this.странаTextBox1.Size = new System.Drawing.Size(185, 20);
            this.странаTextBox1.TabIndex = 12;
            // 
            // городTextBox1
            // 
            this.городTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.локацияBindingSource, "Город", true));
            this.городTextBox1.Location = new System.Drawing.Point(600, 46);
            this.городTextBox1.Name = "городTextBox1";
            this.городTextBox1.Size = new System.Drawing.Size(185, 20);
            this.городTextBox1.TabIndex = 14;
            // 
            // названиеTextBox1
            // 
            this.названиеTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.гостиницыBindingSource, "Название", true));
            this.названиеTextBox1.Location = new System.Drawing.Point(132, 20);
            this.названиеTextBox1.Name = "названиеTextBox1";
            this.названиеTextBox1.Size = new System.Drawing.Size(320, 20);
            this.названиеTextBox1.TabIndex = 3;
            // 
            // гостиницыBindingSource
            // 
            this.гостиницыBindingSource.DataMember = "Гостиницы";
            this.гостиницыBindingSource.DataSource = this.conferenceDataSet;
            // 
            // адресTextBox1
            // 
            this.адресTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.гостиницыBindingSource, "Адрес", true));
            this.адресTextBox1.Location = new System.Drawing.Point(132, 46);
            this.адресTextBox1.Name = "адресTextBox1";
            this.адресTextBox1.Size = new System.Drawing.Size(320, 20);
            this.адресTextBox1.TabIndex = 7;
            // 
            // стоимость_номераTextBox
            // 
            this.стоимость_номераTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.гостиницыBindingSource, "Стоимость_номера", true));
            this.стоимость_номераTextBox.Location = new System.Drawing.Point(600, 72);
            this.стоимость_номераTextBox.Name = "стоимость_номераTextBox";
            this.стоимость_номераTextBox.Size = new System.Drawing.Size(185, 20);
            this.стоимость_номераTextBox.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1256, 443);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "Справки отчеты запросы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.button15);
            this.groupBox10.Controls.Add(this.label13);
            this.groupBox10.Controls.Add(this.label14);
            this.groupBox10.Controls.Add(label15);
            this.groupBox10.Controls.Add(this.город2textbox);
            this.groupBox10.Controls.Add(this.idconference12);
            this.groupBox10.Location = new System.Drawing.Point(8, 350);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1240, 69);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button15.Location = new System.Drawing.Point(1052, 22);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(161, 26);
            this.button15.TabIndex = 2;
            this.button15.Text = "Показать";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(9, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Для города";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(348, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(305, 18);
            this.label14.TabIndex = 0;
            this.label14.Text = "вывести список нуждающихся в гостинице";
            // 
            // город2textbox
            // 
            this.город2textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.город2textbox.Location = new System.Drawing.Point(100, 26);
            this.город2textbox.Name = "город2textbox";
            this.город2textbox.Size = new System.Drawing.Size(242, 24);
            this.город2textbox.TabIndex = 7;
            // 
            // idconference12
            // 
            this.idconference12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idconference12.Location = new System.Drawing.Point(924, 23);
            this.idconference12.Name = "idconference12";
            this.idconference12.Size = new System.Drawing.Size(71, 24);
            this.idconference12.TabIndex = 7;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.button14);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Controls.Add(label11);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.gorodtextbox);
            this.groupBox9.Controls.Add(this.idconfertextbox);
            this.groupBox9.Location = new System.Drawing.Point(8, 244);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1240, 100);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button14.Location = new System.Drawing.Point(1052, 39);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(161, 26);
            this.button14.TabIndex = 2;
            this.button14.Text = "Показать";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(9, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Для города";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(348, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 18);
            this.label10.TabIndex = 0;
            this.label10.Text = "вывести название ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(9, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(350, 18);
            this.label12.TabIndex = 0;
            this.label12.Text = "тезисов докладов, поступивших из этого города";
            // 
            // gorodtextbox
            // 
            this.gorodtextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gorodtextbox.Location = new System.Drawing.Point(100, 30);
            this.gorodtextbox.Name = "gorodtextbox";
            this.gorodtextbox.Size = new System.Drawing.Size(242, 24);
            this.gorodtextbox.TabIndex = 7;
            // 
            // idconfertextbox
            // 
            this.idconfertextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idconfertextbox.Location = new System.Drawing.Point(924, 40);
            this.idconfertextbox.Name = "idconfertextbox";
            this.idconfertextbox.Size = new System.Drawing.Size(71, 24);
            this.idconfertextbox.TabIndex = 7;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button13);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(label8);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.textBox4);
            this.groupBox8.Controls.Add(this.dateTimePicker1);
            this.groupBox8.Controls.Add(this.dateTimePicker2);
            this.groupBox8.Location = new System.Drawing.Point(8, 138);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1240, 100);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button13.Location = new System.Drawing.Point(1052, 39);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(161, 26);
            this.button13.TabIndex = 2;
            this.button13.Text = "Показать";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Для интервала дат с";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(317, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "по";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(9, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(488, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "вывести список участников, уплативших оргвзнос в этом диапазоне";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(924, 40);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(71, 24);
            this.textBox4.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(168, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(143, 24);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Location = new System.Drawing.Point(348, 25);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(143, 24);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button12);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.textBox3);
            this.groupBox7.Controls.Add(label4);
            this.groupBox7.Location = new System.Drawing.Point(8, 71);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1240, 61);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.Location = new System.Drawing.Point(1052, 19);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(161, 26);
            this.button12.TabIndex = 2;
            this.button12.Text = "Показать";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(507, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Вывести список приглашенных, с указанием даты об уплате оргвзноса";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(924, 20);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(71, 24);
            this.textBox3.TabIndex = 7;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button11);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.idConference);
            this.groupBox6.Controls.Add(label2);
            this.groupBox6.Controls.Add(this.dateTimePicker3);
            this.groupBox6.Location = new System.Drawing.Point(8, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1240, 62);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.Location = new System.Drawing.Point(1052, 19);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(161, 26);
            this.button11.TabIndex = 2;
            this.button11.Text = "Показать";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(596, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вывести список приглашенных и посчитать их количество для даты 1-ой рассылки ";
            // 
            // idConference
            // 
            this.idConference.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.участникиBindingSource, "id_конференция", true));
            this.idConference.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.idConference.Location = new System.Drawing.Point(924, 20);
            this.idConference.Name = "idConference";
            this.idConference.Size = new System.Drawing.Size(71, 24);
            this.idConference.TabIndex = 7;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker3.Location = new System.Drawing.Point(611, 20);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(143, 24);
            this.dateTimePicker3.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox11);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1256, 443);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "Приглашение";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.textBox6);
            this.groupBox11.Controls.Add(label18);
            this.groupBox11.Controls.Add(this.button16);
            this.groupBox11.Controls.Add(this.label17);
            this.groupBox11.Controls.Add(this.label16);
            this.groupBox11.Controls.Add(this.textBox5);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(3, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(1250, 437);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            // 
            // textBox6
            // 
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.участникиBindingSource, "id_конференция", true));
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox6.Location = new System.Drawing.Point(836, 82);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(71, 24);
            this.textBox6.TabIndex = 9;
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button16.Location = new System.Drawing.Point(465, 365);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(306, 60);
            this.button16.TabIndex = 2;
            this.button16.Text = "Сгенерировать приглашение";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(324, 86);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(158, 20);
            this.label17.TabIndex = 1;
            this.label17.Text = "Текст приглашения";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(518, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(201, 37);
            this.label16.TabIndex = 1;
            this.label16.Text = "Приглашение";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.Location = new System.Drawing.Point(328, 109);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(579, 250);
            this.textBox5.TabIndex = 0;
            // 
            // участникиTableAdapter1
            // 
            this.участникиTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.UpdateOrder = Conference.ConferenceDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.УчастникиTableAdapter = this.участникиTableAdapter1;
            // 
            // авторыTableAdapter
            // 
            this.авторыTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Conference.ConferenceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.АвторыTableAdapter = this.авторыTableAdapter;
            this.tableAdapterManager.ГостиницыTableAdapter = this.гостиницыTableAdapter;
            this.tableAdapterManager.ДокладыTableAdapter = this.докладыTableAdapter;
            this.tableAdapterManager.КонференцииTableAdapter = this.конференцииTableAdapter;
            this.tableAdapterManager.ЛокацияTableAdapter = this.локацияTableAdapter;
            this.tableAdapterManager.УчастникиTableAdapter = this.участникиTableAdapter;
            this.tableAdapterManager.Ученая_степеньTableAdapter = null;
            this.tableAdapterManager.Ученое_званиеTableAdapter = null;
            // 
            // гостиницыTableAdapter
            // 
            this.гостиницыTableAdapter.ClearBeforeFill = true;
            // 
            // докладыTableAdapter
            // 
            this.докладыTableAdapter.ClearBeforeFill = true;
            // 
            // конференцииTableAdapter
            // 
            this.конференцииTableAdapter.ClearBeforeFill = true;
            // 
            // локацияTableAdapter
            // 
            this.локацияTableAdapter.ClearBeforeFill = true;
            // 
            // участникиTableAdapter
            // 
            this.участникиTableAdapter.ClearBeforeFill = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(1056, 22);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(164, 33);
            this.button17.TabIndex = 12;
            this.button17.Text = "Изменить конференцию";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(1057, 61);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(176, 30);
            this.button18.TabIndex = 71;
            this.button18.Text = "Изменить данные автора";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(1021, 57);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(196, 30);
            this.button19.TabIndex = 24;
            this.button19.Text = "Изменить данные участника";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(857, 22);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(126, 46);
            this.button20.TabIndex = 8;
            this.button20.Text = "Изменить доклад";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(1047, 19);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(181, 34);
            this.button21.TabIndex = 15;
            this.button21.Text = "Изменить гостиницу";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 522);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конференция";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.локацияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conferenceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.авторыBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Conferences.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.конференцииBindingSource)).EndInit();
            this.Autors.ResumeLayout(false);
            this.Uchastniki.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.участникиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.участникиBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conferenceDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.Doklad.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.докладыBindingSource)).EndInit();
            this.Hotels.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.гостиницыBindingSource)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Autors;
        private System.Windows.Forms.TabPage Uchastniki;
        private System.Windows.Forms.TabPage Conferences;
        private System.Windows.Forms.TabPage Doklad;
        private System.Windows.Forms.TabPage Hotels;
        private ConferenceDataSet conferenceDataSet;
        private System.Windows.Forms.BindingSource авторыBindingSource;
        private ConferenceDataSetTableAdapters.АвторыTableAdapter авторыTableAdapter;
        private ConferenceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.GroupBox groupBox2;
        private ConferenceDataSetTableAdapters.ЛокацияTableAdapter локацияTableAdapter;
        private System.Windows.Forms.BindingSource локацияBindingSource;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox странаTextBox;
        private System.Windows.Forms.TextBox фамилияTextBox;
        private System.Windows.Forms.TextBox городTextBox;
        private System.Windows.Forms.TextBox должностьTextBox;
        private System.Windows.Forms.TextBox имяTextBox;
        private System.Windows.Forms.TextBox место_работыTextBox;
        private System.Windows.Forms.TextBox отчествоTextBox;
        private System.Windows.Forms.TextBox кафедраTextBox;
        private System.Windows.Forms.TextBox адресTextBox;
        private System.Windows.Forms.TextBox научное_направлвниеTextBox;
        private System.Windows.Forms.TextBox почтовой_индексTextBox;
        private System.Windows.Forms.TextBox ученое_званиеTextBox;
        private System.Windows.Forms.TextBox рабочий_телефонTextBox;
        private System.Windows.Forms.TextBox ученая_степеньTextBox;
        private System.Windows.Forms.TextBox домашний_телефонTextBox;
        private System.Windows.Forms.TextBox e_mailTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_автор;
        private System.Windows.Forms.DataGridViewTextBoxColumn Фамилия;
        private System.Windows.Forms.DataGridViewTextBoxColumn Имя;
        private System.Windows.Forms.DataGridViewTextBoxColumn Отчество;
        private System.Windows.Forms.DataGridViewTextBoxColumn Адрес;
        private System.Windows.Forms.DataGridViewTextBoxColumn Почтовой_индекс;
        private System.Windows.Forms.DataGridViewTextBoxColumn Рабочий_телефон;
        private System.Windows.Forms.DataGridViewTextBoxColumn Домашний_телефон;
        private System.Windows.Forms.DataGridViewTextBoxColumn e_mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ученая_степень;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ученое_звание;
        private System.Windows.Forms.DataGridViewTextBoxColumn Научное_направление;
        private System.Windows.Forms.DataGridViewTextBoxColumn Кафедра;
        private System.Windows.Forms.DataGridViewTextBoxColumn Место_работы;
        private System.Windows.Forms.DataGridViewTextBoxColumn Должность;
        private System.Windows.Forms.DataGridViewTextBoxColumn Страна;
        private System.Windows.Forms.DataGridViewTextBoxColumn Город;
        private ConferenceDataSetTableAdapters.КонференцииTableAdapter конференцииTableAdapter;
        private System.Windows.Forms.BindingSource конференцииBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox названиеTextBox;
        private System.Windows.Forms.TextBox организаторTextBox;
        private System.Windows.Forms.TextBox статусTextBox;
        private System.Windows.Forms.DateTimePicker дата_началоDateTimePicker;
        private System.Windows.Forms.TextBox оргвзносTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private ConferenceDataSetTableAdapters.УчастникиTableAdapter участникиTableAdapter;
        private System.Windows.Forms.BindingSource участникиBindingSource;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox id_конференцияTextBox;
        private System.Windows.Forms.DateTimePicker дата_поступления_оргвзносаDateTimePicker;
        private System.Windows.Forms.DateTimePicker дата_поступления_заявкиDateTimePicker;
        private System.Windows.Forms.DateTimePicker дата_приездаDateTimePicker;
        private System.Windows.Forms.DateTimePicker дата_отездаDateTimePicker;
        private System.Windows.Forms.CheckBox докладчик_участникCheckBox;
        private System.Windows.Forms.CheckBox потребность_в_гостиницеCheckBox;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.GroupBox groupBox4;
        private ConferenceDataSetTableAdapters.ДокладыTableAdapter докладыTableAdapter;
        private System.Windows.Forms.BindingSource докладыBindingSource;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox id_участникTextBox1;
        private System.Windows.Forms.TextBox тема_докладаTextBox;
        private System.Windows.Forms.TextBox количество_страницTextBox;
        private System.Windows.Forms.TextBox соавторыTextBox;
        private ConferenceDataSetTableAdapters.ГостиницыTableAdapter гостиницыTableAdapter;
        private System.Windows.Forms.BindingSource гостиницыBindingSource;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_гостиница;
        private System.Windows.Forms.DataGridViewTextBoxColumn Название3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Адрес3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Страна3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Город3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Стоимость_номера;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox странаTextBox1;
        private System.Windows.Forms.TextBox городTextBox1;
        private System.Windows.Forms.TextBox названиеTextBox1;
        private System.Windows.Forms.TextBox адресTextBox1;
        private System.Windows.Forms.TextBox стоимость_номераTextBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ConferenceDataSet1 conferenceDataSet1;
        private System.Windows.Forms.BindingSource участникиBindingSource1;
        private ConferenceDataSet1TableAdapters.УчастникиTableAdapter участникиTableAdapter1;
        private ConferenceDataSet1TableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.TextBox размер_оргвзносаTextBox;
        private System.Windows.Forms.CheckBox тезисcheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_участник2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Тема_доклада;
        private System.Windows.Forms.DataGridViewTextBoxColumn Отметка_о_поступлении_тезисов;
        private System.Windows.Forms.DataGridViewTextBoxColumn Количество_страниц;
        private System.Windows.Forms.DataGridViewTextBoxColumn Соавторы;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker дата_рассылки_1_ого_приглашенияDateTimePicker;
        private System.Windows.Forms.DateTimePicker дата_рассылки_2_ого_приглашенияDateTimePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_конференция;
        private System.Windows.Forms.DataGridViewTextBoxColumn Название;
        private System.Windows.Forms.DataGridViewTextBoxColumn Организатор;
        private System.Windows.Forms.DataGridViewTextBoxColumn Статус;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата_начала;
        private System.Windows.Forms.DataGridViewTextBoxColumn Оргвзнос;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_участник;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_автор1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_конференции3;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_гостиница1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата_поступления_оргвзноса;
        private System.Windows.Forms.DataGridViewTextBoxColumn Размер_оргвзноса;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата_поступления_заявки;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата_рассылки_1_ого_приглашения3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата_рассылки_2_ого_приглашения3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата_приезда;
        private System.Windows.Forms.DataGridViewTextBoxColumn Дата_отезда;
        private System.Windows.Forms.DataGridViewTextBoxColumn Докладчик_участник;
        private System.Windows.Forms.DataGridViewTextBoxColumn Потребность_в_гостинице;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox idConference;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox idconfertextbox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox город2textbox;
        private System.Windows.Forms.TextBox idconference12;
        private System.Windows.Forms.TextBox gorodtextbox;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
    }
}

