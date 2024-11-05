namespace GeniiIdiotConsoleApp
{
    public class QuestionWithAnswer 
    {
        public string Question { get; set; }
        public int Answer { get; set; }

        public QuestionWithAnswer(string question, int answer)
        {
            Question = question;
            Answer = answer;
        }

    }
}
