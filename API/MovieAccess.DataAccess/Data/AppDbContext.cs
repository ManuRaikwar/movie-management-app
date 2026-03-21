using Microsoft.EntityFrameworkCore;
using MovieAccess.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAccess.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Movie> Movie { get; set; }
    }
}
