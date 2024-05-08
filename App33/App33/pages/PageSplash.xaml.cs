using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.ComponentModel;
using System.Timers;

using Xamarin.Forms.Shapes;
using System.Collections.ObjectModel;

namespace App33.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSplash : ContentPage
    {
        public PageSplash()
        {
            InitializeComponent();
            myImage.Source = ImageSource.FromResource("App33.droid.jpg");
        }

    }
}