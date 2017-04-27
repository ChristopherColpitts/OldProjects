using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    /// <summary>
    /// Create class for a TargetObject
    /// </summary>
    public class TargetObject
    {
        /// <summary>
        /// Get target height
        /// </summary>
        private int ballHeight = 14;
        /// <summary>
        /// get target width
        /// </summary>
        private int ballWidth = 14;

        /// <summary>
        /// get target position
        /// </summary>
        private Rectangle displayArea;
        /// <summary>
        /// get area to build inside 
        /// </summary>
        private Rectangle gameplayArea;

        /// <summary>
        /// directional input for target to move
        /// </summary>
        public enum Direction { Left, Right, Up, Down }

        /// <summary>
        /// create target object
        /// </summary>
        /// <param name="gameplayArea"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public TargetObject(Rectangle gameplayArea, int x, int y)
        {
            displayArea.Width = ballWidth;
            displayArea.Height = ballHeight;

            displayArea.X = x;
            displayArea.Y = y;

            this.gameplayArea = gameplayArea;
        }

        /// <summary>
        /// Draw TargetObject
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {

            SolidBrush brush = new SolidBrush(Color.Red);
            graphics.FillEllipse(brush, displayArea);

        }

        /// <summary>
        /// Get displaye area for object
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return displayArea;
            }
        }

        /// <summary>
        /// Get X position for cooridinates 
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
        /// get Y position for cooridinates 
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

    }
}
