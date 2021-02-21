
namespace WindowsFormsAppFinal
{
    partial class RaspisanieNaDen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaspisanieNaDen));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Номер_урока = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Предмет = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Кабинет = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.деньlabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.классlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Номер_урока,
            this.Предмет,
            this.Кабинет});
            this.dataGridView1.Location = new System.Drawing.Point(12, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(512, 224);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Расписание на";
            // 
            // Номер_урока
            // 
            this.Номер_урока.HeaderText = "Номер_урока";
            this.Номер_урока.Name = "Номер_урока";
            // 
            // Предмет
            // 
            this.Предмет.HeaderText = "Предмет";
            this.Предмет.Name = "Предмет";
            // 
            // Кабинет
            // 
            this.Кабинет.HeaderText = "Кабинет";
            this.Кабинет.Name = "Кабинет";
            // 
            // деньlabel
            // 
            this.деньlabel.AutoSize = true;
            this.деньlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.деньlabel.Location = new System.Drawing.Point(184, 9);
            this.деньlabel.Name = "деньlabel";
            this.деньlabel.Size = new System.Drawing.Size(148, 25);
            this.деньlabel.TabIndex = 1;
            this.деньlabel.Text = "день недели";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "для класса";
            // 
            // классlabel
            // 
            this.классlabel.AutoSize = true;
            this.классlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.классlabel.Location = new System.Drawing.Point(141, 44);
            this.классlabel.Name = "классlabel";
            this.классlabel.Size = new System.Drawing.Size(74, 25);
            this.классlabel.TabIndex = 1;
            this.классlabel.Text = "класс";
            // 
            // RaspisanieNaDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 340);
            this.Controls.Add(this.классlabel);
            this.Controls.Add(this.деньlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RaspisanieNaDen";
            this.Text = "Расписание";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Номер_урока;
        private System.Windows.Forms.DataGridViewTextBoxColumn Предмет;
        private System.Windows.Forms.DataGridViewTextBoxColumn Кабинет;
        private System.Windows.Forms.Label деньlabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label классlabel;
    }
}