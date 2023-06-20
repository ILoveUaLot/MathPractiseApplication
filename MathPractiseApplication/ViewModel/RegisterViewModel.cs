using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MathPractiseApplication.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _repeatedPassword;

        public string Username
        {
            get => _username; 
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get => _password; 
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string RepeatedPassword
        {
            get => _repeatedPassword; 
            set
            {
                _repeatedPassword = value;
                OnPropertyChanged(nameof(RepeatedPassword));
            }
        }

        public ICommand RegistrationCommand { get; }

        private bool CanExecuteRegistrationCommand(object parameter)
        {
            bool validData = true;
            if (string.IsNullOrWhiteSpace(Username) || Password == null || Password.Length < 3
                ||RepeatedPassword==null ||RepeatedPassword != Password)
                validData = false;
            return validData;
        }
    }
}
