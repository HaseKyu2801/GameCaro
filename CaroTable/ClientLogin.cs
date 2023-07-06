using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
namespace CaroTable
{


    
    public partial class ClientLogin : Form
    {
        Player player;
        SocketManager socket;
       

        public ClientLogin()
        {
            InitializeComponent();
             socket = new SocketManager();
          

        }
     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void ClientLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
        public void eQuit()
        {
            Application.Exit();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            eQuit();
        }

        public void button1_Click(object sender, EventArgs e)
        {
           
            
            if (NameLogin.Text != "")
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hãy Chọn Cho Mình Một Cái Tên");
            }
        }

       
        public TextBox getNameBox()
        {
            TextBox namebox = NameLogin;
            return namebox;
        }

        public TextBox getIP()
        {
            TextBox ip = Iptex;
            return ip;
        }

        private void ClientLogin_Load(object sender, EventArgs e)
        {

        }

        private void ClientLogin_Shown(object sender, EventArgs e)
        {
            Iptex.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(Iptex.Text))
            {
                Iptex.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
           
        }

        private void ClientLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Hide();
        }

        private void Iptex_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
