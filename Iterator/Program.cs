using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iterator
{
	internal static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]


		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}

	abstract class Iterator
	{
		public abstract object First();
		public abstract object Prev();
		public abstract object Next();
		public abstract bool IsDone();
		public abstract object CurrentItem();
	}

	abstract class Chapter
	{
		public string name;
		public string type;
		public int number;
		public string path;
		public abstract Iterator CreateIterator();
	}
	class BookIterator:Iterator
	{

	}
	class BookChapter: Chapter
	{
		public BookChapter()
		{
			parent = null;
		}
		public BookChapter parent;
		public List<BookChapter> child;

	}


}
