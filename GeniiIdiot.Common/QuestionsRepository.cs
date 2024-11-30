using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniiIdiot.Common
{
    public class QuestionsRepository
    {
        private List<Question> Questions;
        public QuestionsRepository()
        {
            Questions = new List<Question>();
        }
        public List<Question> GetQuestions()
        {
            return Questions;
        }

        public void SaveQuestion(FileManager managerQuestion)
        {
            if (FileManager.Exist(managerQuestion._filename))
            {
                Questions.ForEach((q) =>
                {
                    var questionStr = $"{q.Text}#{q.Answer}";
                    managerQuestion.AddInformationToFile(questionStr);

                });
            }
            else
            {
                Questions.Add(new Question("Сколько будет два плюс два умноженное на два?",6));
                Questions.Add(new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",9));
                Questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?",25));
                Questions.Add(new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",60));
                Questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
                Questions.ForEach((q) =>
                {
                    var questionStr = $"{q.Text}#{q.Answer}";
                    managerQuestion.AddInformationToFile(questionStr);

                });
            }
        }

        public void RemoveQuestion(List<Question> questions, FileManager fileManager)
        {
            Questions = questions;
            while (true)
            {
                Console.WriteLine("Если вы хотите удалить вопрос для тестирования введите - yes , если нет, чтобы начать тест нажмите любую клавишу");
                var adminChoise = Console.ReadLine();
                if (adminChoise.ToLower() == "yes")
                {
                    ShowQuestion();
                    Console.WriteLine("Введите номер вопроса:");
                    int numberUser = GetUserAnswerNumber();
                    Questions.RemoveAt(numberUser-1);
                    fileManager.Clear();
                    SaveQuestion(fileManager);
;
                }
                else break;
            }
        }

        private void ShowQuestion()
        {
            Console.WriteLine("Список вопросов : " );
            int numbers = 1;
            Questions.ForEach(q =>
            {
                Console.WriteLine($"Вопрос № : {numbers} {q.Text}");
                numbers++;
            });
        }

        public void AddQuestion()
        {
            while (true)
            {

                Console.WriteLine("Если вы хотите дабавить вопрос для тестирования введите - yes , если нет, чтобы начать тест нажмите любую клавишу");
                var adminChoise = Console.ReadLine();
                if (adminChoise.ToLower() == "yes")
                {
                    Console.WriteLine("Введите текст вопроса");
                    string text = GetUserAnswerText();
                    Console.WriteLine("Введите правильный ответ:");
                    int answer = GetUserAnswerNumber();
                    var question = new Question( text, answer);
                    Questions.Add(question);

                }
                else break;
            }
        }

        public List<Question> GetQuestionsRepository(List<string> valuesStrings)
        {
            var questions = new List<Question>();
            valuesStrings.ForEach(value =>
            {
                var valT = value.Split('#');
                questions.Add(new Question(valT[0], int.Parse(valT[1])));
            });
            return questions;
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

