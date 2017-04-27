using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Objects;

namespace MazeGame
{
    public partial class MazeForm : Form
    {
        int levelCount = 1;
        Player player;
        Maze maze;
        TargetObject target;
        private Random random = new Random();

        public MazeForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void MazeGame_Load(object sender, EventArgs e)
        {
            

            this.WindowState = FormWindowState.Maximized;
            //player = new Player(this.DisplayRectangle);
            maze = new Maze(this.DisplayRectangle);

        }

        public void createPlayer()
        {
            int[] Xcoords = maze.XCoordsFreeArray;
            int[] Ycoords = maze.YCoordsFreeArray;

            player = new Player(this.DisplayRectangle, Xcoords[random.Next(1200)], Ycoords[random.Next(1200)]);
        }

        public void createTarget()
        {
            int[] Xcoords = maze.XCoordsFreeArray;
            int[] Ycoords = maze.YCoordsFreeArray;

            target = new TargetObject(this.DisplayRectangle, Xcoords[random.Next(1200)], Ycoords[random.Next(1200)]);
        }

        private void MazeGame_Paint(object sender, PaintEventArgs e)
        {
            
            maze.Draw(e.Graphics);

            if (player == null)
            {
                createPlayer();
            }

            if (target == null)
            {
                createTarget();
            }

            player.Draw(e.Graphics);
            target.Draw(e.Graphics);

            Font myFont = new Font("ComicSans", 24);
            SolidBrush brush = new SolidBrush(Color.Fuchsia);
            String message = "Level: {0}";
            Point p = new Point(730, 10);
            e.Graphics.DrawString(String.Format(message, levelCount.ToString()), myFont, brush, p);
        }

        private void MazeForm_KeyDown(object sender, KeyEventArgs e)
        {

            timer1.Start();
            int[] Xcoords = maze.XCoordsArray;
            int[] Ycoords = maze.YCoordsArray;

            switch (e.KeyCode)
            {
                case Keys.Right:
                    {
                        player.Move(Player.Direction.Right);
                        checkWin();
                        for (int i = 0; i <= Xcoords.Length - 1; i++)
                        {

                            if(player.XPosition == Xcoords[i] && player.YPosition == Ycoords[i])
                            {
                                player.XPosition = (player.XPosition - 14);
                                break;
                            }
                        }                       
                        break;
                    }
                case Keys.Left:
                    {
                        player.Move(Player.Direction.Left);
                        checkWin();
                        for (int i = 0; i <= Xcoords.Length - 1; i++)
                        {

                            if (player.XPosition == Xcoords[i] && player.YPosition == Ycoords[i])
                            {
                                player.XPosition = (player.XPosition + 14);
                                break;
                            }
                        }
                        break;
                    }
                case Keys.Up:
                    {
                        player.Move(Player.Direction.Up);
                        checkWin();
                        for (int i = 0; i <= Xcoords.Length - 1; i++)
                        {
                            if (player.XPosition == Xcoords[i] && player.YPosition == Ycoords[i])
                            {
                                player.YPosition = (player.YPosition + 14);
                                break;
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        player.Move(Player.Direction.Down);
                        checkWin();
                        for (int i = 0; i <= Xcoords.Length - 1; i++)
                        {

                            if (player.XPosition == Xcoords[i] && player.YPosition == Ycoords[i])
                            {
                                player.YPosition = (player.YPosition - 14);
                                break;
                            }
                        }
                        break;
                    }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //HandleCollisions();
            Invalidate();
        }

        bool checkWin()
        {
            if(player.XPosition == target.XPosition && player.YPosition == target.YPosition)
            {               
                levelCount++;
                createTarget();
                createPlayer();
                return true;                      
            }
            return false;
        }
    }
}
