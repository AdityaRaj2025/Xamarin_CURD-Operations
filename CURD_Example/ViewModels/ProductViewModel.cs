using CURD_Example.Models;
using CURD_Example.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CURD_Example.ViewModels
{
    public class ProductViewModel : BaseProductViewModel
    {
        public Command LoadProductCommand { get; }
        public ObservableCollection<ProductInfo> ProductInfos { get; }
        public Command AddProductCommand { get; }
        public Command ProductTappedEdit { get; }

        public Command ProductTappedDelete { get; }
        public Command ClearProductCommand { get; }

        public ProductViewModel(INavigation _navigation)
        {
            LoadProductCommand = new Command(async () => await ExecuteLoadProductCommand());
            ProductInfos = new ObservableCollection<ProductInfo>();
            AddProductCommand = new Command(OnAddProduct);
            ProductTappedEdit = new Command<ProductInfo>(OnEditProduct);
            ProductTappedDelete = new Command<ProductInfo>(OnDeleteProduct);
            ClearProductCommand = new Command(ClearProduct);
            Navigation = _navigation;
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadProductCommand()
        {
            IsBusy = true;
            try
            {
                ProductInfos.Clear();
                var prodList = await App.ProductService.GetProductsAsync();
                foreach (var prod in prodList)
                {
                    ProductInfos.Add(prod);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
            
        }
        private async void OnAddProduct(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddProductPage));
        }

        private async void OnEditProduct(ProductInfo prod)
        {
            await Navigation.PushAsync(new AddProductPage(prod));
        }

        private async void OnDeleteProduct(ProductInfo prod)
        {
            if(prod == null)
            {
                return;
            }
            await Navigation.PushAsync(new AddProductPage(prod));
            await ExecuteLoadProductCommand();
        }
        private  void ClearProduct()
        {
            ProductInfos.Clear();
        }
    }
}
