using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetwork
{
    /// <summary>
    /// Реализация связей
    /// </summary>
    [Serializable]
    public enum LinkType
    {
        Is_a,
        AKO
    }

    [Serializable]
    public class Link
    {
        public int Id { get; set; } // id связи
        public LinkType LinkType { get; set; } // тип связи

        public override string ToString() // возвращает id
        {
            return Id.ToString();
        }
    }
}
