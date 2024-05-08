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
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace App33.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class page_diagram : ContentPage
    {

        protected override async void OnAppearing() //
        {
            base.OnAppearing();
            
        }
        public page_diagram()
        {
            InitializeComponent();
            image_fon.Aspect = Aspect.Fill;
            Icon_setting.Source = ImageSource.FromResource("App33.Icon_Sett.png");

        }

        //
        private bool isDrawerOpen = false;

        private async void Icon_setting_onClicked(object sender, EventArgs e)
        {
            if (isDrawerOpen) //
            {
                CloseIcon_setting();
            }
            else
            {
                OpenIcon_setting();
            }

            isDrawerOpen = !isDrawerOpen; //
        }

        private async void OpenIcon_setting()
        {
            drawer_setting.IsVisible = true; //
            await drawer_setting.FadeTo(1, 750, Easing.SinInOut); //
        }

        private async void CloseIcon_setting()
        {
            await drawer_setting.FadeTo(0, 750, Easing.SinInOut);
            drawer_setting.IsVisible = false;
        }
        void OnToggled(object sender, ToggledEventArgs e)
        {
            var state = e.Value;
            image_fon.IsVisible = state;
        }

        void OnTogg_Color_Fon(object sender, ToggledEventArgs e)
        {
            if (e.Value) // пример условия, можете задать свое
            {
                Fon_Background.BackgroundColor = Color.Black; // пример установки красного цвета, используйте нужный вам цвет
            }
            else
            {
                Fon_Background.BackgroundColor = Color.Azure; // пример установки синего цвета, используйте нужный вам цвет
            };
        }
        private async void Add_Fon_to_Page_onClicked(object sender, EventArgs e)
        {
            try
            {
                var pickerResult = await MediaPicker.PickPhotoAsync(new MediaPickerOptions { });
                if (pickerResult != null)
                {
                    Stream stream = await pickerResult.OpenReadAsync();
                    string path_fon = pickerResult.FullPath;
                    Add_Image.Source = ImageSource.FromStream(() => stream);
                }
            }
            catch (FeatureNotSupportedException)
            {
                // Обработка исключения, если функция не поддерживается на устройстве
                await DisplayAlert("Ошибка", "Функция выбора изображения не поддерживается", "OK");
            }
            catch (PermissionException)
            {
                // Обработка исключения, если отсутствуют необходимые разрешения
                await DisplayAlert("Ошибка", "Необходимы разрешения для доступа к галерее", "OK");
            }
            catch (Exception)
            {
                // Обработка других исключений
                await DisplayAlert("Ошибка", "Произошла ошибка при выборе изображения", "OK");
            }
        }
        private async void Print_Fon_onClicked(object sender, EventArgs e)
        {
            var pickerResult = await MediaPicker.PickPhotoAsync(new MediaPickerOptions { });
            Stream stream = await pickerResult.OpenReadAsync();
            image_fon.Source = ImageSource.FromStream(() => stream);
        }
        
    }

}