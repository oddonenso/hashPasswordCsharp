﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PhotoStudioEntities2 : DbContext
    {
        public PhotoStudioEntities2()
            : base("name=PhotoStudioEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<clients> clients { get; set; }
        public virtual DbSet<contract> contract { get; set; }
        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<job_doljnost> job_doljnost { get; set; }
        public virtual DbSet<oborudivanie> oborudivanie { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Registration_for_Clients> Registration_for_Clients { get; set; }
        public virtual DbSet<suppliers> suppliers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
