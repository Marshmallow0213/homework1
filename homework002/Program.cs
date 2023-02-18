using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] all = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] computers = new int[4];
            int A, B;
            string welcome = "";
            do
            {
                Console.WriteLine("1A2B的遊戲");
                Random computer = new Random();
                for (int i = 0; i < 4; i++)
                {
                    computers[i] = computer.Next(0, 10);
                }
                var difference = all.Intersect(computers);

                while (difference.Count() < 4)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        computers[j] = computer.Next(0, 10);
                    }
                }

                do
                {
                    Console.WriteLine("請輸入4個數字");
                    int[] players = new int[4];
                    int player = int.Parse(Console.ReadLine());
                    players[0] = player / 1000;
                    players[1] = (player % 1000) / 100;
                    players[2] = (player % 100) / 10;
                    players[3] = player % 10;
                    A = 0;
                    B = 0;
                    bool right;

                    for (int i = 0; i < 4; i++)
                    {
                        right = players[i].Equals(computers[i]);
                        if (right)
                        {
                            A++;
                        }
                    }
                    var b = players.Intersect(computers);
                    var count = b.Count();
                    B = count - A;
                    Console.WriteLine($"{A}A{B}B");
                }
                while (A != 4);
                {
                    Console.WriteLine("恭喜你答對");
                    Console.WriteLine("是否繼續進行遊戲(y/n)");
                    welcome = Console.ReadLine();
                }
            }
            while (welcome == "y");
            {
                Console.WriteLine("下次再來玩喔");
            }
        }
    }
}
