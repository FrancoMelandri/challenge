using System.Collections.Generic;
using GraphQL.Types;

namespace GraphQLService
{
    public class SearchViewModelType : ObjectGraphType<SearchViewModel>
    {
        public SearchViewModelType()
        {
            Name = "Search results";
            Description = "The result of the search.";

            Field(d => d.Search).Description("The search text");
            Field<ListGraphType<SearchItemViewModelType>>("items");
        }
    }

    public class SearchItemViewModelType : ObjectGraphType<SearchItemViewModel>
    {
        public SearchItemViewModelType()
        {
            Name = "Search results item";
            Description = "The single item of the search.";

            Field(d => d.Code).Description("The code of the item");
            Field(d => d.Name).Description("The name of the item");
        }
    }
}
