using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerish.Domain.Models
{
    public class NodeItemBO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }

        public bool Expanded { get; set; }
        public bool Selected { get; set; }

        public bool HasChild { get => Children != null && Children.Any(); }


        public List<NodeItemBO> Children { get; set; } = new List<NodeItemBO>();
    }
}