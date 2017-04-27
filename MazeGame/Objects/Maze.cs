using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    /// <summary>
    /// Class for creating a maze object
    /// </summary>
    public class Maze
    {

        /// <summary>
        /// Maze's display area
        /// </summary>
        private Rectangle displayArea;
        /// <summary>
        /// Area to draw the Maze inside of
        /// </summary>
        private Rectangle gameplayArea;
        /// <summary>
        /// height of horizontal wall
        /// </summary>
        private int horizontalWallHeight = 14;
        /// <summary>
        /// width of horizontal wall
        /// </summary>
        private int horizontalWallWidth = 14;
        /// <summary>
        /// array to hold maze Y coordinates
        /// </summary>
        int[] Ycoords = new int[1352];
        /// <summary>
        /// array to holf maze X coordinates
        /// </summary>
        int[] Xcoords = new int[1352];

        /// <summary>
        /// array to hold free space Y coorinates inside maze inside 
        /// </summary>
        int[] YfreeCoords = new int[1253];
        /// <summary>
        /// array to hold free space X coorinates inside maze inside 
        /// </summary>
        int[] XfreeCoords = new int[1253];


        /// <summary>
        /// Initialize a Maze Object
        /// </summary>
        /// <param name="gameplayArea"></param>
        public Maze(Rectangle gameplayArea)
        {
            displayArea.Width = horizontalWallWidth;
            displayArea.Height = horizontalWallHeight;

            displayArea.X = 0;
            displayArea.Y = 0;

            this.gameplayArea = gameplayArea;

        }

        /// <summary>
        /// Draw the Maze
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {

           // Image im = Image.FromFile("download.jpg");

            using (StreamReader sr = new StreamReader("maze1.txt"))
            {
                String line;
                
                displayArea.Y = 0;
                displayArea.X = 0;
                int i = 0;
                int j = 0;
                
                while ((line = sr.ReadLine()) != null)
                {
                    
                    foreach (char c in line)
                    {
                        if (c == '+' || c == '-')                           
                        {                           
                            displayArea.X += 14;
                            Ycoords[i] = displayArea.Y;
                            Xcoords[i] = displayArea.X;
                            i++;
                            SolidBrush brush = new SolidBrush(Color.DarkGreen);
                            graphics.FillRectangle(brush, displayArea);
                            //graphics.DrawImage(im, displayArea);
                        }
                        else if(c == '|')
                        {
                            
                            displayArea.X += 14;
                            Ycoords[i] = displayArea.Y;
                            Xcoords[i] = displayArea.X;
                            i++;
                            SolidBrush brush = new SolidBrush(Color.DarkGreen);
                            graphics.FillRectangle(brush, displayArea);
                            //graphics.DrawImage(im, displayArea);
                        }
                        else
                        {
                            displayArea.X += 14;
                            YfreeCoords[j] = displayArea.Y;
                            XfreeCoords[j] = displayArea.X;
                            j++;
                        }

                    }
                    displayArea.X = 0;
                    displayArea.Y += 14;

                }
            }
        }

        /// <summary>
        /// Get cooridanes of X position for Maze
        /// </summary>
        public int[] XCoordsArray
        {
            get
            {
                return Xcoords;
            }
        }

        /// <summary>
        /// Get cooridanes of Y position for Maze
        /// </summary>
        public int[] YCoordsArray
        {
            get
            {
                return Ycoords;
            }
        }

        /// <summary>
        /// Get Free space inside of maze X position
        /// </summary>
        public int[] XCoordsFreeArray
        {
            get
            {
                return XfreeCoords;
            }
        }

        /// <summary>
        /// Get Free space inside of maze Y position
        /// </summary>
        public int[] YCoordsFreeArray
        {
            get
            {
                return YfreeCoords;
            }
        }

        /// <summary>
        /// Get the display area for Maze
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return displayArea;
            }
        }

        /// <summary>
        /// get current xposition of Maze
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
        /// get current Y position of maze
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
