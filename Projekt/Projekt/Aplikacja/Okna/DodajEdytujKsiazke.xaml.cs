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
        public DodajEdytujKsiazke()
        {
            InitializeComponent();

            doEdycji = null;

            Autor a = new Autor("Adam", "Mickiewicz", Plec.M);
            autorCmb.ItemsSource = Autor.Autorzy;

            Wydawnictwo w = new Wydawnictwo("Albatros", "Smolna 11", "Warszawa", "00-375");
            wydCmb.ItemsSource = Wydawnictwo.Wydawnictwa;

            Gatunek g = new Gatunek("Dramat");
            gatCmb.ItemsSource = Gatunek.Gatunki;
        }

        public DodajEdytujKsiazke(Ksiazka doEdycji)
        {
            InitializeComponent();

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

        private void Anuluj(object sender, EventArgs e)
        {
            Close();
        }

        private void Zatwierdz(object sender, EventArgs e)
        {
            if (doEdycji == null)
            {
                try
                {
                    new Ksiazka(isbnTxt.Text, tytulTxt.Text, (Autor)autorCmb.SelectedItem, (Gatunek)gatCmb.SelectedItem, rokTxt.Text, iloscTxt.Text, (Wydawnictwo)wydCmb.SelectedItem);
                }
                catch (Exception)
                {
                    Ksiazka.Ksiazki.RemoveAt(Ksiazka.Ksiazki.Count - 1);
                    MessageBox.Show("Podano błędne dane!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                try
                {
                    new Ksiazka(isbnTxt.Text, tytulTxt.Text, (Autor)autorCmb.SelectedItem, (Gatunek)gatCmb.SelectedItem, rokTxt.Text, iloscTxt.Text, (Wydawnictwo)wydCmb.SelectedItem);
                    Ksiazka.Ksiazki.Remove(doEdycji);
                    Close();
                }
                catch (Exception)
                {
                    Ksiazka.Ksiazki.RemoveAt(Ksiazka.Ksiazki.Count - 1);
                    MessageBox.Show("Podano błędne dane!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void TylkoLiczby(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
