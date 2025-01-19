// See https://aka.ms/new-console-template for more information
using DotNetCoreTraining.Database.Models;

Console.WriteLine("Hello, World!");

AppDbContext context = new AppDbContext();
List<Blog> blogs = context.Blogs.ToList();
