﻿using DotNetCoreTraining.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreTraining.ConsoleApp
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=DESKTOP-M44SRQR;Initial Catalog=DotNetTrainingBatch5;Integrated Security = True;TrustServerCertificate=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

            public DbSet<BlogDataModel> blogs { get; set; } 
    }
}
