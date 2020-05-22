using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GallowsGame
{
    class GuessWord
    {
        string word = RandomWord.NewWord();
        List<char> charKey = new List<char>();
        List<char> charValue = new List<char>();
        List<char> used_Letter = new List<char>();

        //Добавляем в словарь значения 
        public void Hide()
        {
            char[] wordChars = word.ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                charKey.Add(wordChars[i]);
                charValue.Add('-');
            }
        }

       private int countАttempt = 6;
        private int count = 0;
        //Проверка наличия буквы
        public void CheckLetter()
        {
            while (countАttempt != 0)
            {
                
                usedLetter();
                Console.WriteLine(showNowWord());
                if (nextCheck() == true) //проверяем не отгодали ли мы все буквы
                {
                    char input_Letter = inputLetter();
                    if (haveChar(input_Letter) > 0) //Проверяем есть ли такой символ
                    {
                        count = 0;
                        Console.Clear();
                    }
                    else
                    {
                        countАttempt--;
                        used_Letter.Add(input_Letter);
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Поздравляем вы выиграли!");
                    break;
                }
            }
            if(countАttempt == 0)
            Console.WriteLine($"Увы, вы проиграли:(\n слово: {word}");
        }
        //считываем слово 
        private char inputLetter()
            {
                try
                {
                Console.WriteLine($"Введите предполагаемую букву у вас { countАttempt} попыток");
                    char input = char.Parse(Console.ReadLine());
                if(usedItLetter(input) == true)
                {
                    throw new System.ArgumentException("Такая буква уже была");
                }
                    return input;
                }
                catch
                {
                    Console.WriteLine("Вы где-то ошиблись,1 попробуйте еще раз");
                    inputLetter();
                    return '\0';
                }

            }

        //проверка есть ли такая буква 
        private int haveChar(char input)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (input == charKey[i])
                    {
                        charValue[i] = charKey[i];
                        charKey[i] = '-';
                        count += 1;
                    }
                }
                return count;
            }

        //проверяем не угадали ли слово
        private bool nextCheck()
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (charValue[i] == '-')
                    {
                        return true;
                    }
                }
                return false;
            }
        //Отображение текущей позиции отгадывания
        private string showNowWord()
            {
                string nowWord = null;
                for (int i = 0; i < word.Length; i++)
                {
                    nowWord += charValue[i];
                }
                return nowWord;
            }
        private void usedLetter() //Выводим буквы, которые исползовали
        {
            string used = null;
            for (int i = 0; i < used_Letter.Count; i++)
            {
                used = used + used_Letter[i] + " ";
            }
            Console.WriteLine($" Использованные буквы: {used}");
        }
        //Проверяем буквы которые уже были
        private bool usedItLetter(char inputChar)
        {
            for (int i = 0; i < used_Letter.Count; i++)
            {
                if(used_Letter[i] == inputChar)
                {
                    return true;
                } 
            }
            return false;
        }
        }
    }
