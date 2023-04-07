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
    /// Logika interakcji dla klasy Czytelnicy.xaml
    /// </summary>
    public partial class Czytelnicy : Window
    {
        ObservableCollection<Czytelnik> czytelnicy;

        /// <summary>
        /// Konstruktor nieparametryczny, który otwiera okno z listą czytelników.
        /// </summary>
        public Czytelnicy()
        {
            InitializeComponent();
            czytelnicy = new ObservableCollection<Czytelnik>(Czytelnik.Czytelnicy);
            czytelnicyLst.ItemsSource = czytelnicy;
        }

        /// <summary>
        /// Metoda pozwala na dodanie czytelnika, wyświetla okno dialogowe z formularzem do dodawania nowego czytelnika.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Dodaj(object sender, EventArgs e)
        {
            DodajEdytujCzytelnika dek = new DodajEdytujCzytelnika();
            dek.ShowDialog();
            czytelnicy = new ObservableCollection<Czytelnik>(Czytelnik.Czytelnicy);
            czytelnicyLst.ItemsSource = czytelnicy;
        }

        /// <summary>
        /// Metoda pozwala na edytowanie czytelnika; sprawdza czy jest zaznaczony jakiś element, 
        /// a jeśli nie to wyświetla komunikat o błędzie; 
        /// wyświetla okno dialogowe z formularzem do edycji nowego czytelnika.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Edytuj(object sender, EventArgs e)
        {
            if (czytelnicyLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano czytelnika!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DodajEdytujCzytelnika dek = new DodajEdytujCzytelnika((Czytelnik)czytelnicyLst.SelectedItem);
            dek.ShowDialog();
            czytelnicy = new ObservableCollection<Czytelnik>(Czytelnik.Czytelnicy);
            czytelnicyLst.ItemsSource = czytelnicy;
        }

        /// <summary>
        /// Metoda usuwa wybranego czytelnika z listy czytelników. 
        /// Sprawdza również czy czytelnik ma jakieś niezwrócone jeszcze książki (poprzez sprawdzanie listy wypożyczeń);
        /// jeśli tak, pyta użytkownika czy na pewno chce usunąć czytelnika oraz jego wypożyczenia. 
        /// Jeśli użytkownik potwierdzi, usuwa również wszystkie wypożyczenia danego czytelnika. 
        /// Następnie odświeża listę czytelników w oknie aplikacji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Usun(object sender, RoutedEventArgs e)
        {
            if (czytelnicyLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano czytelnika!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Czytelnik doUsuniecia = (Czytelnik)czytelnicyLst.SelectedItem;
            bool czySiePowtarza = false;
            foreach (Wypozyczenie wypozyczenie in Wypozyczenie.Wypozyczenia)
            {
                if (wypozyczenie.Czytelnik.Id == doUsuniecia.Id)
                {
                    czySiePowtarza = true;
                }
            }
            if (czySiePowtarza == true)
            {
                MessageBoxResult mr = MessageBox.Show("Ten czytelnik nie zwrócił jeszcze wszystkich książek. Usunięcie czytelnika spowoduje usunięcie jego wypożyczeń. Czy chcesz to zrobić?", "Uwaga", MessageBoxButton.YesNo);
                if (mr == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < Wypozyczenie.Wypozyczenia.Count(); i++)
                    {
                        if (Wypozyczenie.Wypozyczenia[i].Czytelnik.Id == doUsuniecia.Id)
                            Wypozyczenie.Wypozyczenia.Remove(Wypozyczenie.Wypozyczenia[i--]);
                    }
                    czytelnicyLst.SelectedIndex = czytelnicyLst.SelectedIndex - 1;
                    Czytelnik.Czytelnicy.Remove(doUsuniecia);
                }
                else if (mr == MessageBoxResult.No)
                {
                    return;
                }
            }
            else
            {
                czytelnicyLst.SelectedIndex = czytelnicyLst.SelectedIndex - 1;
                Czytelnik.Czytelnicy.Remove(doUsuniecia);
            }
            czytelnicy = new ObservableCollection<Czytelnik>(Czytelnik.Czytelnicy);
            czytelnicyLst.ItemsSource = czytelnicy;
        }

        /// <summary>
        /// Metoda ta sortuje elementy z kolekcji czytelnicy za pomocą funkcji "Sort()" i ustawia je na liście czytelników 
        /// (na kontrolce czytelnicyLst).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sortuj(object sender, RoutedEventArgs e)
        {
            List<Czytelnik> cz = new List<Czytelnik>(czytelnicy);
            cz.Sort();
            czytelnicy = new ObservableCollection<Czytelnik>(cz);
            czytelnicyLst.ItemsSource = czytelnicy;
        }
    }
}
