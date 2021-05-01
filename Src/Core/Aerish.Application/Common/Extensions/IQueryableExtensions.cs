using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aerish.Application
{
    public static class IQueryableExtensions
    {
        public static EntityEntry<T> Add<T>(this IQueryable<T> set, T newEntry) where T : class
        {
            var dbSet = (DbSet<T>)set;

            return dbSet.Add(newEntry);
        }
    }
}
