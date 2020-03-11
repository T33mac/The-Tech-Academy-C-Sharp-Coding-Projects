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
            Console.WriteLine("Welcome to the Grand Hotel and Casino. Let's start by telling me your name.");
            string playerName = Console.ReadLine();
            Console.WriteLine("And how much money did you bring today?");
            int bank = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya")    // "||" means or
            {
                Player player = new Player(playerName, bank);
                Game game = new TwentyOneGame();
                game += player;
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)    // "&&" and
                {
                    game.Play();
                }
                game -= player;
                Console.WriteLine("Thank you for playing.");
            }
            Console.WriteLine("Bye for now. Feel free to look around the casino.");
            Console.Read();
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

//----------------------------------------------------------//
//Deck deck = new Deck();          //traditional counter to count Aces in deck
//int counter = 0;
//foreach (Card card in deck.Cards)
//{
//    if (card.Face == Face.Ace)
//    {
//        counter++;
//    }
//}
//Console.WriteLine(counter);      //traditional counter to count Aces in deck
//----------------------------------------------------------//

//----------------------------------------------------------//
//Deck deck = new Deck();
//int count = deck.Cards.Count(x => x.Face == Face.Ace);  //.Count() is a Lambda function 
//Console.WriteLine(count);                            //Counting everything where x == Face. x could be named anything
//----------------------------------------------------------//

//----------------------------------------------------------//
//List<Card> newList = deck.Cards.Where(x => x.Face == Face.King).ToList();
//foreach (Card card in newList)                                        //Another Lambda function "Where"
//{
//    Console.WriteLine(card.Suit);
//}
//----------------------------------------------------------//

//----------------------------------------------------------//
//List<int> numberList = new List<int>() { 1, 18, 12, 15, 22, 90, 3, 4, 5 };
//int sum = numberList.Sum(x => x + 10); //.Sum(); by itself adds the list together. Function can be added in(Lambda)
//Console.WriteLine(sum);               //.. parenthesis to affect each iteration. this one adds 10 to each item
//----------------------------------------------------------//



