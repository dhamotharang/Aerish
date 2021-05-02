using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Aerish.Imports
{
    public static class AerishDbContextExtensions
    {
        public static void BulkSaveChanges(this IAerishDbContext dbContext)
        {
            if (dbContext is DbContext dbC)
            {
                dbC.BulkSaveChanges();
            }
            else
            {
                dbContext.SaveChanges();
            }
        }
    }
}
