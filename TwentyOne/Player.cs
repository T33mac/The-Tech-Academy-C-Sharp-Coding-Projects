using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Player
    {
        public List<Card> Hand { get; set; }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }

        public static Game operator +(Game game, Player player)  //adding game and player... Returning a game using an overloaded operator
        {
            game.Players.Add(player);
            return game;    //returning because not a void function
        }
        public static Game operator -(Game game, Player player)
        {
            game.Players.Remove(player);
            return game;    //returning because not a void function
        }
    }
}
