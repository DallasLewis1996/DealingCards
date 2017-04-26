using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealingCards
{
    class Player
    {
        public string Name { get; set; }

        public List<Card> hand { get; set; } = new List<Card>();

        public Player(string Name)
        {
            this.Name = Name;
            

        }

        public override string ToString()
        {
            string CardsInHand = (Name + ", you have: ");

            if(hand.Count == 0)
            {
                CardsInHand += "no cards a the moment.";
            }
            else
            {
                foreach (Card c in hand)
                {
                    CardsInHand += c.ToString() + ", ";
                }
            }  
            return CardsInHand;
        }
    }
}
