using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GeniiIdiotConsoleApp
{
    public class ResultsManager
    {
        private readonly string _filename;

        public ResultsManager(string filename = "results.csv")
        {
            _filename = filename;

            // Создаем файл с заголовком, если его нет
            if (!File.Exists(_filename))
            {
                using (var writer = new StreamWriter(_filename))
                {
                    writer.WriteLine("ФИО,Количество правильных ответов,Диагноз");
                }
            }
        }

        public void AddResult(string fullName, int correctAnswers, string diagnosis)
        {
            using (var writer = new StreamWriter(_filename, true))
            {
                writer.WriteLine($"{fullName},{correctAnswers},{diagnosis}");
            }
        }

        public List<Result> GetResults()
        {
            var results = new List<Result>();

            using (var reader = new StreamReader(_filename))
            {
                reader.ReadLine(); // Пропускаем заголовок

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split(',');
                        results.Add(new Result(values[0], int.Parse(values[1]), values[2]));
                    }
                }
            }

            return results;
        }

        public void DisplayResults()
        {
            var results = GetResults();

            if (results.Any())
            {
                Console.WriteLine("+-------------------------------+-----------------------------+------------------+");
                Console.WriteLine("| ФИО                           | Количество правильных ответов | Диагноз          |");
                Console.WriteLine("+-------------------------------+-----------------------------+------------------+");

                foreach (var result in results)
                {
                    Console.WriteLine($"| {result.FullName,-30} | {result.CorrectAnswers,-27} | {result.Diagnosis,-15} |");
                }

                Console.WriteLine("+-------------------------------+-----------------------------+------------------+");
            }
            else
            {
                Console.WriteLine("Нет данных для отображения.");
            }
        }
    }

}
