using DDD.Shared.Domain.Helper;

namespace DDD.Product.Domain.Product
{
    public class ProductEnum
    {
        public enum ProductColor
        {
            Red = 1,
            Green = 2,
            Blue = 3
        }

        public enum ProductType
        {
            TShirt = 1,
            Computer = 2,
            Mobile = 3
        }
    }
}
