using DiceMaster.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiceMaster.ViewModels
{
    class DiceRollViewModel : BaseViewModel
    {

        public DiceRollViewModel()
        {
            DiceRows = new ObservableCollection<DiceRoll>();
            addEntry();
        }
        public DiceRollViewModel(EntireRoll originallRoll)
        {
            DiceRows = originallRoll.all;//refresh screen with older DiceRoll
        }
        public ObservableCollection<DiceRoll> getEntries()
        {
            return DiceRows;
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
            DiceRoll diceRoll = new DiceRoll();
            diceRoll.newDiceRoll(DiceRows.Count + 1);
            DiceRows.Add(diceRoll);
        }
        public string runEdits()
        {
            string message = "";
            foreach(DiceRoll testing in DiceRows)
            {
                if (testing.count == 0)
                {
                    message = "Dice Roll: " + testing.id + " Quantity must be numeric, and greater then zero" ;
                }
                
            }
            return message;
        }
    }
}
