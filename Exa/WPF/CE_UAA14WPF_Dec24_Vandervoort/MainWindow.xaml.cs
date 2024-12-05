using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace CE_UAA14WPF_Dec24_Vandervoort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, string> _mappings = new()
        {
            {
                "golfball",
                "golfball60.png"
            },
            {
                "cercle",
                "petitCercleRouge.png"
            }
        };
        private readonly Dictionary<string, BitmapImage> _bitmaps = new();

        public MainWindow()
        {
            InitializeComponent();
            InitializeBitmaps();
            InitializeDynamicComponents();
        }

        public void InitializeBitmaps()
        {
            string[] keys = _mappings.Keys.ToArray();
            string[] paths = _mappings.Values.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                string key = keys[i];
                string path = paths[i];

                BitmapImage bitmap = new();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("Assets/" + path, UriKind.Relative);

                bitmap.EndInit();

                if (_bitmaps.ContainsKey(key))
                {
                    //retire l'ancienne
                    _bitmaps.Remove(key);
                }
                _bitmaps.Add(key, bitmap);
            }
        }

        private string? _defaultErrorBlockString = null;
        private void InitializeDynamicComponents()
        {
            if (_defaultErrorBlockString == null)
            {
                //on l'encode ici, pour éviter de devoir le changer si il y a quoi que ce soit comme changement à faire de l'autre côté
                _defaultErrorBlockString = ErrorBlock.Text;
            }
            ColSizeInputs.Visibility = Visibility.Hidden;

            //mise en place des évenements
            RowInput.PreviewTextInput += InputValidationEvent;
            ColInput.PreviewTextInput += InputValidationEvent;
            BoutonValider.PreviewMouseDown += ValidationSelection;
            BoutonReset.PreviewMouseDown += BoutonResetPressed;

            BandeLateraleRadio.Checked += AfficheColSizeInputs;
            MarelleRadio.Checked += AfficheColSizeInputs;
            SolitaireRadio.Checked += AfficheColSizeInputs;
        }

        private void AfficheColSizeInputs(object sender, RoutedEventArgs e)
        {
            //Si ce n'est pas le bouton pour la bande latérale, cache la box sinon montre là.
            if (sender == BandeLateraleRadio)
            {
                ColSizeInputs.Visibility = Visibility.Visible;
            } else
            {
                ColSizeInputs.Visibility = Visibility.Hidden;
            }
        }

        private Button[,] _buttonMatrix;
        private void ResetBoard()
        {
            //reset de la matrice et du block dynamique
            Dynamic.Children.Clear();
            Dynamic.RowDefinitions.Clear();
            Dynamic.ColumnDefinitions.Clear();
            _buttonMatrix = new Button[0,0];

            //remise en place du texte d'erreur de base.
            ErrorBlock.Text = _defaultErrorBlockString;
        }

        private void InitializeSolitaireBoard()
        {
            ResetBoard();
            int factor = 9; //le facteur utilisé dans la matrice, décide aussi la taille des boutons 

            _buttonMatrix = new Button[factor, factor];
            double dyHeight = this.Height / 10 * 8;
            double dyWidth = this.Width / 3 * 2;

            for (int i = 0; i < factor; i++)
            {
                Dynamic.ColumnDefinitions.Add(new ColumnDefinition());
                Dynamic.RowDefinitions.Add(new RowDefinition());
                for (int j = 0; j < factor; j++)
                {
                    //cross shape
                    if (((i >= 3 && i <= 5) && (j <= 3 || j >= 5)) || ((j >= 3 && j <= 5)))
                    {
                        Image image = new()
                        {
                            Source = _bitmaps.GetValueOrDefault("cercle")
                            
                        };
                        Button button = new() //la taille est définie par la taille de la matrice.
                        {
                            Content = image,
                            Height = dyHeight / factor,
                            Width = dyWidth / factor,
                            Background = Brushes.Khaki
                        };

                        button.PreviewMouseDown += GameButtonPress;

                        _buttonMatrix[i, j] = button;
                        Grid.SetColumn(button, i);
                        Grid.SetRow(button, j);
                        Dynamic.Children.Add(button);
                    }
                }
            }
        }

        private void InitializeMarelleBoard()
        {
            ResetBoard();
            int factor = 7; //le facteur utilisé dans la matrice, décide aussi la taille des boutons 

            _buttonMatrix = new Button[factor, factor];
            double dyHeight = this.Height / 10 * 8;
            double dyWidth = this.Width / 3 * 2;

            for (int i = 0; i < factor; i++)
            {
                Dynamic.ColumnDefinitions.Add(new ColumnDefinition());
                Dynamic.RowDefinitions.Add(new RowDefinition());
                for (int j = 0; j < factor; j++)
                {
                    //retire le millieu ET (soit diagonale g->d, soit ligne verticale, soit ligne horizontale, soit diagonale d->g)
                    if (!(i == 3 && j == 3) && (i == j || factor / 2 == i || factor / 2 == j || factor - i == j+1))
                    {
                        Image image = new()
                        {
                            Source = _bitmaps.GetValueOrDefault("cercle")

                        };
                        Button button = new() //la taille est définie par la taille de la matrice.
                        {
                            Content = image,
                            Height = dyHeight / factor,
                            Width = dyWidth / factor,
                            Background = Brushes.Khaki
                        };

                        button.PreviewMouseDown += GameButtonPress;

                        _buttonMatrix[i, j] = button;
                        Grid.SetColumn(button, i);
                        Grid.SetRow(button, j);
                        Dynamic.Children.Add(button);
                    }
                }
            }
        }

        private void InitializeBandeLateraleBoard(int colSize, int rowSize)
        {
            ResetBoard();
            _buttonMatrix = new Button[colSize, rowSize];

            double dyHeight = this.Height / 10 * 8;
            double dyWidth = this.Width / 3 * 2;

            for (int i = 0; i < colSize; i++)
            {
                Dynamic.ColumnDefinitions.Add(new ColumnDefinition());
                Dynamic.RowDefinitions.Add(new RowDefinition());
                for (int j = 0; j < rowSize; j++)
                {
                    //Le tour
                    if (i == 0 || j == 0 || (i == colSize - 1) || (j == rowSize - 1))
                    {
                        Button button = new()
                        {
                            Content = "X",
                            Height = dyHeight / rowSize,
                            Width = dyWidth / colSize,
                            
                            Foreground = Brushes.Red,
                            Background = Brushes.Khaki,

                            FontSize = 22,
                            FontWeight = FontWeights.Bold,

                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                        };

                        button.PreviewMouseDown += XGameInverseCouleurs; ;

                        _buttonMatrix[i, j] = button;
                        Grid.SetColumn(button, i);
                        Grid.SetRow(button, j);
                        Dynamic.Children.Add(button);
                    }
                }
            }
        }

        private void XGameInverseCouleurs(object sender, MouseButtonEventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            //inversion background foreground
            (button.Background, button.Foreground) = (button.Foreground, button.Background);
        }

        private void GameButtonPress(object sender, MouseButtonEventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }
            Image image = new() { Source = _bitmaps.GetValueOrDefault("golfball") };
            button.Content = image;
        }

        private void ValidationSelection(object sender, MouseButtonEventArgs e)
        {
            if (SolitaireRadio.IsChecked.HasValue && SolitaireRadio.IsChecked.Value)
            {
                InitializeSolitaireBoard();
            } else if (MarelleRadio.IsChecked.HasValue && MarelleRadio.IsChecked.Value)
            {
                InitializeMarelleBoard();
            } else if (BandeLateraleRadio.IsChecked.HasValue && BandeLateraleRadio.IsChecked.Value)
            {
                //validation des entrées
                bool error = false;
                if (RowInput.Text.Length == 0 || ColInput.Text.Length == 0)
                {
                    //pas d'entrée, ne peut pas parser de chiffres depuis rien.
                    error = true;
                }

                //validation que les inputs soit des integer (donc 0-9)
                bool parsedRow = Int32.TryParse(RowInput.Text, out int rowSize);
                bool parsedCol = Int32.TryParse(ColInput.Text, out int colSize);
                if (!parsedRow || !parsedCol || (rowSize < 2 || rowSize > 12) || (colSize < 2 || colSize > 12))
                {
                    //non parsé ou entre 1 et 12
                    error = true;
                }

                //la matrice ne PEUT PAS être inférieure à 2x2 ou supérieure à 12x12 (donc avoir une entrée "1" dans l'un ou l'autre est incorrect.)
                if (error)
                {
                    ErrorBlock.Text = "Veuillez encoder des dimensions valides comprises entre 2 et 12.";
                    return;
                }

                InitializeBandeLateraleBoard(colSize, rowSize);
            }


        }


        private void BoutonResetPressed(object sender, MouseButtonEventArgs e)
        {
            //l'utilisateur peut reset manuellement, Attention doit ré-appuyer sur valider pour créer une nouvelle matrice.
            ResetBoard();
        }

        private void InputValidationEvent(object sender, TextCompositionEventArgs e)
        {
            if (sender is not TextBox)
            {
                return;
            }
            if (!Int32.TryParse(e.Text, out int _))
            {
                //n'est pas integer.
                e.Handled = true;
            }
        }
    }
}
