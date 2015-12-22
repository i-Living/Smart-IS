using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetwork
{
    /// <summary>
    /// Хранение данных ветвей
    /// </summary>
    [Serializable]
    public class Node
    {
        public Node()
        {
            Childs = new List<Link>();
            Variants = new List<Variant>();
        }
        
        public int Id { get; set; }
        public List<Link> Childs { get; set; }
        public List<Variant> Variants { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
