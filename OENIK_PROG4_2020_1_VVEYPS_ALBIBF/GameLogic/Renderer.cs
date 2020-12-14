// <copyright file="Renderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Repository;

    /// <summary>
    /// The renderer class.
    /// </summary>
    public class Renderer
    {
        private Typeface font = new Typeface("Arial");
        private Point textLocation = new Point(10, 10);
        private Rect bgRect = new Rect(0, 0, Config.Width, Config.Height);
        private FormattedText formattedText;
        private int oldHighScore = -1;
        private ImageBrush hp1 = new ImageBrush();
        private ImageBrush hp2 = new ImageBrush();
        private ImageBrush hp3 = new ImageBrush();
        private ImageBrush player = new ImageBrush();
        private ImageBrush bgbrush = new ImageBrush();
        private Brush bulletb = Brushes.Cyan;

        private GameModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="Renderer"/> class.
        /// </summary>
        /// <param name="model">The game model that we want to draw on the screen.</param>
        public Renderer(GameModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Method that draws the drawinf context on the screen.
        /// </summary>
        /// <param name="ctx">The drawingContext we want to draw.</param>
        public void BuildDisplay(DrawingContext ctx)
        {
            this.DrawBackground(ctx);
            this.DrawPlayer(ctx);
            this.DrawBullets(ctx);
            this.DrawEnemies(ctx);
            this.DrawText(ctx);
        }

        private void DrawEnemies(DrawingContext ctx)
        {
            string path = Directory.GetCurrentDirectory();
            string[] pathData = path.Split('\\');
            path = string.Empty;

            for (int i = 0; i < pathData.Length - 3; i++)
            {
                path += pathData[i] + "\\";
            }

            path += "GameLogic\\Images\\";

            foreach (Enemy enemy in this.model.Enemies)
            {
                if (enemy.BaseHP == 1)
                {
                    this.hp1.ImageSource = new BitmapImage(new Uri(path + "1hpship.png"));
                    ctx.DrawGeometry(this.hp1, null, new RectangleGeometry(enemy.Area));
                }
                else if (enemy.BaseHP == 2)
                {
                    this.hp2.ImageSource = new BitmapImage(new Uri(path + "2hpship.png"));
                    ctx.DrawGeometry(this.hp2, null, new RectangleGeometry(enemy.Area));
                }
                else if (enemy.BaseHP == 3)
                {
                    this.hp3.ImageSource = new BitmapImage(new Uri(path + "3hpship.png"));
                    ctx.DrawGeometry(this.hp3, null, new RectangleGeometry(enemy.Area));
                }
            }
        }

        private void DrawText(DrawingContext ctx)
        {
            if (this.oldHighScore != this.model.Highscore)
            {
                this.formattedText = new FormattedText(this.model.Highscore.ToString(), System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, this.font, 16, Brushes.Yellow);
            }

            ctx.DrawText(this.formattedText, this.textLocation);
        }

        private void DrawBullets(DrawingContext ctx)
        {
            foreach (Bullet bullet in this.model.Bullets)
            {
                ctx.DrawGeometry(this.bulletb, null, new RectangleGeometry(bullet.Area));
            }
        }

        private void DrawPlayer(DrawingContext ctx)
        {
            string path = Directory.GetCurrentDirectory();
            string[] pathData = path.Split('\\');
            path = string.Empty;

            for (int i = 0; i < pathData.Length - 3; i++)
            {
                path += pathData[i] + "\\";
            }

            path += "GameLogic\\Images\\";

            this.player.ImageSource = new BitmapImage(new Uri(path + "player.png"));
            ctx.DrawGeometry(this.player, null, new RectangleGeometry(this.model.Player.Area));
        }

        private void DrawBackground(DrawingContext ctx)
        {
            string path = Directory.GetCurrentDirectory();
            string[] pathData = path.Split('\\');
            path = string.Empty;

            for (int i = 0; i < pathData.Length - 3; i++)
            {
                path += pathData[i] + "\\";
            }

            path += "GameLogic\\Images\\";

            this.bgbrush.ImageSource = new BitmapImage(new Uri(path + "backg.jpg"));
            ctx.DrawRectangle(this.bgbrush, null, this.bgRect);
        }
    }
}
