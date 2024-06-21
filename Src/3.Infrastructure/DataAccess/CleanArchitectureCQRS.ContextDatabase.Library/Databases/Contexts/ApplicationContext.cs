﻿using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.ContextDatabase.Library.People;
using CleanArchitectureCQRS.Domain.Library.Base.Domain.ValueObjects;
using CleanArchitectureCQRS.Domain.Library.Catalogs.Entities;
using CleanArchitectureCQRS.Domain.Library.People.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace CleanArchitectureCQRS.ContextDatabase.Library.Databases.Contexts;

public class ApplicationContext : DbContext, IApplicationContext
{
    protected IDbContextTransaction _transaction;

    //public DbSet<Person> People { get; set; }
    public DbSet<CatalogItem> CatalogItems { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }
    protected ApplicationContext()
    {
    }


    public void BeginTransaction()
    {
        _transaction = Database.BeginTransaction();
    }

    public void RollbackTransaction()
    {
        if (_transaction == null)
        {
            throw new NullReferenceException("Please call `BeginTransaction()` method first.");
        }
        _transaction.Rollback();
    }

    public void CommitTransaction()
    {
        if (_transaction == null)
        {
            throw new NullReferenceException("Please call `BeginTransaction()` method first.");
        }
        _transaction.Commit();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<FirstName>().HaveConversion<FirstNameConversion>();
        configurationBuilder.Properties<LastName>().HaveConversion<LastNameConversion>();
    }

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}