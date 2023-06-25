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
        private bool _currentChildViewIsPractise;
        private bool _currentChildViewIsTest;
        private bool _currentChildViewIsTheory;
        private string _previousState;

        private bool _isConfirmationPopupOpen;
        public bool IsConfirmationPopupOpen
        {
            get => _isConfirmationPopupOpen;
            set
            {                
                _isConfirmationPopupOpen = value;
                OnPropertyChanged(nameof(IsConfirmationPopupOpen));
            }
        }
        public bool CurrentChildViewIsHome
        {
            get => _currentChildViewIsHome;
            set
            {
                _currentChildViewIsHome = value;
                _previousState = "Home";
                OnPropertyChanged(nameof(CurrentChildViewIsHome));
            }
        }
        public bool CurrentChildViewIsPractise
        {
            get => _currentChildViewIsPractise;
            set
            {
                _currentChildViewIsPractise = value;
                _previousState = "Practise";
                OnPropertyChanged(nameof(CurrentChildViewIsPractise));
            }
        }
        public bool CurrentChildViewIsTest
        {
            get => _currentChildViewIsTest;
            set
            {
                _currentChildViewIsTest = value;
                _previousState = "Test";               
                OnPropertyChanged(nameof(CurrentChildViewIsTest));
            }
        }
        public bool CurrentChildViewIsTheory
        {
            get => _currentChildViewIsTheory;
            set
            {
                _currentChildViewIsTheory = value;
                _previousState = "Theory";
                OnPropertyChanged(nameof(CurrentChildViewIsTheory));
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
            AcceptCommand = new ViewModelCommand(ExecuteAcceptCommand);
            DeclineCommand = new ViewModelCommand(ExecuteDeclineCommand);

            _userRepository = new UserExcelRepository();
            LoadCurrentUser();
            ExecuteShowHomeViewCommand(null);
        }

        public ICommand ShowTheoryViewCommand { get; }
        public ICommand ShowPractiseViewCommand { get; }
        public ICommand ShowTestViewCommand { get; }
        
        public ICommand ShowHomeViewCommand { get; }
        

        public void ExecuteShowHomeViewCommand(object obj)
        {
            UpdateViewStates(true, false, false, false);
            CurrentChildView = new HomeView();
        }
        public void ExecuteShowTheoryViewCommand(object obj)
        {
            UpdateViewStates(false, false, false, true);
            CurrentChildView = new ChooseTheoryView();
        }

        public ICommand AcceptCommand { get; }
        public ICommand DeclineCommand { get; }

        private void ExecuteAcceptCommand(object obj)
        {
            IsConfirmationPopupOpen = false;
            UpdateViewStates(false, false, true, false);
            MainWindowState = WindowState.Maximized;
            TestingViewVisibility = true;
            CurrentChildView = new TestView();
        }

        private void ExecuteDeclineCommand(object obj)
        {
            switch (_previousState)
            {
                case ("Home"):
                    CurrentChildViewIsHome = true;
                    break;
                case ("Theory"):
                    CurrentChildViewIsTheory = true;
                    break;
                case ("Practise"):
                    CurrentChildViewIsPractise = true;
                    break;
            }
            IsConfirmationPopupOpen = false;
        }
        private void ExecuteShowTestViewCommand(object obj)
        {
            IsConfirmationPopupOpen = true;
        }

        private void ExecuteShowPractiseViewCommand(object obj)
        {
            UpdateViewStates(false, true, false, false);
            CurrentChildView = new PractiseView();
        }
        private void UpdateViewStates(bool home, bool practise, bool test, bool theory)
        {
            CurrentChildViewIsHome = home;
            CurrentChildViewIsPractise = practise;
            CurrentChildViewIsTest = test;
            CurrentChildViewIsTheory = theory;
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
