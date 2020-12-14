// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceInvaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Threading;
    using GameLogic;
    using Repository;

    /// <summary>
    /// Game controll class.
    /// </summary>
    public class GameControl : FrameworkElement
    {
        private static DispatcherTimer tickTimer;
        private GameLogic logic;
        private GameModel model;
        private Renderer renderer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControl"/> class.
        /// </summary>
        public GameControl()
        {
            this.Loaded += this.GameControl_Loaded;
        }

        /// <summary>
        /// Gets or sets the timer for the game.
        /// </summary>
        public static DispatcherTimer TickTimer { get => tickTimer; set => tickTimer = value; }

        /// <summary>
        /// Overrides OnRender method.
        /// </summary>
        /// <param name="drawingContext">the DrawingContext, that needs to be drawn.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null)
            {
                this.renderer.BuildDisplay(drawingContext);
            }
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.model = new GameModel();
            this.logic = new GameLogic(this.model);
            this.renderer = new Renderer(this.model);

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                TickTimer = new DispatcherTimer();
                TickTimer.Interval = TimeSpan.FromMilliseconds(25);
                TickTimer.Tick += this.TickTimer_Tick;
                TickTimer.Start();
                win.KeyDown += this.Win_KeyDown;
            }

            this.InvalidateVisual();
        }

        private void Win_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.A: this.logic.MovePlayer(Config.Direction.Left); break;
                case System.Windows.Input.Key.D: this.logic.MovePlayer(Config.Direction.Right); break;
                case System.Windows.Input.Key.Space: this.logic.AddBullet(); break;
                case System.Windows.Input.Key.Escape: this.SaveGame(); break;
            }

            this.InvalidateVisual();
        }

        private void SaveGame()
        {
            TickTimer.Stop();
            SaveWindow sw = new SaveWindow(this.logic, Window.GetWindow(this));
            sw.Show();
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            this.logic.OneTick();
            if (this.logic.Gameover)
            {
                TickTimer.Stop();
                this.logic.SaveScoreAtEnd();
                EndWindow go = new EndWindow();
                go.Show();
                Window.GetWindow(this).Close();
            }

            this.InvalidateVisual();
        }
    }
}
