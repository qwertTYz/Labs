using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab1EntryPoint
{
    public class TaskOne
    {
        public void TaskOneLogic()
        {
            while (true)
            {
                string className = EnterClassName();
                if (className == "ErrorOccured") break;

                string methodName = EnterMethodName(className);

                Type type = Type.GetType(className);
                MethodInfo methodInfo = type.GetMethod(methodName);
                if (methodInfo == null)
                {
                    Console.WriteLine($"such method doesnt exist");
                    break;
                }

                List<string> arguments = EnterArguments();

                object[] parameters = new object[arguments.Count];
                for (int i = 0; i < arguments.Count; i++) parameters[i] = arguments[i];

                object? classInstance = Activator.CreateInstance(type);

                ParameterInfo[] parameterInfos = methodInfo.GetParameters();

                if (parameterInfos.Length != parameters.Length)
                {
                    Console.WriteLine("parameter count doesnt match");
                    break;
                }

                for (int i = 0; i < parameterInfos.Length; i++) parameters[i] = Convert.ChangeType(parameters[i], parameterInfos[i].ParameterType);

                Console.Write($"result: {methodInfo.Invoke(classInstance, parameters)}");
                return;
            }
        }
        public static string EnterClassName()
        {
            Console.Write("class: ");
            string className = Console.ReadLine();
            if (Type.GetType(className) == null)
            {
                Console.WriteLine($"cannot create {className}");
                return "ErrorOccured";
            }
            return className;
        }
        public static string EnterMethodName(string className)
        {
            Console.Write("method: ");
            string methodName = Console.ReadLine();
            return methodName;
        }
        public static List<string> EnterArguments()
        {
            List<string> arguments = new List<string>();
            while (true)
            {
                Console.WriteLine("esc - exit\nf - add argument");
                ConsoleKeyInfo option = Console.ReadKey(true);
                if (option.Key == ConsoleKey.Escape) break;
                else if (option.Key == ConsoleKey.F)
                {
                    Console.Write("argument: ");
                    string argument = Console.ReadLine();
                    arguments.Add(argument);
                }
            }

            return arguments;
        }
    }
}
