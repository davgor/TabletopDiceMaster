﻿using DiceMaster.data;
using DiceMaster.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DiceMaster.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DiceRoll> DiceRows { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
