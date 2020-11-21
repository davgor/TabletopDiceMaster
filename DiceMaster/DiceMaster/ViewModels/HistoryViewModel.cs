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
        ObservableCollection<EntireRoll> HistoryLog { get; set; }
        public HistoryViewModel()
        {
            HistoryLog = new ObservableCollection<EntireRoll>();
            Task<List<SQLiteEntireRoll>> SQLiteList = App.Database.GetItemsAsync();
            foreach (SQLiteEntireRoll sQLiteEntireRoll in SQLiteList.Result)
            {
                EntireRoll entireRoll = new EntireRoll();
                entireRoll.convertSQL(sQLiteEntireRoll);
                HistoryLog.Add(entireRoll);
            }
        }
    }
}
