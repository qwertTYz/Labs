using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Lab1Library;
using System.Reflection;
using System.Xml.Linq;
using System.Dynamic;

namespace Lab2Serialization;
public class UserInteraction
{
    [XmlInclude(typeof(Lab1Library.Car))]
    [XmlInclude(typeof(Lab1Library.Service))]
    public static void Main()
    {
        const string path = "XML_SERIALIZE_OUTPUT.xml";
        Console.WriteLine("A-create 10 instances\nS-serialize\nD-deserialize\nM-model(XDocument)\nN-model(XmlDocument)\nJ-task3 XDoc\nK-task3 XmlDoc\nX-exit\n");

        object[] objects = new object[10];
        XDocument xDocument = new XDocument();

        while (true)
        {
            Console.Write("\noption: ");
            ConsoleKeyInfo cki = Console.ReadKey();
            switch (cki.Key)
            {
                // 10 objects
                case ConsoleKey.A:
                    objects = new Logic().MakeTen();
                    if (objects is not null) foreach (var temp in objects) Console.WriteLine(temp);
                    
                    break;
                // serialize
                case ConsoleKey.S:
                    if (objects[0] != null && objects != null)
                    {
                        try
                        {
                            string rootElementName = $"{objects[0].GetType().Name}s";  // Car+s
                            xDocument = new Logic().SerializeTen(rootElementName, path, objects);
                            Console.WriteLine("\n" + xDocument);
                        }
                        catch(System.NullReferenceException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    else Console.WriteLine("\ncreate objects first");
                    break;
                // deserialize
                case ConsoleKey.D:
                    new Logic().DeserializeTen(path);
                    break;
                // model  xDoc
                case ConsoleKey.M:
                    try
                    {
                        new Logic().ShowModelXDoc(path);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;
                // model  xmlDoc
                case ConsoleKey.N:
                    try
                    {
                        new Logic().ShowModelXmlDoc(path);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    break;
                // task 3 xDoc
                case ConsoleKey.J:
                    Console.Write("\nattribute: ");
                    string attributeName = Console.ReadLine();
                    Console.Write("\nindex: ");
                    int elementIndex = int.Parse(Console.ReadLine());
                    Console.Write("\nnew value: ");
                    string newValue = Console.ReadLine();
                    new Logic().Task3XDoc(path, attributeName, elementIndex, newValue);
                    break;
                // task 3 xmlDoc    
                case ConsoleKey.K:
                    Console.Write("\nattribute: ");
                    string attributeNameXml = Console.ReadLine();
                    Console.Write("\nindex: ");
                    int elementIndexXml = int.Parse(Console.ReadLine());
                    Console.Write("\nnew value: ");
                    string newValueXml = Console.ReadLine();
                    new Logic().Task3XmlDoc(path, attributeNameXml, elementIndexXml, newValueXml);
                    break;
                //exit
                case ConsoleKey.X:
                    return;
                default:
                    Console.WriteLine();
                    break;
            }
        }
    }  
}