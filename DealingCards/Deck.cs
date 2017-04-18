using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealingCards
{
    enum rankEnum { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
    enum suitEnum { Hearts, Diamonds, Spades, Clubs }
    class Deck
    {
        int numOfCard = 0;
        const int NUM_CARDS = 52;
        int CardsWanted = 0;
        int cardsUsed = 0;
        private Card[] Cards { get; set; }
        




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
            for(int i = 0; i < 52; i++)
            {
                int r = i + (int)(rand.NextDouble() * (52 - i));
                Card tempCard = Cards[r];
                Cards[r] = Cards[i];
                Cards[i] = tempCard;
            }
        }

        public List<Card> dealCards() //NO ROUND ROBIN -- TRY A BETTER WAY TO SEE IF CARDSWANTED IS KNOWN
        {                             //SEEMS TO BE DEALING THE SAME CARDS TO PLAYERS
            
            bool tryAgain = false;
            List<Card> hand = new List<Card>();
            string input = "";
            if (CardsWanted == 0)
            {
                Console.Write("How many cards would you like to be dealt?: ");
                input = Console.ReadLine();
            }

            do
            {
                try
                {
                    if (CardsWanted == 0)
                    {
                        CardsWanted = int.Parse(input);
                    }
                    tryAgain = false;
                    for (int i = 0; i < CardsWanted; i++)
                    {
                        hand.Add(Cards[i]);
                        cardsUsed++;
                        if(cardsUsed == 52)
                        {
                            i = CardsWanted;
                        }
                    }

                }
                catch(FormatException e)
                {
                    Console.WriteLine("I'm sorry. That was an improper response.");
                    tryAgain = true;
                }

                return hand;

            } while (tryAgain);
        }

        public List<Card> DealOneCard()
        {
            Card tempCard;
            if(cardsUsed == 52)
            {
                Console.WriteLine("I'm sorry. There are no more cards left.");
            }
            else
            {
                cardsUsed++;

            }
            return tempCard; //THIS NEEDS TO BE WORKED ON
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
