﻿using Microsoft.EntityFrameworkCore;
using songsApi.Models;

namespace songsApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Song> Songs { get; set; } 

    }
}
