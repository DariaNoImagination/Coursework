namespace Coursework
{
    partial class ClubsForm
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
            this.спортсменыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тренерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.соревнованияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клубыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.организаторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видыСпортаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxClubs = new System.Windows.Forms.ListBox();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.labelClubs = new System.Windows.Forms.Label();
            this.labelInformation = new System.Windows.Forms.Label();
            this.comboBoxSortMembers = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.спортивныеСооруженияToolStripMenuItem,
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
            // спортивныеСооруженияToolStripMenuItem
            // 
            this.спортивныеСооруженияToolStripMenuItem.Name = "спортивныеСооруженияToolStripMenuItem";
            this.спортивныеСооруженияToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.спортивныеСооруженияToolStripMenuItem.Text = "Спортивные сооружения ";
            this.спортивныеСооруженияToolStripMenuItem.Click += new System.EventHandler(this.спортивныеСооруженияToolStripMenuItem_Click);
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
            // клубыToolStripMenuItem
            // 
            this.клубыToolStripMenuItem.Name = "клубыToolStripMenuItem";
            this.клубыToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.клубыToolStripMenuItem.Text = "Клубы";
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
            // listBoxClubs
            // 
            this.listBoxClubs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxClubs.FormattingEnabled = true;
            this.listBoxClubs.ItemHeight = 18;
            this.listBoxClubs.Location = new System.Drawing.Point(23, 66);
            this.listBoxClubs.Name = "listBoxClubs";
            this.listBoxClubs.Size = new System.Drawing.Size(339, 310);
            this.listBoxClubs.TabIndex = 1;
            this.listBoxClubs.SelectedIndexChanged += new System.EventHandler(this.listBoxClubs_SelectedIndexChanged);
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.ItemHeight = 18;
            this.listBoxInfo.Location = new System.Drawing.Point(395, 66);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(447, 310);
            this.listBoxInfo.TabIndex = 2;
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPrint.Location = new System.Drawing.Point(721, 386);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(118, 39);
            this.buttonPrint.TabIndex = 3;
            this.buttonPrint.Text = "Вывести";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(23, 386);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(106, 39);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.Location = new System.Drawing.Point(256, 386);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(113, 39);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChange.Location = new System.Drawing.Point(135, 386);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(115, 39);
            this.buttonChange.TabIndex = 8;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // labelClubs
            // 
            this.labelClubs.AutoSize = true;
            this.labelClubs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClubs.Location = new System.Drawing.Point(20, 35);
            this.labelClubs.Name = "labelClubs";
            this.labelClubs.Size = new System.Drawing.Size(54, 18);
            this.labelClubs.TabIndex = 11;
            this.labelClubs.Text = "Клубы";
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInformation.Location = new System.Drawing.Point(392, 35);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(100, 18);
            this.labelInformation.TabIndex = 12;
            this.labelInformation.Text = "Информация";
            // 
            // comboBoxSortMembers
            // 
            this.comboBoxSortMembers.FormattingEnabled = true;
            this.comboBoxSortMembers.Location = new System.Drawing.Point(515, 35);
            this.comboBoxSortMembers.Name = "comboBoxSortMembers";
            this.comboBoxSortMembers.Size = new System.Drawing.Size(327, 24);
            this.comboBoxSortMembers.TabIndex = 14;
            // 
            // ClubsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.comboBoxSortMembers);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.labelClubs);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.listBoxClubs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClubsForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem спортивныеСооруженияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спортсменыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тренерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem соревнованияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клубыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem организаторыToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxClubs;
        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label labelClubs;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.ComboBox comboBoxSortMembers;
        private System.Windows.Forms.ToolStripMenuItem видыСпортаToolStripMenuItem;
    }
}