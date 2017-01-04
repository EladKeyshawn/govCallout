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
using Enums;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MainUI_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

           foreach(var x in Enum.GetValues(typeof(Enums.Ministries)))
            {
                string t = myfunc(x);
                if (t == "Ministry of National Infrastructures Energy and Water Resources") t = "Ministry of National Infrastructures Energy and Water\nResources";
                this.listView.Items.Add(t);
            }

           
        }
    
        public string myfunc(object x)
        {
            string aa = x.ToString();
            return aa.Replace("_"," ");
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AutButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
