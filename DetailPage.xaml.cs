namespace EggApp;

public partial class DetailPage : ContentPage
{
    // Countdown timer er lavet med hjælp fra
    // https://www.youtube.com/watch?v=34p2XM74J3g & 
    // https://stackoverflow.com/questions/73816335/device-starttimer-is-deprecated-in-maui-what-is-the-alternative

    private DateTime tidTagning;
    private IDispatcherTimer timer;
    private bool timerDone = false;

    public DetailPage(int cookTime, ImageSource imageSource)
    {
        InitializeComponent();
        tidTagning = new DateTime(DateTime.Now.Ticks + new TimeSpan(0, 0, cookTime).Ticks);
        eggImage.Source = imageSource;
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
        timerDone = false;
        await Navigation.PopAsync(true);
    }

    void UpdateTimerLabel()
    {
        TimeSpan diff = (tidTagning - DateTime.Now);
        if (diff.TotalSeconds < 0)
        {
            TimerDone();
        }
        else
        {
            countdown.Text = diff.Minutes.ToString("00") + ":" + diff.Seconds.ToString("00");
        }
    }

    async void TimerDone()
    {
        timer.Stop();
        countdown.Text = "00:00";
        cookingText.Text = "Your egg is done cooking!";
        timerDone = true;
        ResourceDictionary rd = Application.Current.Resources.MergedDictionaries.First();

        while (timerDone)
        {
            if (countdown.TextColor == (Color)rd["Warning"])
            {
                countdown.TextColor = (Color)rd["PrimaryDark"];
            }
            else
            {
                countdown.TextColor = (Color)rd["Warning"];
            }

            Vibration.Default.Vibrate(350);
            await Task.Delay(1050);
        }
    }
}