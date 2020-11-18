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
    }
}