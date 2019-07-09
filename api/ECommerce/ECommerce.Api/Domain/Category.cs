using System;

namespace ECommerce.Api.Domain
{
    public enum Category
    {
        Books,
        Eletronics
    }

    public static class CategoryMapper
    {
        public static Category ToCategory(this string category)
        {
            switch (category.ToLower())
            {
                case "books":
                    return Category.Books;
                case "eletronics":
                    return Category.Eletronics;
                default:
                    throw new ArgumentException("Invalid category", nameof(category));
            }
        }

        public static string ToString(this Category category)
        {
            switch (category)
            {
                case Category.Books:
                    return "books";
                case Category.Eletronics:
                    return "eletronics";
                default:
                    throw new ArgumentException("Invalid category", nameof(category));
            }
        }
    }
}
