// See https://aka.ms/new-console-template for more information
using DotNetCoreTraining.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.Read();
//Console.ReadLine();
//Console.ReadKey();
//md => markdown


//Ado.Net CRUD
//AdoDotNetCRUD adoDotNetCRUD = new AdoDotNetCRUD();

//Read data
//adoDotNetCRUD.Read();

//Insert data
//adoDotNetCRUD.Create();

//Read data by id
//adoDotNetCRUD.Edit();

//Uodate data
//adoDotNetCRUD.Update();

//Set DeleteFlag=1
//adoDotNetCRUD.Delete();

//Delete data
//adoDotNetCRUD.DeletePermanently();

//Dapper CRUD
DapperCRUD dapperCRUD = new DapperCRUD();
//dapperCRUD.Read();
//dapperCRUD.Create("Hello Testing", "SSDK", "Testing");
//dapperCRUD.Edit(1);
//dapperCRUD.Edit(2);
//dapperCRUD.Update("Hello Testing", "SSDK", "updated Testing",4);
dapperCRUD.Delete(3);
