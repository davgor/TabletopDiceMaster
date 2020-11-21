using DiceMaster.models;
using DiceMaster.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiceMaster.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoritePage : ContentPage
    {
        public FavoriteViewModel _viewModel;
        public FavoritePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new FavoriteViewModel();
        }
        async private void rowClick(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            string favoriteName = clicked.ClassId;
            EntireRoll entireRoll = _viewModel.getFavoriteDiceRows(favoriteName);
            await Navigation.PushAsync(new DiceResultsPage(entireRoll.all));
        }
    }
}