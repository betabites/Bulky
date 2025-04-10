using System.Linq;
using System.Linq.Expressions;
using BulkyWeb.Data;
using BulkyWeb.Models;

namespace SD7501Bulky.DataAccess.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private ApplicationDbContext _db;
    
    public CategoryRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Category category)
    {
        _db.Update(category);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}