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
        /// set what model parameters you need to return
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
        public List<string> ReturnДекВсеДанныеСтудентаFields()
        {
            return ДекВсеДанныеСтудента.First().ModelField();
        }
        public virtual DbSet<ДекВсеДанныеСтудента> ДекВсеДанныеСтудента { get; set; }
        public virtual DbSet<ДекСпециальности> ДекСпециальности { get; set; }
        
  
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
        }
    }
}
