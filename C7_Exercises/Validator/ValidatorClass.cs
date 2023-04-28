using C7_Exercises.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C7_Exercises
{
    public class ValidatorClass 
    {

        private string _message;
        private Regex _userName = new Regex(@"^(?!.*\S[MG]O\b)[a-zA-Z0-9]+(?: [a-zA-Z0-9]+)*$");
        public string Message { get; set; }
        public bool IsValid { get; set; }
        //public bool IsEnabled { get; set; }

        public void ValidateRegisterClass(RegistrationModel model)
        {
            if (IsValidUserName(model.UserName) && IsValidPassword(model.Password) && IsValidConfirmPassword(model.ConfirmPassword,model.Password))
            {
                IsValid = true;
                //IsEnabled = true;
            }
            else if (!IsValidUserName(model.UserName) || !IsValidPassword(model.Password) || !IsValidConfirmPassword(model.ConfirmPassword,model.Password))
            {
                IsValid = false;
                Message = _message;
                //IsEnabled=false;
            }

        }
        public void ValidateLoginClass(LoginModel model)
        {
            if (IsValidUserName(model.UserName) && IsValidPassword(model.Password))
            {
                IsValid = true;
                //IsEnabled = true;
            }
            else if (!IsValidUserName(model.UserName) || !IsValidPassword(model.Password))
            {
                IsValid = false;
                Message = _message;
                //IsEnabled=false;
            }

        }

        private bool IsValidConfirmPassword(string confirmPassword, string password)
        {
            if (string.IsNullOrEmpty(confirmPassword))
            {
                _message = "Enter Confirm Password";
                return false;
            }
            else if(!confirmPassword.Equals(password))
            {
                _message = "Confirm Password doesn't matches with password";
                return false;
            }
            _message = string.Empty;
            return true;
        }

        private bool IsValidPassword(string password)
        {
            if(string.IsNullOrEmpty(password))
            {
                _message = "Enter Password";
                return false;
            }
            else if(password.Length <= 8)
            {
                _message = "Password must contains atleast 8 characters";
                return false;
            }
            _message = string.Empty; 
            return true;
        }

        private bool IsValidUserName(string userName)
        {
            if(string.IsNullOrEmpty(userName))
            {
                _message = "Enter Username";
                return false;
            }
            else if(!IsMatchUserName(userName)) 
            {
                _message = "Enter Valid Username";
                return false;
            }
            _message = string.Empty;
            return true;
           
        }

        private bool IsMatchUserName(string userName)
        {
            if(string.IsNullOrEmpty(userName))
                return false;
            return _userName.IsMatch(userName);
        }
    }
}
