using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Reflection.Metadata.Ecma335;


namespace LabOnePunktThree;

public static class Program
{
    public static void Main()
    {
        try
        {
            Assembly lib = Assembly.LoadFile("C:\\Users\\danii\\Desktop\\LabOneLibrary\\bin\\Debug\\net8.0\\LabOneLibrary.dll");


            Type carType = lib.GetType("LabOneLibrary.Car");

            object mashina = Activator.CreateInstance(carType);

            object[] pars = [false, "bmw", "1111", 0];


            MethodInfo? createMethod = carType.GetMethod("Create");
            createMethod.Invoke(mashina, pars);


            MethodInfo? printMethod = carType.GetMethod("PrintObject");
            printMethod?.Invoke(mashina, null);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"something went wrong:   {ex.Message}");
        }

        Console.ReadKey();
    }
}