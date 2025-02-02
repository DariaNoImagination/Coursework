namespace Coursework
{
    partial class SortCompetitions
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSortCompetitions = new System.Windows.Forms.ComboBox();
            this.textBoxBegin = new System.Windows.Forms.TextBox();
            this.textBoxEnd = new System.Windows.Forms.TextBox();
            this.textBoxSport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Отсортировать = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите параметры сортировки";
            // 
            // comboBoxSortCompetitions
            // 
            this.comboBoxSortCompetitions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSortCompetitions.FormattingEnabled = true;
            this.comboBoxSortCompetitions.Location = new System.Drawing.Point(43, 82);
            this.comboBoxSortCompetitions.Name = "comboBoxSortCompetitions";
            this.comboBoxSortCompetitions.Size = new System.Drawing.Size(325, 33);
            this.comboBoxSortCompetitions.TabIndex = 1;
            this.comboBoxSortCompetitions.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortCompetitions_SelectedIndexChanged);
            // 
            // textBoxBegin
            // 
            this.textBoxBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxBegin.Location = new System.Drawing.Point(43, 139);
            this.textBoxBegin.Name = "textBoxBegin";
            this.textBoxBegin.Size = new System.Drawing.Size(325, 30);
            this.textBoxBegin.TabIndex = 2;
            // 
            // textBoxEnd
            // 
            this.textBoxEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEnd.Location = new System.Drawing.Point(43, 191);
            this.textBoxEnd.Name = "textBoxEnd";
            this.textBoxEnd.Size = new System.Drawing.Size(325, 30);
            this.textBoxEnd.TabIndex = 3;
            // 
            // textBoxSport
            // 
            this.textBoxSport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSport.Location = new System.Drawing.Point(43, 162);
            this.textBoxSport.Name = "textBoxSport";
            this.textBoxSport.Size = new System.Drawing.Size(325, 30);
            this.textBoxSport.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // Отсортировать
            // 
            this.Отсортировать.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Отсортировать.Location = new System.Drawing.Point(131, 227);
            this.Отсортировать.Name = "Отсортировать";
            this.Отсортировать.Size = new System.Drawing.Size(149, 36);
            this.Отсортировать.TabIndex = 8;
            this.Отсортировать.Text = "Отсортировать";
            this.Отсортировать.UseVisualStyleBackColor = false;
            this.Отсортировать.Click += new System.EventHandler(this.Отсортировать_Click);
            // 
            // SortCompetitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(422, 267);
            this.Controls.Add(this.Отсортировать);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSport);
            this.Controls.Add(this.textBoxEnd);
            this.Controls.Add(this.textBoxBegin);
            this.Controls.Add(this.comboBoxSortCompetitions);
            this.Controls.Add(this.label1);
            this.Name = "SortCompetitions";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSortCompetitions;
        private System.Windows.Forms.TextBox textBoxBegin;
        private System.Windows.Forms.TextBox textBoxEnd;
        private System.Windows.Forms.TextBox textBoxSport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Отсортировать;
    }

}