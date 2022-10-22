﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class APozosSuperDigitoEntities : DbContext
    {
        public APozosSuperDigitoEntities()
            : base("name=APozosSuperDigitoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SuperDigito> SuperDigitoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    
        public virtual int DigitoAdd(Nullable<int> numero, Nullable<int> resultado, string fechaHora, Nullable<int> idUsuario)
        {
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("Numero", numero) :
                new ObjectParameter("Numero", typeof(int));
    
            var resultadoParameter = resultado.HasValue ?
                new ObjectParameter("Resultado", resultado) :
                new ObjectParameter("Resultado", typeof(int));
    
            var fechaHoraParameter = fechaHora != null ?
                new ObjectParameter("FechaHora", fechaHora) :
                new ObjectParameter("FechaHora", typeof(string));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DigitoAdd", numeroParameter, resultadoParameter, fechaHoraParameter, idUsuarioParameter);
        }
    
        public virtual int UsuarioAdd(string nombre, string apellidoPaterno, string apellidoMaterno, string userName, string password)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, userNameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<DigitoHistorial_Result> DigitoHistorial(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DigitoHistorial_Result>("DigitoHistorial", idUsuarioParameter);
        }
    
        public virtual ObjectResult<UsuarioGetByUser_Result> UsuarioGetByUser(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetByUser_Result>("UsuarioGetByUser", userNameParameter);
        }
    
        public virtual int HistorialDelete(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HistorialDelete", idUsuarioParameter);
        }
    
        public virtual int DigitoUpdate(Nullable<int> numero, Nullable<int> idUsuario)
        {
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("Numero", numero) :
                new ObjectParameter("Numero", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DigitoUpdate", numeroParameter, idUsuarioParameter);
        }
    
        public virtual int HistorialDeleteBy(Nullable<int> numero, Nullable<int> idUsuario)
        {
            var numeroParameter = numero.HasValue ?
                new ObjectParameter("Numero", numero) :
                new ObjectParameter("Numero", typeof(int));
    
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("HistorialDeleteBy", numeroParameter, idUsuarioParameter);
        }
    }
}