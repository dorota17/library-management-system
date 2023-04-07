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

        public Zwrot()
        {
            InitializeComponent();
            wypozyczenia = new ObservableCollection<Wypozyczenie>(Wypozyczenie.Wypozyczenia);
            wypozyczeniaLst.ItemsSource = wypozyczenia;
        }

        private void WybierzCzytelnika(object sender, RoutedEventArgs e)
        {
            ListaCzytelnikow listaczytelnikow = new ListaCzytelnikow(czytTxt);
            listaczytelnikow.ShowDialog();
        }

        private void WybierzKsiazke(object sender, RoutedEventArgs e)
        {
            ListaKsiazek listaksiazek = new ListaKsiazek(isbnTxt);
            listaksiazek.ShowDialog();
        }

        private void Zwroc(object sender, RoutedEventArgs e)
        {
            if (wypozyczeniaLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano wypożyczenia!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Wypozyczenie doUsuniecia = (Wypozyczenie)wypozyczeniaLst.SelectedItem;
            doUsuniecia.Ksiazka.LiczbaDostepnych++;
            wypozyczeniaLst.SelectedIndex = wypozyczeniaLst.SelectedIndex - 1;
            Wypozyczenie.Wypozyczenia.Remove(doUsuniecia);
            wypozyczenia.Remove(doUsuniecia);
        }
        private void Filtruj(object sender, EventArgs e)
        {
            if (isbnTxt.Text != null && czytTxt.Text != null && isbnTxt.Text != "" && czytTxt.Text != "")
            {
                wypozyczenia.Clear();
                foreach (Wypozyczenie w in Wypozyczenie.Wypozyczenia.Where(wypozyczenie => wypozyczenie.Czytelnik.Id == int.Parse(czytTxt.Text) && wypozyczenie.Ksiazka.Isbn == isbnTxt.Text))
                    wypozyczenia.Add(w);
            }
            else if (isbnTxt.Text != null && isbnTxt.Text != "")
            {
                wypozyczenia.Clear();
                foreach (Wypozyczenie w in Wypozyczenie.Wypozyczenia.Where(wypozyczenie => wypozyczenie.Ksiazka.Isbn == isbnTxt.Text))
                    wypozyczenia.Add(w);
            }
            else if (czytTxt.Text != null && czytTxt.Text != "")
            {
                wypozyczenia.Clear();
                foreach (Wypozyczenie w in Wypozyczenie.Wypozyczenia.Where(wypozyczenie => wypozyczenie.Czytelnik.Id == int.Parse(czytTxt.Text)))
                    wypozyczenia.Add(w);
            }
            else
            {
                wypozyczenia.Clear();
                foreach (Wypozyczenie w in Wypozyczenie.Wypozyczenia)
                    wypozyczenia.Add(w);
            }
        }
    }
}
