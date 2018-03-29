namespace GraphQLService
{
    public class SearchViewModel
    {
        public string Search { get; set; }
        public SearchItemViewModel[] Items { get; set; }
    }

    public class SearchItemViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
} 
