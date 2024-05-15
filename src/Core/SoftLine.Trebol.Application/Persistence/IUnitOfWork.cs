﻿namespace SoftLine.Trebol.Application.Persistence;

public interface IUnitOfWork : IDisposable
{
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> Complete();
}