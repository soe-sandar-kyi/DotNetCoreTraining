﻿using System;
using System.Collections.Generic;

namespace DotNetCoreTraining.Database.Models
{
    public partial class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; } = null!;
        public string BlogAuthor { get; set; } = null!;
        public string BlogContent { get; set; } = null!;
        public bool DeleteFlag { get; set; }
    }
}
