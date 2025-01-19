using DotNetCoreTraining.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraining.ConsoleApp
{
    public class EFCoreCRUD
    {
        //EFcore db provider
        public void Read()
        {
            AppDbContext context = new AppDbContext();
            List<BlogDataModel>? blogList = context.blogs.Where(blog => blog.DeleteFlag == false).ToList();
            foreach (BlogDataModel item in blogList)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }

        }
        public void Create(string title, string author, string content)
        {
            BlogDataModel blog = new BlogDataModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            AppDbContext context = new AppDbContext();
            context.blogs.Add(blog);
            var result = context.SaveChanges();
            Console.WriteLine(result == 1 ? "Saving successful" : "Saving failed");
        }

        public void Edit(int id)
        {
            AppDbContext context = new AppDbContext();
            //BlogDataModel? blog =context.blogs.Where(blog=>blog.BlogId==id).FirstOrDefault();
            BlogDataModel? blog = context.blogs.FirstOrDefault(blog => blog.BlogId == id);
            if (blog is null)
            {
                Console.WriteLine("No data found");
                return;
            }

            Console.WriteLine(blog.BlogId);
            Console.WriteLine(blog.BlogTitle);
            Console.WriteLine(blog.BlogAuthor);
            Console.WriteLine(blog.BlogContent);
        }

        public void Update(int id, string title, string author, string content)
        {
            AppDbContext context = new AppDbContext();
            BlogDataModel? blog = context.blogs.AsNoTracking().FirstOrDefault(blog => blog.BlogId == id);
            if (blog is null)
            {
                Console.WriteLine("No data found");
                return;
            }

            if (!string.IsNullOrEmpty(title))
            {
                blog.BlogTitle = title;
            }
            if (!string.IsNullOrEmpty(author))
            {
                blog.BlogAuthor = author;
            }
            if (!string.IsNullOrEmpty(content))
            {
                blog.BlogContent = content;
            }

            context.Entry(blog).State = EntityState.Modified;
            var result = context.SaveChanges();
            Console.WriteLine(result == 1 ? "Updating successful" : "Updating failed");

        }


        public void Delete(int id)
        {
            AppDbContext context = new AppDbContext();
            BlogDataModel? blog = context.blogs.AsNoTracking().FirstOrDefault(blog => blog.BlogId == id);
            if (blog is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            context.Entry(blog).State = EntityState.Modified;
            var result = context.SaveChanges();
            Console.WriteLine(result == 1 ? "Deleting successful" : "Deleting failed");
        }
    }
}
