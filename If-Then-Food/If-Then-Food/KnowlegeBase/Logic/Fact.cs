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
        public string ConditionTitle { get; set; } //Название главной ветки 
        public string Title { get; set; } //Название ветки факта
        public string Question { get; set; } //Вопрос

        public override string ToString() //Вернуть название факта
        {
            return Title;
        }
    }
}
