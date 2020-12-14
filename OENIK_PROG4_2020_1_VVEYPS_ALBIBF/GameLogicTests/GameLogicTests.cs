// <copyright file="GameLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameLogicTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GameLogic;
    using NUnit.Framework;
    using Repository;
    using static Repository.Config;

    /// <summary>
    /// Logic test class.
    /// </summary>
    [TestFixture]
    public class GameLogicTests
    {
        private GameModel gm;
        private IGameLogic gl;

        /// <summary>
        /// Setup for the test.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            this.gm = new GameModel();
            this.gl = new GameLogic(this.gm);
        }

        /// <summary>
        ///  AddEnemyWave method test.
        /// </summary>
        /// <param name="highscore">player score.</param>
        /// <param name="enemies">number of enemies on the field.</param>
        [TestCase(2, 1)]
        [TestCase(7, 1)]
        [TestCase(15, 1)]
        [TestCase(25, 2)]
        [TestCase(40, 2)]
        [TestCase(60, 2)]
        [TestCase(100, 3)]
        public void AddEnemyTest(int highscore, int enemies)
        {
            this.gm.Enemies.Clear();
            this.gm.Highscore = highscore;
            this.gl.AddEnemyWave();
            Assert.That(this.gm.Enemies.Count, Is.EqualTo(enemies));
        }

        /// <summary>
        /// MovePlayer method test.
        /// </summary>
        /// <param name="direction">The direction of the movement.</param>
        /// <param name="val">The value, of change.</param>
        [TestCase(Direction.Left, -10)]
        [TestCase(Direction.Right, +10)]
        public void MovePlayerTest(Direction direction, int val)
        {
            double begin = this.gm.Player.Area.X;
            this.gl.MovePlayer(direction);

            Assert.That(this.gm.Player.Area.X, Is.EqualTo(begin + val));
        }

        /// <summary>
        /// AddBullet method test.
        /// </summary>
        [Test]
        public void AddBulletTest()
        {
            this.gm.Bullets.Clear();
            this.gl.AddBullet();

            Assert.That(this.gm.Bullets, Is.Not.Empty);
        }

        /// <summary>
        /// MoveBullets method test.
        /// </summary>
        [Test]
        public void MoveBulletsTest()
        {
            this.gm.Bullets.Clear();
            this.gl.AddBullet();
            double begin = this.gm.Bullets.FirstOrDefault().Area.Y;
            this.gl.MoveBullets();
            Assert.That(this.gm.Bullets.FirstOrDefault().Area.Y, Is.EqualTo(begin + this.gm.Bullets.FirstOrDefault().Dy));
        }
    }
}
