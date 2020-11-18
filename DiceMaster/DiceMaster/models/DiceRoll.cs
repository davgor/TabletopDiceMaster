using System;
using System.Collections.Generic;
using System.Text;

namespace DiceMaster.models
{
    class DiceRoll
    {
        public int id { get; set; }
        public String DiceType { get; set; }
        public int count { get; set; }
        public Boolean combined { get; set; }
        public int modifier { get; set; }
        public List<Dice> DiceList = new List<Dice>();
        public void RollTheDie()
        {
            Dice NewDice = new Dice();
            Random rnd = new Random();
            NewDice.result = this.modifier + rnd.Next(1, Int32.Parse(this.DiceType) + 1);
            DiceList.Add(NewDice);
        }
        public void RollDiceSet()
        {
            for (int i = 0;i <= count; i++)
            {
                RollTheDie();
            }
        }
        public void ReRollDiceSet()
        {
            DiceList = new List<Dice>();
            RollDiceSet();
        }
    }
}
