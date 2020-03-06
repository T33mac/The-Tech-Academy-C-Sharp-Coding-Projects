using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public abstract class Game   //A generic class called "Game" *Not 21Game* is easier to inherit."Abstract" cannot be an object
    {                            //...Can only be inherited from
        //Listing properties that types of games will have
        //start to spell prop.. Then tab tab for a generic property template
        public List<Player> Players { get; set; }  //A list of players/People's Names.. Can be Player list b/c we made player class(not string)
        public string Name { get; set; }           //Name of Game
        public string Dealer { get; set; }

        public abstract void Play();  //Abstract method that all inheriting classes must have

        public virtual void ListPlayers()   //add "virtual" keyword to: Method gets inherited by another class
        {                                   //... but inheriting class has ability to override
            foreach (Player player in Players)  //creates a profile player within Players.. changed from ... (string player...
            {
                Console.WriteLine(player);
            }
        }
    }
}
