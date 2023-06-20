using MathPractiseApplication.Models;
using MathPractiseApplication.Repositories;
using MathPractiseApplication.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MathPractiseApplication.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private User _userAccount;
        private IUserRepository _userRepository;
        private ViewModelBase _childView;

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
            //LoadCurrentUser();
        }

        public ICommand ShowTheoryViewCommand { get; }
        public ICommand ShowPractiseViewCommand { get; }
        public ICommand ShowTestViewCommand { get; }
        public void ExecuteShowTheoryViewCommand(object obj)
        {
            
        }
        private void ExecuteShowTestViewCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteShowPractiseViewCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void LoadCurrentUser()
        {
            //var user = _userRepository.UserGetByName();
        }

        
    }
}
