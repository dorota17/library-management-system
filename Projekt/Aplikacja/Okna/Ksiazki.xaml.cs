using Projekt;
using Projekt.Comparators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Aplikacja.Okna
{
    /// <summary>
    /// Logika interakcji dla klasy Ksiazki.xaml
    /// </summary>
    public partial class Ksiazki : Window
    {
        ObservableCollection<Ksiazka> ksiazki;

        /// <summary>
        /// Konstruktor nieparametryczny, który otwiera okno z listą książek.
        /// </summary>
        public Ksiazki()
        {
            InitializeComponent();
            ksiazki = new ObservableCollection<Ksiazka>(Ksiazka.Ksiazki);
            ksiazkiLst.ItemsSource = ksiazki;
            sortCmb.SelectedIndex = 0;
        }

        /// <summary>
        /// Metoda pozwala na dodanie książki, wyświetla okno dialogowe z formularzem do dodawania nowej książki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dodaj(object sender, EventArgs e)
        {
            DodajEdytujKsiazke dek = new DodajEdytujKsiazke();
            dek.ShowDialog();
            ksiazki = new ObservableCollection<Ksiazka>(Ksiazka.Ksiazki);
            ksiazkiLst.ItemsSource = ksiazki;
        }

        /// <summary>
        /// Metoda pozwala na edytowanie książki; sprawdza czy jest zaznaczony jakiś element, 
        /// a jeśli nie to wyświetla komunikat o błędzie; wyświetla okno dialogowe z formularzem do edycji książki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edytuj(object sender, EventArgs e)
        {
            if(ksiazkiLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano książki!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DodajEdytujKsiazke dek = new DodajEdytujKsiazke((Ksiazka)ksiazkiLst.SelectedItem);
            dek.ShowDialog();
            ksiazki = new ObservableCollection<Ksiazka>(Ksiazka.Ksiazki);
            ksiazkiLst.ItemsSource = ksiazki;
        }

        /// <summary>
        /// Metoda pozwala na usunięcie książki korzystając z funkcji "Remove()"; 
        /// sprawdza czy jest zaznaczony jakiś element, a jeśli nie to wyświetla komunikat o błędzie.
        /// Jeżeli dana książka jest obecnie wypożyczona to użytkownik jest pytany czy chce usunąc wszystkie wypożyczenia tej książki.
        /// Nie da się usunąć wypożyczonej książki bez usuwania wypożyczeń.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Usun(object sender, RoutedEventArgs e)
        {
            if (ksiazkiLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano książki!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Ksiazka doUsuniecia = (Ksiazka)ksiazkiLst.SelectedItem;
            bool czySiePowtarza = false;
            foreach (Wypozyczenie wypozyczenie in Wypozyczenie.Wypozyczenia)
            {
                if (wypozyczenie.Ksiazka.Isbn == doUsuniecia.Isbn)
                {
                    czySiePowtarza = true;
                }
            }
            if (czySiePowtarza == true)
            {
                MessageBoxResult mr = MessageBox.Show("Ta ksiażka jest obecnie wypożyczona. Usunięcie jej spowoduje usunięcie wypożyczenia. Czy chcesz to zrobić?", "Uwaga", MessageBoxButton.YesNo);
                if (mr == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < Wypozyczenie.Wypozyczenia.Count(); i++)
                    {
                        if (Wypozyczenie.Wypozyczenia[i].Ksiazka.Isbn == doUsuniecia.Isbn)
                            Wypozyczenie.Wypozyczenia.Remove(Wypozyczenie.Wypozyczenia[i--]);
                    }
                    ksiazkiLst.SelectedIndex = ksiazkiLst.SelectedIndex - 1;
                    Ksiazka.Ksiazki.Remove(doUsuniecia);
                }
                else if (mr == MessageBoxResult.No)
                {
                    return;
                }
            }
            else
            {
                ksiazkiLst.SelectedIndex = ksiazkiLst.SelectedIndex - 1;
                Ksiazka.Ksiazki.Remove(doUsuniecia);
            }
            ksiazki = new ObservableCollection<Ksiazka>(Ksiazka.Ksiazki);
            ksiazkiLst.ItemsSource = ksiazki;
        }

        /// <summary>
        /// Metoda ustawia elementy listy książki bez sortowania.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrakSortowania(object sender, EventArgs e)
        {
            ksiazki = new ObservableCollection<Ksiazka>(Ksiazka.Ksiazki);
            ksiazkiLst.ItemsSource = ksiazki;
        }

        /// <summary>
        /// Metoda sortuje książki po tytule.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortujTytul(object sender, EventArgs e)
        {
            List<Ksiazka> k = new List<Ksiazka>(ksiazki);
            k.Sort();
            ksiazki = new ObservableCollection<Ksiazka>(k);
            ksiazkiLst.ItemsSource = ksiazki;
        }

        /// <summary>
        /// Metoda sortuje książki po autorze.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortujAutor(object sender, EventArgs e)
        {
            List<Ksiazka> k = new List<Ksiazka>(ksiazki);
            k.Sort(new AutorComparator());
            ksiazki = new ObservableCollection<Ksiazka>(k);
            ksiazkiLst.ItemsSource = ksiazki;
        }

        /// <summary>
        /// Metoda sortuje książki po gatunku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortujGatunek(object sender, EventArgs e)
        {
            List<Ksiazka> k = new List<Ksiazka>(ksiazki);
            k.Sort(new GatunekComparator());
            ksiazki = new ObservableCollection<Ksiazka>(k);
            ksiazkiLst.ItemsSource = ksiazki;
        }
    }
}
