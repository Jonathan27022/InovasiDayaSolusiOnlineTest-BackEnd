using Microsoft.EntityFrameworkCore;

namespace OnlineTestPTInovasiDayaSolusi.Data
{
    public class DbApi : DbContext
    {

        public DbApi(DbContextOptions<DbApi> options) : base(options)
    {

    }
    
        public DbSet<Models.Transaction> Transactions { get; set; }
        public DbSet<Models.Status> Statuses { get; set; }
    }
}
