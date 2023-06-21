using C7_Exercises.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises.ViewModel
{
    public partial class GetProductViewModel :ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ProductTable> _productList;
        [ObservableProperty]
        private bool _isCollectionVisible;
        [ObservableProperty]
        private bool _isLoading;

        private GetProductModel _getProductModel;
        public GetProductViewModel()
        {
            _getProductModel = new GetProductModel();
            _= GetProductListAsync();

        }

        private async Task GetProductListAsync()
        {
            _getProductModel.IsLoading = true;
            await _getProductModel.GetProductsLists();
            ProductList = _getProductModel.ProductList;
            IsCollectionVisible = _getProductModel.IsVisibleCollectionView;
            IsLoading = _getProductModel.IsLoading;
        }
    }
}
