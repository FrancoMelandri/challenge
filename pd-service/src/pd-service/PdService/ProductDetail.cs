using System.Collections.Generic;

namespace PdService
{
    public class ProductDetail
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }

        public static ProductDetail Empty()
        {
            return new ProductDetail();
        }
    }
}