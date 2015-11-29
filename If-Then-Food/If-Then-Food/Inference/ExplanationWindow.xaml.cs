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
    /// Логика взаимодействия для ExplanationWindow.xaml
    /// </summary>
    public partial class ExplanationWindow : Window
    {
        private bool close;
        public bool CloseWindow
        {
            get { return close; }
            set { close = value; }
        }
        public ExplanationWindow()
        {
            InitializeComponent();
            close = false;
        }
        public ExplanationWindow(List<string> facts)
        {
            InitializeComponent();
            close = false;
            foreach (var item in facts)
            {
                tb.Text += item + "\n";
            }
        }
        public void Update(List<string> facts)
        {
            tb.Text = string.Empty;
            foreach (var item in facts)
            {
                tb.Text += item + "\n";
            }
        }
        public void Clear()
        {
            tb.Text = string.Empty;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
            e.Cancel = !close;
        }
    }
}
