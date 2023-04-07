using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projekt;

namespace Aplikacja.Okna
{
    /// <summary>
    /// Logika interakcji dla klasy DodajKsiazke.xaml
    /// </summary>
    public partial class DodajEdytujKsiazke : Window
    {
        private Ksiazka doEdycji;

        /// <summary>
        /// Konstruktor nieparametyryczny, który otwiera okno odpowiedzialne za dodanie książki.
        /// </summary>
        public DodajEdytujKsiazke()
        {
            InitializeComponent();

            doEdycji = null;

            
            autorCmb.ItemsSource = Autor.Autorzy;
            autorCmb.SelectedItem = null;

            
            wydCmb.ItemsSource = Wydawnictwo.Wydawnictwa;
            wydCmb.SelectedItem = null;

            
            gatCmb.ItemsSource = Gatunek.Gatunki;
            gatCmb.SelectedItem = null;
        }

        /// <summary>
        /// Konstruktor parametryczny, który otwiera okno odpowiedzialne za edycję danych książki.
        /// </summary>
        /// <param name="doEdycji"></param>
        public DodajEdytujKsiazke(Ksiazka doEdycji)
        {
            InitializeComponent();

            Title = "Edytuj Książkę";

            this.doEdycji = doEdycji;

            autorCmb.ItemsSource = Autor.Autorzy;
            wydCmb.ItemsSource = Wydawnictwo.Wydawnictwa;
            gatCmb.ItemsSource = Gatunek.Gatunki;

            isbnTxt.Text = doEdycji.Isbn;
            tytulTxt.Text = doEdycji.Tytul;
            foreach(Autor autor in autorCmb.Items)
                if(autor.Id == doEdycji.Autor.Id)
                    autorCmb.SelectedItem = autor;
            foreach (Wydawnictwo wydawnictwo in wydCmb.Items)
                if (wydawnictwo.Nazwa == doEdycji.Wydawnictwo.Nazwa)
                    wydCmb.SelectedItem = wydawnictwo;
            rokTxt.Text = doEdycji.RokWydania.ToString();
            foreach (Gatunek gatunek in gatCmb.Items)
                if (gatunek.Nazwa == doEdycji.Gatunek.Nazwa)
                    gatCmb.SelectedItem = gatunek;
            iloscTxt.Text = doEdycji.LiczbaOgolem.ToString();
        }

        /// <summary>
        /// Metoda ta pozwala na usunięcie danych z pól po kliknięciu przycisku Wyczysc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wyczysc(object sender, EventArgs e)
        {
            isbnTxt.Text = null;
            tytulTxt.Text = null;
            autorCmb.SelectedItem = null;
            wydCmb.SelectedItem = null;
            rokTxt.Text = null;
            gatCmb.SelectedItem = null;
            iloscTxt.Text = null;
        }

        /// <summary>
        /// Metoda ta pozwala na zamknięcie okna formularza po kliknięciu przycisku Anuluj.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Anuluj(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Metoda ta pozwala na zatwierdzenie dodania/edycji książki.
        /// Jeżeli dodajemy książkę to metoda wywołuje konstruktor klasy Ksiazka i tworzy nową instancję tej klasy. 
        /// W przypadku przechwycenia wyjątku pojawia się komunikat o błędnych danych.
        /// Edycja książki polega na utworzeniu nowego obiektu klasy Ksiazka i usunięciu poprzedniego.
        /// W przypadku edycji liczby książek sprawdzane jest czy liczba sztuk książek ogółem 
        /// jest nie mniejsza niż liczba książek obecnie wypożyczonych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zatwierdz(object sender, EventArgs e)
        {
            bool juzDodana = false;
            if (doEdycji == null)
            {
                try
                {
                    foreach(Ksiazka ksiazka in Ksiazka.Ksiazki)
                    {
                        if(ksiazka.Isbn == isbnTxt.Text)
                        {
                            juzDodana = true;
                            break;
                        }
                    }
                    if(juzDodana == true)
                        MessageBox.Show("Ta książka jest już w bazie!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        new Ksiazka(isbnTxt.Text, tytulTxt.Text, (Autor)autorCmb.SelectedItem, (Gatunek)gatCmb.SelectedItem, rokTxt.Text, iloscTxt.Text, (Wydawnictwo)wydCmb.SelectedItem);
                        Close();
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Podano błędne dane!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                try
                {
                    if (int.Parse(iloscTxt.Text) - (doEdycji.LiczbaOgolem - doEdycji.LiczbaDostepnych) >= 0)
                    {
                        Ksiazka k = new Ksiazka(isbnTxt.Text, tytulTxt.Text, (Autor)autorCmb.SelectedItem, (Gatunek)gatCmb.SelectedItem, rokTxt.Text, iloscTxt.Text, (Wydawnictwo)wydCmb.SelectedItem);
                        k.LiczbaDostepnych = doEdycji.LiczbaDostepnych;
                        k.LiczbaDostepnych -= doEdycji.LiczbaOgolem - k.LiczbaOgolem;
                        Ksiazka.Ksiazki.Remove(doEdycji);
                        Close();
                    }
                    else
                        MessageBox.Show("Liczba książek nie może być mniejsza niż liczba wypożyczonych!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("Podano błędne dane!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// Metoda umożliwia jedynie wprowadzanie cyfr do pola tekstowego i blokuje możliwość wprowadzania innych znaków.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TylkoLiczby(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
