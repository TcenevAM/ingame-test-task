using InGameTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace InGameTestTask.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { Id = 1, Title = "genre1" },
                new Genre() { Id = 2, Title = "genre2" },
                new Genre() { Id = 3, Title = "genre3" }
            );
        }
    }
}   