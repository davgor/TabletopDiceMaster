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
    public partial class DiceRollPage : ContentPage
    {
        DiceRollViewModel _viewModel;
        public DiceRollPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new DiceRollViewModel();
        }
        async void OnSubmit(object sender, EventArgs args)
        {
            string message = _viewModel.runEdits();
            if (message.Equals(""))
            {
                await Navigation.PushAsync((new DiceResultsPage(_viewModel.DiceRows)));
            } else
            {
                await DisplayAlert("Alert", message, "OK");
                //display error message here 
            }
            
        }
        void OnAdd(object sender, EventArgs args)
        {
            _viewModel.addEntry();
        }
        void OnRemove(object sender, EventArgs args)
        {
            _viewModel.removeEntry();
        }
    }
}