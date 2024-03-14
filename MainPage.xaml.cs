using System;
using Microsoft.Maui.Controls;

namespace EggApp
{
    public partial class MainPage : ContentPage
    {
        // Countdown timer er lavet med hjælp fra
        // https://www.youtube.com/watch?v=34p2XM74J3g & 
        // https://stackoverflow.com/questions/73816335/device-starttimer-is-deprecated-in-maui-what-is-the-alternative

        public int cookTime
        {
            get; set;
        }

        public MainPage()
        {
            InitializeComponent();
        }

        void StartTimeButtonClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("DetailPage");
        }

        void TypeSliderChanged(object sender, EventArgs e)
        {
            int imageNumber = 0;
            switch (Math.Round(typeSlider.Value))
            {
                case 1:
                    imageNumber = 6;
                    countdown.Text = "00:00";
                    break;
                case 2:
                    imageNumber = 3;
                    countdown.Text = "06:00";
                    break;
                case 3:
                    imageNumber = 0;
                    countdown.Text = "10:00";
                    break;
                default:
                    break;
            }
            eggImage.Source = "egg" + imageNumber.ToString() + ".png";
        }

        void TemperatureSliderChanged(object sender, EventArgs e)
        {
            temperature.Text = Math.Round(temperatureSlider.Value) + " °C";
        }

        void PictureButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
