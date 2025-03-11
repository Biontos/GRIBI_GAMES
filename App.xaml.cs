using MauiApp6;

namespace MauiApp6
{
public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new NotionsListPage());
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    } 
}

