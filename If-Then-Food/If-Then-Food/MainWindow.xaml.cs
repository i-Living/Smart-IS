using PRES_console;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Timers;

namespace If_Then_Food
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KnowlegeBase knowlegeBase;
        WorkMemory workMemory;
        List<Fact> confirmedFacts;
        List<string> logs;
        Logs L;
        EditDB E;
        string title;
        public MainWindow()
        {
            InitializeComponent();
            knowlegeBase = XMLDataLoader.Deserialize();
            knowlegeBase.LoadRules();
            workMemory = new WorkMemory(knowlegeBase.Facts);
            confirmedFacts = new List<Fact>();
            logs = new List<string>();
            L = new Logs(logs);
            title = string.Empty;
            Run();
        }
        public void Run()
        {
            if (workMemory.Count == 0)
            {
                tb.Text = "Nothing to analize";
                ybtn.IsEnabled = false;
                nbtn.IsEnabled = false;
            }
            else
                tb.Text = workMemory[0].Question;          
        }

        public void Again()
        {
            knowlegeBase = XMLDataLoader.Deserialize();
            knowlegeBase.LoadRules();
            workMemory = new WorkMemory(knowlegeBase.Facts);
            confirmedFacts = new List<Fact>();
            title = string.Empty;
            ybtn.IsEnabled = true;
            nbtn.IsEnabled = true;
            L.LogsChange.Clear();
            Run();
        }

        private void ybtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                confirmedFacts.Add(workMemory[0]);
                L.AddLog(Convert.ToString(workMemory[0]) + " - yes");
                title = workMemory[0].Title;
                workMemory.RemoveAll(x => x.ConditionTitle != title);

                foreach (var rule in knowlegeBase.Rules)
                {
                    if (rule.If.Except(confirmedFacts).ToList().Count == 0)
                    {
                        tb.Text = Convert.ToString(rule.Then);
                        L.AddLog(Convert.ToString(rule.Then) + " - conclusion");
                        break;
                    }
                    else
                        Run();
                }
            }
            catch
            {
            }
        }

        private void nbtn_Click(object sender, RoutedEventArgs e)
        {
            title = workMemory[0].Title;
            L.AddLog(Convert.ToString(workMemory[0]) + " - no");
            workMemory.RemoveAll(x => x.ConditionTitle == title);
            workMemory.RemoveAt(0);
            foreach (var rule in knowlegeBase.Rules)
            {
                if (rule.If.Except(confirmedFacts).ToList().Count == 0)
                {
                    tb.Text = Convert.ToString(rule.Then);
                    L.AddLog(Convert.ToString(rule.Then) + " - conclusion");
                    break;
                }
                else
                    Run();
            }
            Run();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Again();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            L.Show();
        }

        private void editbtn_Click(object sender, RoutedEventArgs e)
        {
            E = new EditDB();
            E.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            L.CloseWindow = false;
            L.Close();
        }
    }
}
