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

namespace _6TI_VA_Act4_Ex_CD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeCodedComponents();
        }

        public void InitializeCodedComponents()
        {
            //définition des lignes
            gridMain.RowDefinitions.Add(new RowDefinition());
            gridMain.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(5, GridUnitType.Star) });
            gridMain.RowDefinitions.Add(new RowDefinition());

            //définition des colonnes
            gridMain.ColumnDefinitions.Add(new ColumnDefinition());
            gridMain.ColumnDefinitions.Add(new ColumnDefinition());
            gridMain.ColumnDefinitions.Add(new ColumnDefinition());

            //définition de la 1ère ligne
            TextBlock blockL1 = new()
            {
                Text = "TextBlock créé dynamiquement",
                Foreground = Brushes.Red,
                Background = Brushes.Yellow
            };
            Grid.SetColumnSpan(blockL1, 3);
            gridMain.Children.Add(blockL1);

            //définition de la 2nde ligne
            Button btn1 = new()
            {
                Content = "Bouton 1",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            Button btn2 = new()
            {
                Content = "Bouton 2",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            Button btn3 = new()
            {
                Content = "Bouton 3",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            Grid.SetRow(btn1, 1);
            Grid.SetRow(btn2, 1);
            Grid.SetRow(btn3, 1);

            Grid.SetColumn(btn2, 1);
            Grid.SetColumn(btn3, 2);

            gridMain.Children.Add(btn1);
            gridMain.Children.Add(btn2);
            gridMain.Children.Add(btn3);

            //définition de la 2ème ligne

            StackPanel panel = new();
            ComboBox cBox = new();

            TextBlock textBlock = new()
            {
                Text = "Infos: ",
                Foreground = Brushes.Red,
                Background = Brushes.Yellow
            };
            TextBox tb = new TextBox()
            {
                Text = "J'attends vos infos"
            };

            panel.Children.Add(textBlock);
            panel.Children.Add(tb);

            cBox.Items.Add(new ComboBoxItem() { Content = "Vineboom" });
            cBox.Items.Add(new ComboBoxItem() { Content = "Second item" });

            Grid.SetRow(panel, 2);
            Grid.SetRow(cBox, 2);

            Grid.SetColumn(cBox, 2);
            
            Grid.SetColumnSpan(panel, 2);

            gridMain.Children.Add(panel);
            gridMain.Children.Add(cBox);
        }
    }
}
