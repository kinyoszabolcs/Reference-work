// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceInvaders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
    using System.Xml.Linq;
    using GameLogic;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private User SelectedUser { get; set; }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            LoadHelper.BaseHighscore = 0;
            GameWindow gw = new GameWindow();
            gw.Show();
            this.Close();
        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {
            this.SelectedUser = this.GameslistBox.SelectedItem as User;
            int score = this.SelectedUser.Score;
            LoadHelper.BaseHighscore = score;
            GameWindow gw = new GameWindow();
            gw.Show();
            this.Close();
        }

        private void ShowHighscores(object sender, RoutedEventArgs e)
        {
            HighScoreLister lister = new HighScoreLister();
            List<int> scores = lister.ListHighscores();
            string show = "Highscores: \n";
            foreach (var item in scores)
            {
                show += item + "\n";
            }

            MessageBox.Show(show);
        }
    }
}
