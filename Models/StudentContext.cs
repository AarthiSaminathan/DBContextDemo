using Microsoft.EntityFrameworkCore;

namespace DbDemo.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
        public DbSet<Department> Department{get;set;}
        public DbSet<Student> Student{get;set;}


        
    }
}