using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPractiseApplication.Models
{
    public interface ITestQuestionsRepository
    {
        void Add(TestModel user);
        void Edit(TestModel user);
        void Remove(int id);
        List<TestModel> GetQuestions();
    }
}
