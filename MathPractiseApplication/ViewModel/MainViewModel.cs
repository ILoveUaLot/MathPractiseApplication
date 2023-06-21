using MathPractiseApplication.Models;
using MathPractiseApplication.Repositories;
using MathPractiseApplication.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MathPractiseApplication.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IUserRepository _userRepository;
        private User _userAccount;
        private UserAccountModel _userAccountModel;
        private UserControl _currentChildView;
        public UserControl CurrentChildView
        {
            get => _currentChildView; 
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public UserAccountModel UserAccountModel
        {
            get => _userAccountModel; 
            set
            {
                _userAccountModel = value;
                OnPropertyChanged(nameof(UserAccountModel));
            }
        }
        public User UserAccount
        {
            get => _userAccount; 
            set
            {
                _userAccount = value;
                OnPropertyChanged(nameof(UserAccount));
            }
        }

        public MainViewModel()
        {
            _userRepository = new UserExcelRepository();
            ShowTheoryViewCommand = new ViewModelCommand(ExecuteShowTheoryViewCommand);
            ShowPractiseViewCommand = new ViewModelCommand(ExecuteShowPractiseViewCommand);
            ShowTestViewCommand = new ViewModelCommand(ExecuteShowTestViewCommand);
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            LoadCurrentUser();
        }

        public ICommand ShowTheoryViewCommand { get; }
        public ICommand ShowPractiseViewCommand { get; }
        public ICommand ShowTestViewCommand { get; }
        
        public ICommand ShowHomeViewCommand { get; }
        public void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeView();
        }
        public void ExecuteShowTheoryViewCommand(object obj)
        {
            CurrentChildView = new ChooseTheoryView();
        }
        private void ExecuteShowTestViewCommand(object obj)
        {
            CurrentChildView = new TestView();
        }

        private void ExecuteShowPractiseViewCommand(object obj)
        {
            CurrentChildView= new PractiseView();
        }

        private void LoadCurrentUser()
        {
            var user = _userRepository.UserGetByName(Thread.CurrentPrincipal.Identity.Name);
            UserAccountModel = new UserAccountModel();
            if (user != null)
            {
                UserAccount = user;
                UserAccountModel.UserName = user.Name;
                UserAccountModel.ProfilePicture = null;
            }
            else
            {
                MessageBox.Show("Unregistered user", "Error");
                Application.Current.Shutdown();
            }
        }

        
    }
}
