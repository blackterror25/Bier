﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bier.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class beerEntities : DbContext
    {
        public beerEntities()
            : base("name=beerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aspnetroles> aspnetroles { get; set; }
        public virtual DbSet<aspnetuserclaims> aspnetuserclaims { get; set; }
        public virtual DbSet<aspnetuserlogins> aspnetuserlogins { get; set; }
        public virtual DbSet<aspnetusers> aspnetusers { get; set; }
        public virtual DbSet<bier> bier { get; set; }
        public virtual DbSet<inhoud> inhoud { get; set; }
        public virtual DbSet<item> item { get; set; }
        public virtual DbSet<locatie> locatie { get; set; }
    }
}