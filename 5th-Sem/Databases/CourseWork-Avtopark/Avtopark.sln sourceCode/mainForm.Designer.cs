
namespace Avtopark
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label паспортLabel;
            System.Windows.Forms.Label фИОLabel;
            System.Windows.Forms.Label стажLabel;
            System.Windows.Forms.Label классLabel;
            System.Windows.Forms.Label автобусLabel;
            System.Windows.Forms.Label типLabel;
            System.Windows.Forms.Label маршрутLabel;
            System.Windows.Forms.Label начальный_пунктLabel;
            System.Windows.Forms.Label конечный_пунктLabel;
            System.Windows.Forms.Label время_начала_движенияLabel;
            System.Windows.Forms.Label время_окончания_движенияLabel;
            System.Windows.Forms.Label интервал_мин_Label;
            System.Windows.Forms.Label протяженность_мин_Label;
            System.Windows.Forms.Label автобусLabel1;
            System.Windows.Forms.Label паспортLabel1;
            System.Windows.Forms.Label автобусLabel2;
            System.Windows.Forms.Label фИОLabel1;
            System.Windows.Forms.Label маршрутLabel1;
            System.Windows.Forms.Label датаLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выполнитьРезервноеКопированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreBackUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.поискВодителяПоФИОToolStrip = new System.Windows.Forms.ToolStrip();
            this.фИОToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.фИОToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.поискВодителяПоФИОToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.поискВодителяПоПаспортуToolStrip = new System.Windows.Forms.ToolStrip();
            this.паспортToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.паспортToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.поискВодителяПоПаспортуToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.водителиDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.водителиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new Avtopark.Database1DataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button20 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.паспортTextBox = new System.Windows.Forms.TextBox();
            this.фИОTextBox = new System.Windows.Forms.TextBox();
            this.стажTextBox = new System.Windows.Forms.TextBox();
            this.классTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.поискАвтобусаToolStrip = new System.Windows.Forms.ToolStrip();
            this.автобусToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.автобусToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.поискАвтобусаToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button21 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.автобусTextBox = new System.Windows.Forms.TextBox();
            this.автобусыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.тип_вместимостьDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.тип_вместимостьBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.автобусыDataGridView = new System.Windows.Forms.DataGridView();
            this.автобусDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.типDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.поискМаршрутаToolStrip = new System.Windows.Forms.ToolStrip();
            this.маршрутToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.маршрутToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.поискМаршрутаToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.маршрутTextBox = new System.Windows.Forms.TextBox();
            this.маршрутыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.начальный_пунктTextBox = new System.Windows.Forms.TextBox();
            this.конечный_пунктTextBox = new System.Windows.Forms.TextBox();
            this.время_начала_движенияTextBox = new System.Windows.Forms.TextBox();
            this.время_окончания_движенияTextBox = new System.Windows.Forms.TextBox();
            this.интервал_мин_TextBox = new System.Windows.Forms.TextBox();
            this.протяженность_мин_TextBox = new System.Windows.Forms.TextBox();
            this.маршрутыDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.паспортTextBox1 = new System.Windows.Forms.TextBox();
            this.водятBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.автобусTextBox2 = new System.Windows.Forms.TextBox();
            this.фИОTextBox1 = new System.Windows.Forms.TextBox();
            this.маршрутTextBox1 = new System.Windows.Forms.TextBox();
            this.датаDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.водятDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button17 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button13 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.автобусTextBox1 = new System.Windows.Forms.TextBox();
            this.списанные_автобусыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet1 = new Avtopark.Database1DataSet1();
            this.списанные_автобусыDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.водителиTableAdapter = new Avtopark.Database1DataSetTableAdapters.ВодителиTableAdapter();
            this.tableAdapterManager = new Avtopark.Database1DataSetTableAdapters.TableAdapterManager();
            this.автобусыTableAdapter = new Avtopark.Database1DataSetTableAdapters.АвтобусыTableAdapter();
            this.тип_вместимостьTableAdapter = new Avtopark.Database1DataSetTableAdapters.Тип_вместимостьTableAdapter();
            this.маршрутыTableAdapter = new Avtopark.Database1DataSetTableAdapters.МаршрутыTableAdapter();
            this.списанные_автобусыTableAdapter = new Avtopark.Database1DataSet1TableAdapters.Списанные_автобусыTableAdapter();
            this.tableAdapterManager1 = new Avtopark.Database1DataSet1TableAdapters.TableAdapterManager();
            this.водятTableAdapter = new Avtopark.Database1DataSetTableAdapters.ВодятTableAdapter();
            паспортLabel = new System.Windows.Forms.Label();
            фИОLabel = new System.Windows.Forms.Label();
            стажLabel = new System.Windows.Forms.Label();
            классLabel = new System.Windows.Forms.Label();
            автобусLabel = new System.Windows.Forms.Label();
            типLabel = new System.Windows.Forms.Label();
            маршрутLabel = new System.Windows.Forms.Label();
            начальный_пунктLabel = new System.Windows.Forms.Label();
            конечный_пунктLabel = new System.Windows.Forms.Label();
            время_начала_движенияLabel = new System.Windows.Forms.Label();
            время_окончания_движенияLabel = new System.Windows.Forms.Label();
            интервал_мин_Label = new System.Windows.Forms.Label();
            протяженность_мин_Label = new System.Windows.Forms.Label();
            автобусLabel1 = new System.Windows.Forms.Label();
            паспортLabel1 = new System.Windows.Forms.Label();
            автобусLabel2 = new System.Windows.Forms.Label();
            фИОLabel1 = new System.Windows.Forms.Label();
            маршрутLabel1 = new System.Windows.Forms.Label();
            датаLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.поискВодителяПоФИОToolStrip.SuspendLayout();
            this.поискВодителяПоПаспортуToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.водителиDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.водителиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.поискАвтобусаToolStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.автобусыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.тип_вместимостьDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.тип_вместимостьBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.автобусыDataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.поискМаршрутаToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.маршрутыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.маршрутыDataGridView)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.водятBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.водятDataGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.списанные_автобусыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.списанные_автобусыDataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // паспортLabel
            // 
            паспортLabel.AutoSize = true;
            паспортLabel.Location = new System.Drawing.Point(6, 26);
            паспортLabel.Name = "паспортLabel";
            паспортLabel.Size = new System.Drawing.Size(53, 13);
            паспортLabel.TabIndex = 0;
            паспортLabel.Text = "Паспорт:";
            // 
            // фИОLabel
            // 
            фИОLabel.AutoSize = true;
            фИОLabel.Location = new System.Drawing.Point(6, 52);
            фИОLabel.Name = "фИОLabel";
            фИОLabel.Size = new System.Drawing.Size(37, 13);
            фИОLabel.TabIndex = 2;
            фИОLabel.Text = "ФИО:";
            // 
            // стажLabel
            // 
            стажLabel.AutoSize = true;
            стажLabel.Location = new System.Drawing.Point(277, 26);
            стажLabel.Name = "стажLabel";
            стажLabel.Size = new System.Drawing.Size(36, 13);
            стажLabel.TabIndex = 6;
            стажLabel.Text = "Стаж:";
            // 
            // классLabel
            // 
            классLabel.AutoSize = true;
            классLabel.Location = new System.Drawing.Point(277, 52);
            классLabel.Name = "классLabel";
            классLabel.Size = new System.Drawing.Size(41, 13);
            классLabel.TabIndex = 8;
            классLabel.Text = "Класс:";
            // 
            // автобусLabel
            // 
            автобусLabel.AutoSize = true;
            автобусLabel.Location = new System.Drawing.Point(14, 22);
            автобусLabel.Name = "автобусLabel";
            автобусLabel.Size = new System.Drawing.Size(51, 13);
            автобусLabel.TabIndex = 2;
            автобусLabel.Text = "Автобус:";
            // 
            // типLabel
            // 
            типLabel.AutoSize = true;
            типLabel.Location = new System.Drawing.Point(14, 48);
            типLabel.Name = "типLabel";
            типLabel.Size = new System.Drawing.Size(29, 13);
            типLabel.TabIndex = 4;
            типLabel.Text = "Тип:";
            // 
            // маршрутLabel
            // 
            маршрутLabel.AutoSize = true;
            маршрутLabel.Location = new System.Drawing.Point(6, 27);
            маршрутLabel.Name = "маршрутLabel";
            маршрутLabel.Size = new System.Drawing.Size(55, 13);
            маршрутLabel.TabIndex = 0;
            маршрутLabel.Text = "Маршрут:";
            // 
            // начальный_пунктLabel
            // 
            начальный_пунктLabel.AutoSize = true;
            начальный_пунктLabel.Location = new System.Drawing.Point(6, 53);
            начальный_пунктLabel.Name = "начальный_пунктLabel";
            начальный_пунктLabel.Size = new System.Drawing.Size(98, 13);
            начальный_пунктLabel.TabIndex = 2;
            начальный_пунктLabel.Text = "Начальный пункт:";
            // 
            // конечный_пунктLabel
            // 
            конечный_пунктLabel.AutoSize = true;
            конечный_пунктLabel.Location = new System.Drawing.Point(6, 79);
            конечный_пунктLabel.Name = "конечный_пунктLabel";
            конечный_пунктLabel.Size = new System.Drawing.Size(91, 13);
            конечный_пунктLabel.TabIndex = 4;
            конечный_пунктLabel.Text = "Конечный пункт:";
            // 
            // время_начала_движенияLabel
            // 
            время_начала_движенияLabel.AutoSize = true;
            время_начала_движенияLabel.Location = new System.Drawing.Point(275, 27);
            время_начала_движенияLabel.Name = "время_начала_движенияLabel";
            время_начала_движенияLabel.Size = new System.Drawing.Size(134, 13);
            время_начала_движенияLabel.TabIndex = 6;
            время_начала_движенияLabel.Text = "Время начала движения:";
            // 
            // время_окончания_движенияLabel
            // 
            время_окончания_движенияLabel.AutoSize = true;
            время_окончания_движенияLabel.Location = new System.Drawing.Point(275, 57);
            время_окончания_движенияLabel.Name = "время_окончания_движенияLabel";
            время_окончания_движенияLabel.Size = new System.Drawing.Size(152, 13);
            время_окончания_движенияLabel.TabIndex = 8;
            время_окончания_движенияLabel.Text = "Время окончания движения:";
            // 
            // интервал_мин_Label
            // 
            интервал_мин_Label.AutoSize = true;
            интервал_мин_Label.Location = new System.Drawing.Point(578, 28);
            интервал_мин_Label.Name = "интервал_мин_Label";
            интервал_мин_Label.Size = new System.Drawing.Size(85, 13);
            интервал_мин_Label.TabIndex = 10;
            интервал_мин_Label.Text = "Интервал(мин):";
            // 
            // протяженность_мин_Label
            // 
            протяженность_мин_Label.AutoSize = true;
            протяженность_мин_Label.Location = new System.Drawing.Point(578, 57);
            протяженность_мин_Label.Name = "протяженность_мин_Label";
            протяженность_мин_Label.Size = new System.Drawing.Size(116, 13);
            протяженность_мин_Label.TabIndex = 12;
            протяженность_мин_Label.Text = "Протяженность(мин):";
            // 
            // автобусLabel1
            // 
            автобусLabel1.AutoSize = true;
            автобусLabel1.Location = new System.Drawing.Point(6, 26);
            автобусLabel1.Name = "автобусLabel1";
            автобусLabel1.Size = new System.Drawing.Size(51, 13);
            автобусLabel1.TabIndex = 1;
            автобусLabel1.Text = "Автобус:";
            // 
            // паспортLabel1
            // 
            паспортLabel1.AutoSize = true;
            паспортLabel1.Location = new System.Drawing.Point(8, 22);
            паспортLabel1.Name = "паспортLabel1";
            паспортLabel1.Size = new System.Drawing.Size(53, 13);
            паспортLabel1.TabIndex = 2;
            паспортLabel1.Text = "Паспорт:";
            // 
            // автобусLabel2
            // 
            автобусLabel2.AutoSize = true;
            автобусLabel2.Location = new System.Drawing.Point(294, 22);
            автобусLabel2.Name = "автобусLabel2";
            автобусLabel2.Size = new System.Drawing.Size(51, 13);
            автобусLabel2.TabIndex = 4;
            автобусLabel2.Text = "Автобус:";
            // 
            // фИОLabel1
            // 
            фИОLabel1.AutoSize = true;
            фИОLabel1.Location = new System.Drawing.Point(8, 54);
            фИОLabel1.Name = "фИОLabel1";
            фИОLabel1.Size = new System.Drawing.Size(37, 13);
            фИОLabel1.TabIndex = 6;
            фИОLabel1.Text = "ФИО:";
            // 
            // маршрутLabel1
            // 
            маршрутLabel1.AutoSize = true;
            маршрутLabel1.Location = new System.Drawing.Point(294, 51);
            маршрутLabel1.Name = "маршрутLabel1";
            маршрутLabel1.Size = new System.Drawing.Size(55, 13);
            маршрутLabel1.TabIndex = 8;
            маршрутLabel1.Text = "Маршрут:";
            // 
            // датаLabel
            // 
            датаLabel.AutoSize = true;
            датаLabel.Location = new System.Drawing.Point(586, 22);
            датаLabel.Name = "датаLabel";
            датаLabel.Size = new System.Drawing.Size(36, 13);
            датаLabel.TabIndex = 10;
            датаLabel.Text = "Дата:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(808, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьToolStripMenuItem,
            this.выполнитьРезервноеКопированиеToolStripMenuItem,
            this.RestoreBackUPToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // выполнитьРезервноеКопированиеToolStripMenuItem
            // 
            this.выполнитьРезервноеКопированиеToolStripMenuItem.Name = "выполнитьРезервноеКопированиеToolStripMenuItem";
            this.выполнитьРезервноеКопированиеToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.выполнитьРезервноеКопированиеToolStripMenuItem.Text = "Выполнить резервное копирование";
            this.выполнитьРезервноеКопированиеToolStripMenuItem.Click += new System.EventHandler(this.выполнитьРезервноеКопированиеToolStripMenuItem_Click);
            // 
            // RestoreBackUPToolStripMenuItem
            // 
            this.RestoreBackUPToolStripMenuItem.Name = "RestoreBackUPToolStripMenuItem";
            this.RestoreBackUPToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
            this.RestoreBackUPToolStripMenuItem.Text = "Восстановить данные из резервной копии";
            this.RestoreBackUPToolStripMenuItem.Click += new System.EventHandler(this.восстановитьДанныеИзРезервнойКопииToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(306, 22);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 509);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.поискВодителяПоФИОToolStrip);
            this.tabPage1.Controls.Add(this.поискВодителяПоПаспортуToolStrip);
            this.tabPage1.Controls.Add(this.водителиDataGridView);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Водители";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // поискВодителяПоФИОToolStrip
            // 
            this.поискВодителяПоФИОToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.поискВодителяПоФИОToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фИОToolStripLabel,
            this.фИОToolStripTextBox,
            this.поискВодителяПоФИОToolStripButton});
            this.поискВодителяПоФИОToolStrip.Location = new System.Drawing.Point(425, 114);
            this.поискВодителяПоФИОToolStrip.Name = "поискВодителяПоФИОToolStrip";
            this.поискВодителяПоФИОToolStrip.Size = new System.Drawing.Size(347, 25);
            this.поискВодителяПоФИОToolStrip.TabIndex = 4;
            this.поискВодителяПоФИОToolStrip.Text = "поискВодителяПоФИОToolStrip";
            // 
            // фИОToolStripLabel
            // 
            this.фИОToolStripLabel.Name = "фИОToolStripLabel";
            this.фИОToolStripLabel.Size = new System.Drawing.Size(37, 22);
            this.фИОToolStripLabel.Text = "ФИО:";
            // 
            // фИОToolStripTextBox
            // 
            this.фИОToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.фИОToolStripTextBox.Name = "фИОToolStripTextBox";
            this.фИОToolStripTextBox.Size = new System.Drawing.Size(150, 25);
            // 
            // поискВодителяПоФИОToolStripButton
            // 
            this.поискВодителяПоФИОToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.поискВодителяПоФИОToolStripButton.Name = "поискВодителяПоФИОToolStripButton";
            this.поискВодителяПоФИОToolStripButton.Size = new System.Drawing.Size(146, 22);
            this.поискВодителяПоФИОToolStripButton.Text = "Поиск водителя по ФИО";
            this.поискВодителяПоФИОToolStripButton.Click += new System.EventHandler(this.поискВодителяПоФИОToolStripButton_Click);
            // 
            // поискВодителяПоПаспортуToolStrip
            // 
            this.поискВодителяПоПаспортуToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.поискВодителяПоПаспортуToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.паспортToolStripLabel,
            this.паспортToolStripTextBox,
            this.поискВодителяПоПаспортуToolStripButton});
            this.поискВодителяПоПаспортуToolStrip.Location = new System.Drawing.Point(6, 114);
            this.поискВодителяПоПаспортуToolStrip.Name = "поискВодителяПоПаспортуToolStrip";
            this.поискВодителяПоПаспортуToolStrip.Size = new System.Drawing.Size(422, 25);
            this.поискВодителяПоПаспортуToolStrip.TabIndex = 4;
            this.поискВодителяПоПаспортуToolStrip.Text = "поискВодителяПоПаспортуToolStrip";
            // 
            // паспортToolStripLabel
            // 
            this.паспортToolStripLabel.Name = "паспортToolStripLabel";
            this.паспортToolStripLabel.Size = new System.Drawing.Size(57, 22);
            this.паспортToolStripLabel.Text = "Паспорт:";
            // 
            // паспортToolStripTextBox
            // 
            this.паспортToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.паспортToolStripTextBox.Name = "паспортToolStripTextBox";
            this.паспортToolStripTextBox.Size = new System.Drawing.Size(150, 25);
            // 
            // поискВодителяПоПаспортуToolStripButton
            // 
            this.поискВодителяПоПаспортуToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.поискВодителяПоПаспортуToolStripButton.Name = "поискВодителяПоПаспортуToolStripButton";
            this.поискВодителяПоПаспортуToolStripButton.Size = new System.Drawing.Size(170, 22);
            this.поискВодителяПоПаспортуToolStripButton.Text = "Поиск водителя по паспорту";
            this.поискВодителяПоПаспортуToolStripButton.Click += new System.EventHandler(this.поискВодителяПоПаспортуToolStripButton_Click);
            // 
            // водителиDataGridView
            // 
            this.водителиDataGridView.AutoGenerateColumns = false;
            this.водителиDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.водителиDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.водителиDataGridView.DataSource = this.водителиBindingSource;
            this.водителиDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.водителиDataGridView.Location = new System.Drawing.Point(3, 145);
            this.водителиDataGridView.Name = "водителиDataGridView";
            this.водителиDataGridView.Size = new System.Drawing.Size(770, 335);
            this.водителиDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Паспорт";
            this.dataGridViewTextBoxColumn1.HeaderText = "Паспорт";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ФИО";
            this.dataGridViewTextBoxColumn2.HeaderText = "ФИО";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Оклад";
            this.dataGridViewTextBoxColumn3.HeaderText = "Оклад";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Стаж";
            this.dataGridViewTextBoxColumn4.HeaderText = "Стаж";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Класс";
            this.dataGridViewTextBoxColumn5.HeaderText = "Класс";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // водителиBindingSource
            // 
            this.водителиBindingSource.DataMember = "Водители";
            this.водителиBindingSource.DataSource = this.database1DataSet;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button20);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(паспортLabel);
            this.groupBox1.Controls.Add(this.паспортTextBox);
            this.groupBox1.Controls.Add(фИОLabel);
            this.groupBox1.Controls.Add(this.фИОTextBox);
            this.groupBox1.Controls.Add(стажLabel);
            this.groupBox1.Controls.Add(this.стажTextBox);
            this.groupBox1.Controls.Add(классLabel);
            this.groupBox1.Controls.Add(this.классTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа с данными водителей";
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(549, 77);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(209, 23);
            this.button20.TabIndex = 12;
            this.button20.Text = "Показать водителей не на маршрутах";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(549, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Уволить водителя";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(549, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Добавить нового водителя";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // паспортTextBox
            // 
            this.паспортTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.водителиBindingSource, "Паспорт", true));
            this.паспортTextBox.Location = new System.Drawing.Point(65, 23);
            this.паспортTextBox.Name = "паспортTextBox";
            this.паспортTextBox.Size = new System.Drawing.Size(193, 20);
            this.паспортTextBox.TabIndex = 1;
            // 
            // фИОTextBox
            // 
            this.фИОTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.водителиBindingSource, "ФИО", true));
            this.фИОTextBox.Location = new System.Drawing.Point(65, 49);
            this.фИОTextBox.Name = "фИОTextBox";
            this.фИОTextBox.Size = new System.Drawing.Size(193, 20);
            this.фИОTextBox.TabIndex = 3;
            // 
            // стажTextBox
            // 
            this.стажTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.водителиBindingSource, "Стаж", true));
            this.стажTextBox.Location = new System.Drawing.Point(328, 23);
            this.стажTextBox.Name = "стажTextBox";
            this.стажTextBox.Size = new System.Drawing.Size(208, 20);
            this.стажTextBox.TabIndex = 7;
            // 
            // классTextBox
            // 
            this.классTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.водителиBindingSource, "Класс", true));
            this.классTextBox.Location = new System.Drawing.Point(328, 49);
            this.классTextBox.Name = "классTextBox";
            this.классTextBox.Size = new System.Drawing.Size(208, 20);
            this.классTextBox.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.тип_вместимостьDataGridView);
            this.tabPage2.Controls.Add(this.автобусыDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Автобусы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.поискАвтобусаToolStrip);
            this.groupBox3.Location = new System.Drawing.Point(455, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 101);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поиск";
            // 
            // поискАвтобусаToolStrip
            // 
            this.поискАвтобусаToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.поискАвтобусаToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.автобусToolStripLabel,
            this.автобусToolStripTextBox,
            this.поискАвтобусаToolStripButton});
            this.поискАвтобусаToolStrip.Location = new System.Drawing.Point(7, 19);
            this.поискАвтобусаToolStrip.Name = "поискАвтобусаToolStrip";
            this.поискАвтобусаToolStrip.Size = new System.Drawing.Size(290, 25);
            this.поискАвтобусаToolStrip.TabIndex = 3;
            this.поискАвтобусаToolStrip.Text = "поискАвтобусаToolStrip";
            // 
            // автобусToolStripLabel
            // 
            this.автобусToolStripLabel.Name = "автобусToolStripLabel";
            this.автобусToolStripLabel.Size = new System.Drawing.Size(55, 22);
            this.автобусToolStripLabel.Text = "Автобус:";
            // 
            // автобусToolStripTextBox
            // 
            this.автобусToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.автобусToolStripTextBox.Name = "автобусToolStripTextBox";
            this.автобусToolStripTextBox.Size = new System.Drawing.Size(121, 25);
            // 
            // поискАвтобусаToolStripButton
            // 
            this.поискАвтобусаToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.поискАвтобусаToolStripButton.Name = "поискАвтобусаToolStripButton";
            this.поискАвтобусаToolStripButton.Size = new System.Drawing.Size(100, 22);
            this.поискАвтобусаToolStripButton.Text = "Поиск Автобуса";
            this.поискАвтобусаToolStripButton.Click += new System.EventHandler(this.поискАвтобусаToolStripButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button21);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.автобусTextBox);
            this.groupBox2.Controls.Add(автобусLabel);
            this.groupBox2.Controls.Add(типLabel);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 101);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа с данными автобусов";
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(216, 72);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(221, 23);
            this.button21.TabIndex = 4;
            this.button21.Text = "Показать автобусы не на маршруте";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "малый",
            "средний",
            "большой",
            "сочлененный большой",
            "большой двухъярусный"});
            this.comboBox1.Location = new System.Drawing.Point(71, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(216, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(221, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Добавить автобус";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(216, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(221, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Списать автобус";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // автобусTextBox
            // 
            this.автобусTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.автобусыBindingSource, "Автобус", true));
            this.автобусTextBox.Location = new System.Drawing.Point(71, 19);
            this.автобусTextBox.Name = "автобусTextBox";
            this.автобусTextBox.Size = new System.Drawing.Size(139, 20);
            this.автобусTextBox.TabIndex = 3;
            // 
            // автобусыBindingSource
            // 
            this.автобусыBindingSource.DataMember = "Автобусы";
            this.автобусыBindingSource.DataSource = this.database1DataSet;
            // 
            // тип_вместимостьDataGridView
            // 
            this.тип_вместимостьDataGridView.AutoGenerateColumns = false;
            this.тип_вместимостьDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.тип_вместимостьDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.тип_вместимостьDataGridView.DataSource = this.тип_вместимостьBindingSource;
            this.тип_вместимостьDataGridView.Location = new System.Drawing.Point(455, 113);
            this.тип_вместимостьDataGridView.Name = "тип_вместимостьDataGridView";
            this.тип_вместимостьDataGridView.Size = new System.Drawing.Size(315, 364);
            this.тип_вместимостьDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Тип";
            this.dataGridViewTextBoxColumn8.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Вместимость(мест)";
            this.dataGridViewTextBoxColumn9.HeaderText = "Вместимость(мест)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // тип_вместимостьBindingSource
            // 
            this.тип_вместимостьBindingSource.DataMember = "Тип_вместимость";
            this.тип_вместимостьBindingSource.DataSource = this.database1DataSet;
            // 
            // автобусыDataGridView
            // 
            this.автобусыDataGridView.AutoGenerateColumns = false;
            this.автобусыDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.автобусыDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.автобусDataGridViewTextBoxColumn,
            this.типDataGridViewTextBoxColumn});
            this.автобусыDataGridView.DataSource = this.автобусыBindingSource;
            this.автобусыDataGridView.Location = new System.Drawing.Point(6, 113);
            this.автобусыDataGridView.Name = "автобусыDataGridView";
            this.автобусыDataGridView.Size = new System.Drawing.Size(443, 364);
            this.автобусыDataGridView.TabIndex = 0;
            // 
            // автобусDataGridViewTextBoxColumn
            // 
            this.автобусDataGridViewTextBoxColumn.DataPropertyName = "Автобус";
            this.автобусDataGridViewTextBoxColumn.HeaderText = "Автобус";
            this.автобусDataGridViewTextBoxColumn.Name = "автобусDataGridViewTextBoxColumn";
            // 
            // типDataGridViewTextBoxColumn
            // 
            this.типDataGridViewTextBoxColumn.DataPropertyName = "Тип";
            this.типDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.типDataGridViewTextBoxColumn.Name = "типDataGridViewTextBoxColumn";
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.маршрутыDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(776, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Маршруты";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.поискМаршрутаToolStrip);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(маршрутLabel);
            this.groupBox4.Controls.Add(this.маршрутTextBox);
            this.groupBox4.Controls.Add(начальный_пунктLabel);
            this.groupBox4.Controls.Add(this.начальный_пунктTextBox);
            this.groupBox4.Controls.Add(конечный_пунктLabel);
            this.groupBox4.Controls.Add(this.конечный_пунктTextBox);
            this.groupBox4.Controls.Add(время_начала_движенияLabel);
            this.groupBox4.Controls.Add(this.время_начала_движенияTextBox);
            this.groupBox4.Controls.Add(время_окончания_движенияLabel);
            this.groupBox4.Controls.Add(this.время_окончания_движенияTextBox);
            this.groupBox4.Controls.Add(интервал_мин_Label);
            this.groupBox4.Controls.Add(this.интервал_мин_TextBox);
            this.groupBox4.Controls.Add(протяженность_мин_Label);
            this.groupBox4.Controls.Add(this.протяженность_мин_TextBox);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(764, 149);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Работа с данными маршрутов автобусов";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(469, 120);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(140, 23);
            this.button7.TabIndex = 15;
            this.button7.Text = "Удалить маршрут";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // поискМаршрутаToolStrip
            // 
            this.поискМаршрутаToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.поискМаршрутаToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.маршрутToolStripLabel,
            this.маршрутToolStripTextBox,
            this.поискМаршрутаToolStripButton});
            this.поискМаршрутаToolStrip.Location = new System.Drawing.Point(9, 111);
            this.поискМаршрутаToolStrip.Name = "поискМаршрутаToolStrip";
            this.поискМаршрутаToolStrip.Size = new System.Drawing.Size(282, 25);
            this.поискМаршрутаToolStrip.TabIndex = 3;
            this.поискМаршрутаToolStrip.Text = "поискМаршрутаToolStrip";
            // 
            // маршрутToolStripLabel
            // 
            this.маршрутToolStripLabel.Name = "маршрутToolStripLabel";
            this.маршрутToolStripLabel.Size = new System.Drawing.Size(63, 22);
            this.маршрутToolStripLabel.Text = "Маршрут:";
            // 
            // маршрутToolStripTextBox
            // 
            this.маршрутToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.маршрутToolStripTextBox.Name = "маршрутToolStripTextBox";
            this.маршрутToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // поискМаршрутаToolStripButton
            // 
            this.поискМаршрутаToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.поискМаршрутаToolStripButton.Name = "поискМаршрутаToolStripButton";
            this.поискМаршрутаToolStripButton.Size = new System.Drawing.Size(105, 22);
            this.поискМаршрутаToolStripButton.Text = "ПоискМаршрута";
            this.поискМаршрутаToolStripButton.Click += new System.EventHandler(this.поискМаршрутаToolStripButton_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(618, 120);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "Создать новый маршрут";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(469, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(289, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "Изменить протяженнотсь маршрута";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // маршрутTextBox
            // 
            this.маршрутTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.маршрутыBindingSource, "Маршрут", true));
            this.маршрутTextBox.Location = new System.Drawing.Point(105, 24);
            this.маршрутTextBox.Name = "маршрутTextBox";
            this.маршрутTextBox.Size = new System.Drawing.Size(152, 20);
            this.маршрутTextBox.TabIndex = 1;
            // 
            // маршрутыBindingSource
            // 
            this.маршрутыBindingSource.DataMember = "Маршруты";
            this.маршрутыBindingSource.DataSource = this.database1DataSet;
            // 
            // начальный_пунктTextBox
            // 
            this.начальный_пунктTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.маршрутыBindingSource, "Начальный_пункт", true));
            this.начальный_пунктTextBox.Location = new System.Drawing.Point(105, 50);
            this.начальный_пунктTextBox.Name = "начальный_пунктTextBox";
            this.начальный_пунктTextBox.Size = new System.Drawing.Size(152, 20);
            this.начальный_пунктTextBox.TabIndex = 3;
            // 
            // конечный_пунктTextBox
            // 
            this.конечный_пунктTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.маршрутыBindingSource, "Конечный_пункт", true));
            this.конечный_пунктTextBox.Location = new System.Drawing.Point(105, 76);
            this.конечный_пунктTextBox.Name = "конечный_пунктTextBox";
            this.конечный_пунктTextBox.Size = new System.Drawing.Size(152, 20);
            this.конечный_пунктTextBox.TabIndex = 5;
            // 
            // время_начала_движенияTextBox
            // 
            this.время_начала_движенияTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.маршрутыBindingSource, "Время_начала_движения", true));
            this.время_начала_движенияTextBox.Location = new System.Drawing.Point(433, 25);
            this.время_начала_движенияTextBox.Name = "время_начала_движенияTextBox";
            this.время_начала_движенияTextBox.Size = new System.Drawing.Size(118, 20);
            this.время_начала_движенияTextBox.TabIndex = 7;
            // 
            // время_окончания_движенияTextBox
            // 
            this.время_окончания_движенияTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.маршрутыBindingSource, "Время_окончания_движения", true));
            this.время_окончания_движенияTextBox.Location = new System.Drawing.Point(433, 54);
            this.время_окончания_движенияTextBox.Name = "время_окончания_движенияTextBox";
            this.время_окончания_движенияTextBox.Size = new System.Drawing.Size(118, 20);
            this.время_окончания_движенияTextBox.TabIndex = 9;
            // 
            // интервал_мин_TextBox
            // 
            this.интервал_мин_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.маршрутыBindingSource, "Интервал(мин)", true));
            this.интервал_мин_TextBox.Location = new System.Drawing.Point(701, 25);
            this.интервал_мин_TextBox.Name = "интервал_мин_TextBox";
            this.интервал_мин_TextBox.Size = new System.Drawing.Size(48, 20);
            this.интервал_мин_TextBox.TabIndex = 11;
            // 
            // протяженность_мин_TextBox
            // 
            this.протяженность_мин_TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.маршрутыBindingSource, "Протяженность(мин)", true));
            this.протяженность_мин_TextBox.Location = new System.Drawing.Point(701, 54);
            this.протяженность_мин_TextBox.Name = "протяженность_мин_TextBox";
            this.протяженность_мин_TextBox.Size = new System.Drawing.Size(48, 20);
            this.протяженность_мин_TextBox.TabIndex = 13;
            // 
            // маршрутыDataGridView
            // 
            this.маршрутыDataGridView.AutoGenerateColumns = false;
            this.маршрутыDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.маршрутыDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16});
            this.маршрутыDataGridView.DataSource = this.маршрутыBindingSource;
            this.маршрутыDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.маршрутыDataGridView.Location = new System.Drawing.Point(3, 164);
            this.маршрутыDataGridView.Name = "маршрутыDataGridView";
            this.маршрутыDataGridView.Size = new System.Drawing.Size(770, 316);
            this.маршрутыDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Маршрут";
            this.dataGridViewTextBoxColumn10.HeaderText = "Маршрут";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Начальный_пункт";
            this.dataGridViewTextBoxColumn11.HeaderText = "Начальный_пункт";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Конечный_пункт";
            this.dataGridViewTextBoxColumn12.HeaderText = "Конечный_пункт";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Время_начала_движения";
            this.dataGridViewTextBoxColumn13.HeaderText = "Время_начала_движения";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Время_окончания_движения";
            this.dataGridViewTextBoxColumn14.HeaderText = "Время_окончания_движения";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Интервал(мин)";
            this.dataGridViewTextBoxColumn15.HeaderText = "Интервал(мин)";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Протяженность(мин)";
            this.dataGridViewTextBoxColumn16.HeaderText = "Протяженность(мин)";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox6);
            this.tabPage5.Controls.Add(this.водятDataGridView);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(776, 483);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Автобусы на маршруте";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button12);
            this.groupBox6.Controls.Add(this.button11);
            this.groupBox6.Controls.Add(this.button10);
            this.groupBox6.Controls.Add(паспортLabel1);
            this.groupBox6.Controls.Add(this.паспортTextBox1);
            this.groupBox6.Controls.Add(автобусLabel2);
            this.groupBox6.Controls.Add(this.автобусTextBox2);
            this.groupBox6.Controls.Add(фИОLabel1);
            this.groupBox6.Controls.Add(this.фИОTextBox1);
            this.groupBox6.Controls.Add(маршрутLabel1);
            this.groupBox6.Controls.Add(this.маршрутTextBox1);
            this.groupBox6.Controls.Add(датаLabel);
            this.groupBox6.Controls.Add(this.датаDateTimePicker);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(764, 112);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Работа с автобусами на маршруте";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(355, 77);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(200, 23);
            this.button12.TabIndex = 14;
            this.button12.Text = "Снять автобус с маршрута";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(67, 77);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(200, 23);
            this.button11.TabIndex = 13;
            this.button11.Text = "Снять водителя с маршрута";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(589, 77);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(169, 23);
            this.button10.TabIndex = 12;
            this.button10.Text = "Новый автобус на маршруте";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // паспортTextBox1
            // 
            this.паспортTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.водятBindingSource, "Паспорт", true));
            this.паспортTextBox1.Location = new System.Drawing.Point(67, 19);
            this.паспортTextBox1.Name = "паспортTextBox1";
            this.паспортTextBox1.Size = new System.Drawing.Size(200, 20);
            this.паспортTextBox1.TabIndex = 3;
            // 
            // водятBindingSource
            // 
            this.водятBindingSource.DataMember = "Водят";
            this.водятBindingSource.DataSource = this.database1DataSet;
            // 
            // автобусTextBox2
            // 
            this.автобусTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.водятBindingSource, "Автобус", true));
            this.автобусTextBox2.Location = new System.Drawing.Point(355, 16);
            this.автобусTextBox2.Name = "автобусTextBox2";
            this.автобусTextBox2.Size = new System.Drawing.Size(200, 20);
            this.автобусTextBox2.TabIndex = 5;
            // 
            // фИОTextBox1
            // 
            this.фИОTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.водятBindingSource, "ФИО", true));
            this.фИОTextBox1.Location = new System.Drawing.Point(67, 51);
            this.фИОTextBox1.Name = "фИОTextBox1";
            this.фИОTextBox1.Size = new System.Drawing.Size(200, 20);
            this.фИОTextBox1.TabIndex = 7;
            // 
            // маршрутTextBox1
            // 
            this.маршрутTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.водятBindingSource, "Маршрут", true));
            this.маршрутTextBox1.Location = new System.Drawing.Point(355, 48);
            this.маршрутTextBox1.Name = "маршрутTextBox1";
            this.маршрутTextBox1.Size = new System.Drawing.Size(200, 20);
            this.маршрутTextBox1.TabIndex = 9;
            // 
            // датаDateTimePicker
            // 
            this.датаDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.водятBindingSource, "Дата", true));
            this.датаDateTimePicker.Location = new System.Drawing.Point(628, 19);
            this.датаDateTimePicker.Name = "датаDateTimePicker";
            this.датаDateTimePicker.Size = new System.Drawing.Size(130, 20);
            this.датаDateTimePicker.TabIndex = 11;
            // 
            // водятDataGridView
            // 
            this.водятDataGridView.AutoGenerateColumns = false;
            this.водятDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.водятDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25});
            this.водятDataGridView.DataSource = this.водятBindingSource;
            this.водятDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.водятDataGridView.Location = new System.Drawing.Point(3, 124);
            this.водятDataGridView.Name = "водятDataGridView";
            this.водятDataGridView.Size = new System.Drawing.Size(770, 356);
            this.водятDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "id_Водителя";
            this.dataGridViewTextBoxColumn20.HeaderText = "id_Водителя";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Паспорт";
            this.dataGridViewTextBoxColumn21.HeaderText = "Паспорт";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Автобус";
            this.dataGridViewTextBoxColumn22.HeaderText = "Автобус";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "ФИО";
            this.dataGridViewTextBoxColumn23.HeaderText = "ФИО";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Маршрут";
            this.dataGridViewTextBoxColumn24.HeaderText = "Маршрут";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "Дата";
            this.dataGridViewTextBoxColumn25.HeaderText = "Дата";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(776, 483);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Запросы и справки";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 273);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(755, 204);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button19);
            this.groupBox8.Controls.Add(this.button18);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.textBox4);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Location = new System.Drawing.Point(15, 165);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(755, 102);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Справки и отчеты";
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(438, 59);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(136, 26);
            this.button19.TabIndex = 3;
            this.button19.Text = "Выдать полный отчет";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(328, 21);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 23);
            this.button18.TabIndex = 3;
            this.button18.Text = "Выдать";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(246, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Выдать справку о протяженности маршрута №";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(268, 23);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(54, 20);
            this.textBox4.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(416, 26);
            this.label6.TabIndex = 1;
            this.label6.Text = "Выдать отчет по автопарку (количество автобусов и их тип, номера маршрутов, \r\n вр" +
    "емя начала движения и интервал, ФИО водителей и их класс).";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.textBox3);
            this.groupBox7.Controls.Add(this.comboBox2);
            this.groupBox7.Controls.Add(this.comboBox3);
            this.groupBox7.Controls.Add(this.button17);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.textBox1);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.comboBox4);
            this.groupBox7.Controls.Add(this.button13);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.textBox2);
            this.groupBox7.Controls.Add(this.button16);
            this.groupBox7.Controls.Add(this.button14);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.button15);
            this.groupBox7.Location = new System.Drawing.Point(15, 13);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(755, 146);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Запросы";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список водителей, работающих на маршруте №\r\n";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(328, 114);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(246, 20);
            this.textBox3.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "всех"});
            this.comboBox2.Location = new System.Drawing.Point(268, 81);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(54, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "начинается",
            "заканчивается",
            "начинается и заканчивается"});
            this.comboBox3.Location = new System.Drawing.Point(328, 81);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(246, 21);
            this.comboBox3.TabIndex = 3;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(580, 112);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 0;
            this.button17.Text = "Показать";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Движение автобусов на маршруте №";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(268, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(317, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Номера автобусов, на которые работает водитель (Паспорт)";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "всех"});
            this.comboBox4.Location = new System.Drawing.Point(595, 25);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(54, 21);
            this.comboBox4.TabIndex = 3;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(328, 23);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 0;
            this.button13.Text = "Показать";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Номера автобусов, обслуживающих маршрут №";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(268, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(54, 20);
            this.textBox2.TabIndex = 2;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(657, 23);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 0;
            this.button16.Text = "Показать";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(328, 50);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 0;
            this.button14.Text = "Показать";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Протяженность маршрута №";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(580, 79);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 0;
            this.button15.Text = "Показать";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.AutoScroll = true;
            this.tabPage6.Controls.Add(this.groupBox5);
            this.tabPage6.Controls.Add(this.списанные_автобусыDataGridView);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(776, 483);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Списанные автобусы";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Controls.Add(автобусLabel1);
            this.groupBox5.Controls.Add(this.автобусTextBox1);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(764, 60);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Вернуть автобус";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(389, 21);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(157, 23);
            this.button9.TabIndex = 4;
            this.button9.Text = "Удалить навсегда";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(217, 21);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(157, 23);
            this.button8.TabIndex = 3;
            this.button8.Text = "Вернуть автобус";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // автобусTextBox1
            // 
            this.автобусTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.списанные_автобусыBindingSource, "Автобус", true));
            this.автобусTextBox1.Location = new System.Drawing.Point(63, 23);
            this.автобусTextBox1.Name = "автобусTextBox1";
            this.автобусTextBox1.Size = new System.Drawing.Size(136, 20);
            this.автобусTextBox1.TabIndex = 2;
            // 
            // списанные_автобусыBindingSource
            // 
            this.списанные_автобусыBindingSource.DataMember = "Списанные_автобусы";
            this.списанные_автобусыBindingSource.DataSource = this.database1DataSet1;
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet1";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // списанные_автобусыDataGridView
            // 
            this.списанные_автобусыDataGridView.AutoGenerateColumns = false;
            this.списанные_автобусыDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.списанные_автобусыDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19});
            this.списанные_автобусыDataGridView.DataSource = this.списанные_автобусыBindingSource;
            this.списанные_автобусыDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.списанные_автобусыDataGridView.Location = new System.Drawing.Point(3, 72);
            this.списанные_автобусыDataGridView.Name = "списанные_автобусыDataGridView";
            this.списанные_автобусыDataGridView.Size = new System.Drawing.Size(770, 408);
            this.списанные_автобусыDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Автобус";
            this.dataGridViewTextBoxColumn17.HeaderText = "Автобус";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Тип";
            this.dataGridViewTextBoxColumn18.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Дата";
            this.dataGridViewTextBoxColumn19.HeaderText = "Дата";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(808, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // водителиTableAdapter
            // 
            this.водителиTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Avtopark.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.АвтобусыTableAdapter = null;
            this.tableAdapterManager.ВодителиTableAdapter = this.водителиTableAdapter;
            this.tableAdapterManager.ВодятTableAdapter = null;
            this.tableAdapterManager.МаршрутыTableAdapter = null;
            this.tableAdapterManager.ОкладTableAdapter = null;
            this.tableAdapterManager.Тип_вместимостьTableAdapter = null;
            // 
            // автобусыTableAdapter
            // 
            this.автобусыTableAdapter.ClearBeforeFill = true;
            // 
            // тип_вместимостьTableAdapter
            // 
            this.тип_вместимостьTableAdapter.ClearBeforeFill = true;
            // 
            // маршрутыTableAdapter
            // 
            this.маршрутыTableAdapter.ClearBeforeFill = true;
            // 
            // списанные_автобусыTableAdapter
            // 
            this.списанные_автобусыTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.UpdateOrder = Avtopark.Database1DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.Списанные_автобусыTableAdapter = this.списанные_автобусыTableAdapter;
            // 
            // водятTableAdapter
            // 
            this.водятTableAdapter.ClearBeforeFill = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 561);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(824, 600);
            this.MinimumSize = new System.Drawing.Size(824, 600);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Автопарк";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.поискВодителяПоФИОToolStrip.ResumeLayout(false);
            this.поискВодителяПоФИОToolStrip.PerformLayout();
            this.поискВодителяПоПаспортуToolStrip.ResumeLayout(false);
            this.поискВодителяПоПаспортуToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.водителиDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.водителиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.поискАвтобусаToolStrip.ResumeLayout(false);
            this.поискАвтобусаToolStrip.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.автобусыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.тип_вместимостьDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.тип_вместимостьBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.автобусыDataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.поискМаршрутаToolStrip.ResumeLayout(false);
            this.поискМаршрутаToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.маршрутыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.маршрутыDataGridView)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.водятBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.водятDataGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.списанные_автобусыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.списанные_автобусыDataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource водителиBindingSource;
        private Database1DataSetTableAdapters.ВодителиTableAdapter водителиTableAdapter;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView водителиDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox паспортTextBox;
        private System.Windows.Forms.TextBox фИОTextBox;
        private System.Windows.Forms.TextBox стажTextBox;
        private System.Windows.Forms.ToolStrip поискВодителяПоПаспортуToolStrip;
        private System.Windows.Forms.ToolStripLabel паспортToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox паспортToolStripTextBox;
        private System.Windows.Forms.ToolStripButton поискВодителяПоПаспортуToolStripButton;
        private System.Windows.Forms.ToolStrip поискВодителяПоФИОToolStrip;
        private System.Windows.Forms.ToolStripLabel фИОToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox фИОToolStripTextBox;
        private System.Windows.Forms.ToolStripButton поискВодителяПоФИОToolStripButton;
        private System.Windows.Forms.BindingSource автобусыBindingSource;
        private Database1DataSetTableAdapters.АвтобусыTableAdapter автобусыTableAdapter;
        private System.Windows.Forms.DataGridView автобусыDataGridView;
        private System.Windows.Forms.BindingSource тип_вместимостьBindingSource;
        private Database1DataSetTableAdapters.Тип_вместимостьTableAdapter тип_вместимостьTableAdapter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox автобусTextBox;
        private System.Windows.Forms.DataGridView тип_вместимостьDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStrip поискАвтобусаToolStrip;
        private System.Windows.Forms.ToolStripLabel автобусToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox автобусToolStripTextBox;
        private System.Windows.Forms.ToolStripButton поискАвтобусаToolStripButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource маршрутыBindingSource;
        private Database1DataSetTableAdapters.МаршрутыTableAdapter маршрутыTableAdapter;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox маршрутTextBox;
        private System.Windows.Forms.TextBox начальный_пунктTextBox;
        private System.Windows.Forms.TextBox конечный_пунктTextBox;
        private System.Windows.Forms.TextBox время_начала_движенияTextBox;
        private System.Windows.Forms.TextBox время_окончания_движенияTextBox;
        private System.Windows.Forms.TextBox интервал_мин_TextBox;
        private System.Windows.Forms.TextBox протяженность_мин_TextBox;
        private System.Windows.Forms.DataGridView маршрутыDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ToolStrip поискМаршрутаToolStrip;
        private System.Windows.Forms.ToolStripLabel маршрутToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox маршрутToolStripTextBox;
        private System.Windows.Forms.ToolStripButton поискМаршрутаToolStripButton;
        private System.Windows.Forms.Button button7;
        private Database1DataSet1 database1DataSet1;
        private System.Windows.Forms.BindingSource списанные_автобусыBindingSource;
        private Database1DataSet1TableAdapters.Списанные_автобусыTableAdapter списанные_автобусыTableAdapter;
        private Database1DataSet1TableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox автобусTextBox1;
        private System.Windows.Forms.DataGridView списанные_автобусыDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.BindingSource водятBindingSource;
        private Database1DataSetTableAdapters.ВодятTableAdapter водятTableAdapter;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView водятDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox паспортTextBox1;
        private System.Windows.Forms.TextBox автобусTextBox2;
        private System.Windows.Forms.TextBox фИОTextBox1;
        private System.Windows.Forms.TextBox маршрутTextBox1;
        private System.Windows.Forms.DateTimePicker датаDateTimePicker;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox классTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn автобусDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn типDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.ToolStripMenuItem выполнитьРезервноеКопированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestoreBackUPToolStripMenuItem;
    }
}