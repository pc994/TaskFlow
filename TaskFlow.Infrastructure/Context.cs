using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Model;
using Task = TaskFlow.Domain.Model.Task;

namespace TaskFlow.Infrastructure
{
    public class Context : IdentityDbContext
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

        public Context(DbContextOptions options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //seed data
            var category1 = new Category() { Id = 1, Name = "Software" };
            var category2 = new Category() { Id = 2, Name = "Hardware" };
            var category3 = new Category() { Id = 3, Name = "Permission" };
            var category4 = new Category() { Id = 4, Name = "Other" };

            var status1 = new Status() { Id = 1, Name = "New" };
            var status2 = new Status() { Id = 2, Name = "In progress" };
            var status3 = new Status() { Id = 3, Name = "Suspensed" };
            var status4 = new Status() { Id = 4, Name = "Completed" };

            var priority1 = new Priority() { Id = 1, Name = "Low" };
            var priority2 = new Priority() { Id = 2, Name = "Normal" };
            var priority3 = new Priority() { Id = 3, Name = "High" };
            var priority4 = new Priority() { Id = 4, Name = "INSTANT" };

            var testProject = new Project() { Id = 1, Name = "Corp", IsActive = true };

            modelbuilder.Entity<Category>().HasData(category1, category2, category3, category4);
            modelbuilder.Entity<Status>().HasData(status1, status2, status3, status4);
            modelbuilder.Entity<Priority>().HasData(priority1, priority2, priority3, priority4);
            modelbuilder.Entity<Project>().HasData(testProject);

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

            //n:n
            modelbuilder.Entity<TaskTag>()
                .HasKey(tk => new { tk.TaskId, tk.TagId });

            modelbuilder.Entity<TaskTag>()
                .HasOne<Task>(tk => tk.Task)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tk => tk.TaskId);

            modelbuilder.Entity<TaskTag>()
                .HasOne<Tag>(tk => tk.Tag)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tk => tk.TagId);


            
        }
    }
}
