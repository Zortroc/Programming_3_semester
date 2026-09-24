namespace WindowView
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnDeleteStudent = new System.Windows.Forms.Button();
            this.btnShowTableList = new System.Windows.Forms.Button();
            this.btnShowHistogram = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.18F);
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "DecanatPRO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.12F);
            this.label2.Location = new System.Drawing.Point(13, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "МЕНЮ";
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(17, 189);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(142, 23);
            this.btnAddStudent.TabIndex = 2;
            this.btnAddStudent.Text = "Добавить студента";
            this.btnAddStudent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnDeleteStudent
            // 
            this.btnDeleteStudent.Location = new System.Drawing.Point(18, 218);
            this.btnDeleteStudent.Name = "btnDeleteStudent";
            this.btnDeleteStudent.Size = new System.Drawing.Size(141, 23);
            this.btnDeleteStudent.TabIndex = 2;
            this.btnDeleteStudent.Text = "Удалить студента";
            this.btnDeleteStudent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteStudent.UseVisualStyleBackColor = true;
            this.btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);
            // 
            // btnShowTableList
            // 
            this.btnShowTableList.Location = new System.Drawing.Point(18, 247);
            this.btnShowTableList.Name = "btnShowTableList";
            this.btnShowTableList.Size = new System.Drawing.Size(141, 42);
            this.btnShowTableList.TabIndex = 2;
            this.btnShowTableList.Text = "Список студентов в таблицу";
            this.btnShowTableList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowTableList.UseVisualStyleBackColor = true;
            this.btnShowTableList.Click += new System.EventHandler(this.btnShowTableList_Click);
            // 
            // btnShowHistogram
            // 
            this.btnShowHistogram.Location = new System.Drawing.Point(18, 295);
            this.btnShowHistogram.Name = "btnShowHistogram";
            this.btnShowHistogram.Size = new System.Drawing.Size(141, 58);
            this.btnShowHistogram.TabIndex = 2;
            this.btnShowHistogram.Text = "Гистограмма студентов по специальности";
            this.btnShowHistogram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowHistogram.UseVisualStyleBackColor = true;
            this.btnShowHistogram.Click += new System.EventHandler(this.btnShowHistogram_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(220, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(554, 233);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnShowHistogram);
            this.Controls.Add(this.btnShowTableList);
            this.Controls.Add(this.btnDeleteStudent);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "ДеканатПРО МЕНЮ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.Button btnShowTableList;
        private System.Windows.Forms.Button btnShowHistogram;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

