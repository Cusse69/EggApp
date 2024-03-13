using System;
using Microsoft.Maui.Controls;

namespace EggApp
{
    public partial class MainPage : ContentPage
    {
        // Countdown timer er lavet med hjælp fra
        // https://www.youtube.com/watch?v=34p2XM74J3g & 
        // https://stackoverflow.com/questions/73816335/device-starttimer-is-deprecated-in-maui-what-is-the-alternative

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
        }

        void TemperatureSliderChanged(object sender, EventArgs e)
        {
            temperature.Text = Math.Round(temperatureSlider.Value) + " °C";
        }
    }
}
