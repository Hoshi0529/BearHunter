namespace BearHunter;

public partial class SubPage : ContentPage
{
	int ishikawa;
	int kobayashi;
    public SubPage()
    {
        InitializeComponent();
    }

    private async void OnClicked(object sender, EventArgs e)
    {
        // メインページへ移動
        await Shell.Current.GoToAsync("//MainPage");
    }

}