using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticNetwork
{
    /// <summary>
    /// Управление данными из KnowlegeBase
    /// </summary>
    public class KnowlegeBaseManager
    {
        public KnowlegeBase Base { get; set; }
        /// <summary>
        /// Конструктор для KnowlegeBaseManager
        /// </summary>
        /// <param name="kb">Входные данные KnowlegeBase</param>
        public KnowlegeBaseManager(KnowlegeBase kb)
        {
            Base = kb;
        }
        /// <summary>
        /// Добавление новой ветви
        /// </summary>
        /// <param name="node"> Добавляемая ветвь</param>
        public void AddNode(Node node)
        {
            if (Base.Nodes.Find(x => x.Id == node.Id) != null)
                throw new Exception("Multiple id entry");
            Base.Nodes.Add(node);
        }
        /// <summary>
        /// Удаление ветви по ID
        /// </summary>
        /// <param name="id">ID ветви</param>
        public void RemoveNode(int id)
        {
            Base.Nodes.RemoveAll(x => x.Id == id);
        }
        /// <summary>
        /// Выбор элементов для ветви
        /// </summary>
        /// <param name="id">ID ветви</param>
        /// <param name="childs">Элементы для связи</param>
        public void SetNodeChilds(int id, IEnumerable<Link> childs)
        {
            Base.Nodes.Find(x => x.Id == id).Childs = childs.ToList();
        }
        /// <summary>
        /// Выбор вариатнов для ветви
        /// </summary>
        /// <param name="id">ID ветви</param>
        /// <param name="variants">Варианты связей</param>
        public void SetNodeVariants(int id, IEnumerable<Variant> variants)
        {
            Base.Nodes.Find(x => x.Id == id).Variants = variants.ToList();
        }
        /// <summary>
        /// Выбор наибольшей ветви по ID
        /// </summary>
        public int MaxNodeId
        {
            get
            {
                return Base.Nodes.Count > 0 ? (from node in Base.Nodes select node.Id).Max() : 0;
            }
        }
        /// <summary>
        /// Получение ветви по ID
        /// </summary>
        /// <param name="id">ID ветви</param>
        /// <returns>Возвращает ветвь по ID</returns>
        public Node GetById(int id)
        {
            return Base.Nodes.Find(x => x.Id == id);
        }
        /// <summary>
        /// Реализация IEnumerable для Childs
        /// </summary>
        /// <param name="id">Child ID</param>
        /// <returns>Возвращает Child</returns>
        public IEnumerable<Node> GetChilds(int id)
        {
            return from link in GetById(id).Childs select GetById(link.Id);
        }
        /// <summary>
        /// Реализация IEnumerable для Parent
        /// </summary>
        /// <param name="id">Parent ID</param>
        /// <returns>Возвращает Parent Link</returns>
        public IEnumerable<Node> GetParents(int id)
        {
            return from link in GetParentLinks(id) select GetById(link.Id);
        }
        /// <summary>
        /// Релизация IEnumerable для ParentLinks
        /// </summary>
        /// <param name="id">Parent ID</param>
        /// <returns>Возвращает новый Child Link</returns>
        public IEnumerable<Link> GetParentLinks(int id)
        {
            List<Link> result = new List<Link>();
            foreach (var node in Base.Nodes)
                foreach (var link in node.Childs)
                    if (link.Id == id)
                        yield return new Link() { Id = node.Id, LinkType = link.LinkType };
        }
        /// <summary>
        /// Релизация IEnumerable для ViewModels
        /// </summary>
        /// <returns>Возвращает новый NodeViewModel</returns>
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
