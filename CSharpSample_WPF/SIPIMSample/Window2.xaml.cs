using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIPIMSample
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private string _contactName;

        public Window2()
        {
            InitializeComponent();
        }

        public void setContactName(string contactName)
        {
            _contactName = contactName;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            labelContactName.Content = _contactName;
        }
    }
}
