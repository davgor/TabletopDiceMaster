using DiceMaster.data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace DiceMaster.models
{
    public class EntireRoll
    {
        public int id { get; set; }
        public ObservableCollection<DiceRoll> all { get; set; }
        public string Name { get; set; }
        public void ReRollEntireRoll()
        {
            foreach (DiceRoll diceRoll in all)
            {
                diceRoll.RollDiceSet();
            }
        }
        public void convertSQL(SQLiteEntireRoll sQLiteEntireRoll)
        {
            id = sQLiteEntireRoll.id;
            Name = sQLiteEntireRoll.Name;
            all = JsonConvert.DeserializeObject<ObservableCollection<DiceRoll>>(sQLiteEntireRoll.entireRollString);
        }
    }
}
