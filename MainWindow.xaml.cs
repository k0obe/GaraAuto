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

namespace GaraAuto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GaraEntityContext db = new GaraEntityContext();
            int nrAngajati = db.Angajats.Where(t => t.Login == login.Text && t.Parola == password.Password).Count();
            int nrClienti = db.Clients.Where(t => t.Login == login.Text && t.Parola == password.Password).Count();
            int IDClient = db.Clients.Where(t => t.Login == login.Text && t.Parola == password.Password).Select(t => t.Id).FirstOrDefault();
            if (nrAngajati > 0)
            {

                Window1 w = new Window1();
                password.Password = "";
                login.Text = "";
                w.Show();
                this.Hide();
                w.Closed += W_Closed;
            }
            else if (nrClienti > 0)
            {
                Window2 w = new Window2(IDClient);
                password.Password = "";
                login.Text = "";
                w.Show();
                this.Hide();
                w.Closed += W_Closed;
            }
            else
            {
                MessageBox.Show("Login sau parola incorecte");
                password.Password = "";
            }
        }

        private void W_Closed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Adaugare_Client w = new Adaugare_Client(null)
            {
                Owner = this,
            };
            w.ShowDialog();
        }
    }
}
