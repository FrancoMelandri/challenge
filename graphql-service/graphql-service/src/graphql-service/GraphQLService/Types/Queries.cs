using System;
using GraphQL.Types;
using Core;

namespace GraphQLService
{
    public class ProductsQuery : ObjectGraphType<object>
    {
        public ProductsQuery(IProductListFinder productListFinder,
                             IProductDetailsProvider productDetailsProvider)
        {
            Name = "Query";

            Field<SearchViewModelType>(
                "ProductList",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "search", Description = "search term" }
                ),
                resolve: context => productListFinder.Search(context.GetArgument<string>("search"))
            );
    
            Field<ProductDetailsViewModelType>(
                "Product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "code", Description = "product code" }
                ),
                resolve: context => productDetailsProvider.GetDetail(context.GetArgument<string>("code"))
            );
        }
    }
}
