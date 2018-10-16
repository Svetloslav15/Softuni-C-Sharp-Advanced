using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Number_Wars
{
    class Program
    {
        static int turns = 0;
        static void Main(string[] args)
        {
            string[] firstPlayer = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] secondPlayer = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool gameover = false;

            Queue<KeyValuePair<int, char>> firstPlayerDeck = new Queue<KeyValuePair<int, char>>();
            Queue<KeyValuePair<int, char>> secondPlayerDeck = new Queue<KeyValuePair<int, char>>();

            FillStartedDeck(firstPlayer, firstPlayerDeck);
            FillStartedDeck(secondPlayer, secondPlayerDeck);

            while (firstPlayerDeck.Count > 0 && secondPlayerDeck.Count > 0 && !gameover && turns != 1000000)
            {
                turns++;

                var firstCart = firstPlayerDeck.Dequeue();
                int firstDamage = firstCart.Key;
                var secondCart = secondPlayerDeck.Dequeue();
                int secondDamage = secondCart.Key;

                if (firstDamage > secondDamage)
                {
                    firstPlayerDeck.Enqueue(firstCart);
                    firstPlayerDeck.Enqueue(secondCart);
                }
                else if (secondDamage > firstDamage)
                {
                    secondPlayerDeck.Enqueue(secondCart);
                    secondPlayerDeck.Enqueue(firstCart);
                }
                else if (secondDamage == firstDamage)
                {
                    List<KeyValuePair<int, char>> list = new List<KeyValuePair<int, char>>();
                    list.Add(firstCart);
                    list.Add(secondCart);
                    while (!gameover)
                    {
                        if (firstPlayerDeck.Count >= 3 && secondPlayerDeck.Count >= 3)
                        {
                            int firstDem = 0;
                            int secondDem = 0;

                            for (int index = 0; index < 3; index++)
                            {
                                var el1 = firstPlayerDeck.Dequeue();
                                char symbol = el1.Value;
                                list.Add(el1);
                                firstDem += symbol - 96;

                                var el2 = secondPlayerDeck.Dequeue();
                                char symbol2 = el2.Value;
                                list.Add(el2);
                                secondDem += symbol2 - 96;
                            }
                            if (firstDem > secondDem)
                            {
                                FillWiningDeck(firstPlayerDeck, list);
                                break;
                            }
                            else if (secondDem > firstDem)
                            {
                                FillWiningDeck(secondPlayerDeck, list);
                                break;
                            }
                        }
                        else
                        {
                            gameover = true;
                        }
                    }
                }
            }
            if (firstPlayerDeck.Count > secondPlayerDeck.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else if (secondPlayerDeck.Count > firstPlayerDeck.Count)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else if (firstPlayerDeck.Count == secondPlayerDeck.Count)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
        }

        private static void FillStartedDeck(string[] line, Queue<KeyValuePair<int, char>> deck)
        {
            foreach (var card in line)
            {
                var number = int.Parse(card.Substring(0, card.Length - 1));
                var letter = card[card.Length - 1];
                var kvp = new KeyValuePair<int, char>(number, letter);

                deck.Enqueue(kvp);
            }
        }

        private static void FillWiningDeck(Queue<KeyValuePair<int, char>> deck, List<KeyValuePair<int, char>> cards)
        {
            foreach (var card in cards.OrderByDescending(x => x.Key).ThenByDescending(x => x.Value))
            {
                deck.Enqueue(card);
            }
        }
    }
}