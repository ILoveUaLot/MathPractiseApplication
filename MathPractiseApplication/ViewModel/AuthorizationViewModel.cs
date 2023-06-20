using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MathPractiseApplication.ViewModel
{
    public class AuthorizationViewModel : ViewModelBase
    {
        private ViewModelBase _childView;

        public ViewModelBase CurentChildView 
        { 
            get => _childView;
            set
            {
                _childView = value;
                OnPropertyChanged(nameof(CurentChildView));
            }
        }

        public ICommand ShowLoginViewCommand { get; }
        public ICommand ShowRegisterViewCommand { get; }

        public AuthorizationViewModel()
        {
            ShowLoginViewCommand = new ViewModelCommand(ExecuteShowLoginViewCommand);
            ShowRegisterViewCommand = new ViewModelCommand(ExecuteShowRegisterViewCommand);

            //Set default view
            ExecuteShowLoginViewCommand(null);
        }

        private void ExecuteShowRegisterViewCommand(object obj)
        {
            CurentChildView = new RegisterViewModel();
        }

        private void ExecuteShowLoginViewCommand(object obj)
        {
            CurentChildView = new LoginVM();
        }
    }
}
