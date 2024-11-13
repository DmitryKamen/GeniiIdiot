namespace GeniiIdiotConsoleApp
{
    public class Question 
    {
        public int Number { get; set; } 
        public string Text { get; set; }
        public int Answer { get; set; }

        public Question(string text, int answer)
        {
            
            Text = text;
            Answer = answer;
        }

    }
}
