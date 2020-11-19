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
        public ICommand AdvancedFunctions  { get; }
        public int total { get; set; }
        public DiceRoll(int newId)
        {
            id = newId;
            DiceType = "6";
            count = 1;
            modifier = 0;
            DiceList = new ObservableCollection<Dice>();
            RepeatingDiceList = new ObservableCollection<RepeatingDice>();
            AdvancedFunctions = new Command<string>(superRollerFunctions);
        }
        public void RollTheDie()
        {
            Dice NewDice = new Dice();
            Random rnd = new Random();
            NewDice.result = this.modifier + rnd.Next(1, Int32.Parse(this.DiceType) + 1);
            total += NewDice.result;
            DiceList.Add(NewDice);
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
            return message;

        }
        public string explodedsOnNum(int num)
        {
            string message = "";
            return message;
        }
        async public void superRollerFunctions(string x)
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Advanced Functions", "Cancel", null, "Reroll specific", "Explode dice", "Roll again");
            if (action.Equals("Reroll specific"))
            {
                action = await Application.Current.MainPage.DisplayPromptAsync("ReRolling", "Enter the Dice face you'd like to reroll", initialValue: "1", keyboard: Keyboard.Numeric);
                string message = reRollOnNum(Int32.Parse(action));
                if (message.Equals(""))
                {
                    await Application.Current.MainPage.DisplayAlert("Done", "Roll has been updated", "OK");
                }

            } else if (action.Equals("Explode dice"))
            {
                action = await Application.Current.MainPage.DisplayPromptAsync("ReRolling", "Enter the Dice face you'd like to Explode by 2", initialValue: "1", keyboard: Keyboard.Numeric);
                string message = explodedsOnNum(Int32.Parse(action));
                if (message.Equals(""))
                {
                    await Application.Current.MainPage.DisplayAlert("Done", "Roll has been updated", "OK");
                }
            } else if (action.Equals("Roll again")) {
                

            }
        }
    }
}
