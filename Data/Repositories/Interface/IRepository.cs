namespace StudentWebApi.Data.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        // Inserts a new entity of type T into the database.
        int Insert(T entity);
        // Inserts a range of entities of type T into the database.
        int InsertRange(IEnumerable<T> entities);
        // Updates an existing entity of type T in the database.
        int Update(T entity);
        // Deletes an existing entity of type T from the database.
        int Delete(T entity);
        // Deletes a range of entities of type T from the database.
        int DeleteRange(IEnumerable<T> entities);
        // Returns the total number of entities of type T in the database.
        int Count();
        // Returns a list of all entities of type T in the database.
        List<T> List();
        // Returns a list of all entities of type T in the database asynchronously.
        Task<List<T>> ListAsync();
        // Returns an entity of type T by its primary key from the database.
        T? Find(Guid id);
        // Returns an entity of type T by its primary key from the database asynchronously.
        Task<T?> FindAsync(Guid id);
        // Returns an IEnumerable of entities of type T from the database.
        IEnumerable<T> GetEnumerable();
        // Returns an IQueryable of entities of type T from the database.
        IQueryable<T> GetQueryable();

    }
}
