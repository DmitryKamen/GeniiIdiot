using System.Collections.Generic;

namespace GeniiIdiotConsoleApp
{
    public class QuestionsRepository
    {
        private List<Question> Questions;
        public QuestionsRepository()
        {
            Questions = new List<Question>();
        }
        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }
        public void RemoveQuestion(Question question)
        {
            Questions.Remove(question);
        }
        public List<Question> GetQuestions()
        {
            return Questions;
        }

    }
}

