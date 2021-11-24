using AppTaxiPay.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppTaxiPay.Views
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