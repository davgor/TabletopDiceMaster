using DiceMaster.data;
using DiceMaster.models;
using DiceMaster.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace DiceMaster.ViewModels
{
    public class FavoriteViewModel : BaseViewModel
    {
        public ObservableCollection<EntireRoll> FavoritesLog { get; } = new ObservableCollection<EntireRoll>();
        public FavoriteViewModel()
        {
            updateDb();
        }
        public void updateDb()
        {
            Task<List<SQLiteEntireRoll>> SQLiteList = App.Database.GetFavorites();
            foreach (SQLiteEntireRoll sQLiteEntireRoll in SQLiteList.Result)
            {
                EntireRoll entireRoll = new EntireRoll();
                entireRoll.convertSQL(sQLiteEntireRoll);
                FavoritesLog.Add(entireRoll);
            }
        }
        public EntireRoll getFavoriteDiceRows(string name) {
            EntireRoll entireRoll = new EntireRoll();
            foreach(EntireRoll temp in FavoritesLog)
            {
                if (temp.Name.Equals(name))
                {
                    entireRoll = temp;
                }
            }
            return entireRoll;
        }
    }
}
