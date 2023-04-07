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
        public Wypozycz()
        {
            InitializeComponent();
        }

        private void WybierzCzytelnika(object sender, RoutedEventArgs e)
        {
            ListaCzytelnikow listaczytelnikow = new ListaCzytelnikow(czytTxt);
            listaczytelnikow.ShowDialog();
        }

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

        private void WybierzKsiazke(object sender, RoutedEventArgs e)
        {
            ListaKsiazek listaksiazek = new ListaKsiazek(isbnTxt);
            listaksiazek.ShowDialog();
        }

        private void WypozyczKsiazke(object sender, RoutedEventArgs e)
        {
            try
            {
                new Wypozyczenie(Czytelnik.Czytelnicy.Single(czytelnik => czytelnik.Id == int.Parse(czytTxt.Text)), Ksiazka.Ksiazki.Single(ksiazka => ksiazka.Isbn == isbnTxt.Text), DateTime.Today);
                Ksiazka.Ksiazki.Single(ksiazka => ksiazka.Isbn == isbnTxt.Text).LiczbaDostepnych--;
                Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Podano błędne dane!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
