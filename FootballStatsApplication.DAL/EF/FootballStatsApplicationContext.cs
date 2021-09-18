using FootballStatsApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApplication.DAL.EF
{
    class FootballStatsApplicationContext : DbContext
    {
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
    }
}
