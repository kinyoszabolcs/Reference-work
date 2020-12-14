// <copyright file="IGameModel.cs" company="PlaceholderCompany">
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
    /// Interface for the GameModel.
    /// </summary>
    public interface IGameModel
    {
        /// <summary>
        /// Gets or sets the player copy.
        /// </summary>
        Player Player { get; set; }

        /// <summary>
        /// Gets or sets the score achieved.
        /// </summary>
        int Highscore { get; set; }

        /// <summary>
        /// Gets or sets the enemies list.
        /// </summary>
        List<Enemy> Enemies { get; set; }

        /// <summary>
        /// Gets or sets the bullets list.
        /// </summary>
        List<Bullet> Bullets { get; set; }
    }
}
