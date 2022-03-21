using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace GaraAuto
{
    /// <summary>
    /// Interaction logic for Adaugare_Client.xaml
    /// </summary>

    public partial class Adaugare_Client : Window
    {
        GaraEntityContext db = new GaraEntityContext();
        int ClientId;
        string Login;
        public Adaugare_Client(Client a)
        {
            InitializeComponent();
            if (a != null)
            {
                ClientId = a.Id;
                Login = a.Login;
                nume.Text = a.Nume + " " + a.Prenume;
                data.SelectedDate = a.DataNasterii;
                if (a.Gen == "Masculin") genm.IsChecked = true;
                if (a.Gen == "Feminin") genf.IsChecked = true;
                email.Text = a.Email;
                telefon.Text = a.NrTelefon;
                adresa.Text = a.Adresa;
                login.Text = a.Login;
                parola.Password = a.Parola;
                b.Content = "Salveaza modificarile";
            }
            Closing += Adaugare_Client_Closing;
        }

        private void Adaugare_Client_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !"+1234567890".Contains(e.Text);
        }
        private bool validare()
        {
            if ((nume.Text != "" && !new Regex("^[A-Z]{1}[a-z]+([\\s][A-z]{1}[a-z]+)+$").IsMatch(nume.Text)) || nume.Text == "")
            {
                MessageBox.Show("Format incorect nume/prenume");
            }
            else if (telefon.Text != "" && !new Regex("^\\+373[0-9]{8}$").IsMatch(telefon.Text))
            {
                MessageBox.Show("Format incorect numar de telefon, formatul corect (+37300000000)");
            }
            else if (email.Text != "" && !new Regex("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$").IsMatch(email.Text))
            {
                MessageBox.Show("Format incorect adresa e-mail, formatul corect (example@example.com)");
            }
            else if (adresa.Text == "")
            {
                MessageBox.Show("Nu ati completat campul adresa");
            }
            else if (login.Text == "")
            {
                MessageBox.Show("Nu ati completat campul login");
            }
            else if (login.Text.Length < 6)
            {
                MessageBox.Show("Login-ul nu poate fi mai scurt decat 6 caractere");
            }
            else if ((db.Angajats.Where(t => t.Login == login.Text).FirstOrDefault() != null || db.Clients.Where(t => t.Login == login.Text).FirstOrDefault() != null) && login.Text != Login)
            {
                MessageBox.Show("Login ocupat");
            }
            else if (parola.Password == "")
            {
                MessageBox.Show("Nu ati completat campul parola");
            }
            else if (parola.Password.Length < 6)
            {
                MessageBox.Show("Parola nu poate fi mai scurta decat 6 caractere");
            }
            else if (data.SelectedDate == null)
            {
                MessageBox.Show("Nu ati completat campul data");
            }
            else
            {
                return true;
            }
            return false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (validare())
            {
                string genSelectat = "Neindicat";
                if (genm.IsChecked == true) genSelectat = "Masculin";
                if (genf.IsChecked == true) genSelectat = "Feminin";
                string numeU = "", prenumeU = "";
                for (int i = 0; i < nume.Text.Length; i++)
                {
                    if (i == nume.Text.IndexOf(" ")) continue;
                    else if (i < nume.Text.IndexOf(" ")) numeU += nume.Text[i];
                    else prenumeU += nume.Text[i];
                }
                if (ClientId == 0)
                {
                    Client ClientNou = new Client
                    {
                        Nume = numeU,
                        Prenume = prenumeU,
                        DataNasterii = data.SelectedDate,
                        Gen = genSelectat,
                        Email = email.Text,
                        NrTelefon = telefon.Text,
                        Adresa = adresa.Text,
                        Login = login.Text,
                        Parola = parola.Password,
                    };
                    if (Owner is Window1 maindb)
                    {
                        maindb.db.Clients.Add(ClientNou);
                        maindb.db.SaveChanges();
                    }
                    else
                    {
                       db.Clients.Add(ClientNou);
                       db.SaveChanges();
                    }
                }
                else
                {
                    Window1 maindb = Owner as Window1;
                    Client a = maindb.db.Clients.Where(t => t.Id == ClientId).FirstOrDefault();
                    a.Nume = numeU;
                    a.Prenume = prenumeU;
                    a.DataNasterii = data.SelectedDate;
                    a.Gen = genSelectat;
                    a.Email = email.Text;
                    a.NrTelefon = telefon.Text;
                    a.Adresa = adresa.Text;
                    a.Login = login.Text;
                    a.Parola = parola.Password;
                    maindb.clienti_datGrid.ItemsSource = null;
                    maindb.clienti_datGrid.ItemsSource = maindb.db.Clients.Local.ToBindingList();
                    maindb.db.SaveChanges();
                }
                Close();
            }
        }
    }
}
