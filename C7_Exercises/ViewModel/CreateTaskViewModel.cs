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
    public partial  class CreateTaskViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _taskName;
        [ObservableProperty]
        private string _taskDescription;
        [ObservableProperty]
        private DateTime _completionDate;
        [ObservableProperty]
        private TimeSpan _startTime;
        [ObservableProperty]
        private TimeSpan _endTime;
        [ObservableProperty]
        private string _message;
        [ObservableProperty]
        private bool _isValid;
        private CreateTaskModel _createTaskModel;

        public event EventHandler<ResultEventArgs> AddTaskResult;
        public CreateTaskViewModel()
        {
           _createTaskModel = new CreateTaskModel();
        }
        [RelayCommand]
        public async void CreateNewTask()
        {
            _createTaskModel.TaskName = TaskName;
            _createTaskModel.TaskDescription = TaskDescription;
            _createTaskModel.CompletionDate = CompletionDate;
            _createTaskModel.StartTime=StartTime;
            _createTaskModel.EndTime=EndTime;
            await _createTaskModel.InsertCreatedTask();
            IsValid = _createTaskModel.IsValid;
            Message = _createTaskModel.Message;
            AddTaskResult?.Invoke(this,new ResultEventArgs() { IsValid = IsValid,Message = Message});
        }
    }
}
