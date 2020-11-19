﻿using DiceMaster.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DiceMaster.ViewModels
{
    class DiceRollViewModel
    {
        public ObservableCollection<DiceRoll> DiceRows { get; }

        public DiceRollViewModel()
        {
            DiceRows = new ObservableCollection<DiceRoll>();
            addEntry();
        }
        public ObservableCollection<DiceRoll> getEntries()
        {
            return DiceRows;
        }
        public void removeEntry()
        {
            if (DiceRows.Count != 0)
            {
                DiceRows.RemoveAt(DiceRows.Count - 1);
            }
        }

        public void addEntry()
        {
            DiceRows.Add(new DiceRoll
            {
                id = DiceRows.Count + 1,
                DiceType = "6",
                count = 1,
                modifier = 0,
            });
        }
        public string runEdits()
        {
            string message = "";
            foreach(DiceRoll testing in DiceRows)
            {
                if (testing.count == 0)
                {
                    message = "Dice Roll: " + testing.id + " Quantity must be numeric, and greater then zero" ;
                }
                
            }
            return message;
        }
    }
}
