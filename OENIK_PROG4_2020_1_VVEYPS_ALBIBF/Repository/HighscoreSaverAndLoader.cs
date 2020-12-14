// <copyright file="HighscoreSaverAndLoader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that is responsible for saving and loading the highscores.
    /// </summary>
    public class HighscoreSaverAndLoader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HighscoreSaverAndLoader"/> class.
        /// </summary>
        public HighscoreSaverAndLoader()
        {
        }

        /// <summary>
        /// Loads the saved scores from the highscores.tyt file.
        /// </summary>
        /// <returns>The saved scores in a string[].</returns>
        public string[] LoadScore()
        {
                string[] lines = File.ReadAllLines("highscores.txt");
                return lines;
        }

        /// <summary>
        /// Saves a score to the highscores.txt file.
        /// </summary>
        /// <param name="input">The score we want to save.</param>
        public void SaveScore(int input)
        {
                StreamWriter sw = new StreamWriter("highscores.txt", true);
                sw.WriteLine(input);
                sw.Close();
        }
    }
}
