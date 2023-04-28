using C7_Exercises.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C7_Exercises.ViewModel
{
    public partial class GetTasksViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TaskTabel> _taskList;

        [ObservableProperty]
        private string _message;

        [ObservableProperty]
        private bool _isValid;

        [ObservableProperty]
        private bool _isVisibleCollectionView;

        [ObservableProperty]
        private bool _isLoading;

        private GetTaskModel _getTaskModel;
        public event EventHandler<ResultEventArgs> DeleteResult;
        public event EventHandler<TaskTabel> UpdateTaskTabelSelected;

        public GetTasksViewModel()
        {
            
            _getTaskModel = new GetTaskModel();
            GetTaskLists();
        }

        [RelayCommand]
        public async Task DeleteTask(TaskTabel task)
        {
            _getTaskModel.TaskTabel = task;
            await _getTaskModel.DeleteTaskAsync();
            TaskList = _getTaskModel.TaskList;
            Message = _getTaskModel.Message;
            IsValid = _getTaskModel.IsValid;
            DeleteResult?.Invoke(this, new ResultEventArgs() { IsValid = IsValid, Message = Message });
        }

        [RelayCommand]
        public void  UpdateTask(TaskTabel task)
        {
           UpdateTaskTabelSelected?.Invoke(this, task);           
        }
        public async void GetTaskLists()
        {
            _getTaskModel.IsLoading = true;
            await _getTaskModel.GetTaskList();
            TaskList = _getTaskModel.TaskList;
            IsLoading = _getTaskModel.IsLoading;
            IsVisibleCollectionView = _getTaskModel.IsVisibleCollectionView;
        }
    }
}
