namespace FotoABildShared
{
    public class SharedProperties
    {
        public string FilePath { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }

        public SharedProperties(string filepath, int amount, string size)
        {
            FilePath = filepath;
            Amount = amount;
            Size = size;
        }
    }
}
