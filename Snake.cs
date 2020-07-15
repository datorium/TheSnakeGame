using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    class Snake
    {
        public int Step { get; set; } = 20;
        public int HorVelocity { get; set; } = 0;
        public int VerVelocity { get; set; } = 0;

        public List<PictureBox> snakePixels = new List<PictureBox>();

        public Snake()
        {
            InitializeSnake();
        }

        private void InitializeSnake()
        {
            this.AddPixel(300, 300);
            this.AddPixel(300, 320);
            this.AddPixel(300, 340);
        }

        public void AddPixel(int left, int top)
        {
            PictureBox snakePixel;
            snakePixel = new PictureBox();
            snakePixel.Height = 20;
            snakePixel.Width = 20;
            snakePixel.BackColor = Color.Orange;
            snakePixel.Left = left;
            snakePixel.Top = top;
            snakePixels.Add(snakePixel);
        }

        public void Move()
        {
            if(this.VerVelocity == 0 && this.HorVelocity == 0)
            {
                return;
            }

            for(int i = this.snakePixels.Count-1; i > 0; i--)
            {
                snakePixels[i].Location = snakePixels[i - 1].Location;
            }

            this.snakePixels[0].Left += HorVelocity * Step;
            this.snakePixels[0].Top += VerVelocity * Step;
        }

        public void Render(Form form, int index = -1)
        {
            switch (index)
            {
                case -1: //render all
                    foreach (var sp in snakePixels)
                    {
                        form.Controls.Add(sp);
                        sp.BringToFront();
                    }
                    break;
                case -2: //render the last                    
                    form.Controls.Add(snakePixels[snakePixels.Count - 1]);
                    snakePixels[snakePixels.Count - 1].BringToFront();
                    break;
                default: //render pixel with specific index
                    try
                    {
                        form.Controls.Add(snakePixels[index]);
                        snakePixels[index].BringToFront();
                    }
                    catch
                    {

                    }
                    break;
            }
        }
    }
}
