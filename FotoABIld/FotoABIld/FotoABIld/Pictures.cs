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
        public string FitOrFill { get; set; }

        public Pictures(string filepath, int amount, string size, string name,string fitorfill)
        {
            FilePath = filepath;
            Amount = amount;
            Size = size;
            Name = name;
            FitOrFill = fitorfill;
        }
        public Pictures(string filePath)
        {
            FilePath = filePath;
            Amount = 1;
            Size = "10x15";
            Name = "test";
            FitOrFill = "-2";
        }
        public Pictures() { }
    }
}
