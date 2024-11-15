namespace GeniiIdiotConsoleApp
{
    public class Question 
    {
        public int Number { get; set; } 
        public string Text { get; set; }
        public int Answer { get; set; }

        public Question(int number, string text, int answer)
        {
            
            Number = number;
            Text = text;
            Answer = answer;
        }

    }
}
