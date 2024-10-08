using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _6TI_VandervoortAlexandre_WPF_A3Bis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly int[] PRIX_BASE_GRANDE_VACANCES = new int[] { 547, 581, 599, 349, 380, 390 };
        private static readonly int[] PRIX_BASE_NOEL_PAQUES = new int[] { 297, 330, 347, 198, 220, 250 };

        private static readonly double RISTOURNE_3_4_SEMAINES = 0.05;
        private static readonly double RISTOURNE_5_SEMAINES = 0.10;

        private static readonly int FRAIS_RESERVATION = 12;
        private static readonly double FRAIS_PERSONNE_JOUR = 0.30;
        
        private static readonly int[] AVAILABILITY_MONTHS = new int[] { 1, 4, 7, 8, 12 };
        private static readonly DateTime CLOSEST_AVAILABLE_TIME = GetClosestAvailableTime(DateTime.Now);

        public MainWindow()
        {
            InitializeComponent();
            
            //mise en place des valeurs de base (dynamique)
            DateArrivee.SelectedDate = CLOSEST_AVAILABLE_TIME;
            DateSortie.SelectedDate = CLOSEST_AVAILABLE_TIME;
            BoutonCalcul.IsEnabled = false;


            NbrePersonnes.PreviewTextInput += new TextCompositionEventHandler(NbrePersonnePreviewTextInputListener);
            NbrePersonnes.LostFocus += NbrePersonnes_LostFocus;

            DateArrivee.SelectedDateChanged += DateArriveeSelectedDateChangedListener;
            DateSortie.SelectedDateChanged += DateSortieSelectedDateChangedListener;

            DureeSortie.Click += DureeSortie_Click;
            BoutonCalcul.Click += BoutonCalcul_Click;

        }

        /// <summary>
        /// Vérifie l'entrée de toutes les valeurs requises et calcule le prix du séjour.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoutonCalcul_Click(object sender, RoutedEventArgs e)
        {
            if ((RadioLogementChalet.IsPressed || RadioLogementTente.IsPressed) && _setCalculSemaine && NbrePersonnes.Text != String.Empty)
            {
                //toutes les valeurs requises sont actives.

                bool estChalet = RadioLogementChalet.IsPressed;
                int personnes = int.Parse(NbrePersonnes.Text);

                double joursSéjour = GetDuree(DateArrivee.SelectedDate.Value, DateSortie.SelectedDate.Value);
                double semaines = Math.Ceiling(joursSéjour / 7);

                int type;
                if (personnes <= 4)
                {
                    type = 1;
                } else if (personnes == 5)
                {
                    type = 2;
                } else
                {
                    type = 3;
                }

                int index = (estChalet ? 0 : 2) + type;

                bool grandeVacance = DateArrivee.SelectedDate.Value.Month > 6 && DateSortie.SelectedDate.Value.Month < 9;

                double valeur;
                if (grandeVacance)
                {
                    valeur = PRIX_BASE_GRANDE_VACANCES[index];
                } else
                {
                    valeur = PRIX_BASE_NOEL_PAQUES[index];
                }
                valeur += (personnes * joursSéjour * 0.30);

                if (CheckBoxReservation.IsChecked)
                {
                    valeur += FRAIS_RESERVATION;
                }

                if (semaines >= 5)
                {
                    valeur -= valeur * RISTOURNE_5_SEMAINES;
                } else if (semaines >= 3)
                {
                    valeur -= valeur * RISTOURNE_3_4_SEMAINES;
                }


            }
        }

        private bool _setCalculSemaine = false;
        /// <summary>
        /// Calcule le nombre de semaines du séjour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DureeSortie_Click(object sender, RoutedEventArgs e)
        {
            if (!DateArrivee.SelectedDate.HasValue || !DateSortie.SelectedDate.HasValue)
            {
                return;
            }

            
            double semaines = GetDuree(DateArrivee.SelectedDate.Value, DateSortie.SelectedDate.Value) / 7;
            SemainesNbre.Text = "Nombres de semaines: " + Math.Ceiling(semaines) + " (Arrondi en hausse)";

            _setCalculSemaine = true;
            BoutonCalcul.IsEnabled = true;
        }

        /// <summary>
        /// Remet à zero le calcul de prix du séjour
        /// </summary>
        private void ResetCalculSemaine()
        {
            SemainesNbre.Text = "Nombres de semaines: ";
            _setCalculSemaine = false;
            BoutonCalcul.IsEnabled = false;
        }

        /// <summary>
        /// Logique s'occupant de vérifier la date d'arrivée entrée par l'utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DateArriveeSelectedDateChangedListener(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count >= 1)
            {
                DateTime? date = DateArrivee.SelectedDate;

                if (!AVAILABILITY_MONTHS.Contains(date.Value.Month)) {
                    DateArrivee.SelectedDate = CLOSEST_AVAILABLE_TIME;
                }

                //on ne peut pas arriver après avoir quitté cette réservation
                if (DateSortie.SelectedDate < date)
                {
                    DateSortie.SelectedDate = date;
                }


                //date déja passée
                if (DateSortie.SelectedDate < CLOSEST_AVAILABLE_TIME)
                {
                    DateSortie.SelectedDate = CLOSEST_AVAILABLE_TIME;
                }

                ResetCalculSemaine();
            }
        }

        /// <summary>
        /// Logique s'occupant de vérifier la date de fin du séjour entrée par l'utilisateur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DateSortieSelectedDateChangedListener(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count >= 1)
            {
                DateTime? date = DateSortie.SelectedDate;

                //on ne peut pas arriver après avoir quitté cette réservation
                if (DateArrivee.SelectedDate > date)
                {
                    DateSortie.SelectedDate = DateArrivee.SelectedDate;
                }

                //date déja passée
                if (DateArrivee.SelectedDate < CLOSEST_AVAILABLE_TIME)
                {
                    DateArrivee.SelectedDate = CLOSEST_AVAILABLE_TIME;
                }

                ResetCalculSemaine();
            }
        }

        /// <summary>
        /// Vérifie que NbrePersonnes contienne toujours une valeur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NbrePersonnes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NbrePersonnes.Text == String.Empty)
            {
                NbrePersonnes.Text = "1";
            }
        }

        /// <summary>
        /// Vérifie que la valeur dans NbrePersonnes est un nombre entre 1 et 6.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private static double GetDuree(DateTime debut, DateTime fin)
        {
            return (fin - debut).TotalDays;
        }

        /// <summary>
        /// Récupère la date possible la plus proche.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static DateTime GetClosestAvailableTime(DateTime date)
        {
            int dateMonth = date.Month;

            if (!AVAILABILITY_MONTHS.Contains(dateMonth))
            {
                int? closestAvailableMonth = null;
                for (int i = 0; i < AVAILABILITY_MONTHS.Length; i++)
                {
                    int month = AVAILABILITY_MONTHS[i];

                    if (closestAvailableMonth == null)
                    {
                        closestAvailableMonth = month;
                        continue;
                    }

                    if (Math.Abs(month - dateMonth) <= Math.Abs(closestAvailableMonth.Value - dateMonth))
                    {
                        closestAvailableMonth = month;
                    }
                    else if (dateMonth < month)
                    {
                        //Le différenciel augmente (et le mois est déja supérieur au mois actuel, pas besoin de chercher plus loin (on n'aura pas plus proche).
                        break;
                    }
                }

                int day = 0;
                int year = date.Year;
                //on a passé une année.
                if (closestAvailableMonth < dateMonth)
                {
                    year += 1;
                }

                return new DateTime(year, closestAvailableMonth.Value, day + 1);
            }

            return date;
        }
    }
}
