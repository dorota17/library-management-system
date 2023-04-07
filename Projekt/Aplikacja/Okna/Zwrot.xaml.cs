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
    /// Logika interakcji dla klasy Zwrot.xaml
    /// </summary>
    public partial class Zwrot : Window
    {
        ObservableCollection<Wypozyczenie> wypozyczenia;

        /// <summary>
        /// Konstruktor nieparametryczny, który otwiera okno dotyczące zwrotu książek.
        /// </summary>
        public Zwrot()
        {
            InitializeComponent();
            wypozyczenia = new ObservableCollection<Wypozyczenie>(Wypozyczenie.Wypozyczenia);
            wypozyczeniaLst.ItemsSource = wypozyczenia;
        }

        /// <summary>
        /// Metoda otwiera okno z listą czytelników, a po jego wybraniu przekazuje ID i zamyka okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WybierzCzytelnika(object sender, RoutedEventArgs e)
        {
            ListaCzytelnikow listaczytelnikow = new ListaCzytelnikow(czytTxt);
            listaczytelnikow.ShowDialog();
        }

        /// <summary>
        /// Metoda pozwala na przypisanie konkretnej książki do operacji zwrotu. Otwiera okno z listą książek, a po jej wybraniu przekazuje ISBN i zamyka okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WybierzKsiazke(object sender, RoutedEventArgs e)
        {
            ListaKsiazek listaksiazek = new ListaKsiazek(isbnTxt);
            listaksiazek.ShowDialog();
        }

        /// <summary>
        /// Metoda jest odpowiedzialna za zwrot wybranego wypożyczenia z listy wypożyczeń.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zwroc(object sender, RoutedEventArgs e)
        {
            if (wypozyczeniaLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano wypożyczenia!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Wypozyczenie doUsuniecia = (Wypozyczenie)wypozyczeniaLst.SelectedItem;
            Ksiazka.Ksiazki.Single(ksiazka => ksiazka.Isbn == doUsuniecia.Ksiazka.Isbn).LiczbaDostepnych++;
            wypozyczeniaLst.SelectedIndex = wypozyczeniaLst.SelectedIndex - 1;
            Wypozyczenie.Wypozyczenia.Remove(doUsuniecia);
            wypozyczenia.Remove(doUsuniecia);
        }

        /// <summary>
        /// Metoda filtruje listę wypożyczeń przez ISBN i ID czytelnika.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtruj(object sender, EventArgs e)
        {
            wypozyczenia = new ObservableCollection<Wypozyczenie>(Wypozyczenie.Wypozyczenia);
            wypozyczeniaLst.ItemsSource = wypozyczenia;

            if(isbnTxt.Text != null && isbnTxt.Text != "")
            {
                foreach(Wypozyczenie wypozyczenie in Wypozyczenie.Wypozyczenia)
                    if(!wypozyczenie.Ksiazka.Equals(isbnTxt.Text))
                        wypozyczenia.Remove(wypozyczenie);
            }
            if (czytTxt.Text != null && czytTxt.Text != "")
            {
                foreach (Wypozyczenie wypozyczenie in Wypozyczenie.Wypozyczenia)
                    if (!wypozyczenie.Czytelnik.Equals(int.Parse(czytTxt.Text)))
                        wypozyczenia.Remove(wypozyczenie);
            }
        }
    }
}
