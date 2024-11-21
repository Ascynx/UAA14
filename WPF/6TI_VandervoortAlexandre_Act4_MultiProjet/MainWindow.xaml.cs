using _6TI_VandervoortAlexandre_Act4_MultiProjet.Vues;
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

namespace _6TI_VandervoortAlexandre_Act4_MultiProjet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new PageAccueil();

            Accueil.PreviewMouseDown += Accueil_PreviewMouseDown;
            Nav1.PreviewMouseDown += Nav1_PreviewMouseDown;
            Nav2.PreviewMouseDown += Nav2_PreviewMouseDown;
            Nav3.PreviewMouseDown += Nav3_PreviewMouseDown;
        }

        private void Accueil_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new PageAccueil();
        }

        private void Nav3_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new ChaletPage();
        }

        private void Nav2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new TrinomePage();
        }

        private void Nav1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Content = new MatchingPage();
        }
    }
}
