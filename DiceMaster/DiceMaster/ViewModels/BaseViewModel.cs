using DiceMaster.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiceMaster.ViewModels
{
    public class BaseViewModel
    {
        public ObservableCollection<DiceRoll> DiceRows { get; set; }
    }
}
