// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using Repository;
    using static Repository.Config;

    /// <summary>
    /// The game logic.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        private static int wavecounter = 101;
        private static Random rnd = new Random();

        /// <summary>
        /// a gamemodel.
        /// </summary>
        private GameModel model;

        private HighscoreSaverAndLoader saver;
        private GameSaver gamesaver = new GameSaver();

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// </summary>
        /// <param name="model">gamemodel.</param>
        public GameLogic(GameModel model)
        {
            this.Model = model;

            this.Model.Highscore = LoadHelper.BaseHighscore;

            this.saver = new HighscoreSaverAndLoader();

            this.Gameover = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the gameover bool.
        /// </summary>
        public bool Gameover { get; set; }

        /// <summary>
        /// Gets or sets the GameModel copy that the logic uses.
        /// </summary>
        public GameModel Model { get => this.model; set => this.model = value; }

        /// <summary>
        /// Move the player.
        /// </summary>
        /// <param name="d">the pressed button.</param>
        public void MovePlayer(Direction d)
        {
            if (d == Direction.Left)
            {
                this.Model.Player.ChangeX(-10);
            }
            else
            {
                this.Model.Player.ChangeX(10);
            }
        }

        /// <summary>
        /// Add enemies.
        /// </summary>
        public void AddEnemyWave()
        {
            int fullwidth = int.Parse(Config.Width.ToString()) - Config.ShipWidth;
            if (this.Model.Highscore < 5)
            {
                this.Model.Enemies.Add(new Enemy(rnd.Next(0, fullwidth), 0, Config.ShipWidth, Config.ShipHeight, 1));
            }
            else if (this.Model.Highscore >= 5 && this.Model.Highscore < 10)
            {
                this.Model.Enemies.Add(new Enemy(rnd.Next(0, fullwidth), 0, Config.ShipWidth, Config.ShipHeight, 2));
            }
            else if (this.Model.Highscore >= 10 && this.Model.Highscore < 20)
            {
                this.Model.Enemies.Add(new Enemy(rnd.Next(0, fullwidth), 0, Config.ShipWidth, Config.ShipHeight, 3));
            }
            else if (this.Model.Highscore >= 20 && this.Model.Highscore < 35)
            {
                this.Model.Enemies.Add(new Enemy(rnd.Next(0, fullwidth / 2), 0, Config.ShipWidth, Config.ShipHeight, 1));
                this.Model.Enemies.Add(new Enemy(rnd.Next(fullwidth / 2, fullwidth), 0, Config.ShipWidth, Config.ShipHeight, 2));
            }
            else if (this.Model.Highscore >= 35 && this.Model.Highscore < 50)
            {
                this.Model.Enemies.Add(new Enemy(rnd.Next(0, fullwidth / 2), 0, Config.ShipWidth, Config.ShipHeight, 1));
                this.Model.Enemies.Add(new Enemy(rnd.Next(fullwidth / 2, fullwidth), 0, Config.ShipWidth, Config.ShipHeight, 3));
            }
            else if (this.Model.Highscore >= 50 && this.Model.Highscore < 75)
            {
                this.Model.Enemies.Add(new Enemy(rnd.Next(0, fullwidth / 2), 0, Config.ShipWidth, Config.ShipHeight, 2));
                this.Model.Enemies.Add(new Enemy(rnd.Next(fullwidth / 2, fullwidth), 0, Config.ShipWidth, Config.ShipHeight, 3));
            }
            else if (this.Model.Highscore >= 75)
            {
                this.Model.Enemies.Add(new Enemy(rnd.Next(0, fullwidth / 3), 0, Config.ShipWidth, Config.ShipHeight, 1));
                this.Model.Enemies.Add(new Enemy(rnd.Next(fullwidth / 3, 2 * fullwidth / 3), 0, Config.ShipWidth, Config.ShipHeight, 2));
                this.Model.Enemies.Add(new Enemy(rnd.Next(2 * fullwidth / 3, fullwidth), 0, Config.ShipWidth, Config.ShipHeight, 3));
            }
        }

        /// <summary>
        /// Adds bullet.
        /// </summary>
        public void AddBullet()
        {
            this.Model.Bullets.Add(new Bullet(this.Model.Player.Area.X + 17, this.Model.Player.Area.Y + 10, Config.BulletW, Config.BulletH));
        }

        /// <summary>
        /// Move the enemies.
        /// </summary>
        public void MoveEnemies()
        {
            if (wavecounter > 100)
            {
                this.AddEnemyWave();
                wavecounter = 0;
            }

            try
            {
                foreach (Enemy item in this.Model.Enemies)
                {
                    item.ChangeY(item.Dy);
                    if (item.Area.Bottom > Config.Height)
                    {
                        this.Model.Enemies.Remove(item);
                        this.Gameover = true;
                    }

                    foreach (var bullet in this.Model.Bullets)
                    {
                        if (item.Area.IntersectsWith(bullet.Area))
                        {
                            item.HP--;
                            this.Model.Bullets.Remove(bullet);
                            if (item.HP <= 0)
                            {
                                this.Model.Highscore += item.BaseHP;
                                this.Model.Enemies.Remove(item);
                            }
                        }
                    }
                }

                wavecounter++;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Move the bullets.
        /// </summary>
        public void MoveBullets()
        {
            try
            {
                foreach (Bullet bullet in this.Model.Bullets)
                {
                    bullet.ChangeY(bullet.Dy);
                    if (bullet.Area.Top < 0)
                    {
                        this.Model.Bullets.Remove(bullet);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Saves the score to highscores.
        /// </summary>
        public void SaveScoreAtEnd()
        {
            if (this.Gameover)
            {
                this.saver.SaveScore(this.Model.Highscore);
            }
        }

        /// <summary>
        /// Saves the game.
        /// </summary>
        /// <param name="name">name of the save.</param>
        /// <param name="score">the score.</param>
        public void SaveGame(string name, int score)
        {
            this.gamesaver.SaveGame(name, score);
        }

        /// <summary>
        /// One tick.
        /// </summary>
        public void OneTick()
        {
            this.MoveEnemies();
            this.MoveBullets();
        }
    }
}
