namespace Countdown_api.Data
{
    using Countdown_api.Models;
    using Microsoft.EntityFrameworkCore;

    public class CountdownContext : DbContext
    {
        public CountdownContext(DbContextOptions<CountdownContext> options) : base(options)
        {
        }

        public DbSet<CountDown> Countdowns { get; set; }
    }


}
