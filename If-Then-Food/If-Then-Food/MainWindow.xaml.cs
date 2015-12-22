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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Timers;

namespace IfThenFoodProgram
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KnowlegeBase knowlegeBase;
        WorkMemory workMemory;
        List<Fact> confirmedFacts;
        List<string> facts;
        ExplanationWindow ExplW;
        EditDB E;
        string title;
        /// <summary>
        /// конструктор окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            knowlegeBase = XMLDataLoader.Deserialize();
            knowlegeBase.LoadRules();
            workMemory = new WorkMemory(knowlegeBase.Facts);
            confirmedFacts = new List<Fact>();
            facts = new List<string>();
            ExplW = new ExplanationWindow();
            title = string.Empty;
            Run();
        }
        /// <summary>
        /// показ вопроса
        /// </summary>
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
        /// <summary>
        /// запуск программы заного
        /// </summary>
        public void Again()
        {
            knowlegeBase = XMLDataLoader.Deserialize();
            knowlegeBase.LoadRules();
            workMemory = new WorkMemory(knowlegeBase.Facts);
            confirmedFacts = new List<Fact>();
            title = string.Empty;
            ybtn.IsEnabled = true;
            nbtn.IsEnabled = true;
            ExplW.Clear();
            Run();
        }
        /// <summary>
        /// нажатие на кнопку Yes"
        /// </summary>
        private void ybtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                confirmedFacts.Add(workMemory[0]);
                facts.Add(Convert.ToString(workMemory[0]) + " - yes");
                ExplW.Update(facts);
                title = workMemory[0].Title;
                workMemory.RemoveAll(x => x.ConditionTitle != title);

                foreach (var rule in knowlegeBase.Rules)
                {
                    if (rule.If.Except(confirmedFacts).ToList().Count == 0)
                    {
                        tb.Text = Convert.ToString(rule.Then);
                        facts.Add(Convert.ToString(rule.Then) + " - conclusion");
                        ExplW.Update(facts);
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
        /// <summary>
        /// нажатие на кнопку "No"
        /// </summary>
        private void nbtn_Click(object sender, RoutedEventArgs e)
        {
            title = workMemory[0].Title;
            facts.Add(Convert.ToString(workMemory[0]) + " - no");
            ExplW.Update(facts);
            workMemory.RemoveAll(x => x.ConditionTitle == title);
            workMemory.RemoveAt(0);
            foreach (var rule in knowlegeBase.Rules)
            {
                if (rule.If.Except(confirmedFacts).ToList().Count == 0)
                {
                    tb.Text = Convert.ToString(rule.Then);
                    facts.Add(Convert.ToString(rule.Then) + " - conclusion");
                    ExplW.Update(facts);                  
                    break;
                }
                else
                    Run();
            }
            Run();
        }
        /// <summary>
        /// нажатие на кнопку Again
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Again();
        }
        /// <summary>
        /// вызов окна объяснения
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ExplW.Show();
        }
        /// <summary>
        /// вызов окна редактирования
        /// </summary>
        private void editbtn_Click(object sender, RoutedEventArgs e)
        {
            E = new EditDB();
            E.Show();
        }
        /// <summary>
        /// выполняется при закрытии окна
        /// </summary>
        private void Window_Closed(object sender, EventArgs e)
        {
            E.Close();
            ExplW.CloseWindow = true;
            ExplW.Close();
        }
    }
}
