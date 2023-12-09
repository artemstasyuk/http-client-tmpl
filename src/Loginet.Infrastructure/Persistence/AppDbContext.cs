﻿using Loginet.BLL.Entities.Albums;
using Loginet.BLL.Entities.Users;
using Microsoft.EntityFrameworkCore;


namespace Loginet.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{ 
    public DbSet<User> Users { get; set; } = null!;
    
    public DbSet<Album> Albums { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSnakeCaseNamingConvention();
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Inject all configurations of entities 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}