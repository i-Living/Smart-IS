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
        /// <summary>
        /// конструктор
        /// </summary>
        public NodeBuilder()
        {
            node = new Node();
        }
        public NodeBuilder SetId(int id)
        {
            node.Id = id;
            return this;
        }
        /// <summary>
        /// добавляет зависимую ветвь
        /// </summary>
        /// <param name="link">связь</param>
        /// <returns>возвращяет NodeBuilder</returns>
        public NodeBuilder AddChild(Link link)
        {
            node.Childs.Add(link);
            return this;
        }
        /// <summary>
        /// устанавливает зависимую ветвь
        /// </summary>
        /// <param name="childs"></param>
        /// <returns>возвращяет NodeBuilder</returns>
        public NodeBuilder SetChilds(List<Link> childs)
        {
            node.Childs = childs;
            return this;
        }
        /// <summary>
        /// добавляет вариант
        /// </summary>
        /// <param name="variant">вариант</param>
        /// <returns>возвращяет NodeBuilder</returns>
        public NodeBuilder AddVariant(Variant variant)
        {
            node.Variants.Add(variant);
            return this;
        }
        /// <summary>
        /// добавляет вариант
        /// </summary>
        /// <param name="title">название</param>
        /// <param name="linkName">имя связи</param>
        /// <returns>возвращяет NodeBuilder</returns>
        public NodeBuilder AddVariant(string title, string linkName)
        {
            node.Variants.Add(new Variant() { Title = title, LinkName = linkName });
            return this;
        }
        /// <summary>
        /// устанавливает вариант
        /// </summary>
        /// <param name="variants">лист вариантов</param>
        /// <returns>возвращяет NodeBuilder</returns>
        public NodeBuilder SetVariants(List<Variant> variants)
        {
            node.Variants = variants;
            return this;
        }
        /// <summary>
        /// получение узла
        /// </summary>
        /// <returns>возврящает узел</returns>
        public Node GetNode()
        {
            return node;
        }
    }
}
