using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetwork
{
    [Serializable]
    public enum LinkType
    {
        Is_a,
        AKO
    }

    [Serializable]
    public class Link
    {
        public int Id { get; set; }
        public LinkType LinkType { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
