using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balnce { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First());    //Add to hand list.(Deck is list.Cards are items in Deck. First is first card in deck());
            Console.WriteLine(Deck.Cards.First().ToString() + "\n");
            //Next removes the added card from the deck
            Deck.Cards.RemoveAt(0); //(zero based) actually first card in the index/list being removed
        }
    }
}
