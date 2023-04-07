using Projekt;
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
    /// Logika interakcji dla klasy Wydawnictwa.xaml
    /// </summary>
    public partial class Wydawnictwa : Window
    {
        ObservableCollection<Wydawnictwo> wydawnictwa;

        /// <summary>
        /// Konstruktor nieparametryczny, który otwiera okno z listą wydawnictw.
        /// </summary>
        public Wydawnictwa()
        {
            InitializeComponent();
            wydawnictwa = new ObservableCollection<Wydawnictwo>(Wydawnictwo.Wydawnictwa);
            wydawnictwaLst.ItemsSource = wydawnictwa;
        }

        /// <summary>
        /// Metoda pozwala na dodanie wydawnictwa, wyświetla okno dialogowe z formularzem do dodawania nowego wydawnictwa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Dodaj(object sender, EventArgs e)
        {
            DodajEdytujWydawnictwo dek = new DodajEdytujWydawnictwo();
            dek.ShowDialog();
            wydawnictwa = new ObservableCollection<Wydawnictwo>(Wydawnictwo.Wydawnictwa);
            wydawnictwaLst.ItemsSource = wydawnictwa;
        }

        /// <summary>
        /// Metoda pozwala na edytowanie wydawnictwa; sprawdza czy jest zaznaczony jakiś element, 
        /// a jeśli nie to wyświetla komunikat o błędzie; wyświetla okno dialogowe z formularzem do edycji wydawnictwa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Edytuj(object sender, EventArgs e)
        {
            if (wydawnictwaLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano wydawnictwa!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DodajEdytujWydawnictwo dek = new DodajEdytujWydawnictwo((Wydawnictwo)wydawnictwaLst.SelectedItem);
            dek.ShowDialog();
            wydawnictwa = new ObservableCollection<Wydawnictwo>(Wydawnictwo.Wydawnictwa);
            wydawnictwaLst.ItemsSource = wydawnictwa;
        }

        /// <summary>
        /// Metoda usuwa wybrane wydawnictwo z listy wydawnictw. 
        /// Sprawdza również czy w bazie istnieją książki tego wydawnictwa;
        /// jeśli tak, pyta użytkownika czy na pewno chce usunąć wszystkie książki tego wydawnictwa. 
        /// Nie można usunąć wydawnictwa jeżeli istnieją w bazie książki tego wydawnictwa.
        /// Następnie odświeża listę wydawnictw w oknie aplikacji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Usun(object sender, RoutedEventArgs e)
        {
            if (wydawnictwaLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano wydawnictwa!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Wydawnictwo doUsuniecia = (Wydawnictwo)wydawnictwaLst.SelectedItem;
            bool czySiePowtarza = false;
            foreach (Ksiazka ksiazka in Ksiazka.Ksiazki)
            {
                if (ksiazka.Wydawnictwo.Nazwa == doUsuniecia.Nazwa && ksiazka.Wydawnictwo.Ulica == doUsuniecia.Ulica)
                {
                    czySiePowtarza = true;
                }
            }
            if (czySiePowtarza == true)
            {
                MessageBoxResult mr = MessageBox.Show("Czy chcesz usunąć wszystkie książki tego wydawnictwa?", "Uwaga", MessageBoxButton.YesNo);
                if (mr == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < Ksiazka.Ksiazki.Count(); i++)
                    {
                        if (Ksiazka.Ksiazki[i].Wydawnictwo.Nazwa == doUsuniecia.Nazwa && Ksiazka.Ksiazki[i].Wydawnictwo.Ulica == doUsuniecia.Ulica)
                            Ksiazka.Ksiazki.Remove(Ksiazka.Ksiazki[i--]);
                    }
                    wydawnictwaLst.SelectedIndex = wydawnictwaLst.SelectedIndex - 1;
                    Wydawnictwo.Wydawnictwa.Remove(doUsuniecia);
                }
                else if (mr == MessageBoxResult.No)
                {
                    return;
                }
            }
            else
            {
                wydawnictwaLst.SelectedIndex = wydawnictwaLst.SelectedIndex - 1;
                Wydawnictwo.Wydawnictwa.Remove(doUsuniecia);
            }
            wydawnictwa = new ObservableCollection<Wydawnictwo>(Wydawnictwo.Wydawnictwa);
            wydawnictwaLst.ItemsSource = wydawnictwa;
        }

        /// <summary>
        /// Metoda ta sortuje elementy z kolekcji wydawnictwa za pomocą funkcji "Sort()" 
        /// i ustawia je na liście wydawnictw (na kontrolce wydawnictwaLst).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sortuj(object sender, RoutedEventArgs e)
        {
            List<Wydawnictwo> w = new List<Wydawnictwo>(wydawnictwa);
            w.Sort();
            wydawnictwa = new ObservableCollection<Wydawnictwo>(w);
            wydawnictwaLst.ItemsSource = wydawnictwa;
        }
    }
}
