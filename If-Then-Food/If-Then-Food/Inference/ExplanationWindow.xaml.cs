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
        /// <summary>
        /// конструктор окна
        /// </summary>
        public ExplanationWindow()
        {
            InitializeComponent();
            close = false;
        }
        /// <summary>
        /// конструктор окна с фактами
        /// </summary>
        public ExplanationWindow(List<string> facts)
        {
            InitializeComponent();
            close = false;
            foreach (var item in facts)
            {
                tb.Text += item + "\n";
            }
        }
        /// <summary>
        /// медод для обновления ответов
        /// </summary>
        public void Update(List<string> facts)
        {
            tb.Text = string.Empty;
            foreach (var item in facts)
            {
                tb.Text += item + "\n";
            }
        }
        /// <summary>
        /// очистка окна ответов
        /// </summary>
        public void Clear()
        {
            tb.Text = string.Empty;
        }
        /// <summary>
        /// выполняется при закрытии окна программы
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
            e.Cancel = !close;
        }
    }
}
