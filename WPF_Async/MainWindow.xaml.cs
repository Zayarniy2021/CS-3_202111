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

namespace WPF_Async
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnButton1_Click(object sender, RoutedEventArgs e)
        {
            lblLabel.Content = "";
            await System.Threading.Tasks.Task.Factory.StartNew(() => {
                this.Dispatcher.Invoke(() => lblLabel.Content = "Start work");
                
                System.Threading.Thread.Sleep(10000);

                });
            lblLabel.Content = "Done!";
        }
    }
}
