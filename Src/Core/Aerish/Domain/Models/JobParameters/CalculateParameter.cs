using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aerish.Domain.Common;

namespace Aerish.Domain.Models
{
    public class CalculateParameter : ParameterDictionary
    {
        public short PlanYear 
        {
            get => GetAs<short>(nameof(PlanYear));
            set => this[nameof(PlanYear)] = new ParameterBO(nameof(PlanYear), value);
        }

        public short PayRunID 
        {
            get => GetAs<short>(nameof(PayRunID));
            set => this[nameof(PayRunID)] = new ParameterBO(nameof(PayRunID), value);
        }

        public int? PersonID 
        {
            get => GetAs<int?>(nameof(PersonID));
            set => this[nameof(PersonID)] = new ParameterBO(nameof(PersonID), value);
        }

        public int? SpecialGroupID
        {
            get => GetAs<int?>(nameof(SpecialGroupID));
            set => this[nameof(SpecialGroupID)] = new ParameterBO(nameof(SpecialGroupID), value);
        }
    }
}
