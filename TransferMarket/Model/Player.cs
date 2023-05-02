using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player : ModelBase
    {
        public string Name { set; get; }
        public int Age { set; get; }
        public string Nationality { set; get; }
        public string Club { set; get; }
        public string Position { set; get; }
        public string PlayerStatus { set; get; }
        public double Price { set; get; }

        public Player((int, string, int, string, string, string, string, double) player)
        {
            Id = player.Item1;
            Name = player.Item2;
            Age = player.Item3;
            Nationality = player.Item4;
            Club = player.Item5;
            Position = player.Item6;
            PlayerStatus = player.Item7;
            Price = player.Item8;
        }
    }
}
