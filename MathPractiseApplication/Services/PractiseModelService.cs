using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathPractiseApplication.Models;

namespace MathPractiseApplication.Services
{
    public class PractiseModelService : IPractiseService
    {
        private Random random;
        public PractiseModelService()
        {
            random = new Random();
        }

        public bool CheckAnswer(PractiseModel question, double userAnswer)
        {
            return Math.Abs(question.Answer - userAnswer) < 0.01; //0.01 - погрешность, которая может возникнуть из-за работы с типом double
        }

        public PractiseModel GenerateQuestion()
        {
            if (random.Next(2) == 0) // линейное уравнение
            {
                double a = random.NextDouble() * 10;
                double b = random.NextDouble() * 10;

                a = Math.Round(a, 2);
                b = Math.Round(b, 2);
                double answer = -b / a;
                string problem = $"{a}x + {b} = 0";
                return new PractiseModel { Question = problem, Answer = answer };
            }
            else // система уравнений
            {
                double a = random.NextDouble() * 10;
                double b = random.NextDouble() * 10;
                double e = random.NextDouble() * 10;
                double c = random.NextDouble() * 10;
                double d = random.NextDouble() * 10;
                double f = random.NextDouble() * 10;
                //округляем до 2 знаков после запятой
                a = Math.Round(a, 2);
                b = Math.Round(b, 2);
                e = Math.Round(e, 2);
                c = Math.Round(c, 2);
                d = Math.Round(d, 2);
                f = Math.Round(f, 2);

                double y = (f * a - c * e) / (d * a - b * c);
                double x = (e - b * y) / a;
                string problem = $"{a}x + {b}y = {e}, {c}x + {d}y = {f}";
                return new PractiseModel { Question = problem, Answer = Math.Round(x, 2) }; //ищем значение 'x'. 
            }
        }
    }
}
