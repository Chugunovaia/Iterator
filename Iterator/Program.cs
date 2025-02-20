using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
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
	//class Example
	//{
	//	public BookChapter CreateTree()
	//	{
	//		BookChapter first = new BookChapter(0, "cover");
	//		BookChapter cur, cur1;
	//		first.set_par(null, first);
	//		first.new_child(new BookChapter(0,"preface"));
	//		cur = first.child.First();
	//		cur.set_par(first, first);
	//		cur = new BookChapter (1, "part");
	//		cur.set_par(first, first);
	//		first.new_child(cur);
	//		cur1 = new BookChapter(2, "epilogue");
	//		cur1.set_par(first, first);
	//		first.new_child(cur1);

	//		cur1 = new BookChapter(0, "chapter");
	//		cur1.set_par(cur, first);
	//		cur.new_child(cur1);
	//		cur1 = new BookChapter(1, "chapter");
	//		cur1.set_par(cur, first);
	//		cur.new_child(cur1);
	//		cur1 = new BookChapter(2, "chapter");
	//		cur1.set_par(cur, first);
	//		cur.new_child(cur1);


	//		return first;
	//	}
	//}
	abstract class Iterator
	{
		//public abstract object First();
		public abstract object Prev();
		public abstract object Next();
		//public abstract bool IsDone();
		//public abstract object CurrentItem();
	}

	abstract class Aggregate
	{

		public abstract Iterator CreateIterator();
		public abstract object Example();
	}
	class BookIterator:Iterator
	{
		private  BookChapter _aggregate;
		private int _current;
		private BookChapter dop;
		
		public BookIterator(BookChapter aggregate)
		{
			this._aggregate = aggregate;
			_current = aggregate.num;
		}
		//public override object CurrentItem()
		//{

		//	return _aggregate;
		//}
		//public override object First()
		//{
		//	return _aggregate.first;
		//}
		public override object Prev()
		{
			BookChapter buf;
			//
			//return _aggregate.parent;
			dop = _aggregate.parent;

			if (dop==null)
			{
				//return this;
				dop = _aggregate;
				
					while (dop.child != null)
					{

						dop = dop.child.Last(); ;
					}
					_aggregate = dop;
				_current = dop.num;
					return dop;
				
				
			}
			else
			{
				dop = dop.child.Find(i => i.num == _current - 1);
					if (dop!=null)
				{
					while (dop.child != null)
					{

						dop = dop.child.Last(); ;
					}
					
					_aggregate = dop;
					_current = dop.num;

					return dop;
				}
				else
				{
					_aggregate = _aggregate.parent;
					_current = _aggregate.num;
					return _aggregate;
				}
			}
		}
		public override object Next()
		{
			
				if (_aggregate.child != null)
				{
					dop=_aggregate.child.Find(i => i.num == 0);
					_aggregate = dop;
					_current = dop.num;
					return dop;
				}
				else
				{

					_aggregate=DFS(_aggregate, _current);
				_current = _aggregate.num;
					return _aggregate;
					
				}
			
			//throw new NotImplementedException();
		}


		private BookChapter DFS(BookChapter aggregate, int current)
		{
			BookChapter buf;
			buf = aggregate.parent;
			if (buf==null)
			{

				return aggregate;
			}
			else
			{
				buf = buf.child.Find(i => i.num == current + 1);
				if (buf != null)
				{

					aggregate = buf;
					current = aggregate.num;
					return buf;
				}
				else
				{
					buf = aggregate.parent;
					aggregate = buf;
					current = buf.num;

					return DFS(buf, current);

				}
			}

		}
	}
	class Book:Aggregate
	{
		BookChapter first;

		public override object Example()
		{
			first = new BookChapter(0, "cover", "D:\\Users\\iranc\\Documents\\3kourse\\git\\Iterator\\Iterator\\books\\BCover.txt");
			BookChapter cur, cur1;
			first.set_par(null, first);
			first.new_child(new BookChapter(0, "preface", "D:\\Users\\iranc\\Documents\\3kourse\\git\\Iterator\\Iterator\\books\\BPref.txt"));
			cur = first.child.First();
			cur.set_par(first, first);
			cur = new BookChapter(1, "part", "D:\\Users\\iranc\\Documents\\3kourse\\git\\Iterator\\Iterator\\books\\BP1.txt");
			cur.set_par(first, first);
			first.new_child(cur);
			cur1 = new BookChapter(2, "epilogue", "D:\\Users\\iranc\\Documents\\3kourse\\git\\Iterator\\Iterator\\books\\BEp.txt");
			cur1.set_par(first, first);
			first.new_child(cur1);

			cur1 = new BookChapter(0, "chapter", "D:\\Users\\iranc\\Documents\\3kourse\\git\\Iterator\\Iterator\\books\\B1.txt");
			cur1.set_par(cur, first);
			cur.new_child(cur1);
			cur1 = new BookChapter(1, "chapter", "D:\\Users\\iranc\\Documents\\3kourse\\git\\Iterator\\Iterator\\books\\B2.txt");
			cur1.set_par(cur, first);
			cur.new_child(cur1);
			
			return first;
		}
		public override Iterator CreateIterator()
		{
			return new BookIterator(first);
		}
	}
	class BookChapter
	{
		public int num;
		public string type;
		public string path;

		public BookChapter(int n, string t, string p)
		{
			parent = null;
			first = null;
			path = p;
			//child.ForEach(null);
			num = n;
			type = t;
		}

		public BookChapter parent;
		public BookChapter first;
		public List<BookChapter> child;

	
		public void set_par(BookChapter par, BookChapter f)
		{
			parent = par;
			first = f;
		}

		public void new_child(BookChapter ch)
		{
			if (child != null)
			{ child.Add(ch); }
			else
			{
				child = new List<BookChapter>();
				child.Add(ch);
			}
		}

	}

	class NovelIterator : Iterator
	{
		private List<WebNovelChapter> _aggregate;
		private int _current;

		public NovelIterator(List<WebNovelChapter> aggregate)
		{
			_aggregate = aggregate;
			_current = _aggregate.First().num;
		}
		public override object Next()
		{
			_current++;
			if (_current<_aggregate.Count())
			{
				return _aggregate[_current];

			}else
			{
				_current = 0;
				return _aggregate[_current];
			}
		}

		public override object Prev()
		{
			_current--;
			if (_current <0)
			{
				_current = _aggregate.Count()-1;
				return _aggregate[_current];

			}
			else
			{
				return _aggregate[_current];
			}
		}
	}

	class WebNovel : Aggregate
	{
		public List<WebNovelChapter> novel;
		public override object Example()

		{

			//WebNovelChapter chapter;
			//chapter=new WebNovelChapter()
			novel = new List<WebNovelChapter>();
			novel.Add(new WebNovelChapter(0, "D:\\Users\\iranc\\Documents\\3kourse\\git\\Iterator\\Iterator\\books\\n1.txt"));
			novel.Add(new WebNovelChapter(1, "D:\\Users\\iranc\\Documents\\3kourse\\git\\Iterator\\Iterator\\books\\n2.txt"));
			novel.Add(new WebNovelChapter(2, "D:\\Users\\iranc\\Documents\\3kourse\\git\\Iterator\\Iterator\\books\\n3.txt"));

			return novel[0];
		}
		public override Iterator CreateIterator()
		{
			return new NovelIterator(novel);
		}
	}


	class WebNovelChapter
	{
		public int num;
		public string path;
		public WebNovelChapter (int n, string s)
		{
			num = n;
			path = s;
		}
	}


}
