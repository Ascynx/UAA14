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

namespace _6TI_VA_Act4_Ex_CD_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "Interface Dynamique pour le Matching Game";
            this.Width = 400;
            this.Height = 450;
            InitializeDynamicComponents();
        }

        public void InitializeDynamicComponents()
        {
            RowDefinition[] rows = new RowDefinition[4];
            ColumnDefinition[] columns = new ColumnDefinition[4];
            TextBlock[,] blocks = new TextBlock[4,4];

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = new RowDefinition();
                columns[i] = new ColumnDefinition();

                gridMain.RowDefinitions.Add(rows[i]);
                gridMain.ColumnDefinitions.Add(columns[i]);
            }

            for (int x = 0; x < columns.Length; x++)
            {
                for (int y = 0; y < rows.Length; y++)
                {
                    TextBlock block = new()
                    {
                        Text = "?",
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        TextAlignment = TextAlignment.Center,
                        FontSize = 36,
                        Height = 50,
                        Width = 50,
                    };

                    Grid.SetColumn(block, x);
                    Grid.SetRow(block, y);

                    block.PreviewMouseDown += OnPreviewMouseDownEvent;
                    blocks[y, x] = block;
                    gridMain.Children.Add(block);
                }
            }

        }

        private void OnPreviewMouseDownEvent(object sender, MouseButtonEventArgs e)
        {
            if (sender is not TextBlock blockSender)
            {
                return;
            }

            blockSender.Text = "X";
        }
    }
}
