using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App33
{
    public partial class MainPage : CarouselPage
    {
        public MainPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {

                CurrentPage = Children[1]; // Переход на Page 1
                return false; // Остановка таймера после перехода
            });

        }

    }
}
