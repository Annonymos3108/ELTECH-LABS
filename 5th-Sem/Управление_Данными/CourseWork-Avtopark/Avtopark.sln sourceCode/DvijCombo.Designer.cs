
namespace Avtopark
{
    partial class DvijCombo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DvijCombo));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Маршрут = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Время_начала_движения = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Время_окончания_движения = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Маршрут,
            this.Время_начала_движения,
            this.Время_окончания_движения});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(558, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // Маршрут
            // 
            this.Маршрут.HeaderText = "Маршрут";
            this.Маршрут.Name = "Маршрут";
            // 
            // Время_начала_движения
            // 
            this.Время_начала_движения.HeaderText = "Время_начала_движения";
            this.Время_начала_движения.Name = "Время_начала_движения";
            // 
            // Время_окончания_движения
            // 
            this.Время_окончания_движения.HeaderText = "Время_окончания_движения";
            this.Время_окончания_движения.Name = "Время_окончания_движения";
            // 
            // DvijCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 450);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DvijCombo";
            this.Text = "Начало и окончание движений автобусов на всех маршрутах";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Маршрут;
        private System.Windows.Forms.DataGridViewTextBoxColumn Время_начала_движения;
        private System.Windows.Forms.DataGridViewTextBoxColumn Время_окончания_движения;
    }
}