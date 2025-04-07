using System;
using System.Reflection;
using System.Linq;
using LabOneLibrary;

namespace LabOnePunktTwo;


public class Program
{
    public static void Main()
    {
        Assembly lib = Assembly.LoadFrom("LabOneLibrary");
        Type[] types = lib.GetTypes();

        foreach (Type t in types)
        {            
            Console.WriteLine("t.Name:    " + t.FullName);
            foreach(var member  in t.GetMembers())
            {
                Console.WriteLine("member.Name:    " + member.Name);
            }
        }

        Console.ReadKey();
    }
}