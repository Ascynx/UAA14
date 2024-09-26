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

namespace _6TI_VandervoortAlexandre_WPF_A3Bis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DateTime? _dateArrivee;
        private static DateTime? _dateSortie;

        public MainWindow()
        {
            InitializeComponent();
            NbrePersonnes.PreviewTextInput += new TextCompositionEventHandler(NbrePersonnePreviewTextInputListener);
            DateArrivee.SelectedDateChanged += DateArriveeSelectedDateChangedListener;
        }

        public void DateArriveeSelectedDateChangedListener(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                object item = e.AddedItems[0];

                if (item is string dateStr) {
                    if (DateTime.TryParse(dateStr, out DateTime date))
                    {
                        _dateArrivee = date;
                    }
                }
            } else
            {
                _dateArrivee = null;
            }
        }
        public void DateSortieSelectedDateChangedListener(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                object item = e.AddedItems[0];

                if (item is string dateStr)
                {
                    if (DateTime.TryParse(dateStr, out DateTime date))
                    {
                        _dateSortie = date;
                    }
                }
            }
            else
            {
                _dateSortie = null;
            }
        }

        public void NbrePersonnePreviewTextInputListener(object sender, TextCompositionEventArgs e)
        {
            if (!short.TryParse(e.Text, out short v))
            {
                e.Handled = true;
            } else if (v < 1 || v > 6)
            {
                e.Handled = true;
            } else if ((sender as TextBox).Text.Length >= 1)
            {
                //si la taille est déja 1.
                e.Handled = true;
            }
        }
    }
}
