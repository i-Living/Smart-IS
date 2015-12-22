using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetwork
{
    /// <summary>
    /// Класс, создающий ветви дерева
    /// </summary>
    class NodeBuilder
    {
        Node node;
        public NodeBuilder()
        {
            node = new Node();
        }
        public NodeBuilder SetId(int id)
        {
            node.Id = id;
            return this;
        }
        public NodeBuilder AddChild(Link link)
        {
            node.Childs.Add(link);
            return this;
        }

        public NodeBuilder SetChilds(List<Link> childs)
        {
            node.Childs = childs;
            return this;
        }

        public NodeBuilder AddVariant(Variant variant)
        {
            node.Variants.Add(variant);
            return this;
        }

        public NodeBuilder AddVariant(string title, string linkName)
        {
            node.Variants.Add(new Variant() { Title = title, LinkName = linkName });
            return this;
        }

        public NodeBuilder SetVariants(List<Variant> variants)
        {
            node.Variants = variants;
            return this;
        }

        public Node GetNode()
        {
            return node;
        }
    }
}
