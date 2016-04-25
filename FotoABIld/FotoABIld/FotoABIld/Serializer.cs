using System;
using System.IO;
using System.Xml.Serialization;

namespace FotoABIld
{
    //Unused class to serialzie and deserialize objects to XML.
    public static class Serializer<T> where T:class,new ()
    {
        private static XmlSerializer XmlSerializer { get; set; }

         static Serializer()
        {
            
            XmlSerializer = new XmlSerializer(typeof(T));
        }
         public static void Serialize(T item, string filePath)
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

         public static T DeSerialize(string filePath)
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


