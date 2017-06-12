using System;
using System.Collections.Generic;
using System.Timers;

namespace Snake
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Game g = new Game();
			g.Go();
		}
	}

	class Snake
	{
		public int Y;
		public int X;

		public Snake(int x, int y)
		{
			X = x; Y = y;
		}
	}

	class Game
	{
		static List<Snake> size = new List<Snake>();

		int x = 10;
		int y = 10;
		int a = 5;
		int b = 5;
		int way = 0;

		Random rand = new Random();
		Timer timer = new Timer();

		public void GetApple(int q, int w)
		{
			int a = rand.Next(10);
			int b = rand.Next(10);
			int a1 = q;
			int b1 = w;

			int x = a + a1;
			int x1 = x - a1;
			x = x - x1;

			int y = b + b1;
			int y1 = y - b1;
			y = y - y1;

			Console.SetCursorPosition(x, y);
			Console.Write("*");
		}

		public void Go()
		{
			timer.Interval = 200;
			timer.Elapsed += Timer;
			timer.Start();

			size.Add(new Snake(10, 10));
			size.Add(new Snake(0, 0));
			size.Add(new Snake(0, 0));

			while (true)
			{
				switch (Console.ReadKey().Key)
				{
				case ConsoleKey.UpArrow:
					way = 0;
					break;

				case ConsoleKey.DownArrow:
					way = 1;
					break;

				case ConsoleKey.LeftArrow:
					way = 2;
					break;

				case ConsoleKey.RightArrow:
					way = 3;
					break;
				}
			}
		}

		public void MoveSnake(List<Snake> list, int x, int y, int way)
		{
			switch (way)
			{
			case 0:
				int xn0 = list[0].X;
				int yn0 = list[0].Y;
				for (int i0 = 0; i0 < list.Count; i0++)
				{
					if (i0 == 0)
					{
						Console.SetCursorPosition(list[i0].X--, list[i0].Y);
						Console.Write("*");
					}
					else
					{
						int xnn0 = list[i0].X;
						int ynn0 = list[i0].Y;
						list[i0].X = xn0;
						list[i0].Y = yn0;
						xn0 = xnn0;
						yn0 = ynn0;
						Console.SetCursorPosition(list[i0].X, list[i0].Y);
						Console.Write("*");
					}
				}
				break;

			case 1:
				int xn1 = list[0].X;
				int yn1 = list[0].Y;
				for (int i1 = 0; i1 < list.Count; i1++)
				{
					if (i1 == 0)
					{
						Console.SetCursorPosition(list[i1].X++, list[i1].Y);
						Console.Write("*");
					}
					else
					{
						int xnn1 = list[i1].X;
						int ynn1 = list[i1].Y;
						list[i1].X = xn1;
						list[i1].Y = yn1;
						xn1 = xnn1;
						yn1 = ynn1;
						Console.SetCursorPosition(list[i1].X, list[i1].Y);
						Console.Write("*");
					}
				}
				break;

			case 2:
				int xn2 = list[0].X;
				int yn2 = list[0].Y;
				for (int i2 = 0; i2 < list.Count; i2++)
				{
					if (i2 == 0)
					{
						Console.SetCursorPosition(list[i2].X, list[i2].Y--);
						Console.Write("*");
					}
					else
					{
						int xnn2 = list[i2].X;
						int ynn2 = list[i2].Y;
						list[i2].X = xn2;
						list[i2].Y = yn2;
						xn2 = xnn2;
						yn2 = ynn2;
						Console.SetCursorPosition(list[i2].X, list[i2].Y);
						Console.Write("*");
					}
				}
				break;

			case 3:
				int xn3 = list[0].X;
				int yn3 = list[0].Y;
				for (int i3 = 0; i3 < list.Count; i3++)
				{
					if (i3 == 0)
					{
						Console.SetCursorPosition(list[i3].X, list[i3].Y++);
						Console.Write("*");
					}
					else
					{
						int xnn3 = list[i3].X;
						int ynn3 = list[i3].Y;
						list[i3].X = xn3;
						list[i3].Y = yn3;
						xn3 = xnn3;
						yn3 = ynn3;
						Console.SetCursorPosition(list[i3].X, list[i3].Y);
						Console.Write("*");
					}
				}
				break;
			}
		}

		private void Timer(object sender, ElapsedEventArgs e)
		{
			Console.Clear();
			if (x == a && y == b)
			{
				a = a + rand.Next(20);
				if (a > 40)
					a = 5;

				b = b + rand.Next(20);
				if (b > 40)
					b = 5;

				size.Add(new Snake(0, 0));
			}

			switch (way)
			{
			case 3:
				x++;
				MoveSnake(size, x, y, 1);
				GetApple(a, b);
				break;

			case 2:
				x--;
				MoveSnake(size, x, y, 0);
				GetApple(a, b);
				break;

			case 1:
				y++;
				MoveSnake(size, x, y, 3);
				GetApple(a, b);
				break;

			case 0:
				y--;
				MoveSnake(size, x, y, 2);
				GetApple(a, b);
				break;
			}
		}
	}
}