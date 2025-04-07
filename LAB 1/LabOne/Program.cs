using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace LabOne
{
    public class Program
    {
        public static void Main()
        {
            
            try
            {
                Console.Write("class: ");
                string className = Console.ReadLine();

                Type type = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => t.Name == className || t.FullName == $"System.{className}");

                Console.Write("method: ");
                string methodName = Console.ReadLine();

                MethodInfo method = type.GetMethods().FirstOrDefault(m => m.Name == methodName);
                if (method == null)
                {
                    Console.WriteLine("method not found");
                    return;
                }

                ParameterInfo[] parameters = method.GetParameters();
                object[] parsedArgs = new object[parameters.Length];

                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"parameter: {i + 1} ({parameters[i].ParameterType.Name}): ");
                    string input = Console.ReadLine();
                    parsedArgs[i] = Convert.ChangeType(input, parameters[i].ParameterType);
                }

                object instance;
                if (method.IsStatic) instance = null;
                else instance = Activator.CreateInstance(type);


                object output = method.Invoke(instance, parsedArgs);

                if (method.ReturnType != typeof(void)) Console.WriteLine($"output: {output}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"something went wrong: {ex.Message}");
                return;
            }

            Console.ReadKey();
        }
    }
}
