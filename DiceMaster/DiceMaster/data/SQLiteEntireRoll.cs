using DiceMaster.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiceMaster.data
{
    public class SQLiteEntireRoll
    {
        public int id { get; set; }
        public String entireRollString { get; set; }
        public Boolean favorite { get; set; }
        public DateTime date { get; set; }
        public string Name { get; set; }
        public void setDate()
        {
            date = DateTime.Now;
        }
        public void SQLiteSave()
        {
            App.Database.SaveItemAsync(this);
        }
    }
}
