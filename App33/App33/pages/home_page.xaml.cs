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
    public partial class home_page: ContentPage
    {
        private bool isDrawerOpen = false;
        
        public home_page()
        {
            InitializeComponent();
            image_fon.Aspect = Aspect.Fill;
            Icon_setting.Source = ImageSource.FromResource("App33.Icon_Sett.png");
        }
        private List<decimal> prices = new List<decimal>(); // список нужен для сохранения суммы
        private decimal totalSum = 0;
        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            string productName = entryName.Text;
            string productPrice = entryPrice.Text;
            if (!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(productPrice)) // Проверяем, что поля не пустые
            {
                var newRow = new TextCell { Text = productName + " - " + productPrice + "руб." }; // Создаем новую ячейку для строки с данными продукта
                ((TableSection)tableView.Root[0]).Add(newRow); // Добавляем новую строку в таблицу
            }
            if (decimal.TryParse(entryPrice.Text, out decimal price))
            {
                prices.Add(price);
                totalSum += price;
                sum.Text = $"Сумма: {totalSum}";
                entryName.Text = string.Empty;
                entryPrice.Text = string.Empty; // Очищаем поле ввода
            }
        }

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
        private async void HiddenMenu_onClicked(object sender, EventArgs e)
        {
            if (isDrawerOpen)
            {
                CloseDrawer();
            }
            else
            {
                OpenDrawer();
            }

            isDrawerOpen = !isDrawerOpen;
        }
        private async void OpenDrawer()
        {
            drawer.IsVisible = true;
            await drawer.FadeTo(1, 750, Easing.SinInOut);
        }

        private async void CloseDrawer()
        {
            await drawer.FadeTo(0, 750, Easing.SinInOut);
            drawer.IsVisible = false;
        }
        private void OnSaveDelClicked(object sender, EventArgs e)
        {
            ((TableSection)tableView.Root[0]).Clear(); //
            if (decimal.TryParse("0", out decimal price)) //
            {
                prices.Clear();
                prices.Add(price);
                totalSum = price;
                sum.Text = $"Сумма: {totalSum}";
                entryPrice.Text = string.Empty; // Очищаем поле ввода
            }
        }

        //Логика для Setting
        void OnToggled(object sender, ToggledEventArgs e)
        {
            var state = e.Value;
            image_fon.IsVisible = state;
        }

        void OnTogg_Color_Fon(object sender, ToggledEventArgs e) // выбор тебя свет/темн 
        {
            if (e.Value) // пример условия, можете задать свое
            {
                Fon_Background.BackgroundColor = Color.Black; // пример установки черго цвета, используйте нужный вам цвет
            }
            else
            {
                Fon_Background.BackgroundColor = Color.Azure; // пример установки Azure цвета, используйте нужный вам цвет
            };
        }
        private async void Add_Fon_onClicked(object sender, EventArgs e)//, Service_Save_Image_Color service_Save_Image_Color) // выбор изображения
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
        private async void Print_Fon_onClicked(object sender, EventArgs e) // кнопка применить изображение
        {
            var pickerResult = await MediaPicker.PickPhotoAsync(new MediaPickerOptions { });
            Stream stream = await pickerResult.OpenReadAsync();
            string path_fon = pickerResult.FullPath;
            image_fon.Source = ImageSource.FromStream(() => stream);

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
        }

    }
}