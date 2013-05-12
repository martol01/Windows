using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NumbugsRBS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int y = 750;
        int x = 100;
        int choice = 0;
        
        //private DispatcherTimer timer = new DispatcherTimer();
        Image imageAnimation = new Image();
        public MainPage()
        {
            this.InitializeComponent();
            canvas.Children.Add(imageAnimation);
            //choice = 1;
            //timer.Tick += timer_Tick;
           // timer.Interval = new TimeSpan(1000);
            //timer.Start();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        
        
        private void elipsePlay_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
                if (this.Frame != null)
                {
                    this.Frame.Navigate(typeof(WelcomePage));
                }
            
        }

        private void elipseAbout_Tapped(object sender, TappedRoutedEventArgs e)
        {
              if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(AboutPage));
            }
        }

        private void captureSettings_Tapped(object sender, TappedRoutedEventArgs e)
        {
          
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(SettingsPage));
            }
        }

        private void captureStats_Tapped(object sender, TappedRoutedEventArgs e)
        {
           
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(StatsPage));
            }
        }

        private void captureHelp_Tapped(object sender, TappedRoutedEventArgs e)
        {
               if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(HelpPage));
            }
        }

         
        
        
             

              

             
    }
}
