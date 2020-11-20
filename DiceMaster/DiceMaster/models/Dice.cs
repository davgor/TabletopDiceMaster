using System;
using System.Collections.Generic;
using System.Text;

namespace DiceMaster.models
{
    public class Dice
    {
        public int result { get; set; }
        public int modifiedResult { get; set; }
        public void reRoll(string diceType)
        {
            Random rnd = new Random();
            int trueModifier = modifiedResult - result;
            result = rnd.Next(1, Int32.Parse(diceType) + 1);
            modifiedResult = result + trueModifier;
        }
        public Dice(int modifier, string diceType)
        {
            Random rnd = new Random();
            result = rnd.Next(1, Int32.Parse(diceType) + 1);
            modifiedResult = result + modifier;
        }
    }

}
