namespace MovieTutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using MovieTutorial.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieTutorial.Models.MovieDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "MovieTutorial.Models.MovieDbContext";
        }

        protected override void Seed(MovieTutorial.Models.MovieDbContext context)
        {
            context.MovieBase.AddOrUpdate(
                i => i.Title,
                new MovieEntity
                    {
                        Title = "Amba movie",
                        ReleaseDate = DateTime.Parse("2000-12-09"),
                        Genre = "Horror",
                        Price = 7.99M
                    },
                    new MovieEntity
                        {
                            Title = "Jackass the movie",
                            ReleaseDate = DateTime.Parse("1990-02-21"),
                            Genre = "Comedy",
                            Price = 8.50M
                        },
                        new MovieEntity
                            {
                                Title = "Atomic coming",
                                ReleaseDate = DateTime.Parse("2013-05-23"),
                                Genre = "Comedy",
                                Price = 5
                            });
        }
    }
}
