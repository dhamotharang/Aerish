using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aerish.Admin.Client.ViewModels
{
    public class PayRunVM
    {
        public short ClientID { get; set; }

        [Required]
        public short? PlanYear { get; set; }

        [Required]
        public short? PayRunID { get; set; }

        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public DateTime CutOffStart { get; set; }
        public DateTime CutOffEnd { get; set; }

        public DateTime PayoutDate { get; set; }
    }
}
