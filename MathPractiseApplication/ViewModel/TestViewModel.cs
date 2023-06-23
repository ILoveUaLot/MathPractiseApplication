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

        public List<TestModel> Questions
        {
            get => questions; 
            set
            {
                questions = value;
                OnPropertyChanged(nameof(Questions));
            }
        }

        public TestModel CurrentQuestion
        {
            get => _currentQuestion; 
            set
            {
                _currentQuestion = value;
                OnPropertyChanged(nameof(CurrentQuestion));
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

        public TestViewModel()
        {
            _questionsRepository = new TestQuestionExcelRepository();
            LoadQuestions();
            CurrentQuestionIndex = 0;
            if(questions.Count > 0)
            {
                CurrentQuestion = questions[CurrentQuestionIndex];
            }
        }

        private void LoadQuestions()
        {
            Questions = _questionsRepository.GetQuestions();
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
            if (CurrentQuestionIndex > 0)
            {
                return true;
            }
            return false;
        }
        private void ExecuteGetNextQuestionCommand(object obj)
        {
            CurrentQuestionIndex++;
            CurrentQuestion = questions[CurrentQuestionIndex];
        }

        private bool CanExecuteNextQuestionCommand(object obj)
        {
            if(CurrentQuestionIndex < questions.Count - 1)
            {
                return true;
            }
            return false;
        }
    }
}
