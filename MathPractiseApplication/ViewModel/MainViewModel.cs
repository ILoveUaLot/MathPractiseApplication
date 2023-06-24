using GalaSoft.MvvmLight.Messaging;
using MathPractiseApplication.Messages;
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
        private WindowState _windowState;
        private bool _testingViewVisibility;
        private bool _currentChildViewIsHome;

        public bool CurrentChildViewIsHome
        {
            get => _currentChildViewIsHome;
            set
            {
                _currentChildViewIsHome = value;
                OnPropertyChanged(nameof(CurrentChildViewIsHome));
            }
        }
        public bool TestingViewVisibility
        {
            get => _testingViewVisibility;
            set
            {
                _testingViewVisibility = value;
                OnPropertyChanged(nameof(TestingViewVisibility));
            }
        }
        public WindowState MainWindowState
        {
            get => _windowState; 
            set
            {
                _windowState = value;
                OnPropertyChanged(nameof(MainWindowState));
            }
        }
        public UserControl CurrentChildView
        {
            get => _currentChildView; 
            set
            {
                _currentChildView = value;
                if (value is TestView)
                {
                    TestingViewVisibility = true;
                    MainWindowState = WindowState.Maximized;
                }
                CurrentChildViewIsHome = value is HomeView;
                OnPropertyChanged(nameof(CurrentChildView));
                OnPropertyChanged(nameof(CurrentChildViewIsHome));
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
            MainWindowState = WindowState.Normal;

            Messenger.Default.Register<VisibilityChangedMessage>(this, msg =>
            {
                TestingViewVisibility = msg.IsVisible;
                if (!TestingViewVisibility)
                    ExecuteShowHomeViewCommand(null);
            });

            
            ShowTheoryViewCommand = new ViewModelCommand(ExecuteShowTheoryViewCommand);
            ShowPractiseViewCommand = new ViewModelCommand(ExecuteShowPractiseViewCommand);
            ShowTestViewCommand = new ViewModelCommand(ExecuteShowTestViewCommand);
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);

            _userRepository = new UserExcelRepository();
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
