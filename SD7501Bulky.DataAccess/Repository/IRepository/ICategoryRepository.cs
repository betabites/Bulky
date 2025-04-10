using BulkyWeb.Models;

namespace SD7501Bulky.DataAccess.Repository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category category);
    void Save();
}