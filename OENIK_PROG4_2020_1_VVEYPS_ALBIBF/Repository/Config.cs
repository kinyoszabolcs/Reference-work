// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    /// <summary>
    /// The Config class.
    /// </summary>
    public class Config
    {
        private static int shipHeight = 50;

        private static int shipWidth = 35;

        private static int bulletH = 10;

        private static int bulletW = 3;

        private static double width = 300;

        private static double height = 500;

        /// <summary>
        /// The possible directions.
        /// </summary>
        public enum Direction
        {
            /// <summary>
            /// Left.
            /// </summary>
            Left,

            /// <summary>
            /// Right.
            /// </summary>
            Right,
        }

        /// <summary>
        /// Gets or sets the Height of a ship.
        /// </summary>
        public static int ShipHeight { get => shipHeight; set => shipHeight = value; }

        /// <summary>
        /// Gets or sets the Width of a ship.
        /// </summary>
        public static int ShipWidth { get => shipWidth; set => shipWidth = value; }

        /// <summary>
        /// Gets or sets the Height of bullets.
        /// </summary>
        public static int BulletH { get => bulletH; set => bulletH = value; }

        /// <summary>
        /// Gets or sets the Width of bullets.
        /// </summary>
        public static int BulletW { get => bulletW; set => bulletW = value; }

        /// <summary>
        /// Gets or sets the Width of the Game Field.
        /// </summary>
        public static double Width { get => width; set => width = value; }

        /// <summary>
        /// Gets or sets the Height of the Game Field.
        /// </summary>
        public static double Height { get => height; set => height = value; }
    }
}
