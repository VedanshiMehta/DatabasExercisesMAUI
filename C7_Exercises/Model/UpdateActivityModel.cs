using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises.Model
{
    public class UpdateActivityModel
    {
        private ActivityTabel _activityTabel;
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public string Message { get; set; }

        public bool IsValid { get; set; }
        public UpdateActivityModel()
        {
            _activityTabel = new ActivityTabel();
        }
        public async Task UpdateActivities()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                _activityTabel.Id= Id;
                _activityTabel.Title = Title;
                _activityTabel.DueDate = DueDate;
                _activityTabel.IsCompleted = IsCompleted;
                var inserted = await UserDatabase.UpdateData<ActivityTabel>(_activityTabel);
                if (inserted)
                {
                    IsValid = true;
                    Message = "Update Added Successfully";
                }
                else
                {
                    IsValid = false;
                    Message = "Activity not updated";
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
