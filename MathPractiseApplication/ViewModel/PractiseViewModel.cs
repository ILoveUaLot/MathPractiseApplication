﻿using MathPractiseApplication.Models;
using MathPractiseApplication.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MathPractiseApplication.ViewModel
{
    public class PractiseViewModel : ViewModelBase
    {
        private readonly IPractiseService _practiseService;
        private PractiseModel _currentPractiseQuestion;
        private string _userAnswer;
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

        public string UserAnswer
        {
            get
            {
                return _userAnswer;
            } 
            set
            {
                _userAnswer = value;
                OnPropertyChanged(nameof(UserAnswer));   
            }
        }

        public ICommand CheckAnswerCommand { get; }
        public ICommand ReplaceQuestionCommand { get; }
        public void ExecuteReplaceQuestionCommand (object obj)
        {
            GenerateNewProblem();
        }
        private void ExecuteCheckAnswerCommand(object obj)
        {
            if (_practiseService.CheckAnswer(_currentPractiseQuestion, double.Parse(UserAnswer)))
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
            MessageBox.Show(ResultMessage);
        }
        private bool CanExecuteCheckAnswerCommand(object obj)
        {
            bool validData = false;
            double result;
            if(UserAnswer != null && UserAnswer != "" && double.TryParse(UserAnswer, out result))
                validData = true;
            return validData;
        }
        public PractiseViewModel()
        {
            _practiseService = ServiceLocator.ServiceProvider.GetService<IPractiseService>();
            CheckAnswerCommand = new ViewModelCommand(ExecuteCheckAnswerCommand, CanExecuteCheckAnswerCommand);     
            GenerateNewProblem();
        }

        public string CurrentPractiseQuestion => _currentPractiseQuestion.Question;

        private void GenerateNewProblem()
        {
            _currentPractiseQuestion = _practiseService.GenerateQuestion();
            UserAnswer = null;
            OnPropertyChanged(nameof(CurrentPractiseQuestion));
        }
    }
}
