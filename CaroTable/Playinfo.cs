using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroTable
{
    public class Playinfo
    {
        private Point point;
        private string name;

        public Point Point { get => point; set => point = value; }
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
        public string Name { get => name; set => name = value; }

        private int currentPlayer;

        public Playinfo(Point point, int currentPlayer)
        { 
            this.CurrentPlayer = currentPlayer;
            this.Point = point;
          // this.Name = name;  
        }
    
    }
}
