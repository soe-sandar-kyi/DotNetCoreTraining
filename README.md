# DotNetCoreTraining
C#

//Database first
dotnet ef dbcontext scaffold "Server=DESKTOP-M44SRQR;Database=DotNetTrainingBatch5;Integrated Security = True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f