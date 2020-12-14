// <copyright file="LoadHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameLogic
{
    /// <summary>
    /// Static class that helps to get the right highscore value when starting a new game window.
    /// </summary>
    public static class LoadHelper
    {
        /// <summary>
        /// The base score value of the starting game.
        /// </summary>
        private static int baseHighscore = 0;

        /// <summary>
        /// Gets or sets the base score value of the starting game.
        /// </summary>
        public static int BaseHighscore { get => baseHighscore; set => baseHighscore = value; }
    }
}
