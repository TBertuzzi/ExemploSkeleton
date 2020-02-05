using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bertuzzi.Xamarin.Forms.Mocks.ViewModels;
using Bertuzzi.Xamarin.Forms.Mocks.Views;
using Xamarin.Forms;

namespace ExemploSkeleton
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

       
    }
}
