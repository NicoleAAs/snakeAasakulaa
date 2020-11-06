using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Security.Cryptography.X509Certificates;

namespace snakes
{
	class GameOverSnake
	{
		public void WriteGameOver(string name, int score)
		{


			Params settings = new Params();
			Sounds sound2 = new Sounds(settings.GetResourceFolder());
			sound2.PlayNo();
			Random rnd = new Random();
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("GAME OVER", xOffset + 1, yOffset++);
			yOffset++;
			WriteText("Author  Aasakula Nicole", xOffset + 2, yOffset++);
			WriteText("   Your Results: " + score, xOffset + 2, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			Console.WriteLine(score);
			using (var file = new StreamWriter("score.txt", true))
			{
				file.WriteLine("Name: " + name + " | Score:" + score);
				file.Close();
			}
		}

		public void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}
