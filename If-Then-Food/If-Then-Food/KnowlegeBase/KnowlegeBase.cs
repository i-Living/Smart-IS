using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IfThenFoodProgram
{
    /// <summary>
    /// Класс, реализующий хранение данных в виде набора правил и фактов
    /// </summary>
    [Serializable]
    [XmlRoot("KnowlegeBase")]
    public class KnowlegeBase 
    {
        [XmlIgnore]
        public List<Rule> Rules { get; set; } //Лист правил

        public List<string> RulesViews { get; set; } //Лист строк правил
        public List<Fact> Facts { get; set; } //Лист фактов
        public List<Conclusion> Conclusions { get; set; } //Лист выводов

        /// <summary>
        /// Загрузка правил
        /// </summary>
        public void LoadRules() 
        {
            Rules = new List<Rule>();
            foreach (var ruleView in RulesViews)
                Rules.Add(new Rule(ruleView, Facts, Conclusions));
        }
    }
}
