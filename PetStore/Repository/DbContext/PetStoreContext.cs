using PetStore.Areas.Admin.Models;
using PetStore.Repository.PocoClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.PetStore.DAL.Context
{
    public interface IPetStoreContext
    {
        DbSet<AnimalType> AnimalType { get; set; }
        DbSet<Pet> Pet { get; set; }
    }
    public class PetStoreContext : DbContext
    {
        public DbSet<AnimalType> AnimalType { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Pages> CmsPage { get; set; }
        public PetStoreContext() : base ("PetStoreContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<PetStoreContext>(null);
            base.OnModelCreating(modelBuilder);
        }


    }
}