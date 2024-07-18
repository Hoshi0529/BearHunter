using System;


namespace BearHunter
{
    public partial class MainPage : ContentPage
    {
       
        int count = 0;
        int hoshi;
        int yamann;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            // サブページへ移動
            await Shell.Current.GoToAsync("//NewPage1");
        }

    }

  
}
