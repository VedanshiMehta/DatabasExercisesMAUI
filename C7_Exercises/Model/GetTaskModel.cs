using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises.Model
{
    public class GetTaskModel
    {
        public ObservableCollection<TaskTabel> TaskList { get; set; }
        public bool IsVisibleCollectionView { get; set; }
        public bool IsLoading { get; set; }

        public string Message { get; set; }
        public bool IsValid { get; set; }
        public TaskTabel TaskTabel { get; set; }

        public async Task GetTaskList()
        {
            IsVisibleCollectionView = false;
            var taskDetail = await UserDatabase.GetTaskDetail();
            if (taskDetail != null)
            {
                TaskList = new ObservableCollection<TaskTabel>(taskDetail);
                IsLoading = false;
                IsVisibleCollectionView = true;
            }

        }
        public async Task DeleteTaskAsync()
        {
            var deleteTask = await UserDatabase.DeleteData<TaskTabel>(TaskTabel);
            if (deleteTask)
            {
                Message = "Deleted Data Successfully";
                IsValid = true;
                TaskList.Remove(TaskTabel);
            }
            else
            {
                Message = "Something went wrong";
                IsValid = false;
            }
        }
    }
}
