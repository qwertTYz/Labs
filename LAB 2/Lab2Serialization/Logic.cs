using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace Lab2Serialization
{
    public class Logic
    {
        public object[] MakeTen()
        {
            Console.Write("\nclass: ");
            string className = Console.ReadLine();

            Assembly asm = Assembly.LoadFrom("Lab1Library.dll");
            Type type = asm.GetType(className);

            if (type is null)
            {
                Console.WriteLine("class not found");
                return null;
            }

            object[] objects = new object[10];

            for (int i = 0; i < objects.Length; i++) objects[i] = Activator.CreateInstance(type);

            return objects;
        }

        [XmlInclude(typeof(Lab1Library.Car)), XmlInclude(typeof(Lab1Library.Service))]
        public XDocument SerializeTen(string rootElementName, string path, params object[] inputs)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter writer = xDoc.CreateWriter())
            {
                writer.WriteStartElement(rootElementName);
                foreach (var input in inputs)
                {
                    new XmlSerializer(input.GetType()).Serialize(writer, input);
                }

                writer.WriteEndElement();
            }
            
            FileStream fileStream = File.Create(path);
            
            xDoc.Save(fileStream);
            fileStream.Dispose();
            fileStream.Close();
            return xDoc;
        }

        public void DeserializeTen(/*XDocument xDoc*/string path)
        {
            //xDoc.Descendants()
            
            XDocument xDoc = XDocument.Load(path);
            foreach (XElement node in xDoc.Root.Descendants())
            {
                if (node.NodeType != XmlNodeType.Document) Console.WriteLine(node.Value);
            }
            //object[] objects = new object[10];
            //using (XmlReader reader = xDoc.CreateReader())
            //{
            //    while (reader.Read())
            //    {
            //        if (reader.NodeType == XmlNodeType.Element)
            //        {
            //            Console.WriteLine(reader.Name);
            //        }
            //    }
            //}
        }

        public void ShowModelXDoc(string path)
        {
           
            XDocument xDoc = XDocument.Load(path);
            foreach (XElement node in xDoc.Root.Descendants())
            {
                if (node.Name == "Model") Console.WriteLine(node.Value);
            }
        }

        public void ShowModelXmlDoc(string path)
        {

            XmlDocument xmlDoc = new XmlDocument();

            XDocument xDoc = XDocument.Load(path);
            xmlDoc.LoadXml(xDoc.ToString());
            XmlNodeList children = xmlDoc.ChildNodes;
            foreach (XmlNode child in children)
            {
                foreach(XmlNode c in child.ChildNodes)
                {
                    foreach(XmlNode temp in c.ChildNodes)
                    {
                        if (temp.Name == "Model")
                        {
                            Console.WriteLine(temp.OuterXml);
                        }
                    }
                }
            }
            //foreach (XElement node in xDoc.Root.Descendants())
            //{
            //    if (node.Name == "Model") Console.WriteLine(node.Value);
            //}
        }

        public void Task3XDoc(string path, string elementName, int elementIndex, string newValue)
        {
            XDocument xDoc = XDocument.Load(path);

            List<XElement> elements = xDoc.Root.Elements().ToList();

            if (elementIndex >= 0 && elementIndex < elements.Count)
            {
                XElement targetElement = elements[elementIndex];

                XElement child = targetElement.Element(elementName);

                if (child != null) child.Value = newValue;
                else targetElement.Add(new XElement(elementName, newValue));

                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write))
                {
                    fs.SetLength(0);
                    xDoc.Save(fs);
                }
            }
            else Console.WriteLine("invalid index");
        }

        public void Task3XmlDoc(string path, string elementName, int elementIndex, string newValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            
            XmlNodeList elements = xmlDoc.DocumentElement.ChildNodes;

            if (elementIndex >= 0 && elementIndex < elements.Count)
            {
                XmlNode targetElement = elements[elementIndex];

                XmlNode child = targetElement[elementName];

                if (child != null) child.InnerText = newValue;
                else
                {
                    XmlElement newChild = xmlDoc.CreateElement(elementName);
                    newChild.InnerText = newValue;
                    targetElement.AppendChild(newChild);
                }

                xmlDoc.Save(path);
            }
            else Console.WriteLine("invalid index");
        }



    }
}
