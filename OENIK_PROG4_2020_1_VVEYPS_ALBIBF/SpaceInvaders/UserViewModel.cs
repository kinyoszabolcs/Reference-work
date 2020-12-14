// <copyright file="UserViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceInvaders
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Xml.Linq;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// The User ViewModel.
    /// </summary>
    public class UserViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserViewModel"/> class.
        /// </summary>
        public UserViewModel()
        {
            this.SaveList = new ObservableCollection<User>();
            if (File.Exists("savedgames.xml"))
            {
                XDocument xdoc = XDocument.Load("savedgames.xml");
                foreach (var item in xdoc.Root.Descendants("game"))
                {
                    this.SaveList.Add(new User()
                    {
                        Username = item.Element("name").Value,
                        Score = int.Parse(item.Element("score").Value),
                    });
                }
            }
        }

        /// <summary>
        /// Gets or sets the observable collection of users.
        /// </summary>
        public ObservableCollection<User> SaveList { get; set; }
    }
}
