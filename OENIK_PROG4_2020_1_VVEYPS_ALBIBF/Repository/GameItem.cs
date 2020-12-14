// <copyright file="GameItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    /// <summary>
    /// The GameItem class.
    /// </summary>
    public class GameItem
    {
        private Rect area;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameItem"/> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="w">The hight.</param>
        /// <param name="h">The Width.</param>
        public GameItem(double x, double y, double w, double h)
        {
            this.area = new Rect(x, y, w, h);
            this.Dx = 5;
            this.Dy = 5;
        }

        /// <summary>
        /// Gets the area of a GameItem copy.
        /// </summary>
        public Rect Area
        {
            get { return this.area; }
        }

        /// <summary>
        /// Gets or sets the speed in x direction.
        /// </summary>
        public int Dx { get; set; }

        /// <summary>
        /// Gets or sets the speed in y direction.
        /// </summary>
        public int Dy { get; set; }

        /// <summary>
        /// Changes the x coordinate of a GameItem copy.
        /// </summary>
        /// <param name="diff">The value of changing.</param>
        public void ChangeX(int diff)
        {
            this.area.X += diff;
        }

        /// <summary>
        /// Changes the y coordinate of a GameItem copy.
        /// </summary>
        /// <param name="diff">The value of changing.</param>
        public void ChangeY(int diff)
        {
            this.area.Y += diff;
        }

        /// <summary>
        /// Sets the coordinates of a GameItem copy.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public void SetXY(int x, int y)
        {
            this.area.X = x;
            this.area.Y = y;
        }
    }
}
