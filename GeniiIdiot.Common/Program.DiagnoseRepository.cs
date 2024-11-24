using System;
using System.Collections.Generic;

namespace GeniiIdiot.Common
{
    public class DiagnoseRepository
    {
        public static string GetDiagnoses(int countRightAnswers, int countQuestions)
        {
            var diagnoses = new List<DiagnosInNumber>();
            diagnoses.Add(new DiagnosInNumber("кретин", 0, 0));
            diagnoses.Add(new DiagnosInNumber("идиот", 0.1, 0.2));
            diagnoses.Add(new DiagnosInNumber("дурак", 0.3, 0.4));
            diagnoses.Add(new DiagnosInNumber("нормальный", 0.5, 0.6));
            diagnoses.Add(new DiagnosInNumber("талант", 0.7, 0.8));
            diagnoses.Add(new DiagnosInNumber("гений", 0.9, 1));
            double diferense = Math.Round(countRightAnswers / (double)countQuestions, 1);
            foreach (var diagnos in diagnoses)
            {
                if (diferense >= diagnos.MinNumberDiagnos && diferense <= diagnos.MaxNumberDiagnos)
                {
                    return diagnos.DiagnosName;
                }
            }
            return null;
        }
    }
}


