using System.Collections.Generic;

namespace GeniiIdiotConsoleApp
{

    public class UsersResultRepository
    {
        public List<User> Users { get; set; }

        public UsersResultRepository() 
        {    
            Users = new List<User>();
        }    
    }
}
