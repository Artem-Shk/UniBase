using Microsoft.EntityFrameworkCore;
using System;
using Unibase.Server.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public virtual DbSet<ДекСписокГруппФакультета> ДекСписокГруппФакультета { get; set; }
        public virtual DbSet<Факультеты> Факультеты { get; set; }
        public virtual DbSet<ufuОценкиТекущаяУспеваемость> ufuОценкиТекущаяУспеваемость { get; set; }
        public virtual DbSet<JournalData> prepJournalData { get; set; }
        public virtual DbSet<JournalHeaderDB> JournalHeader { get; set; }
        public virtual DbSet<ПреподавателиКафедры> ПреподавателиКафедры { get; set; }
        public virtual DbSet<Кафедры> Кафедры { get; set; }
        public virtual DbSet<Преподаватели> Преподаватели { get; set; }
        public virtual DbSet<ЖурналДанные> ЖурналДанные { get; set; }
        public virtual DbSet<ЖурналЗначения> ЖурналЗначения { get; set; }
        public virtual DbSet<ЖурналДаты> ЖурналДаты { get; set; }
        public virtual DbSet<Все_Группы> Все_Группы { get;  set; }
        public virtual DbSet<ЖурналПреподавателя> ЖурналПреподавателя { get; set; }
        public virtual DbSet<JournalPartRow> JournalPartRow { get; set; }
        public virtual DbSet<Нагрузка> Нагрузка { get; set;}
        //TODO: this shit thats not right 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Деканат;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ДекВсеДанныеСтудента>()
                  .HasKey(m => new { m.ФИО });
            modelBuilder.Entity<ДекСпециальности>()
                  .HasKey(m => new { m.Код });
            modelBuilder.Entity<ДекСписокГруппФакультета>().HasKey(m => new { m.Код });
            modelBuilder.Entity<Факультеты>()
               .HasKey(m => new { m.Код });
            modelBuilder.Entity<ufuОценкиТекущаяУспеваемость>()
               .HasKey(m => new { m.КодЖурнала });
            modelBuilder.Entity<JournalData>().HasKey(m => new { m.key });
            modelBuilder.Entity<JournalHeaderDB>().HasKey(m => new { m.code});
            modelBuilder.Entity<ПреподавателиКафедры>().HasKey(m => new { m.КодКафедры });
            modelBuilder.Entity<Кафедры>().HasKey(m => new { m.Код });
            modelBuilder.Entity<Преподаватели>().HasKey(m => new { m.Код });
            modelBuilder.Entity<ЖурналДанные>().HasKey(m => new { m.Код });
            modelBuilder.Entity<ЖурналЗначения>().HasKey(m => new { m.Код });
            modelBuilder.Entity<ЖурналДаты>().HasKey(m => new { m.Код });
            modelBuilder.Entity<ЖурналПреподавателя>().HasKey(m => new { m.КодГруппы });
            modelBuilder.Entity<Все_Группы>().HasKey(m => new { m.Код });

        }
    }
}
