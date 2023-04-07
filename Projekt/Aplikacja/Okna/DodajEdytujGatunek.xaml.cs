using Projekt;
using System;
using System.Collections.Generic;
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

namespace Aplikacja.Okna
{
    /// <summary>
    /// Logika interakcji dla klasy DodajEdytujGatunek.xaml
    /// </summary>
    public partial class DodajEdytujGatunek : Window
    {
        private Gatunek doEdycji;

        /// <summary>
        /// Konstruktor nieparametyryczny, który otwiera okno odpowiedzialne za dodanie gatunku.
        /// </summary>
        public DodajEdytujGatunek()
        {
            InitializeComponent();

            doEdycji = null;
        }

        /// <summary>
        /// Konstruktor parametryczny, który otwiera okno odpowiedzialne za edycję gatunku.
        /// </summary>
        /// <param name="doEdycji">Gatunek przekazany do edycji</param>
        public DodajEdytujGatunek(Gatunek doEdycji)
        {
            InitializeComponent();
            Title = "Edytuj Gatunek";

            this.doEdycji = doEdycji;
            txtGatunek.Text = doEdycji.Nazwa;
        }

        /// <summary>
        /// Metoda ta pozwala na wyczyszczenie pola z nazwą gatunku po kliknięciu przycisku Wyczysc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wyczysc(object sender, EventArgs e)
        {
            txtGatunek.Text = string.Empty;
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
        /// Metoda ta pozwala na zatwierdzenie dodania/edycji gatunku.
        /// Jeżeli dodajemy gatunek to metoda wywołuje konstruktor klasy Gatunek i tworzy nową instancję tej klasy. 
        /// W przypadku przechwycenia wyjątku pojawia się komunikat o błędnych danych.
        /// Edycja gatunku polega na utworzeniu nowego obiektu klasy Gatunek i usunięciu poprzedniego.
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
                    foreach (Gatunek gatunek in Gatunek.Gatunki)
                    {
                        if (gatunek.Nazwa == txtGatunek.Text)
                        {
                            juzDodany = true;
                        }
                    }
                    if (juzDodany == true)
                        MessageBox.Show("Ten gatunek jest już w bazie!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        new Gatunek(txtGatunek.Text);
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
                    new Gatunek(txtGatunek.Text);
                    Gatunek.Gatunki.Remove(doEdycji);
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

