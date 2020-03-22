using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Casino;
using Casino.TwentyOne;


namespace TwentyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            const string casinoName = "Grand Hotel and Casino";
            Console.WriteLine("Welcome to the {0}. Let's start by telling me your name.", casinoName);
            string playerName = Console.ReadLine();
            if (playerName.ToLower() == "admin")
            {
                List<ExceptionEntity> Exceptions = ReadExceptions(); 
                foreach (var exception in Exceptions)
                {
                    Console.Write(exception.Id + " | ");
                    Console.Write(exception.ExceptionType + " | ");
                    Console.Write(exception.ExceptionMessage + " | ");
                    Console.Write(exception.TimeStamp + " | ");
                    Console.WriteLine();
                }
                Console.Read();
                return;
            }
            bool validAnswer = false;
            int bank = 0;
            while (!validAnswer)
            {
                Console.WriteLine("And how much money did you bring today?");
                validAnswer = int.TryParse(Console.ReadLine(), out bank);
                if (!validAnswer) Console.WriteLine("Please enter digits only, no decimals.");
            }

            Console.WriteLine("Hello, {0}. Would you like to join a game of 21 right now?", playerName);
            string answer = Console.ReadLine().ToLower();
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya")    // "||" means or
            {
                Player player = new Player(playerName, bank);   
                player.Id = Guid.NewGuid();                      //**Assigns a unique Id to the player
                using (StreamWriter file = new StreamWriter(@"C:\Users\trmcg\Logs\log.txt", true)) //"true" makes it append to log
                {
                    file.WriteLine(player.Id);
                }
                Game game = new TwentyOneGame();
                game += player;
                player.isActivelyPlaying = true;
                while (player.isActivelyPlaying && player.Balance > 0)    // "&&" and
                {
                    try
                    {
                        game.Play();
                    }
                    catch (FraudException ex)
                    {
                        Console.WriteLine(ex.Message);
                        UpdateDbWithexception(ex);
                        Console.ReadLine();
                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred. Please contact your system administrator.");
                        UpdateDbWithexception(ex);
                        Console.ReadLine();
                        return;
                    }
                }
                game -= player;
                Console.WriteLine("Thank you for playing.");
            }
            Console.WriteLine("Bye for now. Feel free to look around the casino.");
            Console.Read();
        }
        private static void UpdateDbWithexception(Exception ex)
        {

            string connectionString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = TwentyOneGame; 
                                       Integrated Security = True; Connect Timeout = 30; Encrypt = False; 
                                       TrustServerCertificate = False; ApplicationIntent = ReadWrite; 
                                       MultiSubnetFailover = False";
            string queryString = @"INSERT INTO Exceptions (ExceptionType, ExceptionMessage, TimeStamp) VALUES
                                    (@ExceptionType,@ExceptionMessage,@TimeStamp)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();
                command.Parameters["@ExceptionMessage"].Value = ex.Message;
                command.Parameters["@TimeStamp"].Value = DateTime.Now;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        private static List<ExceptionEntity> ReadExceptions()
        {
            string connectionString = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = TwentyOneGame; 
                                       Integrated Security = True; Connect Timeout = 30; Encrypt = False; 
                                       TrustServerCertificate = False; ApplicationIntent = ReadWrite; 
                                       MultiSubnetFailover = False";

            string queryString = @"Select Id, ExceptionType, ExceptionMessage, TimeStamp from Exceptions";

            List<ExceptionEntity> Exceptions = new List<ExceptionEntity>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ExceptionEntity exception = new ExceptionEntity();
                    exception.Id = Convert.ToInt32(reader["Id"]);
                    exception.ExceptionType = reader["ExceptionType"].ToString();
                    exception.ExceptionMessage = reader["ExceptionMessage"].ToString();
                    exception.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                    Exceptions.Add(exception);
                }
                connection.Close();
            }
            return Exceptions;
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


//----------------------------------------------------------//
//string text = "Here is some text.";          //  **using System.IO;**
//File.WriteAllText(@"C:\Users\trmcg\Logs\log.txt", text); //@ says "the following will not have escape characters"

//string text = File.ReadAllText("C:\\Users\\trmcg\\Logs\\log.txt");   //Set breakpoint/run/hover over text
//----------------------------------------------------------//

//-----------------DateTime-Example------------------------//
//DateTime yearOfBirth = new DateTime(2000, 01, 28, 00, 00, 00);  //public DateTime(int year, int month, int day, int hour, int minute, int second)
//DateTime yearOfGraduation = new DateTime(2019, 06, 16, 00, 00, 00);
//TimeSpan ageAtGraduation = yearOfGraduation - yearOfBirth;
//----------------------------------------------------------//


