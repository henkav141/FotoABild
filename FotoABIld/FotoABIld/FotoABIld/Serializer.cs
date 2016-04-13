using System;
using System.IO;
using System.Xml.Serialization;

namespace FotoABIld
{
    //Unused class to serialzie and deserialize objects to XML.
    public class Serializer<T> where T:class,new ()
    {
        public string FilePath { get; set; }
        public XmlSerializer XmlSerializer { get; set; }

        public Serializer(string filePath)
        {
            FilePath = filePath;
            XmlSerializer = new XmlSerializer(typeof(T));
        }
        public void Serialize(T item)
        {
            try
            {
                using (var streamwriter = new StreamWriter(FilePath))
                {
                    XmlSerializer.Serialize(streamwriter,item);
                }
            }
            catch (Exception)
            {
                
                Console.WriteLine("Problem with Serialize");
            }
        }

        public T DeSerialize()
        {

            if (!File.Exists(FilePath))
                return new T();

            using (var streamreader = new StreamReader(FilePath))
                {
                    return XmlSerializer.Deserialize(streamreader) as T;
                }
            
        }

    }
    }


