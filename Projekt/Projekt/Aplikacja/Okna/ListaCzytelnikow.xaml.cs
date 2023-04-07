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
    /// Logika interakcji dla klasy ListaCzytelnikow.xaml
    /// </summary>
    public partial class ListaCzytelnikow : Window
    {
        TextBox miejsceDocelowe;

        public ListaCzytelnikow(TextBox miejsceDocelowe)
        {
            InitializeComponent();
            this.miejsceDocelowe = miejsceDocelowe;
            new Czytelnik("imie", "nazwisko", Plec.K, 10, "123-123-123", "email");
            czytelnicyLst.ItemsSource = Czytelnik.Czytelnicy;
        }

        private void Zatwierdz(object sender, RoutedEventArgs e)
        {
            if (czytelnicyLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano czytelnika!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                miejsceDocelowe.Text = ((Czytelnik)czytelnicyLst.SelectedItem).Id.ToString();
                Close();
            }
        }
    }
}
