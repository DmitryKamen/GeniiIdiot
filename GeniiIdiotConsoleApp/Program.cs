using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GeniiIdiot.Common;

namespace GeniiIdiotConsoleApp
{

    internal partial class Program
    {
        // Комментарий
        static void Main(string[] args)
        {
            while (true)
            {
                var managerQuestion = new FileManager("question.txt");
                
                var random = new Random();
                Console.WriteLine("Введите ваше имя:");
                var name = QuestionsRepository.GetUserAnswerText();
                var user = new User(name);
                var game = new Game(user);

                while(!game.End())
                {
                    var currentQuestion =game.GetNextQuestion();
                    Console.WriteLine(game.GetQuestionNumberText());
                    Console.WriteLine(currentQuestion.Text);

                    var userAnswer = QuestionsRepository.GetUserAnswerNumber();
                    game.AcceptAnswer(userAnswer);
                }
                var message = game.CalculateDiagnose();
                Console.WriteLine(message);               

                var managerResult = new FileManager("results.txt");
                managerResult.AddInformationToFile(game.usersResultRepository.SaveUserResult());                
                
                Console.WriteLine("Хотите вывести результат введите - yes , если не хотите нажмите любую клавишу");
                var showResultTest = Console.ReadLine();
                if (showResultTest.ToLower() == "yes") game.usersResultRepository.ShowUserResult(managerResult.GetFileInformation());
                game.questionsRepository.AddQuestion();
                game.questionsRepository.SaveQuestion(managerQuestion);
                game.questions = game.questionsRepository.GetQuestionsRepository(managerQuestion.GetFileInformation());
                game.questionsRepository.RemoveQuestion(game.questions, managerQuestion);

                Console.WriteLine("Если хотите продолжить нажмите любую клавишу, если нет введите - no ");
                var continueTest = Console.ReadLine();
                if (continueTest.ToLower() == "no") break;
            }
        }

    }   
}
