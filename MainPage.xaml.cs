using System;
using System.Net;
using Microsoft.Maui.Controls;

namespace EggApp
{
    public partial class MainPage : ContentPage
    {
        private int cookTime = 360;
        private ImageSource imageSource = "egg3.png";
        private bool butttonPressed = false;

        public MainPage()
        {
            InitializeComponent();
            UpdateTime();
        }

        async void StartTimeButtonClicked(object sender, EventArgs e)
        {
            if (!butttonPressed)
            {
                butttonPressed = true;
                await Navigation.PushAsync(new DetailPage(cookTime, imageSource));
                butttonPressed = false;
            }
        }

        async void ScanButtonClicked(object sender, EventArgs e)
        {
            if (!butttonPressed)
            {
                butttonPressed = true;
                await Navigation.PushAsync(new CameraPage());
                butttonPressed = false;
            }
        }

        void TypeSliderChanged(object sender, EventArgs e)
        {
            UpdateTime();
        }

        void TemperatureSliderChanged(object sender, EventArgs e)
        {
            temperature.Text = Math.Round(temperatureSlider.Value) + " °C";
            UpdateTime();
        }

        void UpdateTime()
        {
            int imageNumber = (int)Math.Round(typeSlider.Value);

            imageSource = "egg" + imageNumber.ToString() + ".png";
            if (eggImage.Source != imageSource)
            {
                eggImage.Source = imageSource;
            }

            // Tider hentet fået fra ChatGPT
            // cookTime er i sekunder

            switch (imageNumber)
            {
                case 0:
                    cookTime = 90;
                    break;
                case 1:
                    cookTime = 180;
                    break;
                case 2:
                    cookTime = 270;
                    break;
                case 3:
                    cookTime = 330;
                    break;
                case 4:
                    cookTime = 450;
                    break;
                case 5:
                    cookTime = 540;
                    break;
                case 6:
                    cookTime = 600;
                    break;
                default:
                    break;
            }

            cookTime += (int)Math.Round(90/17*(22-Math.Round(temperatureSlider.Value)));
            int minutes = (int)Math.Floor(cookTime / 60.0);
            int seconds = cookTime % 60;

            countdown.Text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }
}
