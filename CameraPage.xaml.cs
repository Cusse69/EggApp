namespace EggApp;

public partial class CameraPage : ContentPage
{
	public CameraPage()
	{
		InitializeComponent();
	}

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
		cameraView.Camera = cameraView.Cameras.First();

		MainThread.BeginInvokeOnMainThread(async () =>
		{
			await cameraView.StopCameraAsync();
			await cameraView.StartCameraAsync();
        });
    }

	async void ScanButtonClicked(object sender, EventArgs e)
	{
        await Navigation.PopAsync(true);
    }
}