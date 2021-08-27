using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Common.DAL.Data;
using Common.DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Common.DAL
{
  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly DbSet<T> _dbSet;
    protected ApplicationDbContext Db { get; }

    public Repository(ApplicationDbContext db)
    {
      _dbSet = db.Set<T>();
      Db = db;
    }

    public T Get(int id)
    {
      return _dbSet.Find(id);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
    {
      var query = _dbSet.AsQueryable();

      if (filter != null)
        query = query.Where(filter);

      if (includeProperties != null)
      {
        foreach (var includeProp in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
        {
          query = query.Include(includeProp);
        }
      }

      return orderBy != null ? orderBy(query).ToList() : query.ToList();
    }

    public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
    {
      var query = _dbSet.AsQueryable();

      if (filter != null)
        query = query.Where(filter);

      if (includeProperties != null)
      {
        foreach (var includeProp in includeProperties.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries))
        {
          query = query.Include(includeProp);
        }
      }

      return query.FirstOrDefault();
    }

    public void Add(T entity)
    {
      _dbSet.Add(entity);
    }

    public void Remove(int id)
    {
      var entity = _dbSet.Find(id);
      _dbSet.Remove(entity);
    }

    public void Remove(T entity)
    {
      _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
      _dbSet.RemoveRange(entities);
    }
  }
}