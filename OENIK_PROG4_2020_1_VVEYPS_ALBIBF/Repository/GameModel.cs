// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The GameModel class.
    /// </summary>
    public class GameModel : IGameModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// </summary>
        public GameModel()
        {
            this.Player = new Player(Config.Width / 2, Config.Height - Config.ShipHeight, Config.ShipWidth, Config.ShipHeight);
            this.Bullets = new List<Bullet>();
            this.Enemies = new List<Enemy>();
        }

        /// <summary>
        /// Gets or sets the score of the current game.
        /// </summary>
        public int Highscore { get; set; }

        /// <summary>
        /// Gets or sets the Player copy of the current game.
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// Gets or sets the Bullets list of the current game.
        /// </summary>
        public List<Bullet> Bullets { get; set; }

        /// <summary>
        /// Gets or sets the Enemies list of the current game.
        /// </summary>
        public List<Enemy> Enemies { get; set; }
    }
}
