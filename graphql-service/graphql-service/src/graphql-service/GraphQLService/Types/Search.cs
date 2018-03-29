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
        }
    }
}
