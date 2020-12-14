// <copyright file="EndWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceInvaders
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for EndWindow.xaml.
    /// </summary>
    public partial class EndWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndWindow"/> class.
        /// </summary>
        public EndWindow()
        {
            this.InitializeComponent();
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            GameLogic.LoadHelper.BaseHighscore = 0;
            GameWindow gw = new GameWindow();
            gw.Show();
            this.Close();
        }

        private void Menu(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
