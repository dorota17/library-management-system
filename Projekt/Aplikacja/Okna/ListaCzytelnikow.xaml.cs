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
    /// Logika interakcji dla klasy ListaCzytelnikow.xaml
    /// </summary>
    public partial class ListaCzytelnikow : Window
    {
        TextBox miejsceDocelowe;
        ObservableCollection<Czytelnik> czytelnicy;

        /// <summary>
        /// Konstruktor parametryczny, który otwiera okno z listą czytelników.
        /// </summary>
        public ListaCzytelnikow(TextBox miejsceDocelowe)
        {
            InitializeComponent();
            this.miejsceDocelowe = miejsceDocelowe;
            czytelnicy = new ObservableCollection<Czytelnik>(Czytelnik.Czytelnicy);
            czytelnicyLst.ItemsSource = czytelnicy;
        }

        /// <summary>
        /// Metoda umożliwia wybór czytelnika z listy i przypisanie jego ID do pola tekstowego "miejsceDocelowe" oraz zamyka okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zatwierdz(object sender, RoutedEventArgs e)
        {
            if (czytelnicyLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano czytelnika!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                miejsceDocelowe.Text = ((Czytelnik)czytelnicyLst.SelectedItem).Id.ToString();
                Close();
            }
        }

        /// <summary>
        /// Metoda filtruje listę czytelników. Korzysta z metody Equals. Usuwa z listy, 
        /// która jest kopią oryginalnej listy czytelników, te obiekty, które nie spełniają kryterium.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtruj(object sender, EventArgs e)
        {
            czytelnicy = new ObservableCollection<Czytelnik>(Czytelnik.Czytelnicy);
            czytelnicyLst.ItemsSource = czytelnicy;
            if (imieNazwiskoTxt.Text != null && imieNazwiskoTxt.Text != "")
            {
                foreach (Czytelnik czytelnik in Czytelnik.Czytelnicy)
                    if (!czytelnik.Equals(imieNazwiskoTxt.Text))
                        czytelnicy.Remove(czytelnik);
            }
        }
    }
}
