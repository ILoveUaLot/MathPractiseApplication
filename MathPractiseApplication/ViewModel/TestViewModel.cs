using MathPractiseApplication.Models;
using MathPractiseApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MathPractiseApplication.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        private List<TestModel> questions;
        private ITestQuestionsRepository _questionsRepository;
        private TestModel _currentQuestion;
        private int _currentQuestionIndex;
        private int _correctAnswers = 0;
        private int _selectedAnswer;
        private Dictionary<TestModel, int> _userAnswers;

        public string AnsweredQuestionInfo => $"{CurrentQuestionIndex}/{questions.Count}";
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
            }
        }
        public int SelectedAnswer
        {
            get => _selectedAnswer;
            set
            {
                _selectedAnswer = value;
                if (_currentQuestion != null)
                {
                    _userAnswers[_currentQuestion] = value;
                }
                OnPropertyChanged(nameof(SelectedAnswer));
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
                }
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }

        public TestViewModel()
        {
            _userAnswers = new Dictionary<TestModel, int>();
            GetNextQuestion = new ViewModelCommand(ExecuteGetNextQuestionCommand, CanExecuteNextQuestionCommand);
            GetPreviousQuestion = new ViewModelCommand(ExecuteGetPreviousQuestion, CanExecuteGetPreviousQuestion);
            _questionsRepository = new TestQuestionExcelRepository();
            LoadQuestions();
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
            return _correctAnswers;
        }
    }
}
