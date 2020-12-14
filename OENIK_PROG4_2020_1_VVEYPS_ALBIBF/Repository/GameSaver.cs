// <copyright file="GameSaver.cs" company="PlaceholderCompany">
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
    using System.Xml.Linq;

    /// <summary>
    /// Class that is responsible for saving a game.
    /// </summary>
    public class GameSaver
    {
        /// <summary>
        /// Method that saves a game to the savedgames.xml file.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="score">The achieved score.</param>
        public void SaveGame(string name, int score)
        {
            if (File.Exists("savedgames.xml"))
            {
                XDocument xdoc = XDocument.Load("savedgames.xml");
                xdoc.Root.Add(new XElement("game", new XElement("name", name), new XElement("score", score)));
                xdoc.Save("savedgames.xml");
            }
            else
            {
                XDocument xdoc = new XDocument();
                xdoc.Add(new XElement("root"));
                xdoc.Root.Add(new XElement("game", new XElement("name", name), new XElement("score", score)));
                xdoc.Save("savedgames.xml");
            }
        }
    }
}
