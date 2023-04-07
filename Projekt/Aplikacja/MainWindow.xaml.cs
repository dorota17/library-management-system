using Aplikacja.Okna;
using Projekt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace Aplikacja
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Autor.OdczytajAutorowXML();
            Czytelnik.OdczytajCzytelnikowXML();
            Gatunek.OdczytajGatunkiXML();
            Ksiazka.OdczytajKsiazkiXML();
            Wydawnictwo.OdczytajWydawnictwaXML();
            Wypozyczenie.OdczytajWypozyczeniaXML();

            XmlSerializer serializer = new XmlSerializer(typeof(List<int>));
            FileStream fs = new FileStream("id.xml", FileMode.Open);
            List<int> id = (List<int>)serializer.Deserialize(fs);
            fs.Close();
            Czytelnik.NoweId = id[0];
            Autor.NoweId = id[1];

            InitializeComponent();

            czytLiczTxt.Content = Czytelnik.Czytelnicy.Count.ToString();
            ksiazLiczTxt.Content = Ksiazka.Ksiazki.Count.ToString();
            autLiczTxt.Content = Autor.Autorzy.Count.ToString();
        }

        /// <summary>
        /// Metoda otwiera okno Ksiazki z zaktualizowanymi licznikami.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Ksiazki(object sender, EventArgs e)
        {
            Ksiazki ksiazki = new Ksiazki();
            ksiazki.ShowDialog();
            AktualizujLiczniki();
        }

        /// <summary>
        /// Metoda otwiera okno z formularzem "Wypozycz", pozwala użytkownikowi na wypożyczenie książki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wypozycz(object sender, RoutedEventArgs e)
        {
            Wypozycz wypozycz = new Wypozycz();
            wypozycz.ShowDialog();
        }

        /// <summary>
        /// Metoda otwiera okno z formularzem "Zwrot", pozwala użytkownikowi na zwrot książki.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Zwrot(object sender, RoutedEventArgs e)
        {
            Zwrot zwrot = new Zwrot();
            zwrot.ShowDialog();
        }

        /// <summary>
        /// Metoda otwiera okno z formularzem "Gatunki", pozwala użytkownikowi na przeglądanie i edycję gatunków książek.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gatunki(object sender, RoutedEventArgs e)
        {
            Gatunki gatunki = new Gatunki();
            gatunki.ShowDialog();
        }

        /// <summary>
        /// Metoda otwiera okno Czytelnicy z zaktualizowanymi licznikami.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Czytelnicy(object sender, RoutedEventArgs e)
        {
            Czytelnicy czytelnicy = new Czytelnicy();   
            czytelnicy.ShowDialog();
            AktualizujLiczniki();
        }

        /// <summary>
        /// Metoda otwiera okno Autorzy z zaktualizowanymi licznikami.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Autorzy(object sender, RoutedEventArgs e)
        {
            Autorzy autorzy = new Autorzy();
            autorzy.ShowDialog();
            AktualizujLiczniki();
        }

        /// <summary>
        /// Metoda otwiera okno z formularzem "Wydawnictwa", pozwala użytkownikowi na przeglądanie i edycję wydawnictw książek.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Wydawnictwa(object sender, RoutedEventArgs e)
        {
            Wydawnictwa wydawnictwa = new Wydawnictwa();
            wydawnictwa.ShowDialog();
        }

        /// <summary>
        /// Metoda aktualizuje trzy liczniki na podstawie liczby elementów zawartych w trzech kolekcjach.
        /// </summary>
        private void AktualizujLiczniki()
        {
            czytLiczTxt.Content = Czytelnik.Czytelnicy.Count.ToString();
            ksiazLiczTxt.Content = Ksiazka.Ksiazki.Count.ToString();
            autLiczTxt.Content = Autor.Autorzy.Count.ToString();
        }

        private void Zapis(object sender, EventArgs e)
        {
            Autor.ZapiszAutorowXML();
            Czytelnik.ZapiszCzytelnikowXML();
            Gatunek.ZapiszGatunkiXML();
            Ksiazka.ZapiszKsiazkiXML();
            Wydawnictwo.ZapiszWydawnictwaXML();
            Wypozyczenie.ZapiszWypozyczeniaXML();

            List<int> id = new List<int>();
            id.Add(Czytelnik.NoweId);
            id.Add(Autor.NoweId);

            XmlSerializer serializer = new XmlSerializer(typeof(List<int>));
            TextWriter writer = new StreamWriter("id.xml");
            serializer.Serialize(writer, id);
            writer.Close();
        }
    }
}
