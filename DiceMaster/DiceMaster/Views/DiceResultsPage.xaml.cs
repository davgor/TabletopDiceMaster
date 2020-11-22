using DiceMaster.models;
using DiceMaster.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        public DiceResultsPage(ObservableCollection<DiceRoll> submittedRolls, string function)
        {
            InitializeComponent();
            BindingContext = _viewModel = new DiceResultsViewModel(submittedRolls, function);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string result = await DisplayPromptAsync("Favorite", "What would you like to name this Roll set?");
                var test = await App.Database.NameSearch(result);
                if (test.Count == 0)
                {
                    _viewModel.saveObject(result);
                    await Application.Current.MainPage.DisplayAlert("Done", "Favorite has been saved", "OK");
                } else
                {
                    if(!result.Equals(""))
                    {
                        bool answer = await DisplayAlert("Overwrite?", "Favorite already exists overwrite?", "Yes", "No");
                        if (answer)
                        {
                            _viewModel.overwriteObject(result);
                        }
                    }

                }   
            } catch(Exception error)
            {
                Debug.WriteLine(error);
            }

        }

        private void rowClick(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            int rowId = Int32.Parse(clicked.ClassId);
            superRollerFunctions(rowId);

        }
        public DiceRoll getAffectedRoll(int id)
        {
            DiceRoll errorRoll = new DiceRoll();
            foreach (DiceRoll roll in _viewModel.DiceRows)
            {
                return roll;
            }
            return errorRoll;
        }
        async public void superRollerFunctions(int clickedId)
        {
            try
            {
                DiceRoll affectedRoll = getAffectedRoll(clickedId);
                string function = await Application.Current.MainPage.DisplayActionSheet("Advanced Functions", "Cancel", null, "Reroll specific", "Explode dice", "Roll again");
                if (function.Equals("Reroll specific"))
                {
                    string action = await Application.Current.MainPage.DisplayPromptAsync("ReRolling", "Enter the Dice face you'd like to reroll", initialValue: "1", keyboard: Keyboard.Numeric);
                    string message = affectedRoll.reRollOnNum(Int32.Parse(action));
                    if (message.Equals(""))
                    {
                        await Application.Current.MainPage.DisplayAlert("Done", "Roll has been updated", "OK");

                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", message, "OK");
                    }

                }
                else if (function.Equals("Explode dice"))
                {
                    string action = await Application.Current.MainPage.DisplayPromptAsync("ReRolling", "Enter the Dice face you'd like to Explode by 2", initialValue: "6", keyboard: Keyboard.Numeric);
                    string message = affectedRoll.explodedsOnNum(Int32.Parse(action));
                    if (message.Equals(""))
                    {
                        await Application.Current.MainPage.DisplayAlert("Done", "Roll has been updated", "OK");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", message, "OK");
                    }
                }
                else if (function.Equals("Roll again"))
                {
                    string action = await Application.Current.MainPage.DisplayPromptAsync("Filter roll", "Enter number you would like to use for the next roll EX: 4 means reroll modified roll above a 4", initialValue: "3", keyboard: Keyboard.Numeric);
                    if (Int32.Parse(action) < 0)
                    {
                        _viewModel.DiceRows.Clear();
                        _viewModel.DiceRows.Add(affectedRoll.nextRoll(Int32.Parse(action)));
                        await Application.Current.MainPage.DisplayAlert("Done", "Roll has been updated", "OK");
                    }
                }
            } catch (Exception e)
            {

            }
        }
    }
}