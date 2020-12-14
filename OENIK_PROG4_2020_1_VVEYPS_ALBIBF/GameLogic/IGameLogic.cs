// <copyright file="IGameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static Repository.Config;

    /// <summary>
    /// Gamelogic inteface.
    /// </summary>
    public interface IGameLogic
    {
        /// <summary>
        /// Move the player.
        /// </summary>
        /// <param name="d"> Direction.</param>
        void MovePlayer(Direction d);

        /// <summary>
        /// Add enemy wave method.
        /// </summary>
        void AddEnemyWave();

        /// <summary>
        /// Add bullet method.
        /// </summary>
        void AddBullet();

        /// <summary>
        /// Move enemies method.
        /// </summary>
        void MoveEnemies();

        /// <summary>
        /// MoveBullets method.
        /// </summary>
        void MoveBullets();
    }
}
