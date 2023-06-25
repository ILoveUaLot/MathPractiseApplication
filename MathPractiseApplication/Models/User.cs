using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPractiseApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int CompletedExercises { get; set; } 
        public string TestResults { get; set; }

        public User()
        {
            Id = 1;
            Name = string.Empty;
            Password = string.Empty;
            CompletedExercises = 0;
            TestResults = string.Empty;
        }
        public User(string name, string password)
        {
            Name= name;
            Password= password;
            CompletedExercises= 0;
            TestResults = string.Empty;
        }
    }
}
