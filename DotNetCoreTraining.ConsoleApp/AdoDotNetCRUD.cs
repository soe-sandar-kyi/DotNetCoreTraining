using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraining.ConsoleApp
{
    public class AdoDotNetCRUD
    {
        private readonly string _connectionString = "Data Source=DESKTOP-M44SRQR;Initial Catalog=DotNetTrainingBatch5;Integrated Security = True;TrustServerCertificate=True";
        public void Read()
        {
            Console.WriteLine("Connection string" + _connectionString);
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("Connection openning.....");
            connection.Open();
            Console.WriteLine("Connection opened successfully");

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Blog] where DeleteFlag=0";

            SqlCommand command = new SqlCommand(query, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
                Console.WriteLine(reader["DeleteFlag"]);
            }

            Console.WriteLine("Connection closing.....");
            connection.Close();
            Console.WriteLine("Connection closed successfully");

            //DataSet
            //DataTable
            //DataRow
            //DataColumn
            //foreach(DataRow dr in dataTable.Rows)
            //{
            // Console.WriteLine(dr["BlogTitle"]);
            // Console.WriteLine(dr["BlogAuthor"]);
            //Console.WriteLine(dr["BlogContent"]);
            //Console.WriteLine(dr["DeleteFlag"]);
            //}
        }

        public void Create()
        {
            Console.Write("Blog Title: ");
            string title = Console.ReadLine();

            Console.Write("Blog Author: ");
            string author = Console.ReadLine();

            Console.Write("Blog Content: ");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

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

            SqlCommand cmd2 = new SqlCommand(query, connection);
            cmd2.Parameters.AddWithValue("@BlogTitle", title);
            cmd2.Parameters.AddWithValue("@BlogAuthor", author);
            cmd2.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd2.ExecuteNonQuery();


            Console.WriteLine(result == 1 ? "Data inserted successfully" : "Data not inserted");
            connection.Close();
        }

        public void Edit()
        {
            Console.Write("Enter Blog Id: ");
            string blogId = Console.ReadLine();


            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Blog] where BlogId=@BlogId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BlogId", blogId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count == 0)
            {
                Console.WriteLine("No data found");
                return;
            }

            DataRow dr = dataTable.Rows[0];
            Console.WriteLine("Blog Id: " + dr["BlogId"]);
            Console.WriteLine("Blog Title: " + dr["BlogTitle"]);
            Console.WriteLine("Blog Author: " + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content: " + dr["BlogContent"]);
        }

        public void Update()
        {
            Console.Write("Enter Blog Id: ");
            int blogId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Blog Title: ");
            string title = Console.ReadLine();

            Console.Write("Blog Author: ");
            string author = Console.ReadLine();

            Console.Write("Blog Content: ");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"UPDATE [dbo].[Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId=@BlogId";

            SqlCommand cmd2 = new SqlCommand(query, connection);
            cmd2.Parameters.AddWithValue("@BlogId", blogId);
            cmd2.Parameters.AddWithValue("@BlogTitle", title);
            cmd2.Parameters.AddWithValue("@BlogAuthor", author);
            cmd2.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd2.ExecuteNonQuery();
            Console.WriteLine(result == 1 ? "Data updated successfully" : "Data not updateds");
            connection.Close();
        }

        public void Delete()
        {
            Console.Write("Enter Blog Id: ");
            int blogId = Convert.ToInt32(Console.ReadLine());

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"UPDATE [dbo].[Blog]
   SET [DeleteFlag] = 1
 WHERE BlogId=@BlogId";

            SqlCommand cmd2 = new SqlCommand(query, connection);
            cmd2.Parameters.AddWithValue("@BlogId", blogId);
            int result = cmd2.ExecuteNonQuery();
            Console.WriteLine(result == 1 ? "Data Deleted successfully" : "Data not deleted");
            connection.Close();
        }

        public void DeletePermanently()
        {
            Console.Write("Enter Blog Id: ");
            int blogId = Convert.ToInt32(Console.ReadLine());

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"DELETE FROM [dbo].[Blog]
      WHERE BlogId=@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", blogId);
            int result = cmd.ExecuteNonQuery();
            Console.WriteLine(result == 1 ? "Data Deleted successfully" : "Data not deleted");
            connection.Close();
        }
    }
}
