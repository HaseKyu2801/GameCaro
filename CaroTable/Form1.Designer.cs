namespace CaroTable
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            CaroTable = new Panel();
            ConnetTable = new Panel();
            Connect = new Button();
            NamePlay = new TextBox();
            MyName = new Button();
            Draw = new Button();
            Quit = new Button();
            pictureBox1 = new PictureBox();
            CoolDown = new ProgressBar();
            LAN = new TextBox();
            InfoClient = new Panel();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            ChatBox = new Panel();
            Chat = new Button();
            TextChat = new TextBox();
            timerCooldown = new System.Windows.Forms.Timer(components);
            listChat = new ListBox();
            ConnetTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            InfoClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ChatBox.SuspendLayout();
            SuspendLayout();
            // 
            // CaroTable
            // 
            CaroTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CaroTable.BackColor = SystemColors.Control;
            CaroTable.Location = new Point(5, 1);
            CaroTable.Name = "CaroTable";
            CaroTable.Size = new Size(1105, 792);
            CaroTable.TabIndex = 0;
            CaroTable.Paint += CaroTable_Paint;
            // 
            // ConnetTable
            // 
            ConnetTable.Anchor = AnchorStyles.Right;
            ConnetTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ConnetTable.BackColor = SystemColors.Control;
            ConnetTable.Controls.Add(Connect);
            ConnetTable.Controls.Add(NamePlay);
            ConnetTable.Controls.Add(MyName);
            ConnetTable.Controls.Add(Draw);
            ConnetTable.Controls.Add(Quit);
            ConnetTable.Controls.Add(pictureBox1);
            ConnetTable.Controls.Add(CoolDown);
            ConnetTable.Controls.Add(LAN);
            ConnetTable.Location = new Point(1113, 324);
            ConnetTable.Name = "ConnetTable";
            ConnetTable.Size = new Size(332, 237);
            ConnetTable.TabIndex = 1;
            // 
            // Connect
            // 
            Connect.Location = new Point(14, 128);
            Connect.Name = "Connect";
            Connect.Size = new Size(163, 29);
            Connect.TabIndex = 9;
            Connect.Text = "Connect";
            Connect.UseVisualStyleBackColor = true;
            Connect.Click += Connect_Click;
            // 
            // NamePlay
            // 
            NamePlay.Location = new Point(14, 13);
            NamePlay.Name = "NamePlay";
            NamePlay.ReadOnly = true;
            NamePlay.Size = new Size(163, 27);
            NamePlay.TabIndex = 3;
            NamePlay.TextChanged += NamePlay_TextChanged;
            // 
            // MyName
            // 
            MyName.Location = new Point(14, 163);
            MyName.Name = "MyName";
            MyName.Size = new Size(163, 29);
            MyName.TabIndex = 3;
            MyName.UseVisualStyleBackColor = true;
            MyName.Click += UnDo_Click;
            // 
            // Draw
            // 
            Draw.Location = new Point(183, 144);
            Draw.Name = "Draw";
            Draw.Size = new Size(138, 48);
            Draw.TabIndex = 8;
            Draw.Text = "Chơi mới";
            Draw.UseVisualStyleBackColor = true;
            Draw.Click += Draw_Click;
            // 
            // Quit
            // 
            Quit.Location = new Point(14, 198);
            Quit.Name = "Quit";
            Quit.Size = new Size(307, 29);
            Quit.TabIndex = 7;
            Quit.Text = "Đăng Xuất Khỏi Trái Đất";
            Quit.UseVisualStyleBackColor = true;
            Quit.Click += Quit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.AppWorkspace;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(195, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(126, 126);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // CoolDown
            // 
            CoolDown.Location = new Point(14, 45);
            CoolDown.Name = "CoolDown";
            CoolDown.Size = new Size(163, 47);
            CoolDown.TabIndex = 5;
            // 
            // LAN
            // 
            LAN.Location = new Point(14, 98);
            LAN.Name = "LAN";
            LAN.Size = new Size(163, 27);
            LAN.TabIndex = 3;
            LAN.TextChanged += LAN_TextChanged;
            // 
            // InfoClient
            // 
            InfoClient.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            InfoClient.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            InfoClient.BackColor = SystemColors.Control;
            InfoClient.Controls.Add(pictureBox2);
            InfoClient.Controls.Add(label1);
            InfoClient.Location = new Point(1113, 1);
            InfoClient.Name = "InfoClient";
            InfoClient.Size = new Size(332, 322);
            InfoClient.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(49, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(228, 219);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ImageAlign = ContentAlignment.BottomCenter;
            label1.Location = new Point(14, 272);
            label1.Name = "label1";
            label1.Size = new Size(295, 18);
            label1.TabIndex = 2;
            label1.Text = "Rule: 5 point in a line. You will win!";
            label1.Click += label1_Click;
            // 
            // ChatBox
            // 
            ChatBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ChatBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ChatBox.BackColor = SystemColors.ScrollBar;
            ChatBox.Controls.Add(listChat);
            ChatBox.Controls.Add(Chat);
            ChatBox.Controls.Add(TextChat);
            ChatBox.Location = new Point(1113, 558);
            ChatBox.Name = "ChatBox";
            ChatBox.Size = new Size(332, 235);
            ChatBox.TabIndex = 2;
            // 
            // Chat
            // 
            Chat.Location = new Point(240, 192);
            Chat.Name = "Chat";
            Chat.Size = new Size(89, 40);
            Chat.TabIndex = 1;
            Chat.Text = "Enter";
            Chat.UseVisualStyleBackColor = true;
            Chat.Click += Chat_Click;
            // 
            // TextChat
            // 
            TextChat.Location = new Point(3, 200);
            TextChat.Name = "TextChat";
            TextChat.Size = new Size(234, 27);
            TextChat.TabIndex = 0;
            TextChat.TextChanged += textBox3_TextChanged;
            // 
            // timerCooldown
            // 
            timerCooldown.Tick += timerCooldown_Tick;
            // 
            // listChat
            // 
            listChat.FormattingEnabled = true;
            listChat.ItemHeight = 20;
            listChat.Location = new Point(3, 2);
            listChat.Name = "listChat";
            listChat.Size = new Size(326, 184);
            listChat.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(1446, 797);
            Controls.Add(ChatBox);
            Controls.Add(InfoClient);
            Controls.Add(ConnetTable);
            Controls.Add(CaroTable);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Caro Game Test";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Shown += Form1_Shown;
            ConnetTable.ResumeLayout(false);
            ConnetTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            InfoClient.ResumeLayout(false);
            InfoClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ChatBox.ResumeLayout(false);
            ChatBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel CaroTable;
        private Panel ConnetTable;
        private Panel InfoClient;
        private ProgressBar CoolDown;
        private PictureBox pictureBox1;
        private TextBox LAN;
        private Label label1;
        private Panel ChatBox;
        private PictureBox pictureBox2;
        private Button Chat;
        private TextBox TextChat;
        private System.Windows.Forms.Timer timerCooldown;
        private Button Quit;
        private Button Draw;
        private Button MyName;
        private TextBox NamePlay;
        private Button Connect;
        private ListBox listChat;
    }
}