using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.DAL.Data;
using Common.DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Common.DAL
{
  public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
  {
    private readonly DbSet<T> _dbSet;
    protected ApplicationDbContext Db { get; }

    public RepositoryAsync(ApplicationDbContext db)
    {
      _dbSet = db.Set<T>();
      Db = db;
    }

    public async Task<T> GetAsync(int id)
    {
      return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
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

      return orderBy != null ? await orderBy(query).ToListAsync() : await query.ToListAsync();
    }

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null,
      string includeProperties = null)
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

      return await query.FirstOrDefaultAsync();
    }

    public async Task AddAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
    }

    public async Task RemoveAsync(int id)
    {
      var entity = await _dbSet.FindAsync(id);
      await RemoveAsync(entity);
    }

    public async Task RemoveAsync(T entity)
    {
      _dbSet.Remove(entity);
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
      _dbSet.RemoveRange(entities);
    }
  }
}