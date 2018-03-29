using GraphQL.Types;
using GraphQL;

namespace GraphQLService
{
    public class ProductsSchema : Schema
    {
        public ProductsSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<ProductsQuery>();
        }
    }
}
