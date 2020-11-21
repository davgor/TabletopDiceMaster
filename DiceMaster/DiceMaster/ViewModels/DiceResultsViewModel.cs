using DiceMaster.data;
using DiceMaster.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static DiceMaster.data.DiceRollerDatabase;

namespace DiceMaster.ViewModels
{
    public class DiceResultsViewModel : BaseViewModel
    {
        SQLiteEntireRoll saveFormat { get; set; }
        public DiceResultsViewModel(ObservableCollection<DiceRoll> submittedRolls)
        {
            saveFormat = new SQLiteEntireRoll();
            DiceRows = submittedRolls;
            foreach(DiceRoll roll in DiceRows)
            {
                roll.RollDiceSet();
            }
            saveObject("");
        }
        public DiceResultsViewModel(ObservableCollection<DiceRoll> submittedRolls, string function)
        {
            DiceRows = submittedRolls;
        }
        public DiceResultsViewModel(EntireRoll oldRoll)
        {
            DiceRows = oldRoll.all;
        }
        public void saveObject(String name)
        {
            saveFormat.Name = name;
            saveFormat.setDate();
            saveFormat.favorite = (!name.Equals(""));
            saveFormat.entireRollString = JsonConvert.SerializeObject(DiceRows);
            saveFormat.SQLiteSave();
        }
    }
}
