using DiceMaster.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiceMaster.ViewModels
{
    class DiceRollViewModel
    {
        public ObservableCollection<DiceRoll> DiceRows { get; }

        public DiceRollViewModel()
        {
            DiceRows = new ObservableCollection<DiceRoll>();
            DiceRows.Add(new DiceRoll
            {
                DiceType = "3",
                count = 1,
                modifier = 0,
                combined = false
            });
        }
    }
}
