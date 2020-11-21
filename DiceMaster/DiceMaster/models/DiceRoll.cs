using DiceMaster.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiceMaster.models
{
    public class DiceRoll
    {
        public int id { get; set; }
        public String DiceType { get; set; }
        public int count { get; set; }
        public int modifier { get; set; }
        public ObservableCollection<Dice> DiceList { get; set; }
        public ObservableCollection<RepeatingDice> RepeatingDiceList { get; set; }
        
        public int total { get; set; }
        public void newDiceRoll(int newId)
        {
            id = newId;
            DiceType = "6";
            count = 1;
            modifier = 0;
            DiceList = new ObservableCollection<Dice>();
            RepeatingDiceList = new ObservableCollection<RepeatingDice>();
        }
        public void RollTheDie()
        {
            Dice NewDice = new Dice();
            NewDice.newDice(modifier, DiceType);
            total += NewDice.modifiedResult;
            DiceList.Add(NewDice);
        }
        public List<Dice> RollTheDie(List<Dice> tempDiceList)
        {
            Dice NewDice = new Dice();
            NewDice.newDice(modifier, DiceType);
            total += NewDice.modifiedResult;
            tempDiceList.Add(NewDice);
            return tempDiceList;
        }
        public void RollDiceSet()
        {
            total = 0;
            DiceList.Clear();
            RepeatingDiceList.Clear();
            for (int i = 1;i <= count; i++)
            {
                RollTheDie();
            }
            updateRepeatingList();
        }
        public void updateRepeatingList()
        {
            ObservableCollection<RepeatingDice> RepeatingDiceListTEMP = new ObservableCollection<RepeatingDice>();
            int convertedDice = Int32.Parse(DiceType);
            for (int i = 1; i <= convertedDice; i++)
            {
                RepeatingDice RD = new RepeatingDice();
                RD.DiceFace = i;
                RepeatingDiceListTEMP.Add(RD);
            }
            foreach (Dice die in DiceList)
            {
                foreach (RepeatingDice repeat in RepeatingDiceListTEMP)
                {
                    if (repeat.DiceFace == die.result)
                    {
                        repeat.DiceCount += 1;
                        repeat.modifiedFace = repeat.DiceFace + modifier;
                        int[] idArray = { this.id, repeat.DiceFace };
                        repeat.id = idArray;
                    }
                }
            }
            foreach (RepeatingDice repeat in RepeatingDiceListTEMP)
            {
                if (repeat.DiceCount != 0)
                {
                    RepeatingDiceList.Add(repeat);
                }
            }
        }
        public string reRollOnNum(int num)
        {
            string message = "";
            foreach (Dice die in DiceList)
            {
                if (die.result == num)
                {
                    die.reRoll(DiceType);
                }
            }
            RepeatingDiceList.Clear();
            updateRepeatingList();
            return message;

        }
        public string explodedsOnNum(int num)
        {
            string message = "";
            List<Dice> tempDiceList = new List<Dice>();
            foreach (Dice die in DiceList)
            {
                if (die.result == num)
                {
                    tempDiceList = RollTheDie(tempDiceList);
                    tempDiceList = RollTheDie(tempDiceList);
                }
            }
            foreach (Dice die in tempDiceList)
            {
                this.count++;
                this.DiceList.Add(die);
            }
            RepeatingDiceList.Clear();
            updateRepeatingList();
            return message;
        }
    }
}
