namespace GeniiIdiot.Common
{
    public class DiagnosInNumber
    {
        public string DiagnosName { get; set; }

        public double MinNumberDiagnos { get; set; }
        public double MaxNumberDiagnos { get; set; }

        public DiagnosInNumber(string diagnosName, double minNumberDiagnos, double maxNumberDiagnos) 
        {
            DiagnosName = diagnosName;
            MinNumberDiagnos = minNumberDiagnos;
            MaxNumberDiagnos= maxNumberDiagnos;
        } 
    }

}
