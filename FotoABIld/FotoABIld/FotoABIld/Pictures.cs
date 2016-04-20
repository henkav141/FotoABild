//using AVFoundation;

namespace FotoABIld
{
    //Model of the properties saved for each picture
    public class Pictures
    {
        public string FilePath { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }
        public string Name { get; set; }

        public Pictures(string filepath, int amount, string size, string name)
        {
            FilePath = filepath;
            Amount = amount;
            Size = size;
            Name = name;
        }
        public Pictures(string filePath)
        {
            FilePath = filePath;
            Amount = 1;
            Size = "10x15";
            Name = "test";
        }
        public Pictures() { }
    }
}
