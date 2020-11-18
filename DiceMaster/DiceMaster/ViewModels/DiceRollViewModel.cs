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
            addEntry();
        }

        public void removeEntry()
        {
            if (DiceRows.Count != 0)
            {
                DiceRows.RemoveAt(DiceRows.Count - 1);
            }
        }

        public void addEntry()
        {
            DiceRows.Add(new DiceRoll
            {
                id = DiceRows.Count + 1,
                DiceType = "3",
                count = 1,
                modifier = 0,
                combined = false
            });
        }
    }
}
