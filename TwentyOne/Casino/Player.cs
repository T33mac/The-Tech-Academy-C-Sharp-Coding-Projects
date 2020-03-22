using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class Player
    {
        //Example of Constructor call chain
        public Player(string name) : this(name, 100) //require name but assign beginning balance at 100 if null
        {
            //nothing else required here
        }
        public Player(string name, int beginningBalance)
        {
            Hand = new List<Card>();
            Balance = beginningBalance;
            Name = name;
        }
        private List<Card> _hand = new List<Card>();
        public List<Card> Hand { get {return _hand; } set {_hand = value; } }
        public int Balance { get; set; }
        public string Name { get; set; }
        public bool isActivelyPlaying { get; set; }
        public bool Stay { get; set; }
        public Guid Id { get; set; }
        public bool Bet(int amount)
        {
            if (Balance - amount < 0)
            {
                Console.WriteLine("You do not have enough to place a bet that size.");
                return false;
            }
            else
            {
                Balance -= amount;
                return true;
            }
        }
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
