using DDD.Shared.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDD.Product.Domain.Product.ProductEnum;

namespace DDD.Product.Domain.Product
{
    public class Product
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; } = "";
        public double Price { get; protected set; }
        public ProductColor Color { get; protected set; }
        public ProductType Type { get; protected set; }

        public static Product CreateNew(string title, double price, ProductColor Color, ProductType Type)
        {
            return CreateInstance(title, price, Color, Type);
        }
        public static Product CreateNew(string Id, string title, double price, ProductColor Color, ProductType Type)
        {
            if (!Guid.TryParse(Id, out Guid idOut))
            {
                throw new Exception("id is incorrect");
            }
            return CreateInstance(title, price, Color, Type, idOut);
        }

        private static Product CreateInstance(string title, double price, ProductColor Color, ProductType Type, Guid? Id = null)
        {
            Product product = new Product()
            {
                Type = Type,
                Price = price,
                Color = Color,
                Title = title,
                Id = Id ?? Guid.NewGuid()
            };
            return product;
        }

        public static List<Product> Seed()
        {
            return new List<Product> {
            CreateInstance("کامپیوتر اپل",100000000,ProductColor.Blue,ProductType.Computer),
            CreateInstance("کامپیوتر سامسونگ",70000000,ProductColor.Blue,ProductType.Computer),
            CreateInstance("کامپیوتر ایسوز",40000000,ProductColor.Green,ProductType.Computer),
            CreateInstance("موبایل ایسوز",4000000,ProductColor.Red,ProductType.Mobile),
            CreateInstance("موبایل سامسونگ",5000000,ProductColor.Green,ProductType.Mobile),
            CreateInstance("موبایل اپل",40000000,ProductColor.Blue,ProductType.Mobile),
            CreateInstance("پیراهن",100000,ProductColor.Red,ProductType.TShirt),
        };
    }
}
}
