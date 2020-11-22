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
    public partial class HistoryPage : ContentPage
    {
        public HistoryViewModel _viewModel;
        public HistoryPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Object>(this, "third_tab", (obj) =>
            {
                BindingContext = _viewModel = new HistoryViewModel();
            });
        }
        async private void rowClick(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            DateTime date = DateTime.Parse(clicked.ClassId);
            EntireRoll entireRoll = _viewModel.getHistoryDiceRows(date);
            await Navigation.PushAsync(new DiceResultsPage(entireRoll.all, "history"));
        }
    }
}