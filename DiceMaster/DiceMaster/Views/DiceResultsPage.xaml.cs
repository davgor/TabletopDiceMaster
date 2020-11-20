using DiceMaster.models;
using DiceMaster.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiceMaster.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiceResultsPage : ContentPage
    {
        public DiceResultsViewModel _viewModel;
        public DiceResultsPage(ObservableCollection<DiceRoll> submittedRolls)
        {
            InitializeComponent();
            BindingContext = _viewModel = new DiceResultsViewModel(submittedRolls);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Favorite", "What would you like to name this Roll set?");
        }
    }
}