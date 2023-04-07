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
    /// Logika interakcji dla klasy DodajEdytujAutora.xaml
    /// </summary>
    public partial class DodajEdytujAutora : Window
    {

        private Autor doEdycji;

        /// <summary>
        /// Konstruktor nieparametyryczny, który otwiera okno odpowiedzialne za dodanie autora.
        /// </summary>
        public DodajEdytujAutora()
        {
            InitializeComponent();
            doEdycji = null;
            cmbPlec.ItemsSource = Enum.GetValues(typeof(Plec)).Cast<Plec>();
            cmbPlec.SelectedItem = null;
        }

        /// <summary>
        /// Konstruktor parametryczny, który otwiera okno odpowiedzialne za edycję danych autora.
        /// </summary>
        /// <param name="doEdycji">Autor przekazany do edycji</param>
        public DodajEdytujAutora(Autor doEdycji)
        {
            InitializeComponent();

            Title = "Edytuj Autora";

            this.doEdycji = doEdycji;
            cmbPlec.ItemsSource = Enum.GetValues(typeof(Plec)).Cast<Plec>();
           
            txtImie.Text = doEdycji.Imie;
            txtNazwisko.Text = doEdycji.Nazwisko;
            foreach (Plec plec in cmbPlec.Items)
                if (plec == doEdycji.Plec)
                    cmbPlec.SelectedItem = plec;
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
            cmbPlec.SelectedItem = null;
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
        /// Metoda ta pozwala na zatwierdzenie dodania/edycji autora.
        /// Jeżeli dodajemy autora to metoda wywołuje konstruktor klasy Autor i tworzy nową instancję tej klasy. 
        /// W przypadku przechwycenia wyjątku pojawia się komunikat o błędnych danych.
        /// Edycja autora polega na utworzeniu nowego obiektu klasy Autor i usunięciu poprzedniego.
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
                        MessageBox.Show("Podano błędne dane!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                    new Autor(txtImie.Text, txtNazwisko.Text, (Plec)cmbPlec.SelectedItem);
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
                    new Autor(txtImie.Text, txtNazwisko.Text, (Plec)cmbPlec.SelectedItem);
                    Autor.Autorzy.Remove(doEdycji);
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
