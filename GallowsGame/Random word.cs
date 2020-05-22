using System;
using System.IO;


namespace GallowsGame
{
	class RandomWord
	{
		static Random random = new Random();
		public static string NewWord()
		{
			string word;
			string patch = "WordsStockRus1.txt";
			using (StreamReader fs = new StreamReader(patch))
			{
				int count = File.ReadAllLines(patch).Length; // сколько слов в файле
				int rand = random.Next(1, (count));
				for (int i = 1; i < count; i++) // Ищем рандомное слово (???)
				{ 
					 word = fs.ReadLine();
				if (i == rand)
					{
						return word;
					}
				}
				return null;
			}       
		}

	}
}
