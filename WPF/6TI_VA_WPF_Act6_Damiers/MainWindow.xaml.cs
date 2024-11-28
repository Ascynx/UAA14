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

namespace _6TI_VA_WPF_Act6_Damiers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Width = 660;
            this.Height = 660;
            InitializeDynamicComponents();
        }
        
        public void InitializeDynamicComponents()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    RowDefinition row = new RowDefinition()
                    {
                        Height = new GridLength(65),
                    };
                    ColumnDefinition column = new ColumnDefinition()
                    {
                        Width = new GridLength(65)
                    };

                    damier.ColumnDefinitions.Add(column);
                    damier.RowDefinitions.Add(row);

                    string num = "" + (x * 10 + y + 1);

                    TextBlock block = new TextBlock()
                    {
                        Text = num,
                        FontSize = 36,
                        Foreground = Brushes.Red,
                        Background = (y % 2 == 0) == (x % 2 == 0) ? Brushes.White : Brushes.Black,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        TextAlignment = TextAlignment.Center,
                    };
                    block.PreviewMouseDown += OnPreviewMouseDown;

                    Grid.SetRow(block, x);
                    Grid.SetColumn(block, y);

                    damier.Children.Add(block);
                }
            }
        }

        private void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock block)
            {
                //on retire le texte.
                block.Text = "";
            }
        }
    }
}
