using MathPractiseApplication.Models;
using MathPractiseApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MathPractiseApplication.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _repeatedPassword;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
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

        private void ExecuteRegistrationCommand(object obj)
        {
            User newUser = new User(Username, Password);

            bool isAlreadyCreatedUser = userRepository.
                AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            if (!isAlreadyCreatedUser)
            {
                userRepository.Add(newUser);
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                MessageBox.Show("Пользователь с данным username уже был создан");
            }
            Username = "";
            Password = "";
            RepeatedPassword = "";
        }
        private bool CanExecuteRegistrationCommand(object parameter)
        {
            bool validData = true;
            if (string.IsNullOrWhiteSpace(Username) ||
                Username.Length > 10 || Username.Length < 2
                || Password == null || Password.Length < 5
                ||RepeatedPassword==null ||RepeatedPassword != Password)
                validData = false;
            return validData;
        }
        public RegisterViewModel()
        {
            RegistrationCommand = new ViewModelCommand(ExecuteRegistrationCommand, 
                                                        CanExecuteRegistrationCommand);
            userRepository = new UserExcelRepository();
        }
    }
}
