using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniiIdiot.Common
{
    public class QuestionsRepository
    {
        public static string Path = "question.json";
        public static List<Question> GetOll()
        {
            var questions = new List<Question>();
            if(!FileManager.Exist(Path))
            {
                questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
                questions.Add(new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9));
                questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
                questions.Add(new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60));
                questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));

                Save(questions);
                return questions;
            }
            else
            {
                var fileData = FileManager.Get(Path);
                var questionsFromFile = JsonConvert.DeserializeObject<List<Question>>(fileData);
                return questionsFromFile;
            }
        }

        public static void Save(List<Question> questions)
        {
            var jsonData = JsonConvert.SerializeObject(questions, Formatting.Indented);
            FileManager.Replace(Path, jsonData);

        }
        public static string GetUserAnswerText()
        {
            while (true)
            {
                var questionText = Console.ReadLine();
                if (questionText.Contains('#')) Console.WriteLine("В вопросе введен недопустимый символ, введите вопрос заново");
                else return questionText;
            }
        }

        public static int GetUserAnswerNumber()
        {
            int number;
            while (!InputValidator.TryParseToNumber(Console.ReadLine(), out number, out string errorMassage))
            {
                Console.WriteLine(errorMassage);
            }
            return number;
        }
    }
}

