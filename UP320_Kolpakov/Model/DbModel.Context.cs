﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP320_Kolpakov.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Zakaz_220_KolpakovEntities : DbContext
    {
        public Zakaz_220_KolpakovEntities()
            : base("name=Zakaz_220_KolpakovEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Academic> Academics { get; set; }
        public virtual DbSet<Caphedra> Caphedras { get; set; }
        public virtual DbSet<Disciple> Disciples { get; set; }
        public virtual DbSet<Employe> Employes { get; set; }
        public virtual DbSet<Engineer> Engineers { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Facultet> Facultets { get; set; }
        public virtual DbSet<Speciality> Specialities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<ZavCaph> ZavCaphs { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
    }
}
