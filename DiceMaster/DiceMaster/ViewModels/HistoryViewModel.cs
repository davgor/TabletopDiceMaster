using DiceMaster.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiceMaster.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        ObservableCollection<EntireRoll> HistoryLog { get; set; }
        public HistoryViewModel()
        {
            //Get History list here
            //HistoryLog = GetAllDiceRollsSQL();
        }
    }
}
