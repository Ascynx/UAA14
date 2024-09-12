﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
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
using System.Threading;
using System.Diagnostics;

namespace MatchingGame_Vandervoort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly DispatcherTimer _timer = new DispatcherTimer();
        private int _tempsEcoule = 0;
        private int _nbPairesTrouvees = 0;


        public MainWindow()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += new EventHandler(onTimerTick);
            InitGame();
        }

        private void ResetGame()
        {
            foreach(TextBlock block in gridMain.Children.OfType<TextBlock>())
            {
                if (block.Name == "tempsEcoule")
                {
                    block.Text = "Temps écoulé";
                    continue;
                }

                if (block.Visibility == Visibility.Hidden)
                {
                    block.Visibility = Visibility.Visible;
                }
                block.Text = "?";
            }
        }

        private void InitGame()
        {
            _tempsEcoule = 0;
            _nbPairesTrouvees = 0;

            Random sharedRand = Random.Shared;
            List<string> emojis = new()
            {
                "🐈","🐈",
                "🐷","🐷",
                "🐐","🐐",
                "🦊","🦊",
                "🐴","🐴",
                "🦨","🦨",
                "🦉","🦉",
                "🐀","🐀",
            };
            Debug.WriteLine(emojis);


            //vient de l'attribut x:Name
            foreach (TextBlock block in gridMain.Children.OfType<TextBlock>())
            {
                if (block.Name == "tempsEcoule")
                {
                    continue;
                }

                int tailleEmojis = emojis.Count;
                int index = sharedRand.Next(tailleEmojis);
                block.Text = emojis[index];
                emojis.RemoveAt(index);
            }

            _timer.Start();
        }

        private void onTimerTick(object sender, EventArgs e)
        {
            _tempsEcoule++;
            tempsEcoule.Text = Math.Round(_tempsEcoule / 60F) + "m " + _tempsEcoule  + "s";
            if (_nbPairesTrouvees == 8)
            {
                _timer.Stop();
                tempsEcoule.Text = tempsEcoule.Text + " - Rejouer ?";
            }
        }

        TextBlock _lastClicked;
        bool _trouveLien = false;
        private void onMouseDownAnimalListener(object sender, MouseButtonEventArgs e)
        {
            if (sender is not TextBlock blockSender)
            {
                //l'élément n'est pas un text block.
                return;
            }

            if (!_trouveLien)
            {
                blockSender.Visibility = Visibility.Hidden;
                _lastClicked = blockSender;
                _trouveLien = true;
            }
            else if (_lastClicked.Text == blockSender.Text)
            {
                _nbPairesTrouvees++;
                blockSender.Visibility = Visibility.Hidden;
                _trouveLien = false;
            }
            else
            {
                _lastClicked.Visibility = Visibility.Visible;
                _trouveLien = false;
            }
        }

        private void onMouseDownReplayListener(object sender, MouseButtonEventArgs e)
        {
            if  (_nbPairesTrouvees == 8)
            {
                ResetGame();
                InitGame();
            }
        }
    }
}
