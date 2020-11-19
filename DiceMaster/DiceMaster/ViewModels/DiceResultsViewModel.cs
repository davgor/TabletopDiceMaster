using DiceMaster.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiceMaster.ViewModels
{
    class DiceResultsViewModel
    {
        public ObservableCollection<DiceRoll> DiceRows { get; }
        public DiceResultsViewModel(ObservableCollection<DiceRoll> submittedRolls)
        {
            DiceRows = submittedRolls;
            foreach(DiceRoll roll in DiceRows)
            {
                roll.RollTheDie();
            }
        }
    }
}
