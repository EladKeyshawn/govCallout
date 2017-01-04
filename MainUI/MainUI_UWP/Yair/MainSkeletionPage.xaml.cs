using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MainUI_UWP.Yair
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainSkeletionPage : Page
    {
        public MainSkeletionPage()
        {
            this.InitializeComponent();
            //keep it open.
            MySplitViev.IsPaneOpen = true;
            //SplitTogleBtn.IsEnabled = true;
            for (int i = 0; i < 30; i++)
            {


                ListGrid.Children.Add(new RadioButton() { GroupName = "Split", Content = "Button1", Width = 330, Tag = (new TextBlock() { Text = "" }) });
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // this.MyFrame.Navigate(typeof(Views.Home_Page));
            Header.Text = "Home";
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button != null)
            {
                switch (button.Content.ToString())
                {
                    case "Home":
                        //this.MyFrame.Navigate(typeof(Views.Home_Page));
                        break;
                    case "Settings":
                        //this.MyFrame.Navigate(typeof(Views.Settings_Page));
                        break;
                }
                Header.Text = button.Content.ToString();
            }
        }
        private void SplitTogleBtn_Click(object sender, RoutedEventArgs e)
        {
            MySplitViev.IsPaneOpen = !MySplitViev.IsPaneOpen;
        }

        public void setMainWindowList()
        {

        }
    }
}
