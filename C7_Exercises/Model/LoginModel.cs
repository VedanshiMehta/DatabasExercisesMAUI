using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises.Model
{
    public class LoginModel
    {
        private ValidatorClass _validator;

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public bool IsValid { get; set; }

        public LoginModel()
        {

            _validator = new ValidatorClass();

        }



        public async void PerformActionAsync()
        {

            _validator.ValidateLoginClass(this);
            if (_validator.IsValid)
            {
               // IsValid = _validator.IsValid;

                //IsEnabled = _validator.IsEnabled;
                var result = await UserDatabase.GetUserRegisteredDetail();
                var userData = result.Where(x => x.UserName == UserName).ToList().FirstOrDefault();
                if (userData != null)
                {
                    if (userData.Password == Password && userData.UserName == UserName)
                    {
                        IsValid = true;
                        Message = "Login Successfull";
                        CurrentAppData.IsUserLoggedIn = true;
                    }
                    else
                    {
                        IsValid = false;
                        Message = "Username or Password incorrect";
                    }
                }
                else
                {
                    IsValid = false;
                    Message = "User Not found";
                }
               
               


            }
            else
            {
                IsValid = _validator.IsValid;
                Message = _validator.Message;
            }

        }
    }
}
