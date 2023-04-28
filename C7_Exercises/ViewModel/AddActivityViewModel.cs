using C7_Exercises.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace C7_Exercises.ViewModel
{
    public partial class AddActivityViewModel : ObservableObject
    {
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
        private AddActivityModel _model;

      

        public event EventHandler<ResultEventArgs> AddAcivityResult;
        public AddActivityViewModel()
        {
            _model = new AddActivityModel();
        }
        [RelayCommand]
        private  async void AddActivity()
        {
            try
            {
                _model.Title = Title;
                _model.DueDate = DueDate;
                _model.IsCompleted = IsCompleted;  
                await  _model.InsertActivities();
                IsValid = _model.IsValid;
                Message = _model.Message;

                AddAcivityResult?.Invoke(this, new ResultEventArgs() { IsValid = IsValid, Message = Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
