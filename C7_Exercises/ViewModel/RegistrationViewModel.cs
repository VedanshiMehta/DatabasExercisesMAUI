using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises.ViewModel
{
    public partial  class RegistrationViewModel : ObservableObject
    {
       
        

        [ObservableProperty]
        private string _userName;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private string _confimPassword;
        [ObservableProperty]
        private bool _isValid;
        [ObservableProperty]
        private string _message;
        private RegistrationModel _registrationModel;

        public event EventHandler<ResultEventArgs> Result;
        public RegistrationViewModel()
        {
            _registrationModel = new RegistrationModel();
        }

        [RelayCommand]
        public async void InsertData()
        {
            try
            {
                _registrationModel.UserName = UserName;
                _registrationModel.Password = Password;
                _registrationModel.ConfirmPassword = ConfimPassword;
                await _registrationModel.InsertDataAsync();
                IsValid = _registrationModel.IsValid;
                Message = _registrationModel.Message;
                Result?.Invoke(this, new ResultEventArgs() { IsValid = IsValid, Message = Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

       
    }

    public class ResultEventArgs : EventArgs
    {
        
        public string Message { get; set; }
        public bool IsValid { get; set; }
    }
}
