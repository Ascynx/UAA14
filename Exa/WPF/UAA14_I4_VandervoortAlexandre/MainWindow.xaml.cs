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
using UAA14_I4_VandervoortAlexandre.Classes;

namespace UAA14_I4_VandervoortAlexandre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MethodesDuProjet methodes = new();

        public MainWindow()
        {
            InitializeComponent();

            txtNombre1.PreviewTextInput += TxtNombresVerificationEntree;
            txtNombre2.PreviewTextInput += TxtNombresVerificationEntree;

            btnCalculer.PreviewMouseDown += BtnCalculerAppui;
            btnReset.PreviewMouseDown += BtnResetAppui;
        }

        private void TxtNombresVerificationEntree(object sender, TextCompositionEventArgs e)
        {
            char[] inputs = e.Text.ToCharArray();
            for (int i = 0; i < inputs.Length; i++)
            {
                char input = inputs[i];
                double numericCharValue = char.GetNumericValue(input);
                if (numericCharValue != 0 && numericCharValue != 1)
                {
                    e.Handled = true;
                }
            }
        }

        private void BtnResetAppui(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void BtnCalculerAppui(object sender, RoutedEventArgs e)
        {
            if (txtNombre1.Text.Length > 7 || txtNombre2.Text.Length > 7)
            {
                MessageBox.Show("Le nombre maximum de caractères est de 7.");
                return;
            }

            Calcul();
        }

        private void Calcul()
        {
            ushort[] tbN1 = methodes.RemplirTableau(txtNombre1.Text);
            ushort[] tbN2 = methodes.RemplirTableau(txtNombre2.Text);

            ushort[] tRes = new ushort[8];
            bool ok = false;
            if (optAddition.IsChecked.HasValue && optAddition.IsChecked.Value)
            {
                methodes.Additionne(tbN1, tbN2, out tRes, out ok);
            } else if (optSoustraction.IsChecked.HasValue && optSoustraction.IsChecked.Value)
            {
                methodes.Soustrait(tbN1, tbN2, out tRes);
                ok = true;
            }

            string resultatStr;
            if (!ok)
            {
                resultatStr = "Pas réussi à éffectuer l'opération";
            } else
            {
                resultatStr = methodes.Concatene(tRes);
            }
            txtResultat.Text = resultatStr;
        }

        private void Reset()
        {
            optSoustraction.IsChecked = false;
            optAddition.IsChecked = true;

            txtNombre1.Text = string.Empty;
            txtNombre2.Text = string.Empty;
            txtResultat.Text = string.Empty;
        }
    }
}
