using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetwork
{
    public class NodeViewModel
    {
        public string Id { get; set; }
        public string Childs { get; set; }
        public string Parents { get; set; }
        public string Variants { get; set; }
    }
}
