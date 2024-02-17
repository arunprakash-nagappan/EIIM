using Microsoft.EntityFrameworkCore;
using travel.Models;
 
public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){
 
    }
    public DbSet<Signup> users {get; set;}
}