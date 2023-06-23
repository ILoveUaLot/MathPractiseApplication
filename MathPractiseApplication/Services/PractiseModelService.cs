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
                //округляем до 1 знаков после запятой
                a = Math.Round(a, 1);
                b = Math.Round(b, 1);
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
                //округляем до 1 знаков после запятой
                a = Math.Round(a, 1);
                b = Math.Round(b, 1);
                e = Math.Round(e, 1);
                c = Math.Round(c, 1);
                d = Math.Round(d, 1);
                f = Math.Round(f, 1);

                double y = (f * a - c * e) / (d * a - b * c);
                double x = (e - b * y) / a;
                string problem = $"{a}x + {b}y = {e}\n{c}x + {d}y = {f}";
                return new PractiseModel { Question = problem, Answer = Math.Round(x, 1) }; //ищем значение 'x'. 
            }
        }
    }
}
