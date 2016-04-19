using System;
using System.IO;
using System.Xml.Serialization;

namespace FotoABIld
{
    //Unused class to serialzie and deserialize objects to XML.
    public class Serializer<T> where T:class,new ()
    {
        public XmlSerializer XmlSerializer { get; set; }

        public Serializer()
        {
            
            XmlSerializer = new XmlSerializer(typeof(T));
        }
        public void Serialize(T item, string filePath)
        {
            try
            {
                using (var streamwriter = new StreamWriter(filePath))
                {
                    XmlSerializer.Serialize(streamwriter,item);
                }
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Could not Serialize the object");
            }
        }

        public T DeSerialize(string filePath)
        {

            if (!File.Exists(filePath))
                return new T();

            using (var streamreader = new StreamReader(filePath))
                {
                    return XmlSerializer.Deserialize(streamreader) as T;
                }
            
        }

    }
    }


