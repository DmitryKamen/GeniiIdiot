using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GeniiIdiotConsoleApp
{

    internal partial class Program
    {
        // Комментарий
        static void Main(string[] args)
        {
            while (true)
            {

                var questionsRepository = new QuestionsRepository();
                var usersResultRepository = new UsersResultRepository();
                var managerQuestion = new FileManager("question.txt");
                AddQuestion(questionsRepository);
                RemoveQuestion(questionsRepository);
                SaveQuestion(questionsRepository, managerQuestion);
                var questions = GetQuestionsRepository(managerQuestion.GetFileInformation());
                var countQuestions = questions.Count;
                var countRightAnswers = 0;

                var random = new Random();

                Console.WriteLine("Введите ваше имя:");
                var user = new User(Console.ReadLine());

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));

                    var randomQuestionIndex = random.Next(0, countQuestions - i);
                    Console.WriteLine(questions[randomQuestionIndex].Text);

                    var userAnswer = GetUserAnswer();


                    var rightAnswer = questions[randomQuestionIndex].Answer;

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                    questions.RemoveAt(randomQuestionIndex);
                } 
                
                user.Diagnose = GetDiagnoses(countRightAnswers, countQuestions);
                user.RightAnswers = countRightAnswers;
                usersResultRepository.Users.Add(user);

                var managerResult = new FileManager("results.txt");
                managerResult.AddResult(SaveUserResult(user.Name, countRightAnswers, user.Diagnose));                
                while (true)
                {
                    Console.WriteLine("Хотите вывести результат введите - yes , если не хотите нажмите любую клавишу");
                    var showResultTest = Console.ReadLine();
                    if (showResultTest.ToLower() == "yes") ShowUserResult(managerResult.GetFileInformation());
                    else break;
                }
                Console.WriteLine("Если хотите продолжить нажмите любую клавишу, если нет введите - no ");
                var continueTest = Console.ReadLine();
                if (continueTest.ToLower() == "no") break;
            }
        }

        private static void SaveQuestion(QuestionsRepository questionsRepository, FileManager managerQuestion)
        {
            questionsRepository.GetQuestions().ForEach((q) =>
            {
                var questionStr = $"{q.Number}#{q.Text}#{q.Answer}";
                managerQuestion.AddResult(questionStr);

            });

        }

        private static string SaveUserResult(string userName, int countRightAnswers, string diagnose)
        {
            string value = $"{userName}#{countRightAnswers}#{diagnose}"; 
            return value;
        }
        
        private static void ShowUserResult(List<string> resultLine)
        {

            Console.WriteLine("{0,-30}{1,-40}{2,-30}", "Имя", "Количество правильных ответов", "Диагноз");

            foreach (var result in resultLine)
            {
                var resT = result.Split('#');
                Console.WriteLine($"|{resT[0],-30}|{int.Parse(resT[1]), -40}|{resT[2], -30}|");
            }
            
        }

        private static void RemoveQuestion(QuestionsRepository questionsRepository)
        {
            while (true)
            {
                Console.WriteLine("Если вы хотите удалить вопрос для тестирования введите - yes , если нет, чтобы начать тест нажмите любую клавишу");
                var adminChoise = Console.ReadLine();
                if (adminChoise.ToLower() == "yes")
                {
                    Console.WriteLine("Введите номер вопроса:");
                    int number = GetUserAnswer();
                    questionsRepository.GetQuestions().ForEach(q => { if (q.Number == number) questionsRepository.RemoveQuestion(q); })
;
                }
                else break;
            }
        }

        private static void AddQuestion(QuestionsRepository repository)
        {
            while (true)
            {

                Console.WriteLine("Если вы хотите дабавить вопрос для тестирования введите - yes , если нет, чтобы начать тест нажмите любую клавишу");
                var adminChoise = Console.ReadLine();
                if (adminChoise.ToLower() == "yes")
                {
                    Console.WriteLine("Введите номер вопроса:");
                    int number = GetUserAnswer();
                    Console.WriteLine("Введите текст вопроса");
                    string text = Console.ReadLine();
                    Console.WriteLine("Введите правильный ответ:");
                    int answer = GetUserAnswer();
                    var question = new Question( number ,text, answer);
                    repository.AddQuestion(question);

                }
                else break;
            }
        }

        private static int GetUserAnswer()
        {
            while (true)
            {
                try 
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException) 
                {
                    Console.WriteLine("Введённая строка не является числом, введите пожалуйста число: ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Вы ввели слишком большое число: ");
                }
            }   
        }

        static List<Question> GetQuestionsRepository(List<string> valuesStrings)
        {

            var questions = new List<Question>();
            valuesStrings.ForEach(value =>
            {
                var valT = value.Split('#');
                questions.Add(new Question(int.Parse(valT[0]), valT[1], int.Parse(valT[2])));
            });
            return questions;
        }
        static string GetDiagnoses(int countRightAnswers, int countQuestions)
        {
            var diagnoses = new List<DiagnosInNumber>();
            diagnoses.Add(new DiagnosInNumber("кретин", 0, 0));
            diagnoses.Add(new DiagnosInNumber("идиот", 0.1, 0.2));
            diagnoses.Add(new DiagnosInNumber("дурак", 0.3, 0.4));
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
