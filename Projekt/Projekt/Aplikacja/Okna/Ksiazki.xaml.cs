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
    /// Logika interakcji dla klasy Ksiazki.xaml
    /// </summary>
    public partial class Ksiazki : Window
    {
        public Ksiazki()
        {
            InitializeComponent();
            ksiazkiLst.ItemsSource = Ksiazka.Ksiazki;
        }

        public void Dodaj(object sender, EventArgs e)
        {
            DodajEdytujKsiazke dek = new DodajEdytujKsiazke();
            dek.ShowDialog();
        }

        public void Edytuj(object sender, EventArgs e)
        {
            if(ksiazkiLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano książki!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DodajEdytujKsiazke dek = new DodajEdytujKsiazke((Ksiazka)ksiazkiLst.SelectedItem);
            dek.ShowDialog();
        }
        
        public void Usun(object sender, RoutedEventArgs e)
        {
            if (ksiazkiLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano książki!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Ksiazka doUsuniecia = (Ksiazka)ksiazkiLst.SelectedItem;
            ksiazkiLst.SelectedIndex = ksiazkiLst.SelectedIndex - 1;
            Ksiazka.Ksiazki.Remove(doUsuniecia);
        }
    }
}
