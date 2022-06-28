﻿namespace ElectricityConsumerView
{
    partial class FormMain
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
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.потребителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыСчётчиковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.электросчётчикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.снятьПоказанияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.адресаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.снятьПоказанияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.потребителиToolStripMenuItem,
            this.адресаToolStripMenuItem,
            this.типыСчётчиковToolStripMenuItem,
            this.электросчётчикиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // потребителиToolStripMenuItem
            // 
            this.потребителиToolStripMenuItem.Name = "потребителиToolStripMenuItem";
            this.потребителиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.потребителиToolStripMenuItem.Text = "Потребители";
            this.потребителиToolStripMenuItem.Click += new System.EventHandler(this.потребителиToolStripMenuItem_Click);
            // 
            // типыСчётчиковToolStripMenuItem
            // 
            this.типыСчётчиковToolStripMenuItem.Name = "типыСчётчиковToolStripMenuItem";
            this.типыСчётчиковToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.типыСчётчиковToolStripMenuItem.Text = "Типы счётчиков";
            this.типыСчётчиковToolStripMenuItem.Click += new System.EventHandler(this.типыСчётчиковToolStripMenuItem_Click);
            // 
            // электросчётчикиToolStripMenuItem
            // 
            this.электросчётчикиToolStripMenuItem.Name = "электросчётчикиToolStripMenuItem";
            this.электросчётчикиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.электросчётчикиToolStripMenuItem.Text = "Электросчётчики";
            this.электросчётчикиToolStripMenuItem.Click += new System.EventHandler(this.электросчётчикиToolStripMenuItem_Click);
            // 
            // снятьПоказанияToolStripMenuItem
            // 
            this.снятьПоказанияToolStripMenuItem.Name = "снятьПоказанияToolStripMenuItem";
            this.снятьПоказанияToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.снятьПоказанияToolStripMenuItem.Text = "Снять показания";
            // 
            // адресаToolStripMenuItem
            // 
            this.адресаToolStripMenuItem.Name = "адресаToolStripMenuItem";
            this.адресаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.адресаToolStripMenuItem.Text = "Адреса";
            this.адресаToolStripMenuItem.Click += new System.EventHandler(this.адресаToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Потребитель электроэнергии";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem потребителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыСчётчиковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem электросчётчикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem снятьПоказанияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem адресаToolStripMenuItem;
    }
}