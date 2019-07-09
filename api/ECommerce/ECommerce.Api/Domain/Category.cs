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
        public static Category ToCategory(this string category) => (Category)Enum.Parse(typeof(Category), category);
    }
}
