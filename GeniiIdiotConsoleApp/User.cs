namespace GeniiIdiotConsoleApp
{
    public class User
    {
        public string Name { get; set; }

        public int RightAnswers { get; set; }

        public string Diagnose { get; set; }
        public User(string name)
        {
            Name = name;
            RightAnswers = 0;
            Diagnose = "Не определен";
        }

        public void IncrementRightAnswers()
        {
            RightAnswers++;
        }

    }
}
