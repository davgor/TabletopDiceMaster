using DiceMaster.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static DiceMaster.data.DiceRollerDatabase;

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
            EntireRoll entireRoll = new EntireRoll();
            entireRoll.EntireRollHistory(DiceRows);
            diceDB.SaveItemAsync(entireRoll);
        }
        public DiceResultsViewModel(EntireRoll oldRoll)
        {
            DiceRows = oldRoll.all;
        }
        public void saveFavorite(EntireRoll entireRoll)
        {
            diceDB.SaveItemAsync(entireRoll);
        }
    }
}
