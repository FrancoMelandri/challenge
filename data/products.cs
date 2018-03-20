namespace data
{
    public static class Catalog
    {
        public static Item[] Items = new [] 
        {
            new Item { Name = "Item1" },
            new Item { Name = "Item2" },
            new Item { Name = "Item3" },
            new Item { Name = "Item4" },
            new Item { Name = "Item5" }            
        };
    }

    public class Item
    {
        public string Name { get; set; }
    }
}