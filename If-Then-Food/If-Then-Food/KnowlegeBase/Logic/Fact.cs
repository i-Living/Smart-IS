using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfThenFoodProgram
{
    /// <summary>
    /// Реализация факта
    /// </summary>
    [Serializable]
    public class Fact
    {
        public string ConditionTitle { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
