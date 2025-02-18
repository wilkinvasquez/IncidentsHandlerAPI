﻿using IncidentsHandler.Data.Context;
using IncidentsHandler.Data.Repositories.Interfaces.BaseInterface;
using IncidentsHandler.Domain.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IncidentsHandler.Data.Repositories.Entities.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly IncidentsHandlerDbContext _context;

        public BaseRepository(IncidentsHandlerDbContext context)
        {
            _context = context;
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().AsNoTracking().Where(expression).Where(t => t.IsDeleted == false).FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().Where(t => t.IsDeleted == false);
        }

        public ICollection<T> GetAllList()
        {
            return _context.Set<T>().AsNoTracking().Where(t => t.IsDeleted == false).ToList();
        }

        public int Create(T entity)
        {
            _context.Set<T>().AddAsync(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
