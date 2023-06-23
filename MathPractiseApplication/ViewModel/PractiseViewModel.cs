using MathPractiseApplication.Models;
using MathPractiseApplication.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPractiseApplication.ViewModel
{
    public class PractiseViewModel : ViewModelBase
    {
        private readonly IPractiseService _practiseService;
        private PractiseModel _currentPractiseQuestion;
        private double _userAnswer;
        private string _resultMessage;
        public string ResultMessage
        {
            get { return _resultMessage; }
            set
            {
                if (_resultMessage != value)
                {
                    _resultMessage = value;
                    OnPropertyChanged(nameof(ResultMessage));
                }
            }
        }

        private bool? _isCorrectAnswer;
        public bool? IsCorrectAnswer
        {
            get { return _isCorrectAnswer; }
            set
            {
                if (_isCorrectAnswer != value)
                {
                    _isCorrectAnswer = value;
                    OnPropertyChanged(nameof(IsCorrectAnswer));
                }
            }
        }

        public double UserAnswer
        {
            get => _userAnswer; 
            set
            {
                if(_userAnswer != value)
                {
                    _userAnswer = value;
                    OnPropertyChanged(nameof(UserAnswer));

                    if (_practiseService.CheckAnswer(_currentPractiseQuestion, _userAnswer))
                    {
                        ResultMessage = "Ответ верный!";
                        IsCorrectAnswer = true;
                        GenerateNewProblem();
                    }
                    else
                    {
                        ResultMessage = "Попробуйте еще раз!";
                        IsCorrectAnswer = false;
                    }
                }
                
            }
        }

        public PractiseViewModel()
        {
            _practiseService = ServiceLocator.ServiceProvider.GetService<IPractiseService>();
            GenerateNewProblem();
        }

        public string CurrentPractiseQuestion => _currentPractiseQuestion.Question;

        private void GenerateNewProblem()
        {
            _currentPractiseQuestion = _practiseService.GenerateQuestion();
            OnPropertyChanged(nameof(CurrentPractiseQuestion));
        }
    }
}
