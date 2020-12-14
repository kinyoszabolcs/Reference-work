// <copyright file="SaveWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceInvaders
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for SaveWindow.xaml.
    /// </summary>
    public partial class SaveWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveWindow"/> class.
        /// </summary>
        /// <param name="inlogic">Az aktuális logic példány átadása.</param>
        /// <param name="gamewin">Az aktuális game window példány átadása.</param>
        public SaveWindow(GameLogic.GameLogic inlogic, Window gamewin)
        {
            this.InitializeComponent();
            this.Logic = inlogic;
            this.User = new User();
            this.DataContext = this.User;
            this.GameWin = gamewin;
        }

        /// <summary>
        /// Gets or sets the current User.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the current GameLogic copy.
        /// </summary>
        public GameLogic.GameLogic Logic { get; set; }

        /// <summary>
        /// Gets or sets the GameWindow, the program might return to.
        /// </summary>
        public Window GameWin { get; set; }

        private void Send(object sender, RoutedEventArgs e)
        {
            string name = this.User.Username;
            this.Logic.SaveGame(name, this.Logic.Model.Highscore);
            MainWindow mw = new MainWindow();
            mw.Show();
            this.GameWin.Close();
            this.Close();
        }

        private void Resume(object sender, RoutedEventArgs e)
        {
            GameControl.TickTimer.Start();
            this.Close();
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.GameWin.Close();
            this.Close();
        }
    }
}
