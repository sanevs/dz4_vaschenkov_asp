using System.Collections.Concurrent;

namespace Catalog;

public static class ClassCategories
{
    private static readonly ConcurrentBag<Category> _categories = new()
    {
        new Category(1, "Men"),
        new Category(2, "Women"),
        new Category(3, "Kids"),
    };
    public static ConcurrentBag<Category> GetCategories() => _categories;

}