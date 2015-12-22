using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfThenFoodProgram
{
    /// <summary>
    /// Реализация вывода
    /// </summary>
    public class Conclusion
    {
        public string Title { get; set; } //Название

        public override string ToString() //Вернуть название
        {
            return Title;
        }
    }
}
