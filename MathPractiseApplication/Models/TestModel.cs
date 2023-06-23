using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPractiseApplication.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public int IndexOfRightAnswer { get; set; }
    }
}
