﻿using TopShopClient.Pages;

namespace TopShopClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}