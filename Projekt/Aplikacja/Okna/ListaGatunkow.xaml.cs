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
    /// Logika interakcji dla klasy ListaGatunkow.xaml
    /// </summary>
    public partial class ListaGatunkow : Window
    {
        TextBox miejsceDocelowe;
        public ListaGatunkow(TextBox miejsceDocelowe)
        {
            InitializeComponent();
            this.miejsceDocelowe = miejsceDocelowe;
            gatunkiLst.ItemsSource = Gatunek.Gatunki;
        }

        private void Zatwierdz(object sender, EventArgs e)
        {
            if(gatunkiLst.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano gatunku!", "Wystąpił problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                miejsceDocelowe.Text = ((Gatunek)gatunkiLst.SelectedItem).Nazwa;
                Close();
            }
        }


        

       

       
    }
}
