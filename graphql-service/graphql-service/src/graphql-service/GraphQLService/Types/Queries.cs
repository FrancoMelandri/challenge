using System;
using GraphQL.Types;

namespace GraphQLService
{
    public class ProductsQuery : ObjectGraphType<object>
    {
        public ProductsQuery(IProductListFinder productListFinder)
        {
            Name = "Query";

            Field<SearchViewModelType>(
                "ProductList",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "search", Description = "search term" }
                ),
                resolve: context => productListFinder.Search(context.GetArgument<string>("search"))
            );
        }
    }
}
