using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C7_Exercises.Model
{
     public class GetProductModel
     {

        public ObservableCollection<ProductTable> ProductList { get; set; }
        private List<ProductTable> _productListTable;
        public bool IsVisibleCollectionView { get; set; }
        public bool IsLoading { get; set; }

        private GetProductsEndpoint _getProductsEndpoint;
        private bool _isInserted;

        public GetProductModel() 
        { 
            _getProductsEndpoint = new GetProductsEndpoint();
        }

        public async Task GetProductsLists()
        {
            IsVisibleCollectionView = false;
          if(CrossConnectivity.Current.IsConnected)
          {
                _isInserted = Preferences.Default.Get("DataInserted", false);
                if (!_isInserted)
                {

                    await InsertDataAsync();
                }
                else
                {
                    if (_isInserted)
                    {
                        await GetProductList();
                    }
                }               
          }
          else
          {
                IsLoading = true;
                IsVisibleCollectionView= false;

          }
        }

        private async Task InsertDataAsync()
        {
            var response = await _getProductsEndpoint.GetProductListAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var productDetails = JsonConvert.DeserializeObject<GetProductResposeModel>(data);
                _productListTable = new List<ProductTable>();
                foreach (var item in productDetails.Products)
                {
                    _productListTable.Add(new ProductTable()
                    {
                        Id = item.Id,
                        Title = item.Title,
                        Description = item.Description,
                        Price = item.Price,
                        Stock = item.Stock,
                        Brand = item.Brand,
                        Category = item.Category,
                        Thumbnail = item.Thumbnail,
                    });

                }
                var insertData = await UserDatabase.InsertAllData<ProductTable>(_productListTable);
                if (insertData)
                {
                    CurrentAppData.IsDataInserted = true;
                    Preferences.Default.Set("DataInserted", CurrentAppData.IsDataInserted);
                    await GetProductList();
                }
            }
        }

        private async Task GetProductList()
        {
            var productDetail = await UserDatabase.GetProductDetail();
            ProductList = new ObservableCollection<ProductTable>(productDetail);
            IsVisibleCollectionView = true;
            IsLoading = false;
        }
    }
}
