namespace Coursework
{
    partial class SportsForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.спортивныеСооруженияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спорстменыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тренерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.соревнованияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клубыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.организаторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видыСпортаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxSports = new System.Windows.Forms.ListBox();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.спортивныеСооруженияToolStripMenuItem,
            this.спорстменыToolStripMenuItem,
            this.тренерыToolStripMenuItem,
            this.соревнованияToolStripMenuItem,
            this.клубыToolStripMenuItem,
            this.организаторыToolStripMenuItem,
            this.видыСпортаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(900, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // спортивныеСооруженияToolStripMenuItem
            // 
            this.спортивныеСооруженияToolStripMenuItem.Name = "спортивныеСооруженияToolStripMenuItem";
            this.спортивныеСооруженияToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.спортивныеСооруженияToolStripMenuItem.Text = "Спортивные сооружения";
            this.спортивныеСооруженияToolStripMenuItem.Click += new System.EventHandler(this.спортивныеСооруженияToolStripMenuItem_Click);
            // 
            // спорстменыToolStripMenuItem
            // 
            this.спорстменыToolStripMenuItem.Name = "спорстменыToolStripMenuItem";
            this.спорстменыToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.спорстменыToolStripMenuItem.Text = "Спорстмены";
            this.спорстменыToolStripMenuItem.Click += new System.EventHandler(this.спорстменыToolStripMenuItem_Click);
            // 
            // тренерыToolStripMenuItem
            // 
            this.тренерыToolStripMenuItem.Name = "тренерыToolStripMenuItem";
            this.тренерыToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.тренерыToolStripMenuItem.Text = "Тренеры";
            this.тренерыToolStripMenuItem.Click += new System.EventHandler(this.тренерыToolStripMenuItem_Click);
            // 
            // соревнованияToolStripMenuItem
            // 
            this.соревнованияToolStripMenuItem.Name = "соревнованияToolStripMenuItem";
            this.соревнованияToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.соревнованияToolStripMenuItem.Text = "Соревнования";
            this.соревнованияToolStripMenuItem.Click += new System.EventHandler(this.соревнованияToolStripMenuItem_Click);
            // 
            // клубыToolStripMenuItem
            // 
            this.клубыToolStripMenuItem.Name = "клубыToolStripMenuItem";
            this.клубыToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.клубыToolStripMenuItem.Text = "Клубы";
            this.клубыToolStripMenuItem.Click += new System.EventHandler(this.клубыToolStripMenuItem_Click);
            // 
            // организаторыToolStripMenuItem
            // 
            this.организаторыToolStripMenuItem.Name = "организаторыToolStripMenuItem";
            this.организаторыToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.организаторыToolStripMenuItem.Text = "Организаторы";
            this.организаторыToolStripMenuItem.Click += new System.EventHandler(this.организаторыToolStripMenuItem_Click);
            // 
            // видыСпортаToolStripMenuItem
            // 
            this.видыСпортаToolStripMenuItem.Name = "видыСпортаToolStripMenuItem";
            this.видыСпортаToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.видыСпортаToolStripMenuItem.Text = "Виды спорта";
            // 
            // listBoxSports
            // 
            this.listBoxSports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.listBoxSports.FormattingEnabled = true;
            this.listBoxSports.ItemHeight = 18;
            this.listBoxSports.Location = new System.Drawing.Point(24, 80);
            this.listBoxSports.Name = "listBoxSports";
            this.listBoxSports.Size = new System.Drawing.Size(391, 310);
            this.listBoxSports.TabIndex = 1;
            this.listBoxSports.SelectedIndexChanged += new System.EventHandler(this.listBoxSports_SelectedIndexChanged);
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.ItemHeight = 18;
            this.listBoxInfo.Location = new System.Drawing.Point(438, 80);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(418, 310);
            this.listBoxInfo.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(12, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button2.Location = new System.Drawing.Point(158, 396);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 42);
            this.button2.TabIndex = 4;
            this.button2.Text = "Изменить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button3.Location = new System.Drawing.Point(302, 396);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 42);
            this.button3.TabIndex = 5;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(24, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Виды спорта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(435, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Информация";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(523, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "Введите характеристики объекта";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(433, 168);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(434, 30);
            this.textBoxName.TabIndex = 28;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCode.Location = new System.Drawing.Point(433, 235);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(434, 30);
            this.textBoxCode.TabIndex = 29;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button4.Location = new System.Drawing.Point(584, 288);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 37);
            this.button4.TabIndex = 30;
            this.button4.Text = "Добавить";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(435, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "Название:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(430, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 32;
            this.label5.Text = "Код:";
            // 
            // Sports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.listBoxSports);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Sports";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem спортивныеСооруженияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спорстменыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тренерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem соревнованияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клубыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem организаторыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видыСпортаToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxSports;
        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
    