using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises.Model
{
    public class AddActivityModel
    {
        private ActivityTabel _activityTabel;
        
        public string Title { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public string Message { get; set; }

        public bool IsValid { get; set; }
        public AddActivityModel()
        {
            _activityTabel = new ActivityTabel();
        }
        public async Task InsertActivities()
        {
            if(!string.IsNullOrEmpty(Title))
            {

                _activityTabel.Title = Title;
                _activityTabel.DueDate = DueDate;
                _activityTabel.IsCompleted = IsCompleted;
                var inserted = await UserDatabase.InsertData<ActivityTabel>(_activityTabel);
                if(inserted)
                {
                    IsValid = true;
                    Message = "Activity Added Successfully";
                }
                else
                {
                    IsValid = false;
                    Message = "Adctivity not Added";
                }
            }
            else
            {
                Message = "Add Title";
                IsValid = false;
            }
        
        }
    }
}
