namespace GeniiIdiotConsoleApp
{
    public class Result
    {
        public string FullName { get; set; }
        public int CorrectAnswers { get; set; }
        public string Diagnosis { get; set; }

        public Result(string fullName, int correctAnswers, string diagnosis)
        {
            FullName = fullName;
            CorrectAnswers = correctAnswers;
            Diagnosis = diagnosis;
        }
    }

}
