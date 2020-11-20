using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiceMaster.models
{
    public class EntireRoll
    {
        public int id { get; set; }
        public ObservableCollection<DiceRoll> all { get; set; }
        public string Description { get; set; }
        public Boolean favorite { get; set; }
        public void ReRollEntireRoll()
        {
            foreach (DiceRoll diceRoll in all)
            {
                diceRoll.RollDiceSet();
            }
        }
        public void EntireRollFavorite(String descInp, ObservableCollection<DiceRoll> favDiceRolls)
        {
            favorite = true;
            Description = descInp;
            all = favDiceRolls;
            id = getUniqueId();
        }
        public void EntireRollHistory(ObservableCollection<DiceRoll> historyDiceRolls)
        {
            favorite = false;
            Description = "";
            all = historyDiceRolls;
            id = getUniqueId();
        }
        private int getUniqueId()
        {
            Random rnd = new Random();
            int newId = rnd.Next(1000000, 9999999);
            return newId;
        }
    }
}
