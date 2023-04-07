using Projekt;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Aplikacja.Okna
{
    /// <summary>
    /// Logika interakcji dla klasy DodajEdytujCzytelnika.xaml
    /// </summary>
    public partial class DodajEdytujCzytelnika : Window
    {
        private Czytelnik doEdycji;

        /// <summary>
        /// Konstruktor nieparametyryczny, który otwiera okno odpowiedzialne za dodanie czytelnika.
        /// </summary>
        public DodajEdytujCzytelnika()
        {
            InitializeComponent();

            doEdycji = null;
            cmbPlec.ItemsSource = Enum.GetValues(typeof(Plec)).Cast<Plec>();
            cmbPlec.SelectedItem = null;
        }

        /// <summary>
        /// Konstruktor parametryczny, który otwiera okno odpowiedzialne za edycję danych czytelnika.
        /// </summary>
        /// <param name="doEdycji"></param>
        public DodajEdytujCzytelnika(Czytelnik doEdycji)
        {
            InitializeComponent();

            Title = "Edytuj Czytelnika";

            this.doEdycji = doEdycji;

            cmbPlec.ItemsSource = Enum.GetValues(typeof(Plec)).Cast<Plec>();
            cmbPlec.SelectedIndex = 0;
            txtImie.Text = doEdycji.Imie;
            txtNazwisko.Text = doEdycji.Nazwisko;

            txtNumerTelefonu.Text = doEdycji.NumerTelefonu;
            txtWiek.Text = doEdycji.Wiek.ToString();
            txtEmail.Text = doEdycji.Email;

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
        /// Metoda ta pozwala na usunięcie danych z pól po kliknięciu przycisku Wyczysc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wyczysc(object sender, EventArgs e)
        {
            txtImie.Text = string.Empty;   
            txtNazwisko.Text = string.Empty;    
            cmbPlec.SelectedIndex = 0;
            txtNumerTelefonu.Text = string.Empty;
            txtWiek.Text = string.Empty;
            txtEmail.Text = string.Empty;   
        }

        /// <summary>
        /// Metoda ta pozwala na zatwierdzenie dodania/edycji czytelnika.
        /// Jeżeli dodajemy czytelnika to metoda wywołuje konstruktor klasy Czytelnik i tworzy nową instancję tej klasy. 
        /// W przypadku przechwycenia wyjątku pojawia się komunikat o błędnych danych.
        /// Edycja czytelnika polega na utworzeniu nowego obiektu klasy Czytelnik i usunięciu poprzedniego.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zatwierdz(object sender, EventArgs e)
        {
            if (doEdycji == null)
            {
                try
                {
                    if (cmbPlec.SelectedItem == null)
                    {
                        MessageBox.Show("Podano błędne dane!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    new Czytelnik(txtImie.Text, txtNazwisko.Text, (Plec)cmbPlec.SelectedItem, txtWiek.Text, txtNumerTelefonu.Text, txtEmail.Text);
                    Close();
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
                    new Czytelnik(txtImie.Text, txtNazwisko.Text, (Plec)cmbPlec.SelectedItem, txtWiek.Text, txtNumerTelefonu.Text, txtEmail.Text);
                    Czytelnik.Czytelnicy.Remove(doEdycji);
                    Close();
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
