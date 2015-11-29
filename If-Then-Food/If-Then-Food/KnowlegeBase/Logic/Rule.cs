using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfThenFoodProgram
{
    [Serializable]
    public class Rule
    {
        public Rule() { }

        public Rule(string loadInfo, List<Fact> factsList, List<Conclusion> conclusionsList)
        {
            If = new List<Fact>();
            string factsString = string.Empty;
            int i = 4;
            while (loadInfo[i] != ')')
            {
                factsString += loadInfo[i];
                i++;
            }
            i += 7;
            Then = conclusionsList.Find(x => x.Title == loadInfo.Substring(i, loadInfo.Length - i));
            foreach (var factString in factsString.Split('&'))
                If.Add(factsList.Find(x => x.Title == factString));
        }
        
        public List<Fact> If { get; set; }
        public Conclusion Then { get; set; }

        public override string ToString()
        {
            string result = "IF (";
            foreach (var fact in If)
                result += fact + "&";
            return result.Substring(0, result.Length - 1) + ") THEN " + Then;
        }
    }
}
