namespace Coursework
{
    partial class OrganizersForm
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
            this.соревнованияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тренерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.соревнованияToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.клубыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.организаторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видыСпортаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxOrganizers = new System.Windows.Forms.ListBox();
            this.listBoxInformation = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labelClubs = new System.Windows.Forms.Label();
            this.labelInformation = new System.Windows.Forms.Label();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.спортивныеСооруженияToolStripMenuItem,
            this.соревнованияToolStripMenuItem,
            this.тренерыToolStripMenuItem,
            this.соревнованияToolStripMenuItem1,
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
            this.спортивныеСооруженияToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.спортивныеСооруженияToolStripMenuItem.Text = "Спортивные сооружения ";
            this.спортивныеСооруженияToolStripMenuItem.Click += new System.EventHandler(this.спортивныеСооруженияToolStripMenuItem_Click);
            // 
            // соревнованияToolStripMenuItem
            // 
            this.соревнованияToolStripMenuItem.Name = "соревнованияToolStripMenuItem";
            this.соревнованияToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.соревнованияToolStripMenuItem.Text = "Спортсмены";
            this.соревнованияToolStripMenuItem.Click += new System.EventHandler(this.соревнованияToolStripMenuItem_Click);
            // 
            // тренерыToolStripMenuItem
            // 
            this.тренерыToolStripMenuItem.Name = "тренерыToolStripMenuItem";
            this.тренерыToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.тренерыToolStripMenuItem.Text = "Тренеры";
            this.тренерыToolStripMenuItem.Click += new System.EventHandler(this.тренерыToolStripMenuItem_Click);
            // 
            // соревнованияToolStripMenuItem1
            // 
            this.соревнованияToolStripMenuItem1.Name = "соревнованияToolStripMenuItem1";
            this.соревнованияToolStripMenuItem1.Size = new System.Drawing.Size(126, 24);
            this.соревнованияToolStripMenuItem1.Text = "Соревнования";
            this.соревнованияToolStripMenuItem1.Click += new System.EventHandler(this.соревнованияToolStripMenuItem1_Click);
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
            // 
            // видыСпортаToolStripMenuItem
            // 
            this.видыСпортаToolStripMenuItem.Name = "видыСпортаToolStripMenuItem";
            this.видыСпортаToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.видыСпортаToolStripMenuItem.Text = "Виды спорта";
            this.видыСпортаToolStripMenuItem.Click += new System.EventHandler(this.видыСпортаToolStripMenuItem_Click);
            // 
            // listBoxOrganizers
            // 
            this.listBoxOrganizers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxOrganizers.FormattingEnabled = true;
            this.listBoxOrganizers.ItemHeight = 18;
            this.listBoxOrganizers.Location = new System.Drawing.Point(23, 66);
            this.listBoxOrganizers.Name = "listBoxOrganizers";
            this.listBoxOrganizers.Size = new System.Drawing.Size(339, 310);
            this.listBoxOrganizers.TabIndex = 1;
            this.listBoxOrganizers.SelectedIndexChanged += new System.EventHandler(this.listBoxOrganizers_SelectedIndexChanged);
            // 
            // listBoxInformation
            // 
            this.listBoxInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxInformation.FormattingEnabled = true;
            this.listBoxInformation.ItemHeight = 18;
            this.listBoxInformation.Location = new System.Drawing.Point(395, 66);
            this.listBoxInformation.Name = "listBoxInformation";
            this.listBoxInformation.Size = new System.Drawing.Size(434, 310);
            this.listBoxInformation.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(716, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вывести";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(23, 384);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 41);
            this.button4.TabIndex = 6;
            this.button4.Text = "Добавить";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(256, 385);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 40);
            this.button2.TabIndex = 7;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(135, 386);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 39);
            this.button3.TabIndex = 8;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelClubs
            // 
            this.labelClubs.AutoSize = true;
            this.labelClubs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClubs.Location = new System.Drawing.Point(20, 36);
            this.labelClubs.Name = "labelClubs";
            this.labelClubs.Size = new System.Drawing.Size(109, 18);
            this.labelClubs.TabIndex = 11;
            this.labelClubs.Text = "Организаторы";
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInformation.Location = new System.Drawing.Point(392, 36);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(100, 18);
            this.labelInformation.TabIndex = 12;
            this.labelInformation.Text = "Информация";
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Location = new System.Drawing.Point(568, 36);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(261, 24);
            this.comboBoxSort.TabIndex = 14;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // Organizers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.labelClubs);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxInformation);
            this.Controls.Add(this.listBoxOrganizers);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Organizers";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem спортивныеСооруженияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem соревнованияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тренерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem соревнованияToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem клубыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem организаторыToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxOrganizers;
        private System.Windows.Forms.ListBox listBoxInformation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelClubs;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.ToolStripMenuItem видыСпортаToolStripMenuItem;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion
    }

    
}