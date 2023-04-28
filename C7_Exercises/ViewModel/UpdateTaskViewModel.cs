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
    public partial class UpdateTaskViewModel : ObservableObject
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
        [ObservableProperty]
        private int _id;
        private UpdateTaskModel _model;


        public event EventHandler<ResultEventArgs> UpdateTaskResult;
        public UpdateTaskViewModel()
        {
            _model = new UpdateTaskModel();
        }
        [RelayCommand]
        private async void UpdateTask()
        {
            try
            {
                _model.Id = Id;
                _model.TaskName = TaskName;
                _model.TaskDescription = TaskDescription;
                _model.CompletionDate = CompletionDate;
                _model.StartTime = StartTime;
                _model.EndTime = EndTime;
                await _model.UpdateCreatedTask();
                IsValid = _model.IsValid;
                Message = _model.Message;
                UpdateTaskResult?.Invoke(this, new ResultEventArgs() { IsValid = IsValid, Message = Message });

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
