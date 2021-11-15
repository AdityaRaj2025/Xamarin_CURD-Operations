using CURD_Example.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CURD_Example.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        ProductViewModel productViewModel;
        public ProductPage()
        {
            InitializeComponent();
            BindingContext= productViewModel= new ProductViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            productViewModel.OnAppearing();
        }
    }
}