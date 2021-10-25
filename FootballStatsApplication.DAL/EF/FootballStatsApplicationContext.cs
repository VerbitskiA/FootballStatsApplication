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
            //Database.EnsureDeleted();
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
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=fsapp;Trusted_Connection=True;");
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
            modelBuilder.Entity<Place>().HasData(
                new Place[]
                {
                new Place { Id=new Guid("FC5DD963-F6B7-4C5A-A2A1-9A1867823660"), PlaceName = "Зал ФОК"},
                new Place { Id=new Guid("93704A06-45B9-4E72-847E-86D7F3E0E1A9"), PlaceName = "На улице"}
                });
            modelBuilder.Entity<Player>().HasData(
                new Player[]
                {
                new Player { Id=new Guid("62A98A9A-2D3E-404A-8377-3E1A98491F88"),LeagueId=new Guid("AC6773D0-17C7-4E94-BBDB-649CD88780C8"), FirstName = "Александр", SecondName = "Вербицкий", BirthDate = new DateTime(1995,07,17), FootStyle = "Правая", Avatar="Аватарка1"},
                new Player { Id=new Guid("04C09190-549B-414F-BA03-8A7A23F3E8D7"),LeagueId=new Guid("AC6773D0-17C7-4E94-BBDB-649CD88780C8"),  FirstName = "Игорь", SecondName = "Кудряшов", BirthDate = new DateTime(1997,01,01), FootStyle = "Правая", Avatar="Аватарка2"},
                new Player { Id=new Guid("D8786FBE-B69D-4458-9D9D-97EA5E5BBFF4"),LeagueId=new Guid("AC6773D0-17C7-4E94-BBDB-649CD88780C8"),  FirstName = "Никита", SecondName = "Тимофеев", BirthDate = new DateTime(1989,02,01), FootStyle = "Левая", Avatar="Аватарка3"},
                new Player { Id=new Guid("8DEFB759-1198-41CB-AD8B-BAC94CA575D4"),LeagueId=new Guid("AC6773D0-17C7-4E94-BBDB-649CD88780C8"),  FirstName = "Дмитрий", SecondName = "Ткач", BirthDate = new DateTime(1997,01,01), FootStyle = "Правая", Avatar="Аватарка4"},
                new Player { Id=new Guid("483D64E9-25AF-471A-B0FD-414C224B851E"),LeagueId=new Guid("AC6773D0-17C7-4E94-BBDB-649CD88780C8"),  FirstName = "Игорь", SecondName = "Олесик", BirthDate = new DateTime(1997,01,02), FootStyle = "Правая", Avatar="Аватарка5"},
                new Player { Id=new Guid("794B8848-60FC-4C73-92E8-84248193DEF8"),LeagueId=new Guid("187AC176-CB28-4456-9AB5-D3A1EF370542"),  FirstName = "Александр", SecondName = "Сайко", BirthDate = new DateTime(1997,03,01), FootStyle = "Правая", Avatar="Аватарка6"},
                new Player { Id=new Guid("68506FD3-F7C5-4ED1-8C9F-2D30AF9F305C"),LeagueId=new Guid("187AC176-CB28-4456-9AB5-D3A1EF370542"), FirstName = "Илья", SecondName = "Лавничук", BirthDate = new DateTime(1997,01,04), FootStyle = "Правая", Avatar="Аватарка7"},
                new Player { Id=new Guid("9555B3F7-F288-44E5-8568-340E3761A7FC"),LeagueId=new Guid("187AC176-CB28-4456-9AB5-D3A1EF370542"), FirstName = "Артур", SecondName = "Поздняк", BirthDate = new DateTime(1997,01,05), FootStyle = "Левая", Avatar="Аватарка8"},
                new Player { Id=new Guid("816B9432-B526-4975-9709-FB97EE852040"),LeagueId=new Guid("187AC176-CB28-4456-9AB5-D3A1EF370542"), FirstName = "Алексей", SecondName = "Соколов", BirthDate = new DateTime(1988,01,06), FootStyle = "Правая", Avatar="Аватарка9"},
                new Player { Id=new Guid("A7ADBD2C-4C13-4530-88AA-1F4366816EBD"),LeagueId=new Guid("187AC176-CB28-4456-9AB5-D3A1EF370542"), FirstName = "Андрей", SecondName = "Насевич", BirthDate = new DateTime(1995,01,01), FootStyle = "Правая", Avatar="Аватарка10"}
                });
        }
    }
}
