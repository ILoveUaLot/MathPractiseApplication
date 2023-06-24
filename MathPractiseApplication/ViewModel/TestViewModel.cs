using GalaSoft.MvvmLight.Messaging;
using MathPractiseApplication.Messages;
using MathPractiseApplication.Models;
using MathPractiseApplication.Repositories;
using MathPractiseApplication.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MathPractiseApplication.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        private List<TestModel> questions;
        private ITestQuestionsRepository _questionsRepository;
        private IUserRepository _userRepository;
        private TestModel _currentQuestion;
        private int _currentQuestionIndex;
        private int _correctAnswers = 0;
        private int _selectedAnswer;
        private Dictionary<TestModel, int> _userAnswers;

        public string AnsweredQuestionInfo => $"{CurrentQuestionIndex+1}/{questions.Count}";
        public bool IsLastQuestion
        {
            get => _currentQuestionIndex == questions.Count - 1;
        }


        private bool _testViewVisibility;
        public bool TestViewVisibility
        {
            get => _testViewVisibility;
            set
            {
                _testViewVisibility = value;
                OnPropertyChanged(nameof(TestViewVisibility));
            }
        }
        private bool _isRadioButton0Checked;
        public bool IsRadioButton0Checked
        {
            get => _isRadioButton0Checked;
            set
            {
                SetProperty(ref _isRadioButton0Checked, value);
                if (value) SelectedAnswer = 0;
            }
        }

        private bool _isRadioButton1Checked;
        public bool IsRadioButton1Checked
        {
            get => _isRadioButton1Checked;
            set
            {
                SetProperty(ref _isRadioButton1Checked, value);
                if (value) SelectedAnswer = 1;
            }
        }

        private bool _isRadioButton2Checked;
        public bool IsRadioButton2Checked
        {
            get => _isRadioButton2Checked;
            set
            {
                SetProperty(ref _isRadioButton2Checked, value);
                if (value) SelectedAnswer = 2;
            }
        }

        private bool _isRadioButton3Checked;
        public bool IsRadioButton3Checked
        {
            get => _isRadioButton3Checked;
            set
            {
                SetProperty(ref _isRadioButton3Checked, value);
                if (value) SelectedAnswer = 3;
            }
        }


        public List<TestModel> Questions
        {
            get => questions;
            set
            {
                questions = value;
                OnPropertyChanged(nameof(Questions));
            }
        }
        public int CurrentQuestionIndex
        {
            get => _currentQuestionIndex;
            set
            {
                _currentQuestionIndex = value;
                OnPropertyChanged(nameof(CurrentQuestionIndex));
                OnPropertyChanged(nameof(AnsweredQuestionInfo));
                OnPropertyChanged(nameof(IsLastQuestion));
            }
        }
        public int SelectedAnswer
        {
            get => _selectedAnswer;
            set
            {
                if (_currentQuestion != null && SetProperty(ref _selectedAnswer, value))
                {
                    _userAnswers[_currentQuestion] = value;
                }
            }
        }
        public TestModel CurrentQuestion
        {
            get => _currentQuestion;
            set
            {
                _currentQuestion = value;
                if (_userAnswers.ContainsKey(value))
                {
                    SelectedAnswer = _userAnswers[value];
                }
                else
                {
                    _userAnswers.Add(value, -1);
                    SetProperty(ref _selectedAnswer, -1);
                }

                // Set the radio button that corresponds to the selected answer, if any.
                if (_userAnswers.ContainsKey(value) && _userAnswers[value] >= 0)
                {
                    switch (_userAnswers[value])
                    {
                        case 0:
                            IsRadioButton0Checked = true;
                            break;
                        case 1:
                            IsRadioButton1Checked = true;
                            break;
                        case 2:
                            IsRadioButton2Checked = true;
                            break;
                        case 3:
                            IsRadioButton3Checked = true;
                            break;
                    }
                }
                else
                {
                    IsRadioButton0Checked = false;
                    IsRadioButton1Checked = false;
                    IsRadioButton2Checked = false;
                    IsRadioButton3Checked = false;
                }

                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }

        public TestViewModel()
        {
            var _messenger = ServiceLocator.ServiceProvider.GetService<IMessenger>();
            _messenger.Register<VisibilityChangedMessage>(this, OnVisibilityChanged);

            TestViewVisibility = true;
            _userAnswers = new Dictionary<TestModel, int>();

            GetNextQuestion = new ViewModelCommand(ExecuteGetNextQuestionCommand, CanExecuteNextQuestionCommand);
            GetPreviousQuestion = new ViewModelCommand(ExecuteGetPreviousQuestion, CanExecuteGetPreviousQuestion);
            PassTest = new ViewModelCommand(ExecutePassTest, CanExecutePassTest);

            _questionsRepository = new TestQuestionExcelRepository();
            _userRepository = new UserExcelRepository();
            LoadQuestions();
        }

        private void OnVisibilityChanged(VisibilityChangedMessage message)
        {
            TestViewVisibility = message.IsVisible;
        }
        private void LoadQuestions()
        {
            var allQuestions = _questionsRepository.GetQuestions();
            if (allQuestions.Count > 0)
            {
                var rnd = new Random();
                Questions = allQuestions.OrderBy(x => rnd.Next()).Take(20).ToList();
                CurrentQuestion = Questions[0];
                _currentQuestionIndex = 0;
            }
            else
            {
                throw new InvalidOperationException("Not enough questions in the repository");
            }
        }

        public ICommand GetNextQuestion { get; }

        public ICommand GetPreviousQuestion { get; }

        public ICommand PassTest { get; }
        private void ExecutePassTest(object obj)
        {
            CalculateCorrectAnswers();
        }
        private bool CanExecutePassTest(object obj)
        {
            return IsLastQuestion;
        }

        private void ExecuteGetPreviousQuestion(object obj)
        {
            CurrentQuestionIndex--;
            CurrentQuestion = questions[CurrentQuestionIndex];
        }

        private bool CanExecuteGetPreviousQuestion(object obj)
        {
            return CurrentQuestionIndex > 0;
        }

        private void ExecuteGetNextQuestionCommand(object obj)
        {
            CurrentQuestionIndex++;
            CurrentQuestion = questions[CurrentQuestionIndex];
        }

        private bool CanExecuteNextQuestionCommand(object obj)
        {
            return CurrentQuestionIndex < questions.Count - 1;
        }

        public int CalculateCorrectAnswers()
        {
            _correctAnswers = _userAnswers.Count(kvp => kvp.Key.IndexOfRightAnswer == kvp.Value);
            
            Messenger.Default.Send(new VisibilityChangedMessage(false));
            _userRepository.Edit(_userRepository.UserGetByName(Thread.CurrentPrincipal.Identity.Name));
            return _correctAnswers;
        }
    }
}
