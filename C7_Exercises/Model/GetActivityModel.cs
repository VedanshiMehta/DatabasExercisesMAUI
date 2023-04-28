using CommunityToolkit.Maui.Core.Extensions;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace C7_Exercises.Model
{
    public class GetActivityModel
    {

        public ObservableCollection<ActivityTabel> ActivityList { get; set; }
        public bool IsVisibleCollectionView { get; set; }
        public bool IsLoading { get; set; }

        public string Message { get; set; }
        public bool IsValid { get; set; }

        public ActivityTabel ActivityTabel { get; set; }

        public async Task GetActivitiesList()
        {
            IsVisibleCollectionView = false;
            var activityDetail = await UserDatabase.GetActivityDetail();
            if (activityDetail != null)
            {
                ActivityList = new ObservableCollection<ActivityTabel>(activityDetail);
                IsLoading = false;
                IsVisibleCollectionView = true;
            }


        }

        public async Task DeleteActivity()
        {
            var deleteActivity = await UserDatabase.DeleteData<ActivityTabel>(ActivityTabel);
            if(deleteActivity)
            {
                Message = "Deleted Data Successfully";
                IsValid = true;
                ActivityList.Remove(ActivityTabel);
            }
            else
            {
                Message = "Something went wrong";
                IsValid = false;
            }
        }
    }
}

