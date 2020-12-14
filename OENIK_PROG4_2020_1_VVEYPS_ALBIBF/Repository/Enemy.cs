// <copyright file="Enemy.cs" company="PlaceholderCompany">
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
    /// The Enemy class.
    /// </summary>
    public class Enemy : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Enemy"/> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="w">The hight.</param>
        /// <param name="h">The Width.</param>
        /// <param name="hp">The hp of the enemy.</param>
        public Enemy(double x, double y, double w, double h, int hp)
            : base(x, y, w, h)
        {
            this.Dx = 0;
            this.Dy = 2;
            this.HP = hp;
            this.BaseHP = hp;
        }

        /// <summary>
        /// Gets or sets the HP of the enemy.
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// Gets or sets the BaseHP of the enemy.
        /// </summary>
        public int BaseHP { get; set; }
    }
}
