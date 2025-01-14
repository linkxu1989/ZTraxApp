﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZTraxApp.ViewModels;

namespace ZTraxApp.UserControls
{
    /// <summary>
    /// Interaction logic for Clock.xaml
    /// </summary>
    public partial class Clock : UserControl
    {
        ClockViewModel ViewModel;
        public Clock()
        {
            InitializeComponent();
            ViewModel = new ClockViewModel();
            this.DataContext = ViewModel;
        }
    }
}
