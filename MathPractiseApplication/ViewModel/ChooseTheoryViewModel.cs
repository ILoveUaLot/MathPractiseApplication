using MathPractiseApplication.View.Theory;
using MathPractiseApplication.View.Theory.FunctionPropertiesTheory;
using MathPractiseApplication.View.Theory.LinearEquationTheory;
using MathPractiseApplication.View.Theory.SystemOfEquationTheory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MathPractiseApplication.ViewModel
{
    public class ChooseTheoryViewModel : ViewModelBase
    {
        private Page _currentViewTheory;
        public Page CurrentViewTheory
        {
            get => _currentViewTheory; 
            set
            {
                _currentViewTheory = value;
                OnPropertyChanged(nameof(CurrentViewTheory));
            }
        }

        public ICommand ShowLinearEquationTheoryPageCommand { get; }
        public ICommand ShowFunctionPropertiesTheoryPageCommand { get; }
        public ICommand ShowSystemEquationTheoryPageCommand { get; }

        public void ExecuteShowLinearEquationTheoryPageCommand(object obj)
        {
            CurrentViewTheory = new LinearEquationTheoryPage1();
        }
        public void ExecuteShowFunctionPropertiesTheoryPageCommand(object obj)
        {
            CurrentViewTheory = new FunctionPropertiesTheoryPage1();
        }
        public void ExecuteShowSystemEquationTheoryPageCommand(object obj)
        {
            CurrentViewTheory = new SystemOfEquationTheoryPage1();
        }
        public ChooseTheoryViewModel()
        {
            ShowSystemEquationTheoryPageCommand = new ViewModelCommand(ExecuteShowSystemEquationTheoryPageCommand);
            ShowLinearEquationTheoryPageCommand = new ViewModelCommand(ExecuteShowLinearEquationTheoryPageCommand);
            ShowFunctionPropertiesTheoryPageCommand = new ViewModelCommand(ExecuteShowFunctionPropertiesTheoryPageCommand);
        }
    }
}
