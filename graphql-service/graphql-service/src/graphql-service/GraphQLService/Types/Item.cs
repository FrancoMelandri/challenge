using System.Collections.Generic;
using GraphQL.Types;

namespace GraphQLService
{
    public class ProductDetailsViewModelType : ObjectGraphType<ProductDetailsViewModel>
    {
        public ProductDetailsViewModelType()
        {
            Name = "Product details.";
            Description = "The deatisl of the product.";

            Field(d => d.Code).Description("The code of the product.");
            Field(d => d.Name).Description("The name of the product.");
            Field(d => d.Description).Description("The description of the product.");
            Field(d => d.Brand).Description("The brand of the product.");
        }
    }
}
