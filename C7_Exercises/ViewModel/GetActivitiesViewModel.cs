
using C7_Exercises.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C7_Exercises.ViewModel
{
    public partial class GetActivitiesViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _message;

        [ObservableProperty]
        private bool _isValid;

        [ObservableProperty]
        private bool _isVisibleCollectionView;

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private ObservableCollection<ActivityTabel> _activityTabels;

        private GetActivityModel _getActivityModel;

        public event EventHandler<ResultEventArgs> Result;
        public event EventHandler<ActivityTabel> UpdateActivityTabel;
        public ICommand DeleteActivity { get; private set; }
        public ICommand UpdateActivity{get; private set;}
        public GetActivitiesViewModel()
        {
            DeleteActivity = new Command<ActivityTabel>(DeleteActivties);
            UpdateActivity = new Command<ActivityTabel>(UpdateActivities);
            _getActivityModel = new GetActivityModel();
            GetActivityList();

        }

        private void UpdateActivities(ActivityTabel activity)
        {

           UpdateActivityTabel?.Invoke(this, activity);
        }

        private async void DeleteActivties(ActivityTabel activity)
        {
            _getActivityModel.ActivityTabel = activity;
            await _getActivityModel.DeleteActivity();
            ActivityTabels = _getActivityModel.ActivityList;
            Message = _getActivityModel.Message;
            IsValid = _getActivityModel.IsValid;
            Result?.Invoke(this,new ResultEventArgs() { IsValid = IsValid ,Message = Message});
        }

        public async void GetActivityList()
        {
            _getActivityModel.IsLoading = true;
            await _getActivityModel.GetActivitiesList();
            ActivityTabels = _getActivityModel.ActivityList;
            IsLoading  = _getActivityModel.IsLoading;
            IsVisibleCollectionView = _getActivityModel.IsVisibleCollectionView;     
            
        }

      
        
    }
}
