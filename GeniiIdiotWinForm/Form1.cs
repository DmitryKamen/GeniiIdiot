using GeniiIdiot.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeniiIdiotWinForm
{
    public partial class Form1 : Form
    {
        private List<Question> questions;
        private Question currentQuestion;
        private User user;
        private int countQuestions;
        private int questionsNumber = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var questionsRepository = new QuestionsRepository();
            var usersResultRepository = new UsersResultRepository();
            var managerQuestion = new FileManager("question.txt");
            questionsRepository.SaveQuestion(managerQuestion);
            questions = questionsRepository.GetQuestionsRepository(managerQuestion.GetFileInformation());
            countQuestions = questions.Count;
            user = new User("Неизвестно");
            questionsNumber = 0;

            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            var random = new Random();
            var randomQuestionIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomQuestionIndex];
            questionTextLabel.Text = currentQuestion.Text;
            questionsNumber++;
            questionNumberLabel.Text = "Вопрос №" + questionsNumber;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var userAnswer = Convert.ToInt32(userAnswerTextBox.Text);
            var rightAnswer = currentQuestion.Answer;

            if (userAnswer == rightAnswer)
            {
                user.IncrementRightAnswers();
            }
            questions.Remove(currentQuestion);

            var endGame = questions.Count == 0;
            if (endGame)
            {
                user.Diagnose = DiagnoseRepository.GetDiagnoses(user.RightAnswers, countQuestions);
                MessageBox.Show(user.Diagnose);
                return;
            }
            ShowNextQuestion();
        }
    }
}
