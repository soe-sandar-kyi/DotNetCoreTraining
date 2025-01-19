// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.Read();
//Console.ReadLine();
//Console.ReadKey();
//md => markdown

string connectionString = "Data Source=DESKTOP-M44SRQR;Initial Catalog=DotNetTrainingBatch5;Integrated Security = True;TrustServerCertificate=True";
Console.WriteLine("Connection string"+connectionString);
SqlConnection connection = new SqlConnection(connectionString);

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

SqlDataReader reader= command.ExecuteReader();
while(reader.Read())
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
