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
    /// Interaction logic for Adaugare_Angajat.xaml
    /// </summary>
    public partial class Adaugare_Angajat : Window
    {

        int AngajatId;
        string Login;
        public Adaugare_Angajat(Angajat a)
        {
            InitializeComponent();
            if (a != null)
            {
                AngajatId = a.Id;
                Login = a.Login;
                nume.Text = a.Nume + " " + a.Prenume;
                idnp.Text = a.IDNP;
                data.SelectedDate = a.DataNasterii;
                if (a.Gen == "Masculin") genm.IsChecked = true;
                if (a.Gen == "Feminin") genf.IsChecked = true;
                email.Text = a.Email;
                telefon.Text = a.NrTelefon;
                adresa.Text = a.Adresa;
                functia.SelectedIndex = a.Functia;
                salariu.Text = a.Salariu.ToString();
                login.Text = a.Login;
                parola.Password = a.Parola;
                b.Content = "Salveaza modificarile";
            }
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !"1+234567890".Contains(e.Text);
        }
        private bool validare()
        {
            Window1 maindb = Owner as Window1;
            if ((nume.Text != "" && !new Regex("^[A-Z]{1}[a-z]+([\\s][A-z]{1}[a-z]+)+$").IsMatch(nume.Text)) || nume.Text == "")
            {
                MessageBox.Show("Format incorect nume/prenume");
            }
            else if (telefon.Text != "" && !new Regex("^\\+373[0-9]{8}$").IsMatch(telefon.Text))
            {
                MessageBox.Show("Format incorect numar de telefon, formatul corect (+37300000000)");
            }
            else if (idnp.Text != "" && !new Regex("^[0-9]{13}$").IsMatch(idnp.Text))
            {
                MessageBox.Show("Format incorect IDNP, formatul corect (0000000000000), 13 cifre");
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
            else if ((maindb.db.Angajats.Where(t => t.Login == login.Text).FirstOrDefault() != null || maindb.db.Clients.Where(t => t.Login == login.Text).FirstOrDefault() != null) && login.Text != Login)
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
            else if (functia.SelectedItem == null)
            {
                MessageBox.Show("Nu ati completat campul functia");
            }
            else if (salariu.Text != "" && !new Regex("^[1-9]*[0-9]+(\\.[0-9]{1,2})?$").IsMatch(salariu.Text))
            {
                MessageBox.Show("Format incorect salariu");
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
                Window1 maindb = Owner as Window1;
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
                if (AngajatId == 0)
                {
                    maindb.db.Angajats.Add(new Angajat
                    {
                        Nume = numeU,
                        Prenume = prenumeU,
                        IDNP = idnp.Text,
                        DataNasterii = data.SelectedDate,
                        Gen = genSelectat,
                        Email = email.Text,
                        NrTelefon = telefon.Text,
                        Adresa = adresa.Text,
                        Functia = functia.SelectedIndex,
                        Salariu = Convert.ToDecimal(salariu.Text),
                        Login = login.Text,
                        Parola = parola.Password,
                    });
                }
                else
                {
                    Angajat a = maindb.db.Angajats.Where(t => t.Id == AngajatId).FirstOrDefault();
                    a.Nume = numeU;
                    a.Prenume = prenumeU;
                    a.IDNP = idnp.Text;
                    a.DataNasterii = data.SelectedDate;
                    a.Gen = genSelectat;
                    a.Email = email.Text;
                    a.NrTelefon = telefon.Text;
                    a.Adresa = adresa.Text;
                    a.Functia = functia.SelectedIndex;
                    a.Salariu = (decimal)Convert.ToDecimal(salariu.Text);
                    a.Login = login.Text;
                    a.Parola = parola.Password;
                    maindb.angajat_datGrid.ItemsSource = null;
                    maindb.angajat_datGrid.ItemsSource = maindb.db.Angajats.Local.ToBindingList();
                }
                maindb.db.SaveChanges();
                Close();
            }
        }
    }
}
