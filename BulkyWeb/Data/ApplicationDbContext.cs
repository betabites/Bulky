using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
    
}