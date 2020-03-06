using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {

            Deck deck = new Deck();     //created a variable "deck" from the Deck class. Already has 52 cards from deck constructor
            deck.Shuffle(3);             //Calling the shuffle method from the Deck object class to shuffle (3) times

            foreach (Card card in deck.Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit);
            }
            Console.WriteLine("\n" + deck.Cards.Count + " cards in the deck.");  //"Cards" is a property of deck 
            Console.ReadLine();
        }
    }
}

//Modules to be copied and pasted:
//----------------------------------------------------------//
//****this one doesn't work anymore as is because of changes in player class**//
//Game game = new TwentyOneGame();  //Polymorphism, Game instantiation can inherit TwentyOneGame Attributes. Helpful if many games 
//                                    //.... *Calling an abstract class called "Game" to instatiate "TwentyOneGame"*
//                                    //....this is using superclass method. "Game" class is superclass
//game.Players = new List<string>() { "Jessie", "Bill", "Joe", "Freddie", "Sally"};  
//game.ListPlayers();
//----------------------------------------------------------//

//----------------------------------------------------------//
//game.Play();                     //Calling a play that's outside of superclass that's only accessible to Twentyone game
//----------------------------------------------------------//

//----------------------------------------------------------//
//Game game = new TwentyOneGame();
//game.Players = new List<Player>(); //can't add player list w/{"","",""} anymore bc new add player method(Player class)
//Player player = new Player();
//player.Name = "Jessie";
//game += player;     //same as game = game + player; adds player w/overload operator method(Player class) 
//game -= player;     //removes the same player with operator- Remove method
//----------------------------------------------------------//


//enums
//----------------------------------------------------------//
//DaysOfTheWeek day = DaysOfTheWeek.Friday;

//public enum DaysOfTheWeek
//{
//    Sunday, Monday, Tuesday,
//    Wednesday, Thursday, Friday,
//    Saturday
//}

//ConsoleColor color = ConsoleColor.Red;   //ConsoleColor is a pre-loaded C# enum

//Card card = new Card();
//card.Suit = Suit.Hearts;    //implementing enum from Card.cs
////card.Face = "Two";          //not using enum
//int underlyingValue = (int) Suit.Diamonds;     //Casting Suit.Diamonds to an integer. Will be one per Card.cs Index
//Console.WriteLine(underlyingValue);
//Console.ReadLine();           //Will return 1
//----------------------------------------------------------//


