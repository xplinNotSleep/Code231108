using Microsoft.EntityFrameworkCore;
using ReadingPT.Models;

namespace ReadingPT.DataAccess
{
    /// <summary>
    /// EFCore连接操作数据库的核心类
    /// </summary>
    public class ReadingDbContext:DbContext
    {
        public ReadingDbContext()
        {

        }

        public ReadingDbContext(DbContextOptions<ReadingDbContext> options)
            :base(options)
        {

        }

        public virtual DbSet<BookEntityInfo> BookEntityInfos { get; set; }

        public virtual DbSet<BookContentInfo> BookContentInfos { get; set; }

        /// <summary>
        /// 配置dbContext需要的参数,比如数据库连接具体配置信息
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseNpgsql($"Server={Server};Port={Port};User Id={User};Password={Password}; " +
                //    $" Database={DataBase}; Pooling=False");

                optionsBuilder.UseNpgsql($"Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgres; " +
                    $" Database=dbreadingpt; Pooling=False");
            }

        }

        /// <summary>
        /// 配置数据库表映射关系
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntityInfo>(entity =>
            {
                entity.ToTable("BookEntityInfo");
            });
            modelBuilder.Entity<BookContentInfo>(entity =>
            {
                entity.ToTable("BookContentInfo");
            });
            
            
        }


    }
}