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
        public void EntireRollSave(Boolean favInp, String descInp, ObservableCollection<DiceRoll> favDiceRolls)
        {
            favorite = favInp;
            Description = descInp;
            all = favDiceRolls;
            id = getUniqueId();
        }
        private int getUniqueId()
        {
            int newId = 1;
            //Put SQLIte code call here to get next ID number 
            return newId;
        }
    }
}
