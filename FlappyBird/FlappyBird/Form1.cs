using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FlappyBird
{
    public partial class ChrisFlappyBird : Form
    {
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;
        public ChrisFlappyBird()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            PipeBottom.Left -= pipeSpeed;
            PipeTop.Left -= pipeSpeed;
            ScoreText.Text = "Score: "+ score;
            if (PipeBottom.Left < -150)
            {
                PipeBottom.Left = 800;
                score++;
            }
            if (PipeTop.Left < -180)
            {
                PipeTop.Left = 950;
                score++;
            }

if(FlappyBird.Bounds.IntersectsWith(PipeBottom.Bounds)|| FlappyBird.Bounds.IntersectsWith(PipeTop.Bounds) || FlappyBird.Bounds.IntersectsWith(Ground.Bounds))
            {
                endGame();
                
            }
            if (score>5)
            {
                pipeSpeed = 15;
            }
            if (FlappyBird.Top<-25)
            {
                endGame();
            }
                
                    }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }

        }
        private void endGame()
        {
            gametimer.Stop();
            ScoreText.Text += " Game over!!";
        }
    }
}