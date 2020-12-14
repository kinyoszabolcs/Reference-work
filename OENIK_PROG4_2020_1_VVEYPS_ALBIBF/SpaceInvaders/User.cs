// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpaceInvaders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// The User ObservableObject class.
    /// </summary>
    public class User : ObservableObject
    {
        private string username;

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                this.Set(ref this.username, value);
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the achieved score of the player.
        /// </summary>
        public int Score { get; set; }
    }
}
