using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniiIdiot.Common
{

    public class UsersResultRepository
    {
        public List<User> Users { get; set; }

        public UsersResultRepository() 
        {    
            Users = new List<User>();
        }

        public string SaveUserResult()
        {
            var user = Users.Last();
            string value = $"{user.Name}#{user.RightAnswers}#{user.Diagnose}";
            return value;
        }

        public void ShowUserResult(List<string> resultLine)
        {

            Console.WriteLine("{0,-30}{1,-40}{2,-30}", "Имя", "Количество правильных ответов", "Диагноз");

            foreach (var result in resultLine)
            {
                var resT = result.Split('#');
                Console.WriteLine($"|{resT[0],-30}|{int.Parse(resT[1]),-40}|{resT[2],-30}|");
            }
        }
    }
}
