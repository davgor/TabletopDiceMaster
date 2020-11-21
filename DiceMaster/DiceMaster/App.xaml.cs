using DiceMaster.data;
using DiceMaster.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiceMaster
{
    public partial class App : Application
    {
        static DiceRollerDatabase database;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();      
        }
        public static DiceRollerDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DiceRollerDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
