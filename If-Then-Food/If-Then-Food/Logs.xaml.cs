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

namespace If_Then_Food
{
    /// <summary>
    /// Логика взаимодействия для Logs.xaml
    /// </summary>
    public partial class Logs : Window
    {
        List<string> _logs;

        public List<string> LogsChange
        {
            get { return _logs; }
            set { _logs = value; }
        }
        bool close;

        public bool CloseWindow
        {
            get { return close; }
            set { close = value; }
        }
        public Logs()
        {
            InitializeComponent();
            close = true;
        }
        public Logs(List<string> logs)
        {
            InitializeComponent();
            _logs = logs;
            foreach (var item in _logs)
            {
                tb.Text += item + "\n";
            }
            close = true;
        }

        public void AddLog(String log)
        {
            _logs.Add(log);
            tb.Text = " ";
            foreach (var item in _logs)
            {
                tb.Text += item + "\n";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Hidden;
            e.Cancel = close;
        }

    }
}
