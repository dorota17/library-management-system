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
    /// Logika interakcji dla klasy ListaKsiazek.xaml
    /// </summary>
    public partial class ListaKsiazek : Window
    {
        TextBox miejsceDocelowe;
        ObservableCollection<Ksiazka> ksiazki;

        /// <summary>
        /// Konstruktor parametryczny, który otwiera okno z listą książek.
        /// </summary>
        public ListaKsiazek(TextBox miejsceDocelowe)
        {
            InitializeComponent();  
            this.miejsceDocelowe = miejsceDocelowe;
            ksiazki = new ObservableCollection<Ksiazka>(Ksiazka.Ksiazki);
            ksiazkiLst.ItemsSource = ksiazki;
            gatunekCmb.ItemsSource = Gatunek.Gatunki;
        }

        /// <summary>
        /// Metoda odpowiada za przypisanie ISBN wybranej książki do pola tekstowego "miejsceDocelowe" i zamykanie okna po wyborze książki z listy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zatwierdz(object sender, EventArgs e)
        {
            if (ksiazkiLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano książki!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                miejsceDocelowe.Text = ((Ksiazka)ksiazkiLst.SelectedItem).Isbn;
                Close();
            }
        }

        /// <summary>
        /// Metoda odpowiada za filtrowanie listy książek na podstawie wprowadzonych kryteriów takich jak autor, tytuł i gatunek.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtruj(object sender, EventArgs e)
        {
            ksiazki = new ObservableCollection<Ksiazka>(Ksiazka.Ksiazki);
            ksiazkiLst.ItemsSource = ksiazki;
            if (autorTxt.Text != null && autorTxt.Text != "")
            {
                foreach(Ksiazka ksiazka in Ksiazka.Ksiazki)
                    if (!ksiazka.Autor.Equals(autorTxt.Text))
                        ksiazki.Remove(ksiazka);
            }
            if (tytulTxt.Text != null && tytulTxt.Text != "")
            {
                foreach (Ksiazka ksiazka in Ksiazka.Ksiazki)
                    if (!ksiazka.Equals(tytulTxt.Text))
                        ksiazki.Remove(ksiazka);
            }
            if (gatunekCmb.SelectedItem != null)
            {
                foreach (Ksiazka ksiazka in Ksiazka.Ksiazki)
                    if (!ksiazka.Gatunek.Equals((Gatunek)gatunekCmb.SelectedItem))
                        ksiazki.Remove(ksiazka);
            }
        }
    }
}
