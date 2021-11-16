using CURD_Example.Models;
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
    public partial class AddProductPage : ContentPage
    {
        public ProductInfo ProductInfo { get; set; }
        public AddProductPage(ProductInfo prod)
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel();
        }

        public AddProductPage()
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel();

            if(ProductInfo != null)
            {
                 ((AddProductViewModel)BindingContext).ProductInfo=ProductInfo;
            }
        }
    }
}