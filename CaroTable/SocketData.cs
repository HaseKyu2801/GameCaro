using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroTable
{
    [Serializable]
    public class SocketData
    {
        private int command;
        private Point point;
        private string message;
        private string name;

        public int Command { get => command; set => command = value; }
        public Point Point { get => point; set => point = value; }
        public string Message { get => message; set => message = value; }
        public string Name { get => name; set => name = value; }

        public SocketData(int command, Point point, string message = null)
        {
            this.Command = command;
            this.Message = message;
            this.Point = point;      
        }
        public SocketData(int command,string nickname, string message = null)
        {
            this.Command = command;
            this.Message = message;
            this.Name = nickname;
        }
        public SocketData(int command,string message = null)
        {
            this.Command = command;
            this.Message = message;          
        }


    }

    public enum SocketCommand
    {
        SEND_POINT,
        NOTIFY,
        NEW_GAME,
        END_GAME,
        TIME_OUT,
        UNDO,
        QUIT,
        MESSAGE,
        
    }
}
