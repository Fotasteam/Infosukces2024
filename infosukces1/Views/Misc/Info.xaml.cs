using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Storage;

namespace infosukces1.Views.Misc
{
    public sealed partial class Info : Page
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        public Info()
        {
            this.InitializeComponent();

            if (localSettings.Values["ToggleDataSave"] == null)
                localSettings.Values["ToggleDataSave"] = true;

            ToggleSwitchWlaczZapisDanych.IsOn = (bool)localSettings.Values["ToggleDataSave"];
        }

        private void ToggleSwitchWlaczZapisDanych_Toggled(object sender, RoutedEventArgs e)
        {
            localSettings.Values["ToggleDataSave"] = ToggleSwitchWlaczZapisDanych.IsOn;
            ButtonUsunDane.IsEnabled = ToggleSwitchWlaczZapisDanych.IsOn;
        }

        private void ButtonUsunDane_Click(object sender, RoutedEventArgs e)
        {
            localSettings.Values["currentQuestion"] = 0;
        }
    }
}
