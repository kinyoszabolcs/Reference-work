// <copyright file="HighScoreLister.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Repository;

    /// <summary>
    /// Class to list the highscore.
    /// </summary>
    public class HighScoreLister
    {
        private HighscoreSaverAndLoader loader;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighScoreLister"/> class.
        /// </summary>
        public HighScoreLister()
        {
            this.loader = new HighscoreSaverAndLoader();
        }

        /// <summary>
        /// Method to list highscores.
        /// </summary>
        /// <returns>A list of the scores in int.</returns>
        public List<int> ListHighscores()
        {
            string[] scores = this.loader.LoadScore();
            List<int> scoresint = new List<int>();
            foreach (var item in scores)
            {
                scoresint.Add(int.Parse(item));
            }

            return scoresint;
        }
    }
}
