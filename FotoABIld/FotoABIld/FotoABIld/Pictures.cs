namespace FotoABIld
{
    //Model of the properties saved for each picture
    public class Pictures
    {
        public string FilePath { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }

        public Pictures(string filepath, int amount, string size)
        {
            FilePath = filepath;
            Amount = amount;
            Size = size;
        }
        public Pictures() { }
    }
}
