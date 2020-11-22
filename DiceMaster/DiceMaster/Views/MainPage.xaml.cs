using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiceMaster.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            int index = Children.IndexOf(CurrentPage);

            if (index == 0)
            {
                MessagingCenter.Send<Object>(this, "first_tab");
            }
            else if (index == 1)
            {
                MessagingCenter.Send<Object>(this, "second_tab");
            }
            else if (index == 2)
            {
                MessagingCenter.Send<Object>(this, "third_tab");
            }
        }
    }
}