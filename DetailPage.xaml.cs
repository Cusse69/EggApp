using EggApp.ViewModels;

namespace EggApp;

public partial class DetailPage : ContentPage
{
    IDispatcherTimer? timer;
    readonly DateTime tidTagning = new DateTime(DateTime.Now.Ticks + new TimeSpan(0, 7, 0).Ticks);
    public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(1000);
        timer.Tick += (s, e) => CountDownTick();
        timer.Start();
        UpdateTimerLabel();
    }

    void CountDownTick()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            UpdateTimerLabel();
        });
    }

    async void CancelTimeButtonClicked(object sender, EventArgs e)
    {
        timer.Stop();
        await Shell.Current.GoToAsync("..");
    }

    void UpdateTimerLabel()
    {
        TimeSpan diff = (tidTagning - DateTime.Now);
        if (diff.TotalSeconds < 0)
        {
            timer?.Stop();
            countdown.Text = "00:00";
        }
        else
        {
            countdown.Text = diff.Minutes.ToString("00") + ":" + diff.Seconds.ToString("00");
        }
    }
}