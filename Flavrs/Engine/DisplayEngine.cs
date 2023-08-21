using System;
using System.Numerics;
using Flavrs.Entities;

namespace Flavrs.Engine
{
    public static class DisplayEngine
    {
        public static void displayFrame(Dealer dealer)
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine("--dealer--");
            Console.Write($"{dealer.name} | Score: {dealer.getScore()}");
            Console.WriteLine($"| {dealer.getHand()}");
            Console.WriteLine($"Status: {dealer.status}");
            Console.WriteLine("--players--");
            for (int i = 0; i < dealer.table?.getNumberOfPlayers(); i++)
            {
                var player = dealer.table.players[i];
                Console.Write($"{player.name} | Score: {player.getScore()}");
                Console.WriteLine($"| {player.getHand()}");
                if (player.status == "active")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (player.status == "bust")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (player.status == "blackjack")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.WriteLine($"Balance: {player.balance} | Bet: {player.bet} | Status: {player.status}");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}

