namespace Coursework
{
    partial class FacilitiesForm
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
            this.comboBoxSportFacilities = new System.Windows.Forms.ComboBox();
            this.SportFacillityProperties = new System.Windows.Forms.ListBox();
            this.SportFacilityInfo = new System.Windows.Forms.Label();
            this.SportFacilityChoose = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.спортивныеСооруженияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спортсменыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тренерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.соревнованияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.огранизаторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.организаторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.SportFacillityChoice = new System.Windows.Forms.ListBox();
            this.comboBoxProperties = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSportFacilities
            // 
            this.comboBoxSportFacilities.FormattingEnabled = true;
            this.comboBoxSportFacilities.Location = new System.Drawing.Point(204, 39);
            this.comboBoxSportFacilities.Name = "comboBoxSportFacilities";
            this.comboBoxSportFacilities.Size = new System.Drawing.Size(154, 24);
            this.comboBoxSportFacilities.TabIndex = 24;
            this.comboBoxSportFacilities.SelectedIndexChanged += new System.EventHandler(this.comboBoxSportFacilities_SelectedIndexChanged);
            // 
            // SportFacillityProperties
            // 
            this.SportFacillityProperties.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.SportFacillityProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SportFacillityProperties.FormattingEnabled = true;
            this.SportFacillityProperties.ItemHeight = 16;
            this.SportFacillityProperties.Location = new System.Drawing.Point(409, 69);
            this.SportFacillityProperties.Name = "SportFacillityProperties";
            this.SportFacillityProperties.Size = new System.Drawing.Size(441, 308);
            this.SportFacillityProperties.TabIndex = 21;
            this.SportFacillityProperties.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.SportFacillityProperties.MeasureItem += lst_MeasureItem;
            this.SportFacillityProperties.DrawItem += lst_DrawItem;
            // 
            // SportFacilityInfo
            // 
            this.SportFacilityInfo.AutoSize = true;
            this.SportFacilityInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.SportFacilityInfo.Location = new System.Drawing.Point(406, 45);
            this.SportFacilityInfo.Name = "SportFacilityInfo";
            this.SportFacilityInfo.Size = new System.Drawing.Size(100, 18);
            this.SportFacilityInfo.TabIndex = 20;
            this.SportFacilityInfo.Text = "Информация";
            // 
            // SportFacilityChoose
            // 
            this.SportFacilityChoose.AutoSize = true;
            this.SportFacilityChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SportFacilityChoose.Location = new System.Drawing.Point(16, 47);
            this.SportFacilityChoose.Name = "SportFacilityChoose";
            this.SportFacilityChoose.Size = new System.Drawing.Size(170, 16);
            this.SportFacilityChoose.TabIndex = 19;
            this.SportFacilityChoose.Text = "Спортивные сооружения";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(666, 119);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(8, 4);
            this.checkedListBox1.TabIndex = 17;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.спортивныеСооруженияToolStripMenuItem,
            this.спортсменыToolStripMenuItem,
            this.тренерыToolStripMenuItem,
            this.соревнованияToolStripMenuItem,
            this.огранизаторыToolStripMenuItem,
            this.организаторыToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(900, 28);
            this.menuStrip2.TabIndex = 15;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // спортивныеСооруженияToolStripMenuItem
            // 
            this.спортивныеСооруженияToolStripMenuItem.Name = "спортивныеСооруженияToolStripMenuItem";
            this.спортивныеСооруженияToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.спортивныеСооруженияToolStripMenuItem.Text = "Спортивные сооружения";
            // 
            // спортсменыToolStripMenuItem
            // 
            this.спортсменыToolStripMenuItem.Name = "спортсменыToolStripMenuItem";
            this.спортсменыToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.спортсменыToolStripMenuItem.Text = "Спортсмены";
            this.спортсменыToolStripMenuItem.Click += new System.EventHandler(this.спортсменыToolStripMenuItem_Click);
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
            // огранизаторыToolStripMenuItem
            // 
            this.огранизаторыToolStripMenuItem.Name = "огранизаторыToolStripMenuItem";
            this.огранизаторыToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.огранизаторыToolStripMenuItem.Text = "Клубы";
            this.огранизаторыToolStripMenuItem.Click += new System.EventHandler(this.клубыToolStripMenuItem_Click);
            // 
            // организаторыToolStripMenuItem
            // 
            this.организаторыToolStripMenuItem.Name = "организаторыToolStripMenuItem";
            this.организаторыToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.организаторыToolStripMenuItem.Text = "Организаторы";
            this.организаторыToolStripMenuItem.Click += new System.EventHandler(this.организаторыToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(112, 24);
            this.toolStripMenuItem1.Text = "Виды спорта";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(14, 24);
            // 
            // SportFacillityChoice
            // 
            this.SportFacillityChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SportFacillityChoice.FormattingEnabled = true;
            this.SportFacillityChoice.ItemHeight = 18;
            this.SportFacillityChoice.Location = new System.Drawing.Point(19, 68);
            this.SportFacillityChoice.Name = "SportFacillityChoice";
            this.SportFacillityChoice.Size = new System.Drawing.Size(339, 310);
            this.SportFacillityChoice.TabIndex = 26;
            this.SportFacillityChoice.SelectedIndexChanged += new System.EventHandler(this.SportFacillityChoice_SelectedIndexChanged);
            // 
            // comboBoxProperties
            // 
            this.comboBoxProperties.FormattingEnabled = true;
            this.comboBoxProperties.Location = new System.Drawing.Point(666, 42);
            this.comboBoxProperties.Name = "comboBoxProperties";
            this.comboBoxProperties.Size = new System.Drawing.Size(184, 24);
            this.comboBoxProperties.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(724, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 39);
            this.button1.TabIndex = 29;
            this.button1.Text = "Вывести";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button2.Location = new System.Drawing.Point(12, 398);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 40);
            this.button2.TabIndex = 30;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(129, 398);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 40);
            this.button3.TabIndex = 31;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button4.Location = new System.Drawing.Point(255, 399);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 39);
            this.button4.TabIndex = 32;
            this.button4.Text = "Удалить";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Facilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxProperties);
            this.Controls.Add(this.SportFacillityChoice);
            this.Controls.Add(this.comboBoxSportFacilities);
            this.Controls.Add(this.SportFacillityProperties);
            this.Controls.Add(this.SportFacilityInfo);
            this.Controls.Add(this.SportFacilityChoose);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Facilities";
            this.Text = "Form1";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxSportFacilities;
        private System.Windows.Forms.ListBox SportFacillityProperties;

        private System.Windows.Forms.Label SportFacilityInfo;
        private System.Windows.Forms.Label SportFacilityChoose;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem спортивныеСооруженияToolStripMenuItem;
        private System.Windows.Forms.ListBox SportFacillityChoice;
        private System.Windows.Forms.ComboBox comboBoxProperties;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem спортсменыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тренерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem соревнованияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem огранизаторыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem организаторыToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }

}