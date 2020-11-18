using System;
using System.Collections.Generic;
using System.Text;

namespace DiceMaster.models
{
    class EntireRoll
    {
        public int id { get; set; }
        public List<DiceRoll> all = new List<DiceRoll>();
        public string name { get; set; }
        public void addToList(DiceRoll rolledDice)
        {
            all.Add(rolledDice);
        }
        public void ReRollEntireRoll()
        {
            foreach (DiceRoll diceRoll in all)
            {
                diceRoll.ReRollDiceSet();
            }
        }
    }
}
