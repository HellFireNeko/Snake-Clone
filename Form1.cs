using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        readonly int SquareSize = 32;
        readonly int GridWidth = 10;
        readonly int GridHeight = 10;
        Bitmap CanvasBitmap;
        Graphics CanvasGraphics;
        GameGrid Game;
        readonly Dictionary<int, Brush> GameColors = new Dictionary<int, Brush>()
        {
            { 0, Brushes.Gray },
            { 1, Brushes.Green },
            { 2, Brushes.GreenYellow },
            { 3, Brushes.Red }
        };
        readonly Timer GameTimer = new Timer();
        int Score = 0;

        Vector2 snakeStartPosition = new Vector2(5, 6);

        public Form1()
        {
            InitializeComponent();

            InitializeCanvas();

            GameTimer.Tick += GameTick;
            GameTimer.Interval = (int)GameSpeed.Value;

            this.KeyDown += InputAction;
        }

        bool CanRestart = true;
        readonly Queue<Direction> MoveQueue = new Queue<Direction>();

        private void InputAction(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
            if (!CanRestart)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        MoveQueue.Enqueue(Direction.Up);
                        return;

                    case Keys.Up:
                        MoveQueue.Enqueue(Direction.Up);
                        return;

                    case Keys.D:
                        MoveQueue.Enqueue(Direction.Right);
                        return;

                    case Keys.Right:
                        MoveQueue.Enqueue(Direction.Right);
                        return;

                    case Keys.S:
                        MoveQueue.Enqueue(Direction.Down);
                        return;

                    case Keys.Down:
                        MoveQueue.Enqueue(Direction.Down);
                        return;

                    case Keys.A:
                        MoveQueue.Enqueue(Direction.Left);
                        return;

                    case Keys.Left:
                        MoveQueue.Enqueue(Direction.Left);
                        return;
                }
            }
        }

        private void TrySetMoveDirection(Direction dir)
        {
            Vector2 Head = Snake.Last();
            int indx = Snake.Count - 2;
            Vector2 neck = Snake.ElementAt(indx);
            switch (dir)
            {
                case Direction.Left:
                    if (MoveDirection != Direction.Right && MoveDirection != dir)
                    {
                        Vector2 Next1 = new Vector2(Head.X + 1, Head.Y);
                        if (!Next1.Compare(neck))
                            MoveDirection = dir;
                    }
                    break;

                case Direction.Right:
                    if (MoveDirection != Direction.Left && MoveDirection != dir)
                    {
                        Vector2 Next2 = new Vector2(Head.X - 1, Head.Y);
                        if (!Next2.Compare(neck))
                            MoveDirection = dir;
                    }
                    break;

                case Direction.Down:
                    if (MoveDirection != Direction.Up && MoveDirection != dir)
                    {
                        Vector2 Next3 = new Vector2(Head.X, Head.Y + 1);
                        if (!Next3.Compare(neck))
                            MoveDirection = dir;
                    }
                    break;

                case Direction.Up:
                    if (MoveDirection != Direction.Down && MoveDirection != dir)
                    {
                        Vector2 Next4 = new Vector2(Head.X, Head.Y - 1);
                        if (!Next4.Compare(neck))
                            MoveDirection = dir;
                    }
                    break;
            }
        }

        private void GameTick(object sender, EventArgs e)
        {
            HandleInputTick();

            SnakeMove();

            RedrawCanvas();
        }

        private void HandleInputTick()
        {
            if (MoveQueue.Count > 0)
                TrySetMoveDirection(MoveQueue.Dequeue());
        }

        readonly Queue<Vector2> Snake = new Queue<Vector2>();
        Direction MoveDirection = Direction.Right;
        int step = 0;

        Direction GetDirection 
        { 
            get
            {
                if (HamilCheck.Checked)
                {
                    return HamiltonianCycle.GetDirection(step);
                }
                else
                {
                    return MoveDirection;
                }
            } 
        }

        private void SnakeMove()
        {
            Vector2 Head = FindHead();

            switch (GetDirection)
            {
                case Direction.Left:
                    Vector2 Next1 = new Vector2(Head.X - 1, Head.Y);
                    MoveLogic(Next1, Head);
                    break;

                case Direction.Right:
                    Vector2 Next2 = new Vector2(Head.X + 1, Head.Y);
                    MoveLogic(Next2, Head);
                    break;

                case Direction.Down:
                    Vector2 Next3 = new Vector2(Head.X, Head.Y + 1);
                    MoveLogic(Next3, Head);
                    break;

                case Direction.Up:
                    Vector2 Next4 = new Vector2(Head.X, Head.Y - 1);
                    MoveLogic(Next4, Head);
                    break;
            }
            
            if (HamilCheck.Checked)
            {
                step++;
                if (step == 100)
                {
                    step = 0;
                }
            }
        }

        private void MoveLogic(Vector2 Next, Vector2 Head)
        {
            if (Next.X >= GridWidth || Next.X < 0 || Next.Y >= GridHeight || Next.Y < 0 || Game.Map[Next.X, Next.Y] == 1)
            {
                GameOver();
            }
            else if (Game.Map[Next.X, Next.Y] == 0)
            {
                Vector2 TailEnd = Snake.Dequeue();
                Snake.Enqueue(Next);
                Game.SetAt(TailEnd, 0);
                Game.SetAt(Head, 1);
                Game.SetAt(Next, 2);
            }
            else if (Game.Map[Next.X, Next.Y] == 3)
            {
                Snake.Enqueue(Next);
                Game.SetAt(Head, 1);
                Game.SetAt(Next, 2);
                CheckIfComplete();
            }
        }

        private void CheckIfComplete()
        {
            bool check = true;
            for (int x = 0; x < GridWidth; x++)
            {
                for (int y = 0; y < GridHeight; y++)
                {
                    if (Game.Map[x, y] == 0)
                        check = false;
                }
            }

            if (check)
            {
                Score += 750;
                ScoreLabel.Text = Score.ToString();
                GameStateLabel.Text = "Win";
                GameTimer.Stop();
                HamilCheck.Enabled = true;
                Start.Enabled = true;
                GameSpeed.Enabled = true;
                CanRestart = true;
            }
            else
            {
                Score += 250;
                ScoreLabel.Text = Score.ToString();
                PlaceNewApple();
            }
        }

        readonly Random random = new Random();

        private void PlaceNewApple()
        {
            Vector2 Position = new Vector2(random.Next(0, GridWidth), random.Next(0, GridHeight));
            while (Snake.Contains(Position))
            {
                Position = new Vector2(random.Next(0, GridWidth), random.Next(0, GridHeight));
            }
            Game.SetAt(Position, 3);
        }

        Vector2 FindHead() => Snake.Last();

        private void GameOver()
        {
            GameStateLabel.Text = "Game over";
            GameTimer.Stop();

            HamilCheck.Enabled = true;
            Start.Enabled = true;
            GameSpeed.Enabled = true;

            CanRestart = true;
        }

        private void InitializeCanvas()
        {
            // Rezise the canvas:
            Canvas.MaximumSize = new Size(GridWidth * SquareSize, GridHeight * SquareSize);
            Canvas.MinimumSize = new Size(GridWidth * SquareSize, GridHeight * SquareSize);
            Canvas.Size = new Size(GridWidth * SquareSize, GridHeight * SquareSize);

            CanvasBitmap = new Bitmap(Canvas.Width, Canvas.Height);

            CanvasGraphics = Graphics.FromImage(CanvasBitmap);

            CanvasGraphics.FillRectangle(Brushes.Gray, 0, 0, Canvas.Width, Canvas.Height);

            Canvas.Image = CanvasBitmap;

            Game = new GameGrid(GridWidth, GridHeight);
        }

        bool draw = true;

        private void RedrawCanvas()
        {
            if (draw)
            {
                CanvasGraphics = Graphics.FromImage(CanvasBitmap);
                for (int x = 0; x < GridWidth; x++)
                {
                    for (int y = 0; y < GridHeight; y++)
                    {
                        CanvasGraphics.FillRectangle(GameColors[Game.Map[x, y]], x * SquareSize, y * SquareSize, SquareSize, SquareSize);
                    }
                }

                Point previousPoint = new Point();
                var snakeArray = Snake.ToArray();
                foreach(var vect in snakeArray)
                {
                    var p = new Point((vect.X * SquareSize) + (SquareSize / 2), (vect.Y * SquareSize) + (SquareSize / 2));
                    if (previousPoint != new Point())
                    {
                        CanvasGraphics.DrawLine(Pens.Black, previousPoint, p);
                    }
                    previousPoint = p;
                }

                Canvas.Image = CanvasBitmap;
            }
        }

        private void Restart()
        {
            HamilCheck.Enabled = false;
            Start.Enabled = false;
            GameSpeed.Enabled = false;
            step = 0;
            Score = 0;
            ScoreLabel.Text = Score.ToString();
            GameStateLabel.Text = "Playing";
            CanRestart = false;
            GameTimer.Stop();

            MoveQueue.Clear();
            Snake.Clear();

            Game.Map = new GameGrid(GridWidth, GridHeight).Map;

            if (HamilCheck.Checked)
            {
                Game.SetAt(6, 9, 1);
                Snake.Enqueue(new Vector2(6, 9));
                Game.SetAt(5, 9, 2);
                Snake.Enqueue(new Vector2(5, 9));
            }
            else
            {
                Game.SetAt(snakeStartPosition.X, snakeStartPosition.Y - 1, 1);
                Snake.Enqueue(new Vector2(snakeStartPosition.X, snakeStartPosition.Y - 1));
                Game.SetAt(snakeStartPosition, 2);
                Snake.Enqueue(snakeStartPosition);
            }

            MoveDirection = Direction.Right;

            PlaceNewApple();

            GameTimer.Start();

            draw = true;
        }

        private void StartEvent(object sender, EventArgs e)
        {
            Restart();
        }

        private void GameSpeed_ValueChanged(object sender, EventArgs e)
        {
            GameTimer.Interval = (int)GameSpeed.Value;
        }
    }
}
