using Dapper;
using DotNetCoreTraining.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraining.ConsoleApp
{
    public class DapperCRUD
    {
        private readonly string _connectionString = "Data Source=DESKTOP-M44SRQR;Initial Catalog=DotNetTrainingBatch5;Integrated Security = True;TrustServerCertificate=True";

        public void Read()
        {
            //using(IDbConnection db= new SqlConnection(_connectionString))
            //{
            //    string query = "select * from Blog where DeleteFlag=0";
            //    var bloglist = db.Query(query).ToList();
            //    foreach(var item in bloglist)
            //    {
            //        Console.WriteLine(item.BlogId);
            //        Console.WriteLine(item.BlogTitle);
            //        Console.WriteLine(item.BlogAuthor);
            //        Console.WriteLine(item.BlogContent);
            //    }
            //}

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from Blog where DeleteFlag=0";
                var bloglist = db.Query<BlogDataModel>(query).ToList();
                foreach (var item in bloglist)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
        }

        public void Create(string title, string author, string content)
        {
            string query = $@"INSERT INTO [dbo].[Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });
                Console.WriteLine(result == 1 ? "Data inserted successfully" : "Data not inserted");
            }
        }

        public void Edit(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from Blog where DeleteFlag=0 and BlogId=@BlogId";
                BlogDataModel? blog = db.Query<BlogDataModel>(query, new BlogDataModel
                {
                    BlogId = id,
                }).FirstOrDefault();

                //if(blog == null)
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
        }

        public void Update(string title, string author, string content, int id)
        {
            string query = @"UPDATE [dbo].[Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId=@BlogId";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogId = id,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });
                Console.WriteLine(result == 1 ? "Data updated successfully" : "Data not updated");
            }
        }

        public void Delete(int id)
        {
            string query = "delete from Blog where BlogId=@BlogId";
            using(IDbConnection db=new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogId = id,
                });
                Console.WriteLine(result == 1 ? "Data deleted successfully" : "Data not deleted");

            }
        }
    }
}
