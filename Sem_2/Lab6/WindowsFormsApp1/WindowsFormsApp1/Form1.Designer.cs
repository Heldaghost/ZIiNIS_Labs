namespace WindowsFormsApp1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.SequenceBox = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RC4Box = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Сгенерировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GenerateClick);
            // 
            // SequenceBox
            // 
            this.SequenceBox.BackColor = System.Drawing.SystemColors.Menu;
            this.SequenceBox.Location = new System.Drawing.Point(60, 37);
            this.SequenceBox.Name = "SequenceBox";
            this.SequenceBox.Size = new System.Drawing.Size(472, 30);
            this.SequenceBox.TabIndex = 1;
            this.SequenceBox.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(347, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "Сбросить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ResetClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Последовательность";
            // 
            // RC4Box
            // 
            this.RC4Box.BackColor = System.Drawing.SystemColors.Menu;
            this.RC4Box.Location = new System.Drawing.Point(60, 153);
            this.RC4Box.Name = "RC4Box";
            this.RC4Box.Size = new System.Drawing.Size(472, 96);
            this.RC4Box.TabIndex = 4;
            this.RC4Box.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(60, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 43);
            this.button3.TabIndex = 5;
            this.button3.Text = "Зашифровать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.EncryptClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(347, 265);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 43);
            this.button4.TabIndex = 8;
            this.button4.Text = "Расшифровать";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.DecryptClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(625, 364);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.RC4Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SequenceBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Lab6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox SequenceBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RC4Box;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

