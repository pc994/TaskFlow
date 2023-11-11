using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Model;
using Task = TaskFlow.Domain.Model.Task;

namespace TaskFlow.Infrastructure
{
    public class DbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDetail> ProjectDetails { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskAuditableModel> TaskAuditableModels { get; set; }
        public DbSet<TaskTag> TaskTag { get; set; }

        public DbContext(DbContextOptions options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            //1:1
            modelbuilder.Entity<Task>()
                .HasOne(t => t.TaskAuditableModel)
                .WithOne(t => t.Task)
                .HasForeignKey<TaskAuditableModel>(fk => fk.TaskId);

            modelbuilder.Entity<Project>()
                .HasOne(p => p.ProjectDetail)
                .WithOne(p => p.Project)
                .HasForeignKey<ProjectDetail>(fk => fk.ProjectId);


        }
    }
}
