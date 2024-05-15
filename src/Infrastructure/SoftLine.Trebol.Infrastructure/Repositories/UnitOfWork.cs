﻿using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Infrastructure.Persistence;
using System.Collections;

namespace SoftLine.Trebol.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable? _repositories;

    private readonly TrebolDbContext _context;

    public UnitOfWork(TrebolDbContext context)
    {
        _context = context;
    }


    public async Task<int> Complete()
    {

        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception("Error en transacion", e);
        }

    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        if (_repositories is null)
        {
            _repositories = new Hashtable();
        }

        var type = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(RepositoryBase<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IAsyncRepository<TEntity>)_repositories[type]!;


    }
}
