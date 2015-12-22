using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetwork
{
    /// <summary>
    /// Представление для ветвей
    /// </summary>
    public class NodeViewModel
    {
        public string Id { get; set; } // id связи
        public string Childs { get; set; } // зависимая ветвь
        public string Parents { get; set; } // верхняя ветвь
        public string Variants { get; set; } // варианты
    }
}
