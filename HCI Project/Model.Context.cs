﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HCI_Project
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class databaseEntities : DbContext
    {
        public databaseEntities()
            : base("name=databaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Maps> Maps { get; set; }
        public virtual DbSet<ResourceLocation> ResourceLocation { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Tag_Species> Tag_Species { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Species> Species { get; set; }
    }
}