namespace CaroTable
{
    using System.Net.NetworkInformation;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        SocketManager socket;
        ClientLogin clientLogin;
        private int widthScreen = Screen.PrimaryScreen.WorkingArea.Width;
        private int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;


        #endregion


        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
            MessageBox.Show($"{widthScreen}x{heightScreen}");
            if (widthScreen == 1366 && heightScreen == 720)
            {
                Size = new Size(1097, 605);

                CaroTable.Location = new Point(4, 1);
                CaroTable.Size = new Size(809, 569);

                InfoClient.Location = new Point(815, 1);
                InfoClient.Size = new Size(266, 242);
                pictureBox2.Location = new Point(43, 22);
                pictureBox2.Size = new Size(200, 164);
                label1.Location = new Point(12, 204);
                label1.Size = new Size(240, 15);

                ConnetTable.Location = new Point(815, 244);
                ConnetTable.Size = new Size(266, 178);
                pictureBox1.Location = new Point(133, 10);
                pictureBox1.Size = new Size(110, 94);
                NamePlay.Location = new Point(12, 10);
                NamePlay.Size = new Size(100, 23);
                CoolDown.Location = new Point(12, 43);
                CoolDown.Size = new Size(100, 35);
                LAN.Location = new Point(12, 74);
                LAN.Size = new Size(100, 23);
                Connect.Location = new Point(12, 96);
                Connect.Size = new Size(100, 22);
                MyName.Location = new Point(12, 122);
                MyName.Size = new Size(100, 22);
                Draw.Location = new Point(122, 108);
                Draw.Size = new Size(121, 36);
                Quit.Location = new Point(12, 148);
                Quit.Size = new Size(242, 22);




                ChatBox.Location = new Point(815, 423);
                ChatBox.Size = new Size(266, 142);
                listChat.Location = new Point(4, 2);
                listChat.Size = new Size(262, 114);
                TextChat.Location = new Point(4, 117);
                TextChat.Size = new Size(201, 23);
                Chat.Location = new Point(206, 117);
                Chat.Size = new Size(60, 20);



                // MessageBox.Show($"{widthScreen}x{heightScreen}");

                ChessBoard = new ChessBoardManager(CaroTable, NamePlay, pictureBox1, MyName);
                ChessBoard.EndedGame += ChessBoard_EndedGame;
                ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;


                CoolDown.Step = Cons.COOL_DOWN_STEP;
                CoolDown.Maximum = Cons.COOL_DOWN_TIME;
                CoolDown.Value = 0;

                timerCooldown.Interval = Cons.COOL_DOWN_INTERVAL;

                socket = new SocketManager();
                NewGame();//CaroTable.Enabled = false;


            }
            else
            {
                ChessBoard = new ChessBoardManager(CaroTable, NamePlay, pictureBox1, MyName);
                ChessBoard.EndedGame += ChessBoard_EndedGame;
                ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;


                CoolDown.Step = Cons.COOL_DOWN_STEP;
                CoolDown.Maximum = Cons.COOL_DOWN_TIME;
                CoolDown.Value = 0;

                timerCooldown.Interval = Cons.COOL_DOWN_INTERVAL;

                socket = new SocketManager();
                NewGame();
                CaroTable.Enabled = false;
            }
            MyName.Enabled = false;
            Draw.Enabled = false;
        }

        #region
        void ChessBoard_PlayerMarked(object sender, ButtonClickEvent e)
        {
            timerCooldown.Start();
            CaroTable.Enabled = false;
            CoolDown.Value = 0;

            socket.Send(new SocketData((int)SocketCommand.SEND_POINT, e.Clickedpoint, ""));

            Listen();


        }

        void Endgame()
        {
            timerCooldown.Stop();
            CaroTable.Enabled = false;
            MyName.Enabled = false;

            if (NamePlay.Text == "Đối Thủ")
            {
                MessageBox.Show("Bạn Thắng!");
                Draw.Enabled = true;
            }
            else
            {
                MessageBox.Show("Bạn Đã Thua!");
                Draw.Enabled = true;
            }

            ChessBoard.RestartList();

        }

        void EndgameTO()
        {
            string nguoichoi = ChessBoard.A;
            timerCooldown.Stop();
            CaroTable.Enabled = false;
            //UnDo.Enabled = false;

        }
        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            socket.Send(new SocketData((int)SocketCommand.END_GAME, new Point(), ""));
            Endgame();

        }

        private void timerCooldown_Tick(object sender, EventArgs e)
        {
            CoolDown.PerformStep();

            if (CoolDown.Value >= CoolDown.Maximum)
            {

                EndgameTO();
                socket.Send(new SocketData((int)SocketCommand.TIME_OUT, new Point(), ""));

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // NamePlayer.Text = nameLog;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //  NamePlayer.Text = ;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void CaroTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void NewGame()
        {
            CoolDown.Value = 0;
            timerCooldown.Stop();
            ChessBoard.DrawChessBoard();
            Draw.Enabled = false;
        }



       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Bạn Chắc Chứ :v", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, new Point(), ""));

                }
                catch
                {

                }
            }

        }
        public void Undo()
        {
            ChessBoard.Undo();
            CoolDown.Value = 0;
        }

        private void UnDo_Click(object sender, EventArgs e)
        {
            Undo();
        }








        private void LAN_TextChanged(object sender, EventArgs e)
        {
        }

        void Listen()
        {

            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Recevie();

                    ProcessData(data);

                }
                catch (Exception e)
                {

                }

            });

            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.MESSAGE:

                    this.Invoke((MethodInvoker)(() =>
                    {
                        AddMessageToListBox($"{data.Name}: {data.Message}");
                    }));
                    break;

                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        //ChessBoard.ChangeName();
                        NewGame();
                        CaroTable.Enabled = false;
                        Draw.Enabled = false;
                    }));
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        CoolDown.Value = 0;
                        CaroTable.Enabled = true;
                        timerCooldown.Start();
                        ChessBoard.OrtherPlayerMark(data.Point);

                    }));
                    break;
                case (int)SocketCommand.END_GAME:

                    break;
                case (int)SocketCommand.TIME_OUT:
                    {
                        MessageBox.Show("Hết giờ!");
                    }
                    break;
                case (int)SocketCommand.UNDO:
                    Undo();
                    CoolDown.Value = 0;

                    break;
                case (int)SocketCommand.QUIT:
                    timerCooldown.Stop();
                    MessageBox.Show("Đối Thủ của bạn đã chạy >0<");
                    break;
                default:
                    break;
            }

            Listen();
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            NewGame();
            socket.Send(new SocketData((int)SocketCommand.NEW_GAME, new Point(), ""));
            CaroTable.Enabled = true;
        }

        private void AddMessageToListBox(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddMessageToListBox), message);
            }
            else
            {
                listChat.Items.Add(message);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            LAN.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(LAN.Text))
            {
                LAN.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }


        }

        private void Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        #endregion

        private void NamePlay_TextChanged(object sender, EventArgs e)
        {

        }

        private void Connect_Click(object sender, EventArgs e)
        {
            socket.IP = LAN.Text;
            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                CaroTable.Enabled = true;
                Draw.Enabled = false;
                Connect.Enabled = false;
                socket.CreateServer();


            }
            else
            {
                socket.isServer = false;

                CaroTable.Enabled = false;
                Draw.Enabled = false;
                Connect.Enabled = false;
                ChessBoard.ChangeName();
                NamePlay.Text = "Đối Thủ";

                Listen();
            }


        }

        private void Chat_Click(object sender, EventArgs e)
        {
            socket.Send(new SocketData((int)SocketCommand.MESSAGE, MyName.Text, TextChat.Text));
            
            AddMessageToListBox($"{MyName.Text} : {TextChat.Text}");

            TextChat.Clear();
        }
    }
}