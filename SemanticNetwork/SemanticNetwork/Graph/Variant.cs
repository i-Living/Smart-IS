using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetwork
{
    [Serializable]
    public class Variant
    {
        public string Title { get; set; }
        public string LinkName { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}; {1}]", Title, LinkName);
        }
    }
}
