using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniiIdiot.Common
{
    public class InputValidator
    {
        public static bool TryParseToNumber(string input, out int number, out string errorMassage)
        {
           
            try
            {
                number = Convert.ToInt32(input);
                errorMassage = "";
                return true;
            }
            catch (FormatException)
            {
                errorMassage ="Введённая строка не является числом, введите пожалуйста число: ";
                number = 0;
                return false;
            }
            catch (OverflowException)
            {
                errorMassage = "Вы ввели слишком большое число: ";
                number = 0;
                return false;
            }
            
        }
    }
}
