using MathPractiseApplication.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MathPractiseApplication.ViewModel
{
    public class AuthorizationViewModel : ViewModelBase
    {
        private UserControl _childView;

        public UserControl CurentChildView 
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
            CurentChildView = new RegistrationView();
            
        }

        private void ExecuteShowLoginViewCommand(object obj)
        {
            CurentChildView = new LoginView();
//            (CurentChildView.DataContext as LoginVM).IsViewVisible = true;
        }
    }
}
