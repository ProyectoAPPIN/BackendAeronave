﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.mercaderia.bono.Entidades.ModeloEntidades
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AeronauticaEntities : DbContext
    {
        public AeronauticaEntities()
            : base("name=AeronauticaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aeronaves> Aeronaves { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
