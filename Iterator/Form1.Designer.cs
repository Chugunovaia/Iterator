﻿namespace Iterator
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
			this.button2 = new System.Windows.Forms.Button();
			this.prev = new System.Windows.Forms.Button();
			this.next = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(20, 23);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(214, 66);
			this.button1.TabIndex = 0;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(20, 137);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(214, 66);
			this.button2.TabIndex = 0;
			this.button2.Text = "button1";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// prev
			// 
			this.prev.Location = new System.Drawing.Point(20, 746);
			this.prev.Name = "prev";
			this.prev.Size = new System.Drawing.Size(108, 61);
			this.prev.TabIndex = 2;
			this.prev.Text = "<-";
			this.prev.UseVisualStyleBackColor = true;
			this.prev.Visible = false;
			this.prev.Click += new System.EventHandler(this.prev_Click);
			// 
			// next
			// 
			this.next.Location = new System.Drawing.Point(512, 746);
			this.next.Name = "next";
			this.next.Size = new System.Drawing.Size(108, 61);
			this.next.TabIndex = 2;
			this.next.Text = "->";
			this.next.UseVisualStyleBackColor = true;
			this.next.Visible = false;
			this.next.Click += new System.EventHandler(this.next_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(20, 20);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(600, 700);
			this.richTextBox1.TabIndex = 3;
			this.richTextBox1.Text = "";
			this.richTextBox1.Visible = false;
			this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(649, 819);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.next);
			this.Controls.Add(this.prev);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button prev;
		private System.Windows.Forms.Button next;
		private System.Windows.Forms.RichTextBox richTextBox1;
	}
}

