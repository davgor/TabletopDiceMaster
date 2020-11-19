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
        DiceResultsViewModel _viewModel;
        public DiceResultsPage(ObservableCollection<DiceRoll> submittedRolls)
        {
            InitializeComponent();
            BindingContext = _viewModel = new DiceResultsViewModel(submittedRolls);
        }
    }
}