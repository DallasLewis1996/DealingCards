using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC160_ConsoleMenu;

namespace DealingCards
{
    
    class Dealer
    {
        List<Player> Players = new List<Player>();
        Deck deck = new Deck();


        public void StartGame()
        {
            bool tryAgain = false;
            deck.CreateDeck();
           
            do
            {
                int numOfPlayers;
                Console.Write("How many players?: ");
                string response = Console.ReadLine();
                try
                {
                    numOfPlayers = int.Parse(response);
                    for(int i = 0; i < numOfPlayers; i++)
                    {
                        Console.WriteLine("Player " + (i + 1) + ", What is your name?:");
                        string name = Console.ReadLine();
                        Players.Add(new Player(name));
                    }

                    MenuSelection();

                }
                catch (FormatException e)
                {
                    Console.WriteLine("I'm sorry. That is an incorrect response.");
                    tryAgain = true;
                }
            } while (tryAgain);
        }

        public void MenuSelection()
        {
            List<string> list = new List<string>();
            list.Add("Print the Deck");
            list.Add("Shuffle the Deck");
            list.Add("Deal Cards");
            list.Add("Deal one Card to a Player");
            list.Add("Print the Players");
            list.Add("Set the new Players");

            int selection = CSC160_ConsoleMenu.CIO.PromptForMenuSelection(list,true);

            switch (selection)
            {
                case 1: PrintTheDeck();
                    break;
                case 2: ShuffleTheDeck();
                    break;
                case 3: DealCards();
                    break;
                case 4: DealOneCard();
                    break;
                case 5: PrintPlayers();
                    break;
                case 6: SetNewPlayers();
                    break;
            }
            
            
        }

        public void PrintTheDeck()
        {
            Console.Write(deck.ToString());
            MenuSelection();
        }

        public void ShuffleTheDeck()
        {
            deck.Shuffle();
            MenuSelection();
        }
        
        public void DealCards()
        {
            foreach(Player p in Players)
            {
                p.hand = deck.dealCards();
            }
            MenuSelection();
        }

        public void DealOneCard()
        {
            Console.Write("Which player?: ");
            string nameGiven = Console.ReadLine();

            foreach(Player p in Players)
            {
                if(p.Name == nameGiven)
                {         
                    p.hand = deck.DealOneCard();
                }
     
            }           
            MenuSelection();
        }
        
        public void PrintPlayers()
        {
            foreach(Player p in Players)
            {
                Console.WriteLine(p.ToString());
            }
            MenuSelection();
        }

        public void SetNewPlayers()
        {
            Players = new List<Player>();
            deck = new Deck();
            StartGame();
        }

    }

   
}
