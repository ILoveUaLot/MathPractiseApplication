using MathPractiseApplication.Models;
using MathPractiseApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MathPractiseApplication.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private User _userAccount;
        private IUserRepository _userRepository;

        private List<User> _allUserAccs;
        private string _testStat;
        private string _practiseStat;
        public string TestStat
        {
            get => _testStat;
            set
            {
                _testStat = value;
                OnPropertyChanged(nameof(TestStat));
            }
        }

        

        public string PractiseStat
        {
            get => _practiseStat;
            set
            {
                _practiseStat = value;
                OnPropertyChanged(nameof(PractiseStat));
            }
        }
        public List<User> AllUserAccs
        {
            get => _allUserAccs; 
            set
            {
                _allUserAccs = value;
                OnPropertyChanged(nameof(AllUserAccs));
            }
        }
        public HomeViewModel()
        {
            _userRepository = new UserExcelRepository();
            LoadUserData();
            TestStat = UserAcc.TestResults;
            PractiseStat = UserAcc.CompletedExercises.ToString();
            AllUserAccs = _userRepository.GetAllUsers();
        }

        public User UserAcc
        {
            get => _userAccount;
            set
            {
                _userAccount = value;
                OnPropertyChanged(nameof(UserAcc));
            }
        }

        private void LoadUserData()
        {
            UserAcc = _userRepository.UserGetByName(Thread.CurrentPrincipal.Identity.Name);
        }
    }
}
