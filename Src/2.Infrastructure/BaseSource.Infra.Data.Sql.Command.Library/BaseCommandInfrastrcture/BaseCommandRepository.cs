﻿using BaseSource.Core.Application.Library.BaseApplication.Contracts.Data.Commands;
using BaseSource.Core.Domain.Library.BaseDomain.Entities;
using BaseSource.Core.Domain.Library.BaseDomain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaseSource.Infra.Data.Sql.Command.Library.BaseCommandInfrastrcture;


/// <summary>
/// پایه سرویس های مورد نظری که لازم داریم  برای یک موجودیت یا دامنه
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TDbContext"></typeparam>
/// <typeparam name="TId"></typeparam>
public class BaseCommandRepository<TEntity, TDbContext, TId> : ICommandRepository<TEntity, TId>, IUnitOfWork
    where TEntity : AggregateRoot<TId>
    where TDbContext : BaseCommandDbContext
     where TId : struct,
          IComparable,
          IComparable<TId>,
          IConvertible,
          IEquatable<TId>,
          IFormattable
{

    protected readonly TDbContext _dbContext;

    public BaseCommandRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    public void Delete(TId id)
    {
        var entity = _dbContext.Set<TEntity>().Find(id);
        _dbContext.Set<TEntity>().Remove(entity);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    public void DeleteGraph(TId id)
    {
        var entity = GetGraph(id);
        if (entity is not null && !entity.Id.Equals(default))
            _dbContext.Set<TEntity>().Remove(entity);
    }





    #region insert
    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>

    public void Insert(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task InsertAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }
    #endregion

    #region Get Single Item

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TEntity Get(TId id)
    {
        return _dbContext.Set<TEntity>().Find(id);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="businessId"></param>
    /// <returns></returns>
    public TEntity Get(BusinessId businessId)
    {
        return _dbContext.Set<TEntity>().FirstOrDefault(c => c.BusinessId == businessId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TEntity> GetAsync(TId id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="businessId"></param>
    /// <returns></returns>
    public async Task<TEntity> GetAsync(BusinessId businessId)
    {
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(c => c.BusinessId == businessId);
    }
    #endregion

    #region Get single item with graph

    /// <summary>
    /// دریافت تمامی شاخه موجودیت و زیر شاخه هایش
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TEntity GetGraph(TId id)
    {
        var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
        IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
        var temp = graphPath.ToList();
        foreach (var item in graphPath)
        {
            query = query.Include(item);
        }
        return query.FirstOrDefault(c => c.Id.Equals(id));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="businessId"></param>
    /// <returns></returns>
    public TEntity GetGraph(BusinessId businessId)
    {
        var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
        IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
        var temp = graphPath.ToList();
        foreach (var item in graphPath)
        {
            query = query.Include(item);
        }
        return query.FirstOrDefault(c => c.BusinessId == businessId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<TEntity> GetGraphAsync(TId id)
    {
        var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
        IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
        foreach (var item in graphPath)
        {
            query = query.Include(item);
        }
        return await query.FirstOrDefaultAsync(c => c.Id.Equals(id));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="businessId"></param>
    /// <returns></returns>
    public async Task<TEntity> GetGraphAsync(BusinessId businessId)
    {
        var graphPath = _dbContext.GetIncludePaths(typeof(TEntity));
        IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
        foreach (var item in graphPath)
        {
            query = query.Include(item);
        }
        return await query.FirstOrDefaultAsync(c => c.BusinessId == businessId);
    }
    #endregion

    #region Exists
    /// <summary>
    /// 
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return _dbContext.Set<TEntity>().Any(expression);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbContext.Set<TEntity>().AnyAsync(expression);
    }
    #endregion

    #region Transaction management
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int Commit()
    {
        return _dbContext.SaveChanges();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Task<int> CommitAsync()
    {
        return _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    public void BeginTransaction()
    {
        _dbContext.BeginTransaction();
    }


    /// <summary>
    /// 
    /// </summary>
    public void CommitTransaction()
    {
        _dbContext.CommitTransaction();
    }

    /// <summary>
    /// 
    /// </summary>
    public void RollbackTransaction()
    {
        _dbContext.RollbackTransaction();
    }
    #endregion
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntity">حتما باید از جنس AggregateRoot باشد</typeparam>
/// <typeparam name="TDbContext">حتما باید از جنس BaseCommandDbContext باشد</typeparam>
public class BaseCommandRepository<TEntity, TDbContext> : BaseCommandRepository<TEntity, TDbContext, long>
    where TEntity : AggregateRoot
    where TDbContext : BaseCommandDbContext
{
    public BaseCommandRepository(TDbContext dbContext) : base(dbContext)
    {
    }
}