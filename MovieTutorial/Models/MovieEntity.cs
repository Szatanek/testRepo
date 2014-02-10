// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovieEntity.cs" company="Amba">
// </copyright>
// <summary>
//   Defines the MovieEntity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MovieTutorial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;

    public class MovieEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public int Rating { get; set; }
    }

    public class MovieDbContext : DbContext
    {
        public DbSet<MovieEntity> MovieBase { get; set; }
    }
}