using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PRES_console
{
    [Serializable]
    [XmlRoot("KnowlegeBase")]
    public class KnowlegeBase //Хранение знаний
    {
        [XmlIgnore]
        public List<Rule> Rules { get; set; }

        public List<string> RulesViews { get; set; }
        public List<Fact> Facts { get; set; }
        public List<Conclusion> Conclusions { get; set; }

        public void LoadRules() 
        {
            Rules = new List<Rule>();
            foreach (var ruleView in RulesViews)
                Rules.Add(new Rule(ruleView, Facts, Conclusions));
        }
    }
}
