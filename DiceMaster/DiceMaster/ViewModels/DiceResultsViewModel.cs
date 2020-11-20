using DiceMaster.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiceMaster.ViewModels
{
    public class DiceResultsViewModel : BaseViewModel
    {   
        public DiceResultsViewModel(ObservableCollection<DiceRoll> submittedRolls)
        {
            DiceRows = submittedRolls;
            foreach(DiceRoll roll in DiceRows)
            {
                roll.RollDiceSet();
            }
        }
        public DiceResultsViewModel(EntireRoll oldRoll)
        {
            DiceRows = oldRoll.all;
        }
    }
}
