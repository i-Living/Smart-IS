using IfThenFoodProgram;
using System;
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

namespace IfThenFoodProgram
{
    /// <summary>
    /// Логика взаимодействия для EditDB.xaml
    /// </summary>
    public partial class EditDB : Window
    {
        KnowlegeBase knowlegeBase;
        public EditDB()
        {
            InitializeComponent();
            knowlegeBase = XMLDataLoader.Deserialize();
            Load_CB();
        }

        private void Load_CB()
        {
            RThen.ItemsSource = knowlegeBase.Conclusions;
            FCb.ItemsSource = knowlegeBase.Facts;
            RCb.ItemsSource = knowlegeBase.RulesViews;
            CCb.ItemsSource = knowlegeBase.Conclusions;
            RThen.Items.Refresh();
            FCb.Items.Refresh();
            RCb.Items.Refresh();
            CCb.Items.Refresh();
        }

        private void RAdd_Click(object sender, RoutedEventArgs e)
        {
            if (RIf.Text.Length > 0 && RThen.SelectedItem != null)
            {
                List<Fact> fl = new List<Fact>();
                string s = RIf.Text;
                string[] t = s.Split('&');
                foreach (string k in t)
                {
                    fl.Add(knowlegeBase.Facts.Find(x => x.Title == k));
                }
                Conclusion c = new Conclusion();
                c.Title = RThen.SelectedItem.ToString();

                ////////формирование строки
                string rule = string.Empty;
                rule += "IF (";
                foreach (var fact in fl)
                {
                    rule += fact + "&";
                }
                rule = rule.Substring(0, rule.Length - 1);
                rule += ") THEN " + c;
                ////////
                knowlegeBase.RulesViews.Add(rule);
                XMLDataLoader.Serialize(knowlegeBase);
                Load_CB();
                FQ.Clear();
            }
        }

        private void FAdd_Click(object sender, RoutedEventArgs e)
        {
            if (FTitle.Text.Length > 0 && FQ.Text.Length > 0)
            {
                Fact f = new Fact();
                f.ConditionTitle = FCTitle.Text;
                f.Title = FTitle.Text;
                f.Question = FQ.Text;
                knowlegeBase.Facts.Add(f);
                XMLDataLoader.Serialize(knowlegeBase);
                Load_CB();
                FQ.Clear();
            }
        }

        private void CAdd_Click(object sender, RoutedEventArgs e)
        {
            if (CT.Text.Length > 0)
            {
                Conclusion c = new Conclusion();
                c.Title = CT.Text;
                knowlegeBase.Conclusions.Add(c);
                XMLDataLoader.Serialize(knowlegeBase);
                Load_CB();
                CT.Clear();
            }
        }

        private void FD_Click(object sender, RoutedEventArgs e)
        {
            if (FCb.SelectedItem != null)
                for (int i = 0; i < knowlegeBase.Facts.Count; i++)
                {
                    if (knowlegeBase.Facts[i].Title == FCb.SelectedItem.ToString())
                        knowlegeBase.Facts.Remove(knowlegeBase.Facts[i]);
                }
            XMLDataLoader.Serialize(knowlegeBase);
            Load_CB();
        }

        private void RD_Click(object sender, RoutedEventArgs e)
        {
            if(RCb.SelectedItem != null)
            {
                for (int i = 0; i < knowlegeBase.RulesViews.Count; i++)
                {
                    if (knowlegeBase.RulesViews[i] == RCb.SelectedItem.ToString())
                        knowlegeBase.RulesViews.Remove(knowlegeBase.RulesViews[i]);
                }
                XMLDataLoader.Serialize(knowlegeBase);
                Load_CB();
            }
        }

        private void CD_Click(object sender, RoutedEventArgs e)
        {
            if (CCb.SelectedItem != null)
            {
                for (int i = 0; i < knowlegeBase.Conclusions.Count; i++)
                {
                    if (knowlegeBase.Conclusions[i].Title == CCb.SelectedItem.ToString())
                        knowlegeBase.Conclusions.Remove(knowlegeBase.Conclusions[i]);
                }
                XMLDataLoader.Serialize(knowlegeBase);
                Load_CB();
            }
        }

    }
}
