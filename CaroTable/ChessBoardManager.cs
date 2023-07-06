using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace CaroTable
{
    public class ChessBoardManager
    {
        #region Properties

        private int widthScreen = Screen.PrimaryScreen.WorkingArea.Width;
        private int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;
        private Panel chessBoard;
        public Panel ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }
        private List<Player> player;
        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }

        private TextBox playerName;

        private PictureBox playerPicture;

        private List<List<Button>> matrix;
        public int Currentplayer { get { return currentplayer; } set { currentplayer = value; } }

        public TextBox PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        Button myname;
        public Button MyName
        {
            get { return myname; }
            set { myname = value; }
        }

        public PictureBox PlayerPicture { get => playerPicture; set => playerPicture = value; }
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }
        public Stack<Playinfo> PlayTimeLine { get { return playTimeLine; } set { playTimeLine = value; } }

        public string A { get => a; set => a = value; }
        public string B { get => b; set => b = value; }

        private int currentplayer;

        private event EventHandler<ButtonClickEvent> playerMarked;
        public event EventHandler<ButtonClickEvent> PlayerMarked
        {
            add { playerMarked += value; }
            remove { playerMarked -= value; }
        }

        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add { endedGame += value; }
            remove { endedGame -= value; }
        }
        string a;

        string b = "Người Chơi Giấu Tên";

        ClientLogin client = new ClientLogin();   

        private Stack<Playinfo> playTimeLine;

        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard, TextBox player, PictureBox mark,Button myname)
        {

            client.ShowDialog();
            string p1 = "Bạn";
            string p2 = "Đối Thủ";
            
            this.A = p1;
            this.ChessBoard = chessBoard;
            this.PlayerName = player;
            this.MyName = myname;
            this.PlayerPicture = mark;
            this.Player = new List<Player>()
            {
                new Player(p1, Image.FromFile(Application.StartupPath + "\\Resources\\X.png")),
                new Player(p2, Image.FromFile(Application.StartupPath + "\\Resources\\O.png")),
            };

            this.MyName.Text = p1;
                           
                
                   
        }



        #endregion

        #region Methods




        public void DrawChessBoard()
        {
            if (widthScreen == 1366 && heightScreen == 720)
            {
                ChessBoard.Enabled = true; PlayTimeLine.Clear();
                ChessBoard.Controls.Clear();

                PlayTimeLine = new Stack<Playinfo>();

                Currentplayer = 0;

                ChangePlayer();

                Matrix = new List<List<Button>>();

                Button old = new Button() { Width = 0, Location = new Point(0, 0) };
                for (int i = 0; i < Cons.CB_H; i++)
                {
                    Matrix.Add(new List<Button>());

                    for (int j = 0; j < Cons.CB_W; j++)
                    {
                        Button btn = new Button()
                        {
                            Width = Cons.Chess_W2,
                            Height = Cons.Chess_H2,
                            Location = new Point(old.Location.X + old.Width, old.Location.Y),
                            BackgroundImageLayout = ImageLayout.Stretch,
                            Tag = i.ToString()

                        };
                        btn.Click += Btn_Click;


                        ChessBoard.Controls.Add(btn);

                        Matrix[i].Add(btn);

                        old = btn;
                    }
                    old.Location = new Point(0, old.Location.Y + Cons.Chess_H2);
                    old.Width = 0;
                    old.Height = 0;
                }
            }
           else
            {
                ChessBoard.Enabled = true;
                ChessBoard.Controls.Clear();

                PlayTimeLine = new Stack<Playinfo>();

                Currentplayer = 0;

                ChangePlayer();

                Matrix = new List<List<Button>>();

                Button old = new Button() { Width = 0, Location = new Point(0, 0) };
                for (int i = 0; i < Cons.CB_H; i++)
                {
                    Matrix.Add(new List<Button>());

                    for (int j = 0; j < Cons.CB_W; j++)
                    {
                        Button btn = new Button()
                        {
                            Width = Cons.Chess_W,
                            Height = Cons.Chess_H,
                            Location = new Point(old.Location.X + old.Width, old.Location.Y),
                            BackgroundImageLayout = ImageLayout.Stretch,
                            Tag = i.ToString()

                        };
                        btn.Click += Btn_Click;


                        ChessBoard.Controls.Add(btn);

                        Matrix[i].Add(btn);

                        old = btn;
                    }
                    old.Location = new Point(0, old.Location.Y + Cons.Chess_H);
                    old.Width = 0;
                    old.Height = 0;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
                return;

            Mark(btn);

            PlayTimeLine.Push(new Playinfo(GetChessPoint(btn), Currentplayer));

            Currentplayer = Currentplayer == 1 ? 0 : 1;

            ChangePlayer();

            if (playerMarked != null)
            {
                playerMarked(this, new ButtonClickEvent(GetChessPoint(btn)));

            }

            if (isEndGame(btn))
            {
                EndGame();
            }

        }

        public void EndGame()
        {
            if (endedGame != null)
            {
                endedGame(this, new EventArgs());
            }
        }
        private bool isEndGame(Button btn)
        {
            return isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimary(btn) || isEndSub(btn);
        }

        private Point GetChessPoint(Button btn)
        {


            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);

            Point point = new Point(horizontal, vertical);

            return point;
        }

        private bool isEndHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countLeft = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;
            }
            int countRight = 0;
            for (int i = point.X + 1; i < Cons.CB_W; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                    break;


            }
            return countLeft + countRight == 5;
        }

        private bool isEndVertical(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBottom = 0;
            for (int i = point.Y + 1; i < Cons.CB_H; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;


            }
            return countTop + countBottom == 5;
        }

        private bool isEndPrimary(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;

                if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBottom = 0;
            for (int i = 1; i <= Cons.CB_W - point.X; i++)
            {
                if (point.Y + i >= Cons.CB_H || point.X + i >= Cons.CB_W)
                    break;

                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }
            return countTop + countBottom == 5;
        }

        private bool isEndSub(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i > Cons.CB_W || point.Y - i < 0)
                    break;

                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else break;
            }

            int countBottom = 0;
            for (int i = 1; i <= Cons.Chess_W - point.X; i++)
            {
                if (point.Y + i >= Cons.CB_H || point.X - i < 0)
                    break;

                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else break;
            }
            return countTop + countBottom == 5;
        }



        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[Currentplayer].Mark;


        }
        private void ChangePlayer()
        {
            PlayerName.Text = Player[Currentplayer].Name;
            PlayerPicture.Image = Player[Currentplayer].Mark;
        }

        public void ChangeName()
        {
            Player.Reverse();

        }

        public void RestartList()
        {
            Player.Reverse();
        }
        

        public bool Undo()
        {
            if (PlayTimeLine.Count <= 0)
                return false;

            bool isUndo1 = UndoAStep();
            bool isUndo2 = UndoAStep();

            Playinfo oldPoint = PlayTimeLine.Peek();
            Currentplayer = oldPoint.CurrentPlayer == 1 ? 0 : 1;

            return isUndo1 && isUndo2;
        }

        private bool UndoAStep()
        {
            if (PlayTimeLine.Count <= 0)
                return false;

            Playinfo oldPoint = PlayTimeLine.Pop();
            Button btn = Matrix[oldPoint.Point.Y][oldPoint.Point.X];

            btn.BackgroundImage = null;

            if (PlayTimeLine.Count <= 0)
            {
                Currentplayer = 0;
            }
            else
            {
                oldPoint = PlayTimeLine.Peek();
            }

            ChangePlayer();

            return true;
        }

        public void OrtherPlayerMark(Point point)
        {
            
            Button btn = Matrix[point.Y][point.X];
            if (btn.BackgroundImage != null)
                return;
           
            Mark(btn);

            PlayTimeLine.Push(new Playinfo(GetChessPoint(btn), Currentplayer));

            Currentplayer = Currentplayer == 1 ? 0 : 1;

            ChangePlayer();

            if (isEndGame(btn))
            {
                EndGame();
            }
        }





        #endregion

        

    }
    public class ButtonClickEvent : EventArgs
    {
        private Point clickedpoint;

        public Point Clickedpoint { get => clickedpoint; set => clickedpoint = value; }
        public ButtonClickEvent(Point point)
        {
            this.Clickedpoint = point;
        }
    }
}
