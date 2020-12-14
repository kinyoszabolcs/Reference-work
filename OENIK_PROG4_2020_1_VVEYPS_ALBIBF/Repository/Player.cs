// <copyright file="Player.cs" company="PlaceholderCompany">
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
    /// The player class.
    /// </summary>
    public class Player : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="x">The x coordinate of the player.</param>
        /// <param name="y">The y coordinate of the player.</param>
        /// <param name="w">The width of the player.</param>
        /// <param name="h">The hight of the player.</param>
        public Player(double x, double y, double w, double h)
            : base(x, y, w, h)
        {
            this.Dy = 0;
        }
    }
}
