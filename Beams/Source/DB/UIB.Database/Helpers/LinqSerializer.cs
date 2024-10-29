using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace HCM.Database
{
    /// <summary>
    /// Class to make functions specifically of Linq
    /// </summary>
    internal class LinqSerializer
    {
        private static string AssemblyName = typeof(LinqSerializer).Assembly.GetName().Name;

        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetString<T>(T input)
        {
            // see http://msdn.microsoft.com/en-us/library/bb546184.aspx
            DataContractSerializer dcs = new DataContractSerializer(input.GetType());

            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb);
            dcs.WriteObject(writer, input);
            writer.Close();

            return sb.ToString();
        }

        /// <summary>
        /// deserialize to object
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static object GetObject(string input)
        {
            TextReader treader = new StringReader(input);
            XmlReader reader = XmlReader.Create(treader);

            reader.MoveToContent();

            Type _type = Type.GetType(AssemblyName + "." + reader.LocalName);

            DataContractSerializer dcs = new DataContractSerializer(_type);

            object linqObject = (object)dcs.ReadObject(reader, false);
            reader.Close();

            return linqObject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static List<string> GetElements(string input)
        {
            TextReader treader = new StringReader(input);
            XDocument oDoc = XDocument.Load(treader);
            return oDoc.Root.Elements().Select(o => o.Name.LocalName).ToList();
        }
    }
}
