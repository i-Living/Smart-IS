using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfThenFoodProgram
{
    /// <summary>
    /// Реализация правила
    /// </summary>
    [Serializable]
    public class Rule
    {
        /// <summary>
        /// Простой конструктор
        /// </summary>
        public Rule() { } 
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="loadInfo">информация</param>
        /// <param name="factsList">Лист фактов</param>
        /// <param name="conclusionsList">Лист выводов</param>
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
        
        public List<Fact> If { get; set; } //Лист фактов
        public Conclusion Then { get; set; } //Лист выводов

        public override string ToString() //Вернуть строку If Then
        {
            string result = "IF (";
            foreach (var fact in If)
                result += fact + "&";
            return result.Substring(0, result.Length - 1) + ") THEN " + Then;
        }
    }
}
