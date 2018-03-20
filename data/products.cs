namespace data
{
    public static class Catalog
    {
        public static Item[] Items = new [] 
        {
            new Item { 
                Code = "Item1",
                Name = "Name 1",
                Description = "Description 1",
                Brand = "Brand 1",
            },
            new Item { 
                Code = "Item2",
                Name = "Name 2",
                Description = "Description 2",
                Brand = "Brand 2",
            },
            new Item { 
                Code = "Item3",
                Name = "Name 3",
                Description = "Description 3",
                Brand = "Brand 3",
            },
            new Item { 
                Code = "Item4",
                Name = "Name 4",
                Description = "Description 4",
                Brand = "Brand 4",
            },
            new Item { 
                Code = "Item5",
                Name = "Name 5",
                Description = "Description 5",
                Brand = "Brand 5",
            },
        };
    }

    public class Item
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
    }
}