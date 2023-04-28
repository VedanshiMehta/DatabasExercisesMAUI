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
    public partial class UpdateActivityViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _id;
        [ObservableProperty]
        private string _title;
        [ObservableProperty]
        private DateTime _dueDate;
        [ObservableProperty]
        private bool _isCompleted;
        [ObservableProperty]
        private bool _isValid;
        [ObservableProperty]
        private string _message;

        private UpdateActivityModel _updateActivityModel;



        public event EventHandler<ResultEventArgs> UpdateAcivityResult;
        public UpdateActivityViewModel()
        {
            _updateActivityModel = new UpdateActivityModel();
        }
        [RelayCommand]
        private async void UpdateActivity()
        {
            try
            {
                _updateActivityModel.Id = Id;
                _updateActivityModel.Title = Title;
                _updateActivityModel.DueDate = DueDate;
                _updateActivityModel.IsCompleted = IsCompleted;
                await _updateActivityModel.UpdateActivities();
                IsValid = _updateActivityModel.IsValid;
                Message = _updateActivityModel.Message;

                UpdateAcivityResult?.Invoke(this, new ResultEventArgs() { IsValid = IsValid, Message = Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
