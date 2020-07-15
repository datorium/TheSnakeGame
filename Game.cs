using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    public partial class Game : Form
    {
        Area area = new Area();
        Snake snake = new Snake();
        Timer mainTimer = new Timer();

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
        }




        private void InitializeTimer()
        {
            mainTimer.Interval = 500;
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            snake.Move();
        }

        private void InitializeGame()
        {
            this.Height = 600;
            this.Width = 600;
            
            this.Controls.Add(area);
            area.Top = 100;
            area.Left = 100;
            //area.Location = new Point(100, 100);

            //adding snake body
            snake.Render(this);

            //adding controls
            this.KeyDown += new KeyEventHandler(Game_KeyPress);
        }

        private void Game_KeyPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    snake.HorVelocity = 1;
                    snake.VerVelocity = 0;
                    break;
                case Keys.Down:
                    snake.HorVelocity = 0;
                    snake.VerVelocity = 1;
                    break;
                case Keys.Left:
                    snake.HorVelocity = -1;
                    snake.VerVelocity = 0;
                    break;
                case Keys.Up:
                    snake.HorVelocity = 0;
                    snake.VerVelocity = -1;
                    break;
                case Keys.B:
                    snake.AddPixel(snake.snakePixels[snake.snakePixels.Count - 1].Left, snake.snakePixels[snake.snakePixels.Count - 1].Top);
                    snake.Render(this, -2);
                    break;
            }
        }
    }
}
