using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    /// <summary>
    /// Create class for player object
    /// </summary>
    public class Player
    {

        /// <summary>
        /// Get players height
        /// </summary>
        private int ballHeight = 14;
        /// <summary>
        /// Get Players width
        /// </summary>
        private int ballWidth = 14;

        /// <summary>
        /// Get the display area of Player
        /// </summary>
        private Rectangle displayArea;
        /// <summary>
        /// Get the Area to build the player inside of
        /// </summary>
        private Rectangle gameplayArea;


        /// <summary>
        /// Get directional input for movement
        /// </summary>
        public enum Direction { Left, Right, Up, Down }

        /// <summary>
        /// Initalize a Player Object
        /// </summary>
        /// <param name="gameplayArea"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Player(Rectangle gameplayArea, int x, int y)
        {
            displayArea.Width = ballWidth;
            displayArea.Height = ballHeight;

            displayArea.X = x;
            displayArea.Y = y;

            this.gameplayArea = gameplayArea;
        }

        /// <summary>
        /// Move player object in input direction
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Direction direction)
        {
            if (direction == Direction.Left)
            {
                displayArea.X = (displayArea.X < 14) ? 0 : displayArea.X - 14;
            }
            else if (direction == Direction.Right)
            {
                if (displayArea.Right >= gameplayArea.Right)
                {
                    displayArea.X = gameplayArea.Right - displayArea.Width;
                }
                else
                {
                    displayArea.X += 14;
                }
            }
            else if (direction == Direction.Up)
            {
                displayArea.Y = (displayArea.Y < 14) ? 0 : displayArea.Y - 14;
            }
            else if (direction == Direction.Down)
            {
                if (displayArea.Bottom >= gameplayArea.Bottom)
                {
                    displayArea.Y = gameplayArea.Bottom - displayArea.Height;
                }
                else
                {
                    displayArea.Y += 14;
                }
            }
        }


        /// <summary>
        /// Draw a player object
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            //SolidBrush brush = new SolidBrush(Color.White);
            //graphics.FillRectangle(brush, displayArea);

            SolidBrush brush = new SolidBrush(Color.DarkBlue);
            graphics.FillEllipse(brush, displayArea);

        }

        /// <summary>
        /// Get display area of player
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return displayArea;
            }
        }

        /// <summary>
        /// get X position of player
        /// </summary>
        public int XPosition
        {
            get
            {
                return displayArea.X;
            }
            set
            {
                displayArea.X = value;
            }
        }

        /// <summary>
        /// get Y position of player
        /// </summary>
        public int YPosition
        {
            get
            {
                return displayArea.Y;
            }
            set
            {
                displayArea.Y = value;
            }
        }

        /// <summary>
        /// get width of player
        /// </summary>
        public int Width
        {
            get
            {
                return ballWidth;
            }
        }

        /// <summary>
        /// Get Height of player
        /// </summary>
        public int Height
        {
            get
            {
                return ballHeight;
            }
        }

        //public int Left
        //{
        //    get
        //    {
        //        return displayArea.Left;
        //    }
        //}

        //public int Right
        //{
        //    get
        //    {
        //        return displayArea.Right;
        //    }
        //}

        //public int Top
        //{
        //    get
        //    {
        //        return displayArea.Top;
        //    }
        //}

        //public int Bottom
        //{
        //    get
        //    {
        //        return displayArea.Bottom;
        //    }
        //}

    }
}
