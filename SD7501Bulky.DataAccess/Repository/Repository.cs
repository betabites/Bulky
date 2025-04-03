using System.Linq.Expressions;

namespace SD7501Bulky.DataAccess.Repository;

internal class Repository<T>: IRepository<T> where T : class
{
    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(T entity)
    {
        throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }
}