using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using TinyCsvParser.Mapping;

namespace Aerish.Imports.Commands.ImportCommands
{
    public class BaseCsvMapping<T> : CsvMapping<T> where T : class, new()
    {
        public BaseCsvMapping() 
            : base()
        {
        }

        public new BaseCsvMapping<T> MapProperty<TProperty>(int columnIndex, Expression<Func<T, TProperty>> property)
        {
            base.MapProperty(columnIndex, property);

            return this;
        }
    }
}
