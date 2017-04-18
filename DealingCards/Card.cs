using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealingCards
{
    class Card
    {
        public Card(rankEnum r, suitEnum s)
        {
            this.Rank = r.ToString();
            this.Suite = s.ToString();
        }

        public string Rank{ get; private set; }
          
        public string Suite { get; private set;}

        public override string ToString()
        {
            return this.Rank + " of " + this.Suite;
            
        }
    }
}
