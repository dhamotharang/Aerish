using System;
using System.Collections.Generic;
using System.Text;

namespace Aerish.Domain.Models
{
    public class NodeItemSetBO
    {
        public NodeItemBO SelectedNode { get; set; }
        public IEnumerable<NodeItemBO> Nodes { get; set; }
    }
}
