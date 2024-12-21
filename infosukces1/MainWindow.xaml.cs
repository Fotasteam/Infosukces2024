using Microsoft.UI;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;

namespace infosukces1
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(AppTitleBar);
            Title = "Wirtualna Rzeczywistoœæ";

            this.InitializeComponent();

            MicaBackdrop micaBackdrop = new MicaBackdrop();
            micaBackdrop.Kind = MicaKind.Base;
            this.SystemBackdrop = micaBackdrop;

            NavViewMain.SelectedItem = NavItemDefault;
        }

        private void NavViewMain_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            FrameNavigationOptions navoptions = new FrameNavigationOptions();
            navoptions.TransitionInfoOverride = args.RecommendedNavigationTransitionInfo;
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;
            string tagReplaced;
            if (item.Tag.ToString().Contains("INFORMACJE"))
            {
                tagReplaced = item.Tag.ToString().Replace("INFORMACJE", "");
                contentFrame.NavigateToType(Type.GetType("infosukces1.Views.Informacje." + tagReplaced), null, navoptions);
            }
            else if (item.Tag.ToString().Contains("CIEKAWOSTKI"))
            {
                tagReplaced = item.Tag.ToString().Replace("CIEKAWOSTKI", "");
                contentFrame.NavigateToType(Type.GetType("infosukces1.Views.Ciekawostki." + tagReplaced), null, navoptions);
            }
            else contentFrame.NavigateToType(Type.GetType("infosukces1.Views.Misc." + item.Tag.ToString()), null, navoptions);
        }
    }
}
