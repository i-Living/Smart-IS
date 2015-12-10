using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetwork
{
    public class KnowlegeBaseManager
    {
        public KnowlegeBase Base { get; }

        public KnowlegeBaseManager(KnowlegeBase kb)
        {
            Base = kb;
        }

        public void AddNode(Node node)
        {
            if (Base.Nodes.Find(x => x.Id == node.Id) != null)
                throw new Exception("Multiple id entry");
            Base.Nodes.Add(node);
        }

        public void RemoveNode(int id)
        {
            Base.Nodes.RemoveAll(x => x.Id == id);
        }

        public void SetNodeChilds(int id, IEnumerable<Link> childs)
        {
            Base.Nodes.Find(x => x.Id == id).Childs = childs.ToList();
        }

        public void SetNodeVariants(int id, IEnumerable<Variant> variants)
        {
            Base.Nodes.Find(x => x.Id == id).Variants = variants.ToList();
        }

        public int MaxNodeId
        {
            get
            {
                return Base.Nodes.Count > 0 ? (from node in Base.Nodes select node.Id).Max() : 0;
            }
        }

        public Node GetById(int id)
        {
            return Base.Nodes.Find(x => x.Id == id);
        }

        public IEnumerable<Node> GetChilds(int id)
        {
            /*List<Node> result = new List<Node>();
            foreach (var link in GetById(id).Childs)
                result.Add(GetById(link.Id));
            return result;*/
            return from link in GetById(id).Childs select GetById(link.Id);
        }

        public IEnumerable<Node> GetParents(int id)
        {
            return from link in GetParentLinks(id) select GetById(link.Id);
        }

        public IEnumerable<Link> GetParentLinks(int id)
        {
            List<Link> result = new List<Link>();
            foreach (var node in Base.Nodes)
                foreach (var link in node.Childs)
                    if (link.Id == id)
                        yield return new Link() { Id = node.Id, LinkType = link.LinkType };
        }

        public IEnumerable<NodeViewModel> GetViewModels()
        {
            foreach (var node in Base.Nodes)
            {
                yield return new NodeViewModel()
                {
                    Id = node.Id.ToString(),
                    Variants = string.Join(", ", from variant in node.Variants select variant.ToString()),
                    Childs = string.Join(", ", from link in node.Childs select link.ToString()),
                    Parents = string.Join(", ", GetParentLinks(node.Id)),
                };
            }
        }
    }
}
