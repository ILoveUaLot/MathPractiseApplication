using MathPractiseApplication.Models;
using MathPractiseApplication.Repositories;
using MathPractiseApplication.View;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MathPractiseApplication.ViewModel
{
    class LoginVM : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true;


        private IUserRepository userRepository;

        public LoginVM()
        {
            userRepository = new UserExcelRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

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
            get { return _username; }
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

        public string ErrorMessage
        {
            get => _errorMessage; 
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ShowPassword { get; } //TODO: show password
        

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData = true;
            if (string.IsNullOrWhiteSpace(Username) ||
                Username.Length>10||Username.Length<2 
                || Password == null || Password.Length < 5)
                validData = false;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            if (isValidUser)
            {
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }
        }
    }
}
