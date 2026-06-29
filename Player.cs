using System;
using System.Collections.Generic;
using System.Text;

namespace Projectsodv1202
{
    public abstract class Player
    {
        public string Name { get; set; }
        public string Symbol { get; set; }

        protected Player(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public abstract void MakeMove(Board board);
    }
}
