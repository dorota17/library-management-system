using Aplikacja.Okna;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Ksiazka.OdczytajXML("plik"); // nazwa pliku + właściwa ścieżka!
            InitializeComponent();
        }

        public void Ksiazki(object sender, EventArgs e)
        {
            Ksiazki ksiazki = new Ksiazki();
            ksiazki.ShowDialog();
        }

        private void Wypozycz(object sender, RoutedEventArgs e)
        {
            Wypozycz wypozycz = new Wypozycz();
            wypozycz.ShowDialog();
        }

        private void Zwrot(object sender, RoutedEventArgs e)
        {
            Zwrot zwrot = new Zwrot();
            zwrot.ShowDialog();
        }
    }
}
