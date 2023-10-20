using DecanatLiteWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using UniBase.Models;

namespace UniBase.Models
{
    public partial class DekanatModel : DbContext
    {

        public DekanatModel()
        {
            
        }

        public DekanatModel(DbContextOptions<DekanatModel> options) : base(options)
        {
            Database.EnsureCreated();
        }
        /// <summary>
        /// set what model parameters you need to return  //TODO: this shit thats not right
        /// example:
        /// ReturnFields<ДекВсеДанныеСтудента>()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>List<string></returns>
        public List<string> ReturnDbFields<T>()
        {
            var entityType = this.Model.FindEntityType(typeof(T));
            if (entityType != null)
            {
                List<string> propertyNames = entityType.GetProperties().Select(p => p.Name).ToList();
                return propertyNames;
            }
            return null;
        }
        // Это кажеться мне не правильным
        public List<string> ReturnДекВсеДанныеСтудентаFields()
        {
            return ДекВсеДанныеСтудента.First().ModelField();
        }
        public virtual DbSet<ДекВсеДанныеСтудента> ДекВсеДанныеСтудента { get; set; }
        public virtual DbSet<ДекСпециальности> ДекСпециальности { get; set; }
        public virtual DbSet<ДекСписокГруппФакультета> ДекСписокГруппФакультета {get; set; }
        public virtual DbSet<Факультеты> Факультеты { get; set; }
        public virtual DbSet<ufuОценкиТекущаяУспеваемость> ufuОценкиТекущаяУспеваемость { get; set; }
        //TODO: this shit thats not right
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=sql;Database=Деканат;Trusted_Connection=True; TrustServerCertificate=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ДекВсеДанныеСтудента>()
                  .HasKey(m => new { m.ФИО });
            modelBuilder.Entity<ДекСпециальности>()
                  .HasKey(m => new { m.Код });
            modelBuilder.Entity<ДекСписокГруппФакультета>()
                 .HasKey(m => new { m.Код });
            modelBuilder.Entity<Факультеты>()
               .HasKey(m => new { m.Код });
            modelBuilder.Entity<ufuОценкиТекущаяУспеваемость>()
               .HasKey(m => new { m.КодЖурнала });
        }
    }
}
