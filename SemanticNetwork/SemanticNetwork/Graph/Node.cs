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
        /// <summary>
        /// конструктор ветви
        /// </summary>
        public Node()
        {
            Childs = new List<Link>();
            Variants = new List<Variant>();
        }
        
        public int Id { get; set; } // id ветви
        public List<Link> Childs { get; set; } // лист связей
        public List<Variant> Variants { get; set; } // лист вариантов

        public override string ToString() // возвращает id ветви
        {
            return Id.ToString();
        }
    }
}
