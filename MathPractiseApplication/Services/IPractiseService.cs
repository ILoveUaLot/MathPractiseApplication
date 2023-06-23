using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPractiseApplication.Models;

namespace MathPractiseApplication.Services
{
    public interface IPractiseService
    {
        PractiseModel GenerateQuestion();
        bool CheckAnswer(PractiseModel question, double userAnswer);
    }
}
