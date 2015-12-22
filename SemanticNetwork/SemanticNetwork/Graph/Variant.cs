using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetwork
{
    /// <summary>
    /// Хранение различных вариантов
    /// </summary>
    [Serializable]
    public class Variant
    {
        public string Title { get; set; } // название
        public string LinkName { get; set; } // имя связи

        public override string ToString() // выводит название и имя связи
        {
            return string.Format("[{0}; {1}]", Title, LinkName);
        }
    }
}
