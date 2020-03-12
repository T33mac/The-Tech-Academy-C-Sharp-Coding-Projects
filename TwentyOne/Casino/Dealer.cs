using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Casino
{
    public class Dealer
    {
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public int Balance { get; set; }

        public void Deal(List<Card> Hand)
        {
            Hand.Add(Deck.Cards.First());    //Add to hand list.(Deck is list.Cards are items in Deck. First is first card in deck());
            string card = string.Format(Deck.Cards.First().ToString());
            Console.WriteLine(card + "\n");
            //The following logs to C:\Users\trmcg\Logs\log.txt
            //**public StreamWriter(string path, bool append);
            using (StreamWriter file = new StreamWriter(@"C:\Users\trmcg\Logs\log.txt", true)) //"true" makes it append to log
            {
                file.WriteLine(DateTime.Now);
                file.WriteLine(card);  //line we're writing to file
            }
            //Next removes the added card from the deck
            Deck.Cards.RemoveAt(0); //(zero based) actually first card in the index/list being removed
        }
    }
}
