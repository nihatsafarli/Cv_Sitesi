﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resume.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbResumeEntities : DbContext
    {
        public DbResumeEntities()
            : base("name=DbResumeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbladmin> tbladmin { get; set; }
        public virtual DbSet<tbldeneyimler> tbldeneyimler { get; set; }
        public virtual DbSet<tblegitimler> tblegitimler { get; set; }
        public virtual DbSet<tblhakkimda> tblhakkimda { get; set; }
        public virtual DbSet<tblhobiler> tblhobiler { get; set; }
        public virtual DbSet<tbliletisim> tbliletisim { get; set; }
        public virtual DbSet<tblsertifikalar> tblsertifikalar { get; set; }
        public virtual DbSet<tblyetenekler> tblyetenekler { get; set; }
        public virtual DbSet<tblsosyalmedya> tblsosyalmedya { get; set; }
    }
}
