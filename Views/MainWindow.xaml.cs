﻿namespace MultiLineStringFormatter.Views
{ 
    using MultiLineStringFormatter.ViewModels;
    using System.Windows;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }
}
