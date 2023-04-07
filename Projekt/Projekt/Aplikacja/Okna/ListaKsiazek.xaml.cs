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
    /// Logika interakcji dla klasy ListaKsiazek.xaml
    /// </summary>
    public partial class ListaKsiazek : Window
    {
        TextBox miejsceDocelowe;

        public ListaKsiazek(TextBox miejsceDocelowe)
        {
            InitializeComponent();  
            this.miejsceDocelowe = miejsceDocelowe;
            ksiazkiLst.ItemsSource = Ksiazka.Ksiazki;
        }

        private void Zatwierdz(object sender, EventArgs e)
        {
            if (ksiazkiLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano książki!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                miejsceDocelowe.Text = ((Ksiazka)ksiazkiLst.SelectedItem).Isbn;
                Close();
            }
        }
    }
}
