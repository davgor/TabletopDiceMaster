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

        }
        async void OnAdd(object sender, EventArgs args)
        {
            _viewModel.addEntry();
        }
        async void OnRemove(object sender, EventArgs args)
        {
            _viewModel.removeEntry();
        }
    }
}