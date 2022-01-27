using System;
using System.Collections.Concurrent;
using System.Linq;
using Catalog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var catalog = new ClassCatalog();

app.MapGet("/products", (HttpContext context) =>
    catalog.GetProducts(DateTime.Now.DayOfWeek, context.Request.Headers.UserAgent.ToString()));

string AddProduct(string name, int price, int categoryId)
{
    var category = ClassCategories.GetCategories().First(c => c.Id == categoryId);
    catalog.AddProduct(new Product(name, price, category));
    return $"Product {name} of {category.Name} category, price = {price} added to catalog.";
}
app.MapGet("/add/{name}/{price}/{categoryId}",(string name, int price, int categoryId) => 
    AddProduct(name, price, categoryId));

app.MapGet("/userinfo", (HttpContext context) => context.Request.Headers.UserAgent);
app.Run();
