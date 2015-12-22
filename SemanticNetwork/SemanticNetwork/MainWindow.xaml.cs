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

namespace SemanticNetwork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EditNodeWindow editNodeWindow;
        KnowlegeBase knowlegeBase;
        KnowlegeBaseManager knowlegeBaseManager;
        InferenceEngine inferenceEngine;

        public MainWindow()
        {
            InitializeComponent();
            knowlegeBase = (LoadKnowlegeBaseFromFile());
            knowlegeBaseManager = new KnowlegeBaseManager(knowlegeBase);
            editNodeWindow = new EditNodeWindow(this, knowlegeBaseManager);
            inferenceEngine = new InferenceEngine(knowlegeBaseManager);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            FillTable();
        }

        KnowlegeBase LoadKnowlegeBaseFromFile()
        {
            return XMLDataLoader.Deserialize();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XMLDataLoader.Serialize(knowlegeBase);
        }

        private void btnShowEditWindow_Click(object sender, RoutedEventArgs e)
        {
            editNodeWindow.ShowModal();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            inferenceEngine.Search(new Sentence() { Data = tbData.Text.ToLower(), Question = tbQuestion.Text.ToLower() });
        }

        public void FillTable()
        {
            lvMain.ItemsSource = knowlegeBaseManager.GetViewModels();
        }
    }
}
