namespace Coursework
{
    partial class SportsmenForm
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
            this.спорToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спортсменыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тренерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.соревнованияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клубыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.организаторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видыСпортаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SportsmenChoice = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBoxSportsmen = new System.Windows.Forms.ComboBox();
            this.comboBoxProperties = new System.Windows.Forms.ComboBox();
            this.SportInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SportsmenProperties = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.спорToolStripMenuItem,
            this.спортсменыToolStripMenuItem,
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
            // спорToolStripMenuItem
            // 
            this.спорToolStripMenuItem.Name = "спорToolStripMenuItem";
            this.спорToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.спорToolStripMenuItem.Text = "Спортивные сооружения";
            this.спорToolStripMenuItem.Click += new System.EventHandler(this.спорToolStripMenuItem_Click);
            // 
            // спортсменыToolStripMenuItem
            // 
            this.спортсменыToolStripMenuItem.Name = "спортсменыToolStripMenuItem";
            this.спортсменыToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.спортсменыToolStripMenuItem.Text = "Спортсмены";
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
            this.видыСпортаToolStripMenuItem.Click += new System.EventHandler(this.видыСпортаToolStripMenuItem_Click);
            // 
            // SportsmenChoice
            // 
            this.SportsmenChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.SportsmenChoice.FormattingEnabled = true;
            this.SportsmenChoice.ItemHeight = 18;
            this.SportsmenChoice.Location = new System.Drawing.Point(21, 76);
            this.SportsmenChoice.Name = "SportsmenChoice";
            this.SportsmenChoice.Size = new System.Drawing.Size(339, 292);
            this.SportsmenChoice.TabIndex = 27;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button2.Location = new System.Drawing.Point(12, 390);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 38);
            this.button2.TabIndex = 31;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button1.Location = new System.Drawing.Point(252, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 38);
            this.button1.TabIndex = 32;
            this.button1.Text = "Удалить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button3.Location = new System.Drawing.Point(132, 390);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 38);
            this.button3.TabIndex = 33;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button4.Location = new System.Drawing.Point(761, 390);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 38);
            this.button4.TabIndex = 34;
            this.button4.Text = "Вывести";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBoxSportsmen
            // 
            this.comboBoxSportsmen.FormattingEnabled = true;
            this.comboBoxSportsmen.Location = new System.Drawing.Point(125, 46);
            this.comboBoxSportsmen.Name = "comboBoxSportsmen";
            this.comboBoxSportsmen.Size = new System.Drawing.Size(235, 24);
            this.comboBoxSportsmen.TabIndex = 35;
            this.comboBoxSportsmen.SelectedIndexChanged += new System.EventHandler(this.comboBoxSportsmen_SelectedIndexChanged);
            // 
            // comboBoxProperties
            // 
            this.comboBoxProperties.FormattingEnabled = true;
            this.comboBoxProperties.Location = new System.Drawing.Point(590, 45);
            this.comboBoxProperties.Name = "comboBoxProperties";
            this.comboBoxProperties.Size = new System.Drawing.Size(285, 24);
            this.comboBoxProperties.TabIndex = 36;
            // 
            // SportInfo
            // 
            this.SportInfo.AutoSize = true;
            this.SportInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SportInfo.Location = new System.Drawing.Point(377, 51);
            this.SportInfo.Name = "SportInfo";
            this.SportInfo.Size = new System.Drawing.Size(100, 18);
            this.SportInfo.TabIndex = 37;
            this.SportInfo.Text = "Информация";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Спортсмены";
            // 
            // SportsmenProperties
            // 
            this.SportsmenProperties.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.SportsmenProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.SportsmenProperties.FormattingEnabled = true;
            this.SportsmenProperties.ItemHeight = 16;
            this.SportsmenProperties.Location = new System.Drawing.Point(380, 76);
            this.SportsmenProperties.Name = "SportsmenProperties";
            this.SportsmenProperties.Size = new System.Drawing.Size(495, 292);
            this.SportsmenProperties.TabIndex = 21;
            this.SportsmenProperties.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.SportsmenProperties.MeasureItem += lst_MeasureItem;
            this.SportsmenProperties.DrawItem += lst_DrawItem;
            // 
            // Sportsmen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.SportsmenProperties);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SportInfo);
            this.Controls.Add(this.comboBoxProperties);
            this.Controls.Add(this.comboBoxSportsmen);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SportsmenChoice);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Sportsmen";
            this.Text = "Form4";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem спорToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спортсменыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тренерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem соревнованияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клубыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem организаторыToolStripMenuItem;
        private System.Windows.Forms.ListBox SportsmenChoice;
        private System.Windows.Forms.ToolStripMenuItem видыСпортаToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBoxSportsmen;
        private System.Windows.Forms.ComboBox comboBoxProperties;
        private System.Windows.Forms.Label SportInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox SportsmenProperties;
    }

}