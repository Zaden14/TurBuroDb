//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurBuroDb
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities3 : DbContext
    {
        public Entities3()
            : base("name=Entities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<ВидТура> ВидТура { get; set; }
        public virtual DbSet<Должность> Должность { get; set; }
        public virtual DbSet<ИнформацияКлиента> ИнформацияКлиента { get; set; }
        public virtual DbSet<Питание> Питание { get; set; }
        public virtual DbSet<Пол> Пол { get; set; }
        public virtual DbSet<Пользователь> Пользователь { get; set; }
        public virtual DbSet<Проживание> Проживание { get; set; }
        public virtual DbSet<Роли> Роли { get; set; }
        public virtual DbSet<Страны> Страны { get; set; }
        public virtual DbSet<Тур> Тур { get; set; }
        public virtual DbSet<Фото> Фото { get; set; }
    }
}
