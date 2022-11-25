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
using System.Text.RegularExpressions;
namespace BankApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            Klient klient1;
        string Pinwartosc = "";
        int liczbyPin=0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

       

        private void ConfirmDane_Click(object sender, RoutedEventArgs e)
        {
            if (Imie.Text=="" || Naziwsko.Text==""|| Nrkonta.Text=="" )
            {
                MessageBox.Show("Podaj wszystkie dane");
            }
            else
            {

            klient1 = new Klient(Imie.Text, Naziwsko.Text, Nrkonta.Text);
                nrkontalabel.Content += Nrkonta.Text;
                Imie.Text = "";
                Naziwsko.Text = "";
                Nrkonta.Text = "";

            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
          
        }

       

        private void PinButton_Click(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as Button;
          
            if (liczbyPin<4)
            {
                Pinwartosc += clickedButton.Content;
                newPin.Text += clickedButton.Content;
                liczbyPin++;
            }
            else
            {
                MessageBox.Show("Zatwierdz pin");
            }
        }

        private void ConfirmPin_Click(object sender, RoutedEventArgs e)
        {
            if (klient1 != null)
            {

            klient1.setPin(Pinwartosc);
            liczbyPin = 0;
            Pinwartosc = "";
            newPin.Text = null;
            }
            else
            {
                MessageBox.Show("Najpierw stowrz konto");
            }
        }

        private void Wplata_Click(object sender, RoutedEventArgs e)
        {
            if (Kasa.Text!=null)
            {
                int pieniadze = Int32.Parse(Kasa.Text);
                klient1.setStanKonta(klient1.getStanKonta() + pieniadze);
                    stankontalabel.Content=klient1.getStanKonta().ToString();

                Kasa.Text = null;

            }
        }

        private void Wyplata_Click(object sender, RoutedEventArgs e)
        {
            if (Kasa.Text != null)
            {
                int pieniadze = Int32.Parse(Kasa.Text)*-1;
                if (klient1.getStanKonta() - pieniadze>=0)
                {

                klient1.setStanKonta(pieniadze);
                    stankontalabel.Content=klient1.getStanKonta().ToString();
                }
                else
                {
                    MessageBox.Show("Nie mozna tyle wyciagnac");
                    Kasa.Text = null;
                }
            }
        }
    }
}
