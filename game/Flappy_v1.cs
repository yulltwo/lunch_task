using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> Pipe1 = new List<int>();
        List<int> Pipe2 = new List<int>();
        int PipeWidth = 55;
        int PipeDifferentY = 140;
        int PipeDifferentX = 180;
        bool start = true;
        bool running;
        int step = 5;
        int OriginalX, OriginalY;
        bool ResetPipes = false;
        int points;
        bool inPipe = false;
        int score;
        int ScoreDifferent;

        private void Die()
        {
            running = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            button1.Visible = true;
            button1.Enabled = true;
            ReadAndShowScore();
            points = 0;
            pictureBox1.Location = new Point(OriginalX, OriginalY);
            ResetPipes = true;
            Pipe1.Clear();
        }

        private void ReadAndShowScore()
        {
            using (StreamReader reader = new StreamReader("Score.ini"))
            {
                score = int.Parse(reader.ReadToEnd());
                reader.Close();
                if (int.Parse(label1.Text) == 0 | int.Parse(label1.Text) > 0)
                {
                    ScoreDifferent = score - int.Parse(label1.Text) + 1;
                }
                if (score < int.Parse(label1.Text))
                {
                    MessageBox.Show(string.Format("Felicitari, ai facut un scor mai mare decat {0}. Noul scor este {1}", score, label1.Text), "Flappy Bird", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (StreamWriter writer = new StreamWriter("Score.ini"))
                    {
                        writer.Write(label1.Text);
                        writer.Close();
                    }
                }
                if (score > int.Parse(label1.Text))
                {
                    MessageBox.Show(string.Format("Iti mai trebuia {0} ca sa depasesti scorul maxim de {1}", ScoreDifferent, score), "Flappy Bird", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (score == int.Parse(label1.Text))
                {
                    MessageBox.Show(string.Format("Ai facut exact {0} (scorul maxim), incearca sa-1 depasesti de data asta", "Flappy Bird", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void StartGame()
        {
            ResetPipes = false;
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            Random random = new Random();
            int num = random.Next(40, this.Height - this.PipeDifferentY);
            int num1 = num + this.PipeDifferentY;
            Pipe1.Clear();
            Pipe1.Add(this.Width);
            Pipe1.Add(num);
            Pipe1.Add(this.Width);
            Pipe1.Add(num1);

            num = random.Next(40, (this.Height - PipeDifferentY));
            num1 = num + PipeDifferentY;
            Pipe2.Clear();
            Pipe1.Add(this.Width + PipeDifferentX);
            Pipe1.Add(num);
            Pipe1.Add(this.Width + PipeDifferentX);
            Pipe1.Add(num1);

            button1.Visible = false;
            button1.Enabled = false;
            running = true;
            Focus();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OriginalX = pictureBox1.Location.X;
            OriginalY = pictureBox1.Location.Y;
            if (!File.Exists("Score.ini"))
            {
                File.Create("Score.ini").Dispose();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Pipe1[0] + +PipeWidth <= 0 | start == true)
            {
                Random rnd = new Random();
                int px = this.Width;
                int py = rnd.Next(40, (this.Height - PipeDifferentY));
                var p2x = px;
                var p2y = py + PipeDifferentY;
                Pipe1.Clear();
                Pipe1.Add(px);
                Pipe1.Add(py);
                Pipe1.Add(p2x);
                Pipe1.Add(p2y);
            }
            else
            {
                Pipe1[0] = Pipe1[0] - 2;
                Pipe1[2] = Pipe1[2] - 2;
            }
            if (Pipe2[0] + +PipeWidth <= 0)
            {
                Random rnd = new Random();
                int px = this.Width;
                int py = rnd.Next(40, (this.Height - PipeDifferentY));
                var p2x = px;
                var p2y = py + PipeDifferentY;
                int[] p1 = { px, py, p2x, p2y };
                Pipe2.Clear();
                Pipe2.Add(px);
                Pipe2.Add(py);
                Pipe2.Add(p2x);
                Pipe2.Add(p2y);
            }
            else
            {
                Pipe2[0] = Pipe2[0] - 2;
                Pipe2[2] = Pipe2[2] - 2;
            }
            if (start == true)
            {
                start = false;
             
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(!ResetPipes && Pipe1.Any() && Pipe2.Any())
            {
                //prima de sus
                e.Graphics.FillRectangle(Brushes.DarkGreen, new Rectangle(Pipe1[0], 0, PipeWidth, Pipe1[1]));
                e.Graphics.FillRectangle(Brushes.DarkGreen, new Rectangle(Pipe1[0] - 10, Pipe1[3] - PipeDifferentY, 75, 15));
                //prima de jos
                e.Graphics.FillRectangle(Brushes.DarkGreen, new Rectangle(Pipe1[2], Pipe1[3], PipeWidth, this.Height - Pipe1[3]));
                e.Graphics.FillRectangle(Brushes.DarkGreen, new Rectangle(Pipe1[2] - 10, Pipe1[3], 75, 15));
                //a doua de sus
                e.Graphics.FillRectangle(Brushes.DarkGreen, new Rectangle(Pipe2[0], 0, PipeWidth, Pipe2[1]));
                e.Graphics.FillRectangle(Brushes.DarkGreen, new Rectangle(Pipe2[0] - 10, Pipe2[3] - PipeDifferentY, 75, 15));                //a doua de jos
                //a doua de jos
                e.Graphics.FillRectangle(Brushes.DarkGreen, new Rectangle(Pipe2[2], Pipe2[3], PipeWidth, this.Height - Pipe2[3]));
                e.Graphics.FillRectangle(Brushes.DarkGreen, new Rectangle(Pipe2[2] - 10, Pipe2[3] - PipeDifferentY, 75, 15));
            }
        }

        private void checkForPoint()
        {
            Rectangle rec = pictureBox1.Bounds;
            Rectangle rec1 = new Rectangle(Pipe1[2] + 20, Pipe1[3] - PipeDifferentY, 15, PipeDifferentY);
            Rectangle rec2 = new Rectangle(Pipe2[2] + 20, Pipe2[3] - PipeDifferentY, 15, PipeDifferentY);
            Rectangle intersect1 = Rectangle.Intersect(rec, rec1);
            Rectangle intersect2 = Rectangle.Intersect(rec, rec2);
            if(!ResetPipes | start)
            {
                if (intersect1 != Rectangle.Empty | intersect2 != Rectangle.Empty)
                {
                    if (!inPipe)
                    {
                        points++;

                     }
                }

           }
        }
    }
}

