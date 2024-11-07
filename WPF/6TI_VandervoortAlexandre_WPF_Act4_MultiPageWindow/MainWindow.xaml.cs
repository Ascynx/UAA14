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
using _6TI_VandervoortAlexandre_WPF_Act4_MultiPageWindow.Vues;

namespace _6TI_VandervoortAlexandre_WPF_Act4_MultiPageWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Page1Button.Click += onPage1ButtonPress;
            Page2Button.Click += onPage2ButtonPress;
        }

        public void onPage1ButtonPress(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageOne();
        }

        public void onPage2ButtonPress(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PageTwo();
        }
    }
}
