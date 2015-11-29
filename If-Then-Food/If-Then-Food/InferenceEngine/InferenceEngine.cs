using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PRES_console
{
    class InferenceEngine
    {
        KnowlegeBase knowlegeBase;
        WorkMemory workMemory;

        public InferenceEngine()
        {
            knowlegeBase = XMLDataLoader.Deserialize();
            knowlegeBase.LoadRules();
            workMemory = new WorkMemory(knowlegeBase.Facts);
        }


        public void Run()
        {
            List<Fact> confirmedFacts = new List<Fact>();

            Console.WriteLine("Welcome!");
            bool exit = false;
            while (exit == false)
            {
                if (workMemory.Count == 0)
                {
                    Console.WriteLine("Nothing to analize");
                    break;
                }
                Console.WriteLine(workMemory[0].Question + " (y/n)");
                string currentAnswer = Console.ReadLine();
                string title = workMemory[0].Title;
                if (currentAnswer == "y")
                {
                    confirmedFacts.Add(workMemory[0]);
                    workMemory.RemoveAll(x => x.ConditionTitle != title);
                }
                else
                {
                    workMemory.RemoveAll(x => x.ConditionTitle == title);
                    workMemory.RemoveAt(0);
                }
                foreach (var rule in knowlegeBase.Rules)
                {
                    if (rule.If.Except(confirmedFacts).ToList().Count == 0)
                    {
                        Console.WriteLine(rule.Then);
                        exit = true;
                        break;
                    }
                }
            }
        }
    }
}
