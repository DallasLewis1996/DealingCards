using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealingCards
{
   
    class Program
    {
         static void Main(string[] args)
        {
            PlayGame();
        }

        public static void PlayGame()
        {
            Dealer dealer = new Dealer();
            dealer.StartGame();


            
            
        }
    }

    
}
