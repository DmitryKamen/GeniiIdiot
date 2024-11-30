using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniiIdiot.Common
{
    public class Game
    {
        public List<Question> questions;
        public Question currentQuestion;
        public QuestionsRepository questionsRepository;
        public UsersResultRepository usersResultRepository;
        public int countQuestions;
        public int questionsNumber;
        public User user;

        public Game(User user)
        { 
            this.user = user;
            questionsRepository = new QuestionsRepository();
            usersResultRepository = new UsersResultRepository();
            var managerQuestion = new FileManager("question.txt");
            questionsRepository.SaveQuestion(managerQuestion);
            questions = questionsRepository.GetQuestionsRepository(managerQuestion.GetFileInformation());
            countQuestions = questions.Count;
            questionsNumber = 0;
        }

        public Question GetNextQuestion()
        {
            var random = new Random();
            var randomQuestionIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomQuestionIndex];
            questionsNumber++;
            return currentQuestion;
        }

        public void AcceptAnswer(int userAnswer)
        {
            var rightAnswer = currentQuestion.Answer;

            if (userAnswer == rightAnswer)
            {
                user.IncrementRightAnswers();
            }
            questions.Remove(currentQuestion);
        }

        public string GetQuestionNumberText()
        {
            return "Вопрос №" + questionsNumber;
        }

        public bool End()
        {
            return questions.Count == 0;
        }

        public string CalculateDiagnose()
        {
            user.Diagnose = DiagnoseRepository.GetDiagnoses(user.RightAnswers, countQuestions);
            usersResultRepository.Users.Add(user);
            var managerResult = new FileManager("results.txt");
            managerResult.AddInformationToFile(usersResultRepository.SaveUserResult());
            return $"{user.Name}, Ваш диагноз : {user.Diagnose}";
        }
    }
}
