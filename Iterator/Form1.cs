using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Iterator
{
	public partial class Form1 : Form
	{
		//Example read = new Example();
		dynamic current;
		Iterator i;
		public Form1()
		{
			InitializeComponent();
			
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			button1.Visible = false;
			button2.Visible = false;
			richTextBox1.Visible = true;
			prev.Visible = true;
			next.Visible = true;
			Aggregate book=new Book();
			current=book.Example();
			i=book.CreateIterator();
			FileInfo fileInfo = new FileInfo(current.path);

			richTextBox1.Text = File.ReadAllText(current.path);

		}



		private void button2_Click(object sender, EventArgs e)
		{
			button1.Visible = false;
			button2.Visible = false;
			richTextBox1.Visible = true;
			prev.Visible = true;
			next.Visible = true;
			Aggregate novel = new WebNovel();
			current = novel.Example();
			i = novel.CreateIterator();
			FileInfo fileInfo = new FileInfo(current.path);

			richTextBox1.Text = File.ReadAllText(current.path);
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void prev_Click(object sender, EventArgs e)
		{
			current = i.Prev();
			FileInfo fileInfo = new FileInfo(current.path);

			richTextBox1.Text = File.ReadAllText(current.path);
			//richTextBox1.Text = current.path;
		}

		private void next_Click(object sender, EventArgs e)
		{
			current =i.Next();
			FileInfo fileInfo = new FileInfo(current.path);

			richTextBox1.Text = File.ReadAllText(current.path);
		}
	}
}
