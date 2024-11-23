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
                questionsRepository.SaveQuestion(managerQuestion);
                var questions = questionsRepository.GetQuestionsRepository(managerQuestion.GetFileInformation());
                var countQuestions = questions.Count;

                var random = new Random();

                Console.WriteLine("Введите ваше имя:");
                var name = QuestionsRepository.GetUserAnswerText();
                var user = new User(name);

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));

                    var randomQuestionIndex = random.Next(0, countQuestions - i);
                    Console.WriteLine(questions[randomQuestionIndex].Text);

                    var userAnswer = QuestionsRepository.GetUserAnswerNumber();


                    var rightAnswer = questions[randomQuestionIndex].Answer;

                    if (userAnswer == rightAnswer)
                    {
                        user.IncrementRightAnswers();
                    }
                    questions.RemoveAt(randomQuestionIndex);
                } 
                
                user.Diagnose = DiagnoseRepository.GetDiagnoses(user.RightAnswers, countQuestions);
                usersResultRepository.Users.Add(user);

                var managerResult = new FileManager("results.txt");
                managerResult.AddInformationToFile(usersResultRepository.SaveUserResult());                
                
                Console.WriteLine("Хотите вывести результат введите - yes , если не хотите нажмите любую клавишу");
                var showResultTest = Console.ReadLine();
                if (showResultTest.ToLower() == "yes") usersResultRepository.ShowUserResult(managerResult.GetFileInformation());
                questionsRepository.AddQuestion();
                questionsRepository.SaveQuestion(managerQuestion);
                questions = questionsRepository.GetQuestionsRepository(managerQuestion.GetFileInformation());
                questionsRepository.RemoveQuestion(questions, managerQuestion);

                
                Console.WriteLine("Если хотите продолжить нажмите любую клавишу, если нет введите - no ");
                var continueTest = Console.ReadLine();
                if (continueTest.ToLower() == "no") break;
            }
        }

    }   
}
