﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThidasaAssignemnt.DbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ThidasaDbEntities : DbContext
    {
        public ThidasaDbEntities()
            : base("name=ThidasaDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AssignedJob> AssignedJobs { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<QualificationsOfEmployee> QualificationsOfEmployees { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
    }
}
