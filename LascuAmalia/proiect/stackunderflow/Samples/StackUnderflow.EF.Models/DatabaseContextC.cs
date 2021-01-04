using Microsoft.EntityFrameworkCore;
using StackUnderflow.DatabaseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.EF
{
    public class DatabaseContextC : DbContext
    {
        public DatabaseContextC()
        {

        }
        public DatabaseContextC(DbContextOptions<DatabaseContextC> options)
            : base(options)
        {
        }

       
        public DbSet<Question> Questions { get; set; }

    }
    
    }

