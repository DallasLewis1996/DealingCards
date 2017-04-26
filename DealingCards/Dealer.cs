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
        private List<Player> Players = new List<Player>();
        private Deck deck = new Deck();


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
                        do
                        {
                            Console.WriteLine("Player " + (i + 1) + ", What is your name?:");
                            string name = Console.ReadLine();

                            if (name.Trim() == "")
                            {
                                Console.WriteLine("I'm sorry. You must provide a valid name.");
                                tryAgain = true;
                            }
                            else
                            {
                                Players.Add(new Player(name));
                                tryAgain = false;
                            }
                        } while (tryAgain);
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

            Console.WriteLine();
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
            foreach(Player p in Players)
            {
                p.hand = new List<Card>();
            }
            deck.Shuffle();
            MenuSelection();
        }
        
        public void DealCards()
        {
            int numOfCards = 0;
            bool tryAgain = false;
            do
            {
                    Console.Write("How many cards would you like dealt?: ");
                    string input = Console.ReadLine();
                try
                {
                    int tempNum = int.Parse(input);
                    
                    if(numOfCards != tempNum)
                    {
                        Console.WriteLine("I'm sorry there are not enough cards");
                        MenuSelection();
                    }
                    else
                    {
                        numOfCards = tempNum;
                        foreach (Player p in Players)
                        {
                            p.hand = deck.dealCards(p.hand, numOfCards);
                        }
                        MenuSelection();
                    }

                }
                catch
                {
                    Console.WriteLine("That was an improper response.");
                    tryAgain = true;
                }
            } while (tryAgain);
        }

        public void DealOneCard()
        {
            Console.Write("Which player?: ");
            string nameGiven = Console.ReadLine();

            foreach(Player p in Players)
            {
                if(p.Name == nameGiven)
                {         
                    p.hand = deck.DealOneCard(p.hand);
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
