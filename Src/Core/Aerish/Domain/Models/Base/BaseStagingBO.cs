using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class BaseStagingBO
    {
        public LoadStatus LoadStatus { get; set; }


        public int RowIndex { get; set; }
        public bool ImportIsValid { get; set; }
        public bool ValidationIsValid { get; set; }


        public MappingError MappingError { get; set; }

        public IEnumerable<ValidationFailureBO> ValidationFailures { get; set; } = new List<ValidationFailureBO>();

    }

    public class MappingError
    {
        public int? ColumnIndex { get; set; }
        public string Value { get; set; }
        public string UnmappedRow { get; set; }
    }
}
