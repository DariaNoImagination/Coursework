namespace Coursework
{
    partial class Delete
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
            this.checkedListBoxToDelete = new System.Windows.Forms.CheckedListBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelChooseWhatToDelete = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListBoxToDelete
            // 
            this.checkedListBoxToDelete.CheckOnClick = true;
            this.checkedListBoxToDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBoxToDelete.FormattingEnabled = true;
            this.checkedListBoxToDelete.Location = new System.Drawing.Point(12, 68);
            this.checkedListBoxToDelete.Name = "checkedListBoxToDelete";
            this.checkedListBoxToDelete.Size = new System.Drawing.Size(460, 308);
            this.checkedListBoxToDelete.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.Location = new System.Drawing.Point(172, 384);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(140, 54);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelChooseWhatToDelete
            // 
            this.labelChooseWhatToDelete.AutoSize = true;
            this.labelChooseWhatToDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChooseWhatToDelete.Location = new System.Drawing.Point(103, 29);
            this.labelChooseWhatToDelete.Name = "labelChooseWhatToDelete";
            this.labelChooseWhatToDelete.Size = new System.Drawing.Size(277, 22);
            this.labelChooseWhatToDelete.TabIndex = 2;
            this.labelChooseWhatToDelete.Text = "Выберите объект для удаления";
            // 
            // Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(484, 450);
            this.Controls.Add(this.labelChooseWhatToDelete);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.checkedListBoxToDelete);
            this.Name = "Delete";
            this.Text = "Form6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxToDelete;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelChooseWhatToDelete;
    }
}
    