using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Lab1EntryPoint;

public class EntryPoint
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1 - first task\n2 - second task\n3 - third task\n4 - exit");
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    TaskOne task1 = new TaskOne();
                    task1.TaskOneLogic();
                    break;
                case ConsoleKey.D2:
                    TaskTwo task2 = new TaskTwo();
                    task2.TaskTwoLogic();
                    break;
                case ConsoleKey.D3:
                    TaskThree task3 = new TaskThree();
                    task3.TaskThreeLogic();
                    break;
                case ConsoleKey.D4:
                    return;
                default:
                    break;
            }
        }
    }
}