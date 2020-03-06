using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Deck
    {
        public Deck()  //always use the name of the class it's in for the constructor
        {              //*everything within these curly brackets is part of constructor
            Cards = new List<Card>();
            List<string> Suits = new List<string>() { "Clubs", "Hearts", "Diamonds", "Spades" }; //4
            List<string> Faces = new List<string>()
            {
                "Two", "Three", "Four", "Five", "Six", "Seven",                 //13 (4 * 13 is 52)**number of cards the Deck 
                "Eight", "Nine", "Ten", "Jack", "Queen", "King" , "Ace"         //...constructor will create
            };

            foreach (string face in Faces)    // 13 times the next loop will run *creates "face" variable
            {
                foreach (string suit in Suits)// 4 times 
                {
                    Card card = new Card();   // creates "card" 52 times differently. This value disappears with every loop
                    card.Suit = suit;         // assigns 52 cards with a suit
                    card.Face = face;         // assigns 1 of 13 values 13 times to each of four suits
                    Cards.Add(card);          //  card variable added to Cards list
                }
            }
        }
        public List<Card> Cards { get; set; }

        public void Shuffle(int times = 1)      
        {                                                          
            for (int i = 0; i < times; i++)
            {
                List<Card> TempList = new List<Card>();
                Random random = new Random();

                while (Cards.Count > 0)
                {
                    int randomIndex = random.Next(0, Cards.Count); //picks a random # between 0 - # of cards
                    TempList.Add(Cards[randomIndex]);
                    Cards.RemoveAt(randomIndex);                    //**look up RemoveAt
                }
                Cards = TempList;
            }
        }
    }
}
