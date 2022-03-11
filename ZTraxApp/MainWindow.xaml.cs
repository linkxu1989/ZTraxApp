using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ZTraxApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, Uri> allViews = new Dictionary<string, Uri>();
        public MainWindow()
        {
            InitializeComponent();
            //allViews 
            allViews.Add("readers", new Uri("Pages/Readers.xaml", UriKind.Relative));
            allViews.Add("badges", new Uri("Pages/Badges.xaml", UriKind.Relative));
            allViews.Add("events", new Uri("Pages/Events.xaml", UriKind.Relative));
            allViews.Add("assets", new Uri("Pages/Assets.xaml", UriKind.Relative));
            allViews.Add("contacts", new Uri("Pages/Contacts.xaml", UriKind.Relative));
            allViews.Add("locations", new Uri("Pages/Locations.xaml", UriKind.Relative));
            allViews.Add("frontpanel", new Uri("Pages/Frontpanel.xaml", UriKind.Relative));
        }

        /*
        *Readers List
        */
        public void readersButton(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["readers"]);
        }


        /*
        *Badges Reader
        */
        public void badgesButton(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["badges"]);                    
        }

        /*
        *Events
        */
        public void eventsButton(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["events"]);                    
        }


        /*
        *Assets
        */
        public void assetsButton(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["assets"]);
        }

        /*
        *Contacts
        */
        public void contactsButton(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["contacts"]);
        }

        /*
        *Locations
        */
        public void locationsButton(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["locations"]);
        }

        /*
        *Frontpanel
        */
        public void frontpanelButton(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["frontpanel"]);
        }


        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Onsizechanged(object sender, SizeChangedEventArgs e)
        {
            System.Windows.Rect r = new System.Windows.Rect(e.NewSize);
            RectangleGeometry gm = new RectangleGeometry(r, 7, 7); // 40 is radius here
            ((UIElement)sender).Clip = gm;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void BtnNorm_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_reader.Visibility = Visibility.Collapsed;
                tt_badge.Visibility = Visibility.Collapsed;
                tt_event.Visibility = Visibility.Collapsed;
                tt_assets.Visibility = Visibility.Collapsed;
                tt_contacts.Visibility = Visibility.Collapsed;
                tt_location.Visibility = Visibility.Collapsed;
                tt_frontpanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_reader.Visibility = Visibility.Visible;
                tt_badge.Visibility = Visibility.Visible;
                tt_event.Visibility = Visibility.Visible;
                tt_assets.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_location.Visibility = Visibility.Visible;
                tt_frontpanel.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.5;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

    }
}
