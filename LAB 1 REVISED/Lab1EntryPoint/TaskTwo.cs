using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab1EntryPoint
{
    public class TaskTwo
    {
        public void TaskTwoLogic()
        {
            Assembly assembly = Assembly.LoadFrom("Lab1Library.dll");

            Type[] types = assembly.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine("class: " + t.Name);
                foreach (var temp in t.GetProperties())
                {
                    Console.WriteLine("\t\tproperty:" + temp.Name);
                }
                foreach (var temp in t.GetMethods())
                {
                    Console.WriteLine("\t\tmethod:" + temp.Name);
                }
            }
        }
    }
}
