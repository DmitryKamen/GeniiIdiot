using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GeniiIdiotConsoleApp
{
    public class FileManager
    {
        private readonly string _filename;

        public FileManager(string filename)
        {
            _filename = filename;

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


