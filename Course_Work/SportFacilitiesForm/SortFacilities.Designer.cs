namespace Coursework
{
    partial class SortFacilities
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
            this.labelSort = new System.Windows.Forms.Label();
            this.comboBoxChooseAction = new System.Windows.Forms.ComboBox();
            this.textBoxcharacteristicsInput = new System.Windows.Forms.TextBox();
            this.SortByProperties = new System.Windows.Forms.Button();
            this.labelSort2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCharacteristic = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelSort
            // 
            this.labelSort.AutoSize = true;
            this.labelSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSort.Location = new System.Drawing.Point(44, 30);
            this.labelSort.Name = "labelSort";
            this.labelSort.Size = new System.Drawing.Size(368, 25);
            this.labelSort.TabIndex = 0;
            this.labelSort.Text = "Введите дополнительные параметры";
            this.labelSort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxChooseAction
            // 
            this.comboBoxChooseAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxChooseAction.FormattingEnabled = true;
            this.comboBoxChooseAction.Location = new System.Drawing.Point(37, 116);
            this.comboBoxChooseAction.Name = "comboBoxChooseAction";
            this.comboBoxChooseAction.Size = new System.Drawing.Size(375, 37);
            this.comboBoxChooseAction.TabIndex = 1;
            this.comboBoxChooseAction.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseAction_SelectedIndexChanged);
            // 
            // textBoxcharacteristicsInput
            // 
            this.textBoxcharacteristicsInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxcharacteristicsInput.Location = new System.Drawing.Point(37, 170);
            this.textBoxcharacteristicsInput.Name = "textBoxcharacteristicsInput";
            this.textBoxcharacteristicsInput.Size = new System.Drawing.Size(375, 34);
            this.textBoxcharacteristicsInput.TabIndex = 2;
            // 
            // SortByProperties
            // 
            this.SortByProperties.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SortByProperties.Location = new System.Drawing.Point(137, 224);
            this.SortByProperties.Name = "SortByProperties";
            this.SortByProperties.Size = new System.Drawing.Size(179, 52);
            this.SortByProperties.TabIndex = 19;
            this.SortByProperties.Text = "Отсортировать";
            this.SortByProperties.UseVisualStyleBackColor = false;
            this.SortByProperties.Click += new System.EventHandler(this.SortByProperties_Click);
            // 
            // labelSort2
            // 
            this.labelSort2.AutoSize = true;
            this.labelSort2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSort2.Location = new System.Drawing.Point(162, 55);
            this.labelSort2.Name = "labelSort2";
            this.labelSort2.Size = new System.Drawing.Size(120, 25);
            this.labelSort2.TabIndex = 20;
            this.labelSort2.Text = "сортировки";
            this.labelSort2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(39, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(39, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "label2";
            // 
            // comboBoxCharacteristic
            // 
            this.comboBoxCharacteristic.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCharacteristic.FormattingEnabled = true;
            this.comboBoxCharacteristic.Location = new System.Drawing.Point(37, 143);
            this.comboBoxCharacteristic.Name = "comboBoxCharacteristic";
            this.comboBoxCharacteristic.Size = new System.Drawing.Size(375, 37);
            this.comboBoxCharacteristic.TabIndex = 24;
            // 
            // SortFacilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(458, 288);
            this.Controls.Add(this.comboBoxCharacteristic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelSort2);
            this.Controls.Add(this.SortByProperties);
            this.Controls.Add(this.textBoxcharacteristicsInput);
            this.Controls.Add(this.comboBoxChooseAction);
            this.Controls.Add(this.labelSort);
            this.Name = "SortFacilities";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSort;
        private System.Windows.Forms.ComboBox comboBoxChooseAction;
        private System.Windows.Forms.TextBox textBoxcharacteristicsInput;
        private System.Windows.Forms.Button SortByProperties;
        private System.Windows.Forms.Label labelSort2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCharacteristic;
    }
}