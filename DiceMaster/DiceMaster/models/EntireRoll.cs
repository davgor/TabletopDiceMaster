using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiceMaster.models
{
    public class EntireRoll
    {
        public int id { get; set; }
        public ObservableCollection<DiceRoll> all = new ObservableCollection<DiceRoll>();
        public string Description { get; set; }
        public Boolean favorite { get; set; }
        public void ReRollEntireRoll()
        {
            foreach (DiceRoll diceRoll in all)
            {
                diceRoll.ReRollDiceSet();
            }
        }
    }
}
