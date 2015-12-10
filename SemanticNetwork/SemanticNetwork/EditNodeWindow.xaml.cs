using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SemanticNetwork
{
    /// <summary>
    /// Interaction logic for EditNodeWindow.xaml
    /// </summary>
    public partial class EditNodeWindow : Window
    {
        KnowlegeBaseManager knowlegeBaseManager;
        MainWindow parent;

        public List<ContentControl> AllItems { get; set; }
    
        public IEnumerable<int> AllItemsId
        {
            get
            {
                return from item in AllItems select (int)item.Tag;
            }
        }

        public List<Link> ChildLinks { get; set; }

        /*public List<ContentControl> ChildItems
        { 
            get
            {
                return (from link in ChildLinks select new ContentControl() { Tag = link }).ToList();
            }
        }*/

        public List<Link> SelectedChildLinks { get; set; }

        public List<Variant> Variants { get; set; }


        public int CurrentNodeId
        {
            get
            {
                return cbNode.SelectedIndex != 0 ? (int)(cbNode.SelectedItem as ContentControl).Tag : -1;
            }
        }

        public EditNodeWindow(MainWindow parent, KnowlegeBaseManager knowlegeBaseManager)
        {
            InitializeComponent();
            this.knowlegeBaseManager = knowlegeBaseManager;
            this.parent = parent;

            ChildLinks = new List<Link>();
            SelectedChildLinks = new List<Link>();
            AllItems = new List<ContentControl>();
            Variants = new List<Variant>();
        }

        Link ItemToLink(ContentControl contentControl)
        {
            return (Link)contentControl.Tag;
        }

        ContentControl ItemToLink(Link link)
        {
            return new ContentControl() { Content = link.Id.ToString(), Tag = link };
        }

        List<ContentControl> GetChildItems(List<Link> childs, int nodeId)
        {
            return (from itemId 
                    in AllItemsId
                    where 
                        !(from link in childs select link.Id).Contains(itemId) &&
                        itemId != nodeId
                    select new ContentControl() { Content = itemId, Tag = itemId }).ToList();
        }

        List<ContentControl> GetChildItems()
        {
            return (from itemId
                    in AllItemsId
                    select new ContentControl() { Content = itemId, Tag = itemId }).ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();

            List<LinkType> linkTypes = Enum.GetValues(typeof(LinkType)).Cast<LinkType>().ToList();
            IEnumerable<ContentControl> linkTypeControls = (from linkType in linkTypes select new ContentControl() { Content = linkType.ToString(), Tag = linkType });
            cbChildLink.ItemsSource = linkTypeControls;
            cbChildLink.SelectedIndex = 0;
        }

        void Load()
        {
            cbNode.Items.Clear();
            AllItems.Clear();
            
            lvChilds.ItemsSource = SelectedChildLinks;
            lvVariants.ItemsSource = Variants;

            cbNode.Items.Add("Add new...");
            foreach (var node in knowlegeBaseManager.Base.Nodes)
                AllItems.Add(new ContentControl() { Content = node.Id.ToString(), Tag = node.Id});
            foreach (var node in knowlegeBaseManager.Base.Nodes)
                cbNode.Items.Add(new ContentControl() { Content = node.Id.ToString(), Tag = node.Id });
            cbNode.SelectedIndex = 0;
            tbVariantTitle.Clear();
            tbVariantlinkname.Clear();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Visibility = Visibility.Hidden;
            e.Cancel = true;
            parent.FillTable();
        }

        public void LoadNode(Node node)
        {
            
        }

        private void cbNode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbNode.SelectedIndex == 0)
            {
                btnSave.Content = "Add";
                tbId.IsEnabled = true;
                SelectedChildLinks.Clear();
                lvParents.ItemsSource = new List<Link>();
                lvChilds.ItemsSource = new List<Link>();
                Variants = new List<Variant>();
                lvVariants.ItemsSource = Variants;
                tbId.Text = (knowlegeBaseManager.MaxNodeId + 1).ToString();
                cbChilds.ItemsSource = GetChildItems();
            }
            else if (cbNode.SelectedIndex > 0)
            {
                btnSave.Content = "Save";
                tbId.IsEnabled = false;
                Node node = knowlegeBaseManager.Base.Nodes.Find(x => x.Id == (int)(cbNode.SelectedItem as ContentControl).Tag);
                tbId.Text = node.Id.ToString();
                tbId.IsEnabled = false;
                
                SelectedChildLinks.Clear();
                SelectedChildLinks = new List<Link>(node.Childs);
                Variants = new List<Variant>(node.Variants);
                lvChilds.ItemsSource = SelectedChildLinks;
                lvVariants.ItemsSource = Variants;
                cbChilds.ItemsSource = GetChildItems(SelectedChildLinks, node.Id);
                lvParents.ItemsSource = knowlegeBaseManager.GetParentLinks(node.Id);
            }
            cbChilds.Items.Refresh();
            cbChilds.SelectedIndex = -1;
        }

        private void btnAddChild_Click(object sender, RoutedEventArgs e)
        {
            if (cbChilds.SelectedIndex != -1)
            {
                int id = (int)(cbChilds.SelectedItem as ContentControl).Tag;
                SelectedChildLinks.Add(new Link() { Id = id, LinkType = (LinkType)(cbChildLink.SelectedItem as ContentControl).Tag });
                lvChilds.Items.Refresh();
                ChildLinks.RemoveAll(x => x.Id == id);
                cbChilds.ItemsSource = GetChildItems(SelectedChildLinks, CurrentNodeId);
                cbChilds.Items.Refresh();
                tbVariantlinkname.Clear();
                tbVariantTitle.Clear();
            }
        }

        private void btnRemoveChild_Click(object sender, RoutedEventArgs e)
        {
            if (lvChilds.SelectedIndex != -1)
            {
                int id = (lvChilds.SelectedItem as Link).Id;
                SelectedChildLinks.RemoveAll(x => x.Id == id);
                lvChilds.Items.Refresh();
                cbChilds.ItemsSource = GetChildItems(SelectedChildLinks, CurrentNodeId);
                cbChilds.Items.Refresh();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cbNode.SelectedIndex == 0)
            {
                knowlegeBaseManager.AddNode(new NodeBuilder().
                    SetId(Convert.ToInt32(tbId.Text)).
                    SetChilds(SelectedChildLinks).
                    SetVariants(Variants).
                    GetNode());
            }
            else
            {
                int id = (int)(cbNode.SelectedItem as ContentControl).Tag;
                knowlegeBaseManager.SetNodeChilds(id, SelectedChildLinks);
                knowlegeBaseManager.SetNodeVariants(id, Variants);
            }
            Load();
            //Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            parent.FillTable();
        }

        public void ShowModal()
        {
            Load();
            ShowDialog();
        }

        private void btnAddVariant_Click(object sender, RoutedEventArgs e)
        {
            Variants.Add(new Variant() { Title = tbVariantTitle.Text, LinkName = tbVariantlinkname.Text });
            lvVariants.ItemsSource = Variants;
            tbVariantTitle.Clear();
            tbVariantlinkname.Clear();
            lvVariants.Items.Refresh();
        }

        private void btnRemoveVariant_Click(object sender, RoutedEventArgs e)
        {
            Variants.Remove(lvVariants.SelectedItem as Variant);
            lvVariants.ItemsSource = Variants;
            tbVariantTitle.Clear();
            tbVariantlinkname.Clear();
            lvVariants.Items.Refresh();
        }
    }
}
