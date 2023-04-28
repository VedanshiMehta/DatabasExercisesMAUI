using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises.Model
{
    public  class UpdateTaskModel
    {
        private string _message;
        private TaskTabel _taskTabel;
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }

        public int Id { get; set; }
        public DateTime CompletionDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        public string Message { get; set; }

        public bool IsValid { get; set; }

        public UpdateTaskModel()
        {
            _taskTabel = new TaskTabel();
        }
        public async Task UpdateCreatedTask()
        {
            if (IsValidTaskName() && IsValidTaskDescription())
            {
                IsValid = true;
                Message = string.Empty;
                _taskTabel.Id = Id;   
                _taskTabel.Title = TaskName;
                _taskTabel.Description = TaskDescription;
                _taskTabel.CompletionDate = CompletionDate;
                _taskTabel.StartTime = StartTime;
                _taskTabel.EndTime = EndTime;
                _taskTabel.CompletedDate = CompletionDate.ToString("dd/MM/yyyy");
                DateTime startTime = DateTime.Today.Add(StartTime);
                DateTime endTime = DateTime.Today.Add(EndTime);
                _taskTabel.CompletionTime = startTime.ToString("hh:mm tt") + " - " + endTime.ToString("hh:mm tt");
                var createdTask = await UserDatabase.UpdateData<TaskTabel>(_taskTabel);
                if (createdTask)
                {
                    IsValid = true;
                    Message = "Task Updated Successfully";
                }
                else
                {
                    IsValid = false;
                    Message = "Something went wrong";
                }

            }
            else if (!IsValidTaskName() || !IsValidTaskDescription())
            {
                IsValid = false;
                Message = _message;
            }

        }

        private bool IsValidTaskDescription()
        {
            if (string.IsNullOrEmpty(TaskDescription))
            {
                _message = "Enter Task Description";
                return false;
            }
            _message = string.Empty;
            return true;

        }

        private bool IsValidTaskName()
        {
            if (string.IsNullOrEmpty(TaskName))
            {
                _message = "Enter Task Name";
                return false;
            }
            _message = string.Empty;
            return true;
        }
    }
}
