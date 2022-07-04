namespace ElectricityConsumerView
{
    partial class FormReadMeter
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
            this.comboBoxNumber = new System.Windows.Forms.ComboBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxEnd = new System.Windows.Forms.TextBox();
            this.textBoxBegin = new System.Windows.Forms.TextBox();
            this.textBoxConsumer = new System.Windows.Forms.TextBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelConsumer = new System.Windows.Forms.Label();
            this.labelBegin = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxNumber
            // 
            this.comboBoxNumber.FormattingEnabled = true;
            this.comboBoxNumber.Location = new System.Drawing.Point(87, 12);
            this.comboBoxNumber.Name = "comboBoxNumber";
            this.comboBoxNumber.Size = new System.Drawing.Size(459, 23);
            this.comboBoxNumber.TabIndex = 0;
            this.comboBoxNumber.SelectedIndexChanged += new System.EventHandler(this.comboBoxNumber_SelectedIndexChanged);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(87, 41);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.ReadOnly = true;
            this.textBoxAddress.Size = new System.Drawing.Size(459, 23);
            this.textBoxAddress.TabIndex = 1;
            // 
            // textBoxEnd
            // 
            this.textBoxEnd.Location = new System.Drawing.Point(121, 126);
            this.textBoxEnd.Name = "textBoxEnd";
            this.textBoxEnd.Size = new System.Drawing.Size(172, 23);
            this.textBoxEnd.TabIndex = 2;
            // 
            // textBoxBegin
            // 
            this.textBoxBegin.Location = new System.Drawing.Point(121, 99);
            this.textBoxBegin.Name = "textBoxBegin";
            this.textBoxBegin.Size = new System.Drawing.Size(172, 23);
            this.textBoxBegin.TabIndex = 3;
            // 
            // textBoxConsumer
            // 
            this.textBoxConsumer.Location = new System.Drawing.Point(87, 70);
            this.textBoxConsumer.Name = "textBoxConsumer";
            this.textBoxConsumer.ReadOnly = true;
            this.textBoxConsumer.Size = new System.Drawing.Size(459, 23);
            this.textBoxConsumer.TabIndex = 4;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNumber.Location = new System.Drawing.Point(12, 13);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(52, 17);
            this.labelNumber.TabIndex = 5;
            this.labelNumber.Text = "Номер:";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAddress.Location = new System.Drawing.Point(12, 42);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(47, 17);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.Text = "Адрес:";
            // 
            // labelConsumer
            // 
            this.labelConsumer.AutoSize = true;
            this.labelConsumer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelConsumer.Location = new System.Drawing.Point(12, 71);
            this.labelConsumer.Name = "labelConsumer";
            this.labelConsumer.Size = new System.Drawing.Size(67, 17);
            this.labelConsumer.TabIndex = 7;
            this.labelConsumer.Text = "Владелец:";
            // 
            // labelBegin
            // 
            this.labelBegin.AutoSize = true;
            this.labelBegin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBegin.Location = new System.Drawing.Point(12, 100);
            this.labelBegin.Name = "labelBegin";
            this.labelBegin.Size = new System.Drawing.Size(103, 17);
            this.labelBegin.TabIndex = 8;
            this.labelBegin.Text = "Начало месяца:";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEnd.Location = new System.Drawing.Point(12, 127);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(95, 17);
            this.labelEnd.TabIndex = 9;
            this.labelEnd.Text = "Конец месяца:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(431, 100);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(115, 49);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.Location = new System.Drawing.Point(310, 100);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(115, 49);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormReadMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 159);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.labelBegin);
            this.Controls.Add(this.labelConsumer);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.textBoxConsumer);
            this.Controls.Add(this.textBoxBegin);
            this.Controls.Add(this.textBoxEnd);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.comboBoxNumber);
            this.Name = "FormReadMeter";
            this.Text = "Снятие показаний";
            this.Load += new System.EventHandler(this.FormReadMeter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxNumber;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxEnd;
        private System.Windows.Forms.TextBox textBoxBegin;
        private System.Windows.Forms.TextBox textBoxConsumer;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelConsumer;
        private System.Windows.Forms.Label labelBegin;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}