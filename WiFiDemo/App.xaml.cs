using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

namespace WiFiDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = CrossConnectivity.Current.IsConnected ? (Page)new MainPage() : new Page1();
        }

        protected override void OnStart()
        {
            base.OnStart();
            CrossConnectivity.Current.ConnectivityChanged += HandleConnectivityChanged;
        }

        private void HandleConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            Type Currentpage = this.MainPage.GetType();
            if(e.IsConnected && Currentpage !=  typeof(MainPage))
            {
                this.MainPage = new MainPage();

            }
            else if (!e.IsConnected && Currentpage != typeof(Page1))
                this.MainPage = new Page1();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
