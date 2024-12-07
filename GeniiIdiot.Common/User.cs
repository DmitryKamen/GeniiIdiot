namespace GeniiIdiot.Common
{
    public class User
    {
        public string Name { get; set; }

        public int RightAnswers { get; set; }

        public string Diagnose { get; set; }
        
        public User() { }
        public User(string name)
        {
            Name = name;
            RightAnswers = 0;
            Diagnose = "Не определен";
        }
        public User(string name, int rightAnswer,string diagnose)
        {
            Name = name;
            RightAnswers = rightAnswer;
            Diagnose = diagnose;
        }

        public void IncrementRightAnswers()
        {
            RightAnswers++;
        }

    }
}
