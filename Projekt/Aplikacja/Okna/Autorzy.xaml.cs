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
    /// Logika interakcji dla klasy Autorzy.xaml
    /// </summary>
    public partial class Autorzy : Window
    {
        ObservableCollection<Autor> autorzy;

        /// <summary>
        /// Konstruktor nieparametryczny, który otwiera okno z listą autorów.
        /// </summary>
        public Autorzy()
        {
            InitializeComponent();
            autorzy = new ObservableCollection<Autor>(Autor.Autorzy);
            autorzyLst.ItemsSource = Autor.Autorzy;
        }

        /// <summary>
        /// Metoda pozwala na dodanie autora, wyświetla okno dialogowe z formularzem do dodawania nowego autora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Dodaj(object sender, EventArgs e)
        {
            DodajEdytujAutora dek = new DodajEdytujAutora();
            dek.ShowDialog();
            autorzy = new ObservableCollection<Autor>(Autor.Autorzy);
            autorzyLst.ItemsSource = Autor.Autorzy;
        }

        /// <summary>
        /// Metoda pozwala na edytowanie autora; sprawdza czy jest zaznaczony jakiś element, 
        /// a jeśli nie to wyświetla komunikat o błędzie; wyświetla okno dialogowe z formularzem do edycji autora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Edytuj(object sender, EventArgs e)
        {
            if (autorzyLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano autora!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DodajEdytujAutora dek = new DodajEdytujAutora((Autor)autorzyLst.SelectedItem);
            dek.ShowDialog();
            autorzy = new ObservableCollection<Autor>(Autor.Autorzy);
            autorzyLst.ItemsSource = Autor.Autorzy;
        }

        /// <summary>
        /// Metoda pozwala na usunięcie autora korzystając z funkcji "Remove()".
        /// Jeżeli w bazie danych znajdują się książki tego autora to użytkownik jest pytany czy chce usunąc wraz z autorem
        /// wszystkie jego książki. Nie można usunąć autora nie usuwając jego książek.
        /// Następnie odświeża listę autorów w oknie aplikacji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Usun(object sender, RoutedEventArgs e)
        {
            if (autorzyLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano autora!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Autor doUsuniecia = (Autor)autorzyLst.SelectedItem;
            bool czySiePowtarza = false;
            foreach (Ksiazka ksiazka in Ksiazka.Ksiazki)
            {
                if (ksiazka.Autor.Id == doUsuniecia.Id)
                {
                    czySiePowtarza = true;
                }
            }
            if (czySiePowtarza == true)
            {
                MessageBoxResult mr = MessageBox.Show("Czy chcesz usunąć wszystkie książki tego autora?", "Uwaga", MessageBoxButton.YesNo);
                if (mr == MessageBoxResult.Yes)
                {
                    for(int i=0;i<Ksiazka.Ksiazki.Count;i++)
                    {
                        if (Ksiazka.Ksiazki[i].Autor.Id == doUsuniecia.Id)
                        {
                            Ksiazka.Ksiazki.Remove(Ksiazka.Ksiazki[i--]);
                        }
                    }
                    autorzyLst.SelectedIndex = autorzyLst.SelectedIndex - 1;
                    Autor.Autorzy.Remove(doUsuniecia);
                }
                else if (mr == MessageBoxResult.No)
                {
                    return;
                }
            }
            else
            {
                autorzyLst.SelectedIndex = autorzyLst.SelectedIndex - 1;
                Autor.Autorzy.Remove(doUsuniecia);
            }
            autorzy = new ObservableCollection<Autor>(Autor.Autorzy);
            autorzyLst.ItemsSource = Autor.Autorzy;
        }

        /// <summary>
        /// Metoda ta sortuje elementy z kolekcji autorzy za pomocą funkcji "Sort()" i ustawia je na liście autorów 
        /// (na kontrolce autorzyLst).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sortuj(object sender, RoutedEventArgs e)
        {
            List<Autor> a = new List<Autor>(autorzy);
            a.Sort();
            autorzy = new ObservableCollection<Autor>(a);
            autorzyLst.ItemsSource = autorzy;
        }
    }
}
