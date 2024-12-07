using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniiIdiot.Common
{

    public class UsersResultRepository
    {
        public static string Path = "result.json";
        
        public static void Show(List<User> resultLine)
        {

            Console.WriteLine("{0,-30}{1,-40}{2,-30}", "Имя", "Количество правильных ответов", "Диагноз");

            foreach (var res in resultLine)
            {
                Console.WriteLine($"|{res.Name}|{res.RightAnswers}|{res.Diagnose}|");
            }
        }

        public static void Append(User user)
        {
            var userResults = CetAll();
            userResults.Add(user);
            Save(userResults);

        }

        public static List<User> CetAll()
        {
            if (!FileManager.Exist(Path))
            {
                return new List<User>();
            }
            else
            {
                var fileData = FileManager.Get(Path);
                var userResult = JsonConvert.DeserializeObject<List<User>>(fileData);
                return userResult;
            }
        }

        public static void Save(List<User> users)
        {
            var jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
            FileManager.Replace(Path, jsonData);

        }
    }
}
