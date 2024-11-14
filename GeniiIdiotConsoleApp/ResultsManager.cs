using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GeniiIdiotConsoleApp
{
    public class ResultsManager
    {
        private readonly string _filename;

        public ResultsManager(string filename)
        {
            _filename = filename;

            // Создаем файл с заголовком, если его нет
            if (!File.Exists(_filename))
            {
                File.Create(_filename);
            }
        }

        public void AddResult(string value)
        {
            var writer = new StreamWriter(_filename, true);
            writer.WriteLine(value);
            writer.Close();

        }

        public List<string> GetFileInformation()
        {
            var results = new List<string>();

            var reader = new StreamReader(_filename);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line != null)
                {
                    results.Add(line);
                }
            }
            reader.Close();
            return results;
        }
    }
}


