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
    public class KnowlegeBase
    {
        public KnowlegeBase()
        {
            Nodes = new List<Node>();
        }

        public List<Node> Nodes { get; set; }
    }
}
