namespace ElectricityConsumerView
{
    partial class FormElectricMeter
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
            this.labelType = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.comboBoxAddress = new System.Windows.Forms.ComboBox();
            this.labelConsumer = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.labelDateOfCheck = new System.Windows.Forms.Label();
            this.labelInspectionPeriod = new System.Windows.Forms.Label();
            this.labelFinalInspection = new System.Windows.Forms.Label();
            this.dateTimePickerDateOfCheck = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFinalInspection = new System.Windows.Forms.DateTimePicker();
            this.textBoxInspectionPeriod = new System.Windows.Forms.TextBox();
            this.textBoxConsumer = new System.Windows.Forms.TextBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelType.Location = new System.Drawing.Point(12, 9);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(32, 17);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Тип:";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAddress.Location = new System.Drawing.Point(12, 38);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(47, 17);
            this.labelAddress.TabIndex = 1;
            this.labelAddress.Text = "Адрес:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(101, 8);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(315, 23);
            this.comboBoxType.TabIndex = 2;
            // 
            // comboBoxAddress
            // 
            this.comboBoxAddress.FormattingEnabled = true;
            this.comboBoxAddress.Location = new System.Drawing.Point(101, 37);
            this.comboBoxAddress.Name = "comboBoxAddress";
            this.comboBoxAddress.Size = new System.Drawing.Size(315, 23);
            this.comboBoxAddress.TabIndex = 3;
            this.comboBoxAddress.SelectedIndexChanged += new System.EventHandler(this.comboBoxAddress_SelectedIndexChanged);
            // 
            // labelConsumer
            // 
            this.labelConsumer.AutoSize = true;
            this.labelConsumer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelConsumer.Location = new System.Drawing.Point(11, 96);
            this.labelConsumer.Name = "labelConsumer";
            this.labelConsumer.Size = new System.Drawing.Size(89, 17);
            this.labelConsumer.TabIndex = 4;
            this.labelConsumer.Text = "Потребитель:";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(101, 66);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(315, 23);
            this.textBoxNumber.TabIndex = 5;
            // 
            // labelDateOfCheck
            // 
            this.labelDateOfCheck.AutoSize = true;
            this.labelDateOfCheck.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDateOfCheck.Location = new System.Drawing.Point(12, 166);
            this.labelDateOfCheck.Name = "labelDateOfCheck";
            this.labelDateOfCheck.Size = new System.Drawing.Size(94, 17);
            this.labelDateOfCheck.TabIndex = 6;
            this.labelDateOfCheck.Text = "Дата приёмки:";
            // 
            // labelInspectionPeriod
            // 
            this.labelInspectionPeriod.AutoSize = true;
            this.labelInspectionPeriod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelInspectionPeriod.Location = new System.Drawing.Point(11, 192);
            this.labelInspectionPeriod.Name = "labelInspectionPeriod";
            this.labelInspectionPeriod.Size = new System.Drawing.Size(153, 17);
            this.labelInspectionPeriod.TabIndex = 7;
            this.labelInspectionPeriod.Text = "Срок госпроверки (лет):";
            // 
            // labelFinalInspection
            // 
            this.labelFinalInspection.AutoSize = true;
            this.labelFinalInspection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFinalInspection.Location = new System.Drawing.Point(11, 220);
            this.labelFinalInspection.Name = "labelFinalInspection";
            this.labelFinalInspection.Size = new System.Drawing.Size(168, 17);
            this.labelFinalInspection.TabIndex = 8;
            this.labelFinalInspection.Text = "Дата последней проверки:";
            // 
            // dateTimePickerDateOfCheck
            // 
            this.dateTimePickerDateOfCheck.Location = new System.Drawing.Point(185, 162);
            this.dateTimePickerDateOfCheck.Name = "dateTimePickerDateOfCheck";
            this.dateTimePickerDateOfCheck.Size = new System.Drawing.Size(231, 23);
            this.dateTimePickerDateOfCheck.TabIndex = 9;
            // 
            // dateTimePickerFinalInspection
            // 
            this.dateTimePickerFinalInspection.Location = new System.Drawing.Point(185, 216);
            this.dateTimePickerFinalInspection.Name = "dateTimePickerFinalInspection";
            this.dateTimePickerFinalInspection.Size = new System.Drawing.Size(231, 23);
            this.dateTimePickerFinalInspection.TabIndex = 10;
            // 
            // textBoxInspectionPeriod
            // 
            this.textBoxInspectionPeriod.Location = new System.Drawing.Point(185, 189);
            this.textBoxInspectionPeriod.Name = "textBoxInspectionPeriod";
            this.textBoxInspectionPeriod.Size = new System.Drawing.Size(231, 23);
            this.textBoxInspectionPeriod.TabIndex = 11;
            // 
            // textBoxConsumer
            // 
            this.textBoxConsumer.Location = new System.Drawing.Point(101, 95);
            this.textBoxConsumer.Name = "textBoxConsumer";
            this.textBoxConsumer.ReadOnly = true;
            this.textBoxConsumer.Size = new System.Drawing.Size(315, 23);
            this.textBoxConsumer.TabIndex = 12;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNumber.Location = new System.Drawing.Point(12, 67);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(52, 17);
            this.labelNumber.TabIndex = 13;
            this.labelNumber.Text = "Номер:";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.Location = new System.Drawing.Point(222, 245);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 32);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(322, 245);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 32);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormElectricMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 283);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.textBoxConsumer);
            this.Controls.Add(this.textBoxInspectionPeriod);
            this.Controls.Add(this.dateTimePickerFinalInspection);
            this.Controls.Add(this.dateTimePickerDateOfCheck);
            this.Controls.Add(this.labelFinalInspection);
            this.Controls.Add(this.labelInspectionPeriod);
            this.Controls.Add(this.labelDateOfCheck);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.labelConsumer);
            this.Controls.Add(this.comboBoxAddress);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelType);
            this.Name = "FormElectricMeter";
            this.Text = "Создание электросчётчика";
            this.Load += new System.EventHandler(this.FormElectricMeter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxAddress;
        private System.Windows.Forms.Label labelConsumer;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label labelDateOfCheck;
        private System.Windows.Forms.Label labelInspectionPeriod;
        private System.Windows.Forms.Label labelFinalInspection;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateOfCheck;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinalInspection;
        private System.Windows.Forms.TextBox textBoxInspectionPeriod;
        private System.Windows.Forms.TextBox textBoxConsumer;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}