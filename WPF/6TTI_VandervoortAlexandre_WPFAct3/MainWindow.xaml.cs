using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace _6TTI_VandervoortAlexandre_WPFAct3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _aBoxDouble;
        private double _bBoxDouble;
        private double _cBoxDouble;

        private string _resultat;

        public MainWindow()
        {
            InitializeComponent();
            ABox.PreviewTextInput += ABox_PreviewTextInput;
            BBox.PreviewTextInput += BBox_PreviewTextInput;
            CBox.PreviewTextInput += CBox_PreviewTextInput;

            CalculBouton.MouseMove += CalculBouton_MouseMove;
            CalculBouton.Click += CalculBouton_Click;
        }

        private void CalculBouton_Click(object sender, RoutedEventArgs e)
        {
            ResoudTrinome(_aBoxDouble, _bBoxDouble, _cBoxDouble, out _resultat);
            new ResultWindow(_resultat).Show();
        }

        private void CBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Control control = (sender as Control);
            if (double.TryParse(e.Text, out double texDouble))
            {
                _cBoxDouble = texDouble;
                control.BorderBrush = Brushes.LightGray;
            }
            else
            {
                control.BorderBrush = Brushes.DarkRed;
            }
        }

        private void BBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Control control = (sender as Control);
            if (double.TryParse(e.Text, out double texDouble))
            {
                _bBoxDouble = texDouble;
                control.BorderBrush = Brushes.LightGray;
            }
            else
            {
                control.BorderBrush = Brushes.DarkRed;
            }
        }

        private void ABox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Control control = (sender as Control);
            if (double.TryParse(e.Text, out double texDouble))
            {
                _aBoxDouble = texDouble;
                control.BorderBrush = Brushes.LightGray;
            }
            else
            {
                control.BorderBrush = Brushes.DarkRed;
            }
        }

        private void CalculBouton_MouseMove(object sender, MouseEventArgs e)
        {
            VBouton.Visibility = Visibility.Visible;
            VBouton.Background = Brushes.Red;
        }

        static void ResoudTrinome(double a, double b, double c, out string message)
        {
            double delta = Math.Pow(b, 2) - 4 * a * c;
            if (delta < 0)
            {
                message = "Il n'y a pas de solution réelle";

            }
            else if (delta == 0)
            {
                double x1 = -b / (2 * a);
                message = "Il y a une solution " + x1;
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                message = "Il y a deux solutions " + x1 + " et " + x2;
            }
        }
    }
}
