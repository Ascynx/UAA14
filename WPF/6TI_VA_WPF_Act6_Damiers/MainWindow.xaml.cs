using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static readonly Dictionary<string, BitmapImage> _bitmaps = new();

        private static readonly Dictionary<string, string> _mappings = new()
            {
                {
                    "pawn",
                    "p.png"
                },
                {
                    "rook",
                    "t.png"
                },
                {
                    "knight",
                    "kn.png"
                },
                {
                    "bishop",
                    "b.png"
                },
                {
                    "queen",
                    "q.png"
                },
                {
                    "king",
                    "k.png"
                }
            };

        private static readonly Dictionary<int, string> _pawnLocations = new()
        {
            {
                1,
                "rook"
            },
            {
                2,
                "knight"
            },
            {
                3,
                "bishop"
            },
            {
                4,
                "king"
            },
            {
                5,
                "queen"
            },
            {
                6,
                "bishop"
            },
            {
                7,
                "knight"
            },
            {
                8,
                "rook"
            },
            {
                10,
                "pawn"
            },
            {
                11,
                "pawn"
            },
            {
                12,
                "pawn"
            },
            {
                13,
                "pawn"
            },
            {
                14,
                "pawn"
            },
            {
                15,
                "pawn"
            },
            {
                16,
                "pawn"
            },
            {
                17,
                "pawn"
            },
            {
                18,
                "pawn"
            }
        };

        public MainWindow()
        {
            InitializeComponent();

            this.Title = "Damier ex3"
            this.Width = 660;
            this.Height = 660;
            InitializeBitMap();
            InitializeDynamicComponents();
        }

        public void InitializeBitMap()
        {
            

            string[] keys = _mappings.Keys.ToArray();
            string[] values = _mappings.Values.ToArray();
            for (int i = 0; i < _mappings.Count; i++)
            {
                string key = keys[i];
                string value = values[i];

                BitmapImage bitmap = new();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("Assets/Images/" + value, UriKind.Relative);

                bitmap.DecodePixelHeight = 65;
                bitmap.DecodePixelWidth = 65;

                bitmap.EndInit();

                //retire l'ancienne instance (on va le re-decoder).
                if (_bitmaps.ContainsKey(key))
                {
                    _bitmaps.Remove(key);
                }
                _bitmaps.Add(key, bitmap);
            }
        }

        public void InitializeDynamicComponents()
        {
            int xMax = 8;
            int yMax = 8;
            for (int x = 0; x < xMax; x++)
            {
                for (int y = 0; y < yMax; y++)
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

                    int num = (x * 10 + y + 1);
                    int max = ((xMax - 1) * 10 + yMax + 1);
                    if (max - num <= 18)
                    {
                        num = max - num;
                    }

                    string? imageKey;
                    if (num <= 18)
                    {
                        _pawnLocations.TryGetValue(num, out imageKey);
                    } else imageKey = null;

                    BitmapImage? bitmap;
                    if (imageKey != null)
                    {
                        _bitmaps.TryGetValue(imageKey, out bitmap);
                    } else
                    {
                        bitmap = null;
                    }

                    Button button = new()
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        Background = (y % 2 == 0) == (x % 2 == 0) ? Brushes.White : Brushes.Black,
                    };

                    Image image = new()
                    {
                        Source = bitmap,
                    };

                    Grid.SetRow(button, x);
                    Grid.SetColumn(button, y);

                    button.Content = image;
                    damier.Children.Add(button);
                }
            }
        }
    }
}
