
namespace Conference
{
    partial class DeleteHotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteHotel));
            this.forceDelChkBox = new System.Windows.Forms.CheckBox();
            this.delbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.updChkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // forceDelChkBox
            // 
            this.forceDelChkBox.AutoSize = true;
            this.forceDelChkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forceDelChkBox.Location = new System.Drawing.Point(27, 184);
            this.forceDelChkBox.Name = "forceDelChkBox";
            this.forceDelChkBox.Size = new System.Drawing.Size(381, 44);
            this.forceDelChkBox.TabIndex = 0;
            this.forceDelChkBox.Text = "Удалить все данные по участникам \r\nконференций, проживающих в этой гостинице";
            this.forceDelChkBox.UseVisualStyleBackColor = true;
            // 
            // delbutton
            // 
            this.delbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delbutton.Location = new System.Drawing.Point(117, 247);
            this.delbutton.Name = "delbutton";
            this.delbutton.Size = new System.Drawing.Size(176, 46);
            this.delbutton.TabIndex = 1;
            this.delbutton.Text = "Удалить гостиницу";
            this.delbutton.UseVisualStyleBackColor = true;
            this.delbutton.Click += new System.EventHandler(this.delbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Для удаления гостиницы введитде id_гостиницы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(92, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "id_гостиница";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(206, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 4;
            // 
            // updChkBox
            // 
            this.updChkBox.AutoSize = true;
            this.updChkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updChkBox.Location = new System.Drawing.Point(27, 134);
            this.updChkBox.Name = "updChkBox";
            this.updChkBox.Size = new System.Drawing.Size(320, 44);
            this.updChkBox.TabIndex = 0;
            this.updChkBox.Text = "Обновить поля данных в связанных \r\nтаблицах и заполнять null значениями";
            this.updChkBox.UseVisualStyleBackColor = true;
            // 
            // DeleteHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 314);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delbutton);
            this.Controls.Add(this.updChkBox);
            this.Controls.Add(this.forceDelChkBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeleteHotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удалить гостиницу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox forceDelChkBox;
        private System.Windows.Forms.Button delbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox updChkBox;
    }
}