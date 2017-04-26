using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealingCards
{
    class Deck
    {
        private enum rankEnum { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
        private enum suitEnum { Hearts, Diamonds, Spades, Clubs }

        private int numOfCard = 0;
        private const int NUM_CARDS = 52;
        private int cardsUsed = 0;
        private Card[] Cards { get; set; }
        private List<Card> hand;

        public void CreateDeck()
        {
            Cards = new Card[NUM_CARDS];
            foreach (suitEnum s in (suitEnum[])Enum.GetValues(typeof(suitEnum)))
            {
                foreach (rankEnum r in (rankEnum[])Enum.GetValues(typeof(rankEnum)))
                {
                    Cards[numOfCard] = new Card(r, s);
                    numOfCard++;
                }
            }
            
        }

        public  void Shuffle()
        {
            Random rand = new Random();
            cardsUsed = 0;
            for(int i = 0; i < 52; i++)
            {
                int r = i + (int)(rand.NextDouble() * (52 - i));
                Card tempCard = Cards[r];
                Cards[r] = Cards[i];
                Cards[i] = tempCard;
            }
        }

        public List<Card> dealCards(List<Card> hand, int num) //NO ROUND ROBIN 
        {                             
            for (int i = 0; i < num; i++)
            {
                hand.Add(Cards[cardsUsed]);
                cardsUsed++;
                if(cardsUsed == 52)
                {
                    i = num;
                }
            }

             return hand;
        }

        public List<Card> DealOneCard(List<Card> hand) 
        {
            if(cardsUsed == 52)
            {
                Console.WriteLine("I'm sorry. There are no more cards left.");
            }
            else
            {
                hand.Add(Cards[cardsUsed]);
                cardsUsed++;
            }

            return hand; 
        }
        public override string ToString()
        {
            string cards = "";
            for (int i = cardsUsed; i < 52; i++)
            {
                cards += Cards[i].ToString() + "\n";
            }
            return cards;
        }
        
    }
}
