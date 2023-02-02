
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Rome_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            // Создаем словарь с римскими и арабскими цифрами, потом выводим объект. 
            // Я слабо знаю словари, поэтому решил попробовать сделать через них использовал справочник для обучения

            var Rome = new Dictionary<string, int>()
            {
                 { "I", 1},
                 { "V", 5},
                 { "X", 10},
                 { "L", 50},
                 { "C", 100},
                 { "D", 500},
                 { "M", 1000},
            };

            foreach (var number in Rome)
            {
                Console.WriteLine($"Римская цифра: {number.Key}  Арабская: {number.Value}");
            }

            string InputText = Console.ReadLine();
            // Проверка
            while (double.TryParse(InputText, out var parsedNumber))
            {
                InputText = Console.ReadLine();
            }

            foreach (var number in Rome)
            {
                if (InputText == number.Key)
                {
                    Console.WriteLine("С римской СС: " + number.Value);

                }
            }

            // Теперь разделяем строку и заполняем массив c переводом в десятичную
            string[] numbers = new string[InputText.Length];
            // Переносим
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Convert.ToString(InputText[i]);
            }
            // Переводим каждый символ
            for (int i = 0; i < numbers.Length; i++)
            {
                foreach (var number in Rome)
                {
                    if (numbers[i] == number.Key)
                    {
                        numbers[i] = Convert.ToString(number.Value);
                    }
                }
            }
            // Теперь нужно реализовать подсчет

            int answer = 0;

            // Взять символ по одному, начиная с индекса 0:
            // Если текущее значение символа больше или равно значению следующего символа, добавьте это значение к промежуточной сумме.
            // иначе вычтите это значение, добавив значение следующего символа к промежуточной сумме.


            for (int i = 0; i < numbers.Length; i++)
            {
                if (i != numbers.Length - 1)
                {
                    if ((Convert.ToInt32(numbers[i]) >= Convert.ToInt32(numbers[i + 1])))
                    {
                        answer = answer + (Convert.ToInt32(numbers[i]));
                    }
                    else
                    {
                        answer = answer - Convert.ToInt32(numbers[i]);
                    }

                }
                else
                {
                    answer = answer + Convert.ToInt32(numbers[i]);
                }

            }
            Console.WriteLine(answer);
        }
    }
}
