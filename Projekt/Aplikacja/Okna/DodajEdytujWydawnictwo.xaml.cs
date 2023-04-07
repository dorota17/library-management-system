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

namespace Aplikacja.Okna
{
    /// <summary>
    /// Logika interakcji dla klasy DodajEdytujWydawnictwo.xaml
    /// </summary>
    public partial class DodajEdytujWydawnictwo : Window
    {
        private Wydawnictwo doEdycji;

        /// <summary>
        /// Konstruktor nieparametyryczny, który otwiera okno odpowiedzialne za dodanie wydawnictwa.
        /// </summary>
        public DodajEdytujWydawnictwo()
        {
            InitializeComponent();
            doEdycji = null;
        }

        /// <summary>
        /// Konstruktor parametryczny, który otwiera okno odpowiedzialne za edycję danych wydaawnictwa.
        /// </summary>
        /// <param name="doEdycji"></param>
        public DodajEdytujWydawnictwo(Wydawnictwo doEdycji)
        {
            InitializeComponent();

            Title = "Edytuj Wydawnictwo";

            this.doEdycji = doEdycji;

            txtNazwa.Text = doEdycji.Nazwa;
            txtUlica.Text = doEdycji.Ulica;
            txtMiasto.Text = doEdycji.Miasto;
            txtKodPocztowy.Text = doEdycji.KodPocztowy;
        }

        /// <summary>
        /// Metoda ta pozwala na usunięcie danych z pól po kliknięciu przycisku Wyczysc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wyczysc(object sender, EventArgs e)
        {
            txtNazwa.Text = string.Empty;
            txtUlica.Text = string.Empty;
            txtMiasto.Text = string.Empty;
            txtKodPocztowy.Text = string.Empty;
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
        /// Metoda ta pozwala na zatwierdzenie dodania/edycji wydawnictwa.
        /// Jeżeli dodajemy wydawnictwo to metoda wywołuje konstruktor klasy Wydawnictwo i tworzy nową instancję tej klasy. 
        /// W przypadku przechwycenia wyjątku pojawia się komunikat o błędnych danych.
        /// Edycja wydawnictwa polega na utworzeniu nowego obiektu klasy Wydawnictwi i usunięciu poprzedniego.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zatwierdz(object sender, EventArgs e)
        {
            bool juzDodany = false;
            if (doEdycji == null)
            {
                try
                {
                    foreach (Wydawnictwo wydawnictwo in Wydawnictwo.Wydawnictwa)
                    {
                        if ((wydawnictwo.Nazwa == txtNazwa.Text) && (wydawnictwo.Ulica == txtUlica.Text) && (wydawnictwo.Miasto == txtMiasto.Text) && (wydawnictwo.KodPocztowy == txtKodPocztowy.Text))
                        {
                            juzDodany = true;
                        }
                    }
                    if (juzDodany == true)
                        MessageBox.Show("To wydawnictwo jest już w bazie!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        new Wydawnictwo(txtNazwa.Text, txtUlica.Text, txtMiasto.Text, txtKodPocztowy.Text);
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
                    new Wydawnictwo(txtNazwa.Text, txtUlica.Text, txtMiasto.Text, txtKodPocztowy.Text); 
                    Wydawnictwo.Wydawnictwa.Remove(doEdycji);
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Podano błędne dane!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
