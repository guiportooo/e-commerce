using ECommerce.Api.Domain;
using System;

namespace ECommerce.Api.Extensions
{
    public static class StringExtensions
    {
        public static Category ToCategory(this string category) => (Category)Enum.Parse(typeof(Category), category, true);
    }
}
