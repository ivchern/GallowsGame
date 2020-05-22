using System;

namespace GallowsGame
{
    class Program
    {
        static void Main(string[] args)
        {
       
            while (true)
            {
            GuessWord gw = new GuessWord();
                gw.Hide();
                gw.CheckLetter();
                Console.WriteLine("Нажмите любую клавишу, чтобы начать сначала");
            Console.ReadKey();
            Console.Clear();

            }
        }
    }
}
