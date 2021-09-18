using FootballStatsApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.DAL.EF
{
    public class FootballStatsApplicationContext : DbContext
    {
        public FootballStatsApplicationContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
            optionsBuilder.UseInMemoryDatabase(databaseName: "FsDbInMemory");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<League>().HasData(
                new League[]
                {
                new League { Id=new Guid("AC6773D0-17C7-4E94-BBDB-649CD88780C8"), LeagueName="Питон 4х4 5х5",CreatedOn=new DateTime(2020,11,20),Keyword="Piton"},
                new League { Id=new Guid("187AC176-CB28-4456-9AB5-D3A1EF370542"), LeagueName="Супер новая лига",CreatedOn=new DateTime(2022,01,01),Keyword="NewPiton"}                
                });
        }
    }
}
