using Projekt;
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
using System.Windows.Shapes;
using Aplikacja.Okna;

namespace Aplikacja.Okna
{
    /// <summary>
    /// Logika interakcji dla klasy Wypozyczenie.xaml
    /// </summary>
    public partial class Wypozycz : Window
    {
        /// <summary>
        /// Konstruktor nieparametryczny, który otwiera okno dotyczące wypożyczenia książek.
        /// </summary>
        public Wypozycz()
        {
            InitializeComponent();
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
        /// Metoda pobiera i wyświetla liczbę dostepnych książek na podstwie ISBN, wykorzystuje funkcję Single().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AktualizujLiczbe(object sender, EventArgs e)
        {
            try
            {
                liczbaTxt.Text = Ksiazka.Ksiazki.Single(ksiazka => ksiazka.Isbn == isbnTxt.Text).LiczbaDostepnych.ToString();
            }
            catch(Exception)
            {
                liczbaTxt.Text = null;
            }
        }

        /// <summary>
        /// Metoda otwiera okno z listą książek i czeka na akcję zatwierdzenia wyboru przez użytkownika.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WybierzKsiazke(object sender, RoutedEventArgs e)
        {
            ListaKsiazek listaksiazek = new ListaKsiazek(isbnTxt);
            listaksiazek.ShowDialog();
        }

        /// <summary>
        /// Metoda jest odpowiedzialna za sprawdzenie liczby dostępnych książek i wypożyczenie książki, gdy jest taka możliwość.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WypozyczKsiazke(object sender, RoutedEventArgs e)
        {
            try
            {
                if(int.Parse(liczbaTxt.Text) > 0)
                {
                    new Wypozyczenie(Czytelnik.Czytelnicy.Single(czytelnik => czytelnik.Id == int.Parse(czytTxt.Text)), Ksiazka.Ksiazki.Single(ksiazka => ksiazka.Isbn == isbnTxt.Text), DateTime.Today);
                    Close();
                }
                else
                    MessageBox.Show("Książka niedostępna!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);


            }
            catch (Exception)
            {
                MessageBox.Show("Podano błędne dane!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
