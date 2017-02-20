﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContactManagement.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ContactEntities : DbContext
    {
        public ContactEntities()
            : base("name=ContactEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Name> Names { get; set; }
    
        public virtual ObjectResult<GetAllContact_Result> GetAllContact()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllContact_Result>("GetAllContact");
        }
    
        public virtual int SaveContact(string firstname, string lastname, string mi, string suffix, string street, string direction, string streetName, string streetType, string city, string state, Nullable<int> zip)
        {
            var firstnameParameter = firstname != null ?
                new ObjectParameter("Firstname", firstname) :
                new ObjectParameter("Firstname", typeof(string));
    
            var lastnameParameter = lastname != null ?
                new ObjectParameter("Lastname", lastname) :
                new ObjectParameter("Lastname", typeof(string));
    
            var miParameter = mi != null ?
                new ObjectParameter("Mi", mi) :
                new ObjectParameter("Mi", typeof(string));
    
            var suffixParameter = suffix != null ?
                new ObjectParameter("Suffix", suffix) :
                new ObjectParameter("Suffix", typeof(string));
    
            var streetParameter = street != null ?
                new ObjectParameter("Street", street) :
                new ObjectParameter("Street", typeof(string));
    
            var directionParameter = direction != null ?
                new ObjectParameter("Direction", direction) :
                new ObjectParameter("Direction", typeof(string));
    
            var streetNameParameter = streetName != null ?
                new ObjectParameter("StreetName", streetName) :
                new ObjectParameter("StreetName", typeof(string));
    
            var streetTypeParameter = streetType != null ?
                new ObjectParameter("StreetType", streetType) :
                new ObjectParameter("StreetType", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var stateParameter = state != null ?
                new ObjectParameter("State", state) :
                new ObjectParameter("State", typeof(string));
    
            var zipParameter = zip.HasValue ?
                new ObjectParameter("Zip", zip) :
                new ObjectParameter("Zip", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveContact", firstnameParameter, lastnameParameter, miParameter, suffixParameter, streetParameter, directionParameter, streetNameParameter, streetTypeParameter, cityParameter, stateParameter, zipParameter);
        }
    }
}
