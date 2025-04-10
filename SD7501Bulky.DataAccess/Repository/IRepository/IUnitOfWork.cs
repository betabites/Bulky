namespace SD7501Bulky.DataAccess.Repository;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }
    void Save();
}