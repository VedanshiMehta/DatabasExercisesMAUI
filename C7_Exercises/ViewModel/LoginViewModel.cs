using C7_Exercises.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private bool _isValid;
        [ObservableProperty]
        private string _message;
        private LoginModel _loginModel;

        public event EventHandler<ResultEventArgs> LoginResult;
        public LoginViewModel()
        {
            _loginModel = new LoginModel();
        }

        [RelayCommand]
        public  void Login()
        {
            try
            {
                _loginModel.UserName = UserName;
                _loginModel.Password = Password;
                _loginModel.PerformActionAsync();
                IsValid = _loginModel.IsValid;
                Message = _loginModel.Message;
                LoginResult?.Invoke(this, new ResultEventArgs() { IsValid = IsValid, Message = Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }

    
}

