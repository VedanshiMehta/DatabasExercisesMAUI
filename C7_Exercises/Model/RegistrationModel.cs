
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises
{
    public class RegistrationModel
    {

        private ValidatorClass _validator;

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        private UserDetailTabel _userDetailTabel;
        public string Message { get; set; }
        public bool IsValid { get; set; }

        public RegistrationModel()
        {

            _validator = new ValidatorClass();
            _userDetailTabel = new UserDetailTabel();

        }



        public async Task InsertDataAsync()
        {

            _validator.ValidateRegisterClass(this);
            if (_validator.IsValid)
            {
                IsValid = _validator.IsValid;

                //IsEnabled = _validator.IsEnabled;
                var result = await UserDatabase.GetUserRegisteredDetail();
                var userData = result.Where(x => x.UserName == UserName).ToList().FirstOrDefault();
                if (userData != null)
                {
                    if (UserName.Equals(userData.UserName))
                    {
                        IsValid = false;
                        Message = "User already registered";
                    }
                }
                else
                {
                    _userDetailTabel.UserName = UserName;
                    _userDetailTabel.Password = Password;
                    var insertedData = await UserDatabase.InsertData<UserDetailTabel>(_userDetailTabel);
                    if (insertedData)
                    {
                        Message = "Data Inserted Successfully";
                    }
                    else
                    {
                        Message = "Data Insertion failed";
                    }
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
