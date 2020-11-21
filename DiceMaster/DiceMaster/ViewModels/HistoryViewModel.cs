using DiceMaster.data;
using DiceMaster.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DiceMaster.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        public ObservableCollection<EntireRoll> HistoryLog { get; } = new ObservableCollection<EntireRoll>();
        public HistoryViewModel()
        {
            updateDb();
        }
        public void updateDb()
        {
            Task<List<SQLiteEntireRoll>> SQLiteList = App.Database.GetItemsAsync();
            foreach (SQLiteEntireRoll sQLiteEntireRoll in SQLiteList.Result)
            {
                EntireRoll entireRoll = new EntireRoll();
                entireRoll.convertSQL(sQLiteEntireRoll);
                HistoryLog.Add(entireRoll);
            }
        }

        public EntireRoll getHistoryDiceRows(DateTime rowId)
        {
            EntireRoll entireRoll = new EntireRoll();
            foreach(EntireRoll temp in HistoryLog)
            {
                if (temp.date == rowId)
                {
                    entireRoll = temp;
                }
            }
            return entireRoll;
        }
    }
}
