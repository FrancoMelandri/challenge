namespace UiService.Models
{
    public class SearchViewModel
    {
        public SearchItemViewModel[] Items { get; set; }
    }

    public class SearchItemViewModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
} 
