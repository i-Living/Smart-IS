using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemanticNetwork
{
    class InferenceEngine
    {
        KnowlegeBaseManager knowlegeBaseManager;

        public InferenceEngine(KnowlegeBaseManager knowlegeBaseManager)
        {
            this.knowlegeBaseManager = knowlegeBaseManager;
        }
        
        public void Search(Sentence sentence)
        {
            List<string> result = new List<string>();

            //Search nodes which contain the data from sentence
            Dictionary<Node, int> dataNodes = new Dictionary<Node, int>();
            foreach (var node in knowlegeBaseManager.Base.Nodes)
            {
                foreach (var variant in node.Variants)
                {
                    if (sentence.Data.Contains(variant.Title))
                    {
                        if (!dataNodes.ContainsKey(node))
                            dataNodes.Add(node, 0);
                        dataNodes[node]++;
                    }
                }
            }
            Dictionary<Variant, int> variants = new Dictionary<Variant, int>();
            foreach (KeyValuePair<Node,int> pair in dataNodes)
            {
                CheckNode(pair.Key, pair.Value, sentence, variants);
            }
            MessageBox.Show(string.Join("\n", from pair in variants orderby pair.Value descending select string.Format("{0}({1})", pair.Key, pair.Value)));
        }

        void CheckNode(Node node, int multiplyer, Sentence sentence, Dictionary<Variant, int> variants)
        {
            foreach (var variant in node.Variants)
            {
                if (sentence.Question.Contains(variant.LinkName))
                {
                    if (!variants.ContainsKey(variant))
                        variants.Add(variant, 0);
                    variants[variant] += 1 * multiplyer;
                }
            }
            foreach (var childNode in knowlegeBaseManager.GetChilds(node.Id))
            {
                CheckNode(childNode, multiplyer, sentence, variants);
            }
        }
    }
}
