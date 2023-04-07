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
    /// Logika interakcji dla klasy Gatunki.xaml
    /// </summary>
    public partial class Gatunki : Window
    {
        ObservableCollection<Gatunek> gatunki;

        /// <summary>
        /// Konstruktor nieparametryczny, który otwiera okno z listą gatunków.
        /// </summary>
        public Gatunki()
        {
            InitializeComponent();
            gatunki = new ObservableCollection<Gatunek>(Gatunek.Gatunki);
            gatunkiLst.ItemsSource = gatunki;
        }

        /// <summary>
        /// Metoda pozwala na dodanie agatunku, wyświetla okno dialogowe z formularzem do dodawania nowego gatunku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Dodaj(object sender, EventArgs e)
        {
            DodajEdytujGatunek dek = new DodajEdytujGatunek();
            dek.ShowDialog();
            gatunki = new ObservableCollection<Gatunek>(Gatunek.Gatunki);
            gatunkiLst.ItemsSource = gatunki;
        }

        /// <summary>
        /// Metoda służy do usuwania gatunków z listy gatunków. 
        /// Sprawdza też czy istnieją książki przypisane do tego gatunku. 
        /// Nie można usunąć gatunku jeżeli istnieją książki o tym gatunku.
        /// Następnie odświeża listę gatunków w oknie aplikacji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Usun(object sender, RoutedEventArgs e)
        {
            if (gatunkiLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano gatunku!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Gatunek doUsuniecia = (Gatunek)gatunkiLst.SelectedItem;
            bool czySiePowtarza = false;
            foreach (Ksiazka ksiazka in Ksiazka.Ksiazki)
            {
                if (ksiazka.Gatunek.Nazwa == doUsuniecia.Nazwa)
                {
                    czySiePowtarza = true;
                }
            }
            if (czySiePowtarza == true)
            {
                MessageBoxResult mr = MessageBox.Show("Czy chcesz usunąć wszystkie książki tego gatunku?", "Uwaga", MessageBoxButton.YesNo);
                if (mr == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < Ksiazka.Ksiazki.Count(); i++)
                    {
                        if (Ksiazka.Ksiazki[i].Gatunek.Nazwa == doUsuniecia.Nazwa)
                            Ksiazka.Ksiazki.Remove(Ksiazka.Ksiazki[i--]);
                    }
                    gatunkiLst.SelectedIndex = gatunkiLst.SelectedIndex - 1;
                    Gatunek.Gatunki.Remove(doUsuniecia);
                }
                else if (mr == MessageBoxResult.No)
                {
                    return;
                }
            }
            else
            {
                gatunkiLst.SelectedIndex = gatunkiLst.SelectedIndex - 1;
                Gatunek.Gatunki.Remove(doUsuniecia);
            }
            gatunki = new ObservableCollection<Gatunek>(Gatunek.Gatunki);
            gatunkiLst.ItemsSource = gatunki;
        }

        /// <summary>
        /// Metoda pozwala na edytowanie gatunku; sprawdza czy jest zaznaczony jakiś element, 
        /// a jeśli nie to wyświetla komunikat o błędzie; wyświetla okno dialogowe z formularzem do edycji nowego gatunku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Edytuj(object sender, EventArgs e)
        {
            if (gatunkiLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano gatunku!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DodajEdytujGatunek dek = new DodajEdytujGatunek((Gatunek)gatunkiLst.SelectedItem);
            dek.ShowDialog();
            gatunki = new ObservableCollection<Gatunek>(Gatunek.Gatunki);
            gatunkiLst.ItemsSource = gatunki;
        }

        /// <summary>
        /// Metoda ta sortuje elementy z kolekcji gatunki za pomocą funkcji "Sort()" i ustawia je na liście gatunków 
        /// (na kontrolce gatunkiLst).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sortuj(object sender, RoutedEventArgs e)
        {
            List<Gatunek> g = new List<Gatunek>(gatunki);
            g.Sort();
            gatunki = new ObservableCollection<Gatunek>(g);
            gatunkiLst.ItemsSource = gatunki;
        }
    }
}
