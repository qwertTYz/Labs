using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab1EntryPoint
{
    public class TaskThree
    {
        public void TaskThreeLogic()
        {
            const string printObjectMethodName = "PrintObject";
            const string CreateMethodName = "Create";
            const string typeName = "Lab1Library.Service";

            Assembly assembly = Assembly.LoadFrom("Lab1Library.dll");
            Type type = assembly.GetType(typeName);
            MethodInfo methodInfo = type.GetMethod(CreateMethodName);

            object typeInstance = Activator.CreateInstance(type);
            object[] parameters = new object[methodInfo.GetParameters().Length];
            parameters[0] = "servis";
            parameters[1] = "street";
            parameters[2] = false;

            var classInstance = methodInfo.Invoke(typeInstance, parameters);

            methodInfo = type.GetMethod(printObjectMethodName);
            methodInfo.Invoke(classInstance, null);
        }
    }
}
