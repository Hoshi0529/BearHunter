namespace BearHunter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override async void OnStart()
        {
            // パーミッションリクエストのメソッドを呼び出す
            await RequestLocationPermissionAsync();
        }

        public async Task RequestLocationPermissionAsync()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            // status をチェックして、許可が出ているか確認
            if (status == PermissionStatus.Granted)
            {
                // パーミッションが許可された場合の処理
            }
            else
            {
                // ユーザーがパーミッションを拒否した場合の処理
                // ここで適切なメッセージを表示したり、代替機能を提案するなどの処理を行う
            }
        }
    }
}
