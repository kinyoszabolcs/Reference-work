// <copyright file="Bullet.cs" company="PlaceholderCompany">
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
    /// The Bullet class.
    /// </summary>
    public class Bullet : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bullet"/> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="w">The hight.</param>
        /// <param name="h">The Width.</param>
        public Bullet(double x, double y, double w, double h)
            : base(x, y, w, h)
        {
            this.Dy = -20;
            this.Dx = 0;
        }
    }
}
