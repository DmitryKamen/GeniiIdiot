using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeniiIdiotConsoleApp
{

    internal class Program
    {
        // Комментарий
        static void Main(string[] args)
        {
            string continueTest = "";
            while (true)
            {

                var questionsWithAnswers = GetQuestionsWithAnswers();
                int countQuestions = questionsWithAnswers.Count;
                int countRightAnswers = 0;

                Random random = new Random();

                Console.WriteLine("Введите ваше имя:");
                User user1 = new User(Console.ReadLine());

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));

                    int randomQuestionIndex = random.Next(0, countQuestions - i);
                    Console.WriteLine(questionsWithAnswers[randomQuestionIndex].Question);

                    int userAnswer;
                    while (true)
                    {
                        string answerStr = Console.ReadLine();
                        if (int.TryParse(answerStr, out userAnswer))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Введённая строка не является числом, введите пожалуйста число: ");
                        }
                    }

                    int rightAnswer = questionsWithAnswers[randomQuestionIndex].Answer;

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                    questionsWithAnswers.RemoveAt(randomQuestionIndex);
                }

                //Console.WriteLine("Количество правильных ответов: " + countRightAnswers);
                //Console.WriteLine($"{user1.Name} Ваш диагноз: {GetDiagnoses(countRightAnswers, countQuestions)}");

                var manager = new ResultsManager();
                manager.AddResult(user1.Name, countRightAnswers, GetDiagnoses(countRightAnswers, countQuestions));
                manager.DisplayResults();

                Console.WriteLine("Вы хотите повторить тест? yes/no?");
                continueTest = Console.ReadLine();
                if (continueTest.ToLower() == "no") break;
            }
        }
        static List<QuestionWithAnswer> GetQuestionsWithAnswers()
        {

            List<QuestionWithAnswer> questions = new List<QuestionWithAnswer>();
            questions.Add(new QuestionWithAnswer("Сколько будет два плюс два умноженное на два?", 6));
            questions.Add(new QuestionWithAnswer("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9));
            questions.Add(new QuestionWithAnswer("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
            questions.Add(new QuestionWithAnswer("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60));
            questions.Add(new QuestionWithAnswer("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
            return questions;
        }
        static string GetDiagnoses(int countRightAnswers, int countQuestions)
        {
            var diagnoses = new List<DiagnosInNumber>();
            diagnoses.Add(new DiagnosInNumber("кретин", 0, 0.1));
            diagnoses.Add(new DiagnosInNumber("идиот", 0.2, 0.3));
            diagnoses.Add(new DiagnosInNumber("дурак", 0.4, 0.4));
            diagnoses.Add(new DiagnosInNumber("нормальный", 0.5, 0.6));
            diagnoses.Add(new DiagnosInNumber("талант", 0.7, 0.8));
            diagnoses.Add(new DiagnosInNumber("гений", 0.9, 1));
            double diferense = Math.Round(countRightAnswers / (double)countQuestions, 1);
            foreach (var diagnos in diagnoses)
            {
                if (diferense >= diagnos.MinNumberDiagnos && diferense <= diagnos.MaxNumberDiagnos)
                {
                    return diagnos.DiagnosName;
                }
            }
            return null;
        }
    }

}
