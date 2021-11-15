using CURD_Example.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CURD_Example.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}