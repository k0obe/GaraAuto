using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace GaraAuto
{
    /// <summary>
    /// Interaction logic for Adaugare_Ruta.xaml
    /// </summary>
    public partial class Adaugare_Ruta : Window
    {

        int RutaId;
        int SelectedAngajat, SelectedRutiera, SelectedLocStart, SelectedLocDestinatie;
        public Adaugare_Ruta(Ruta a)
        {
            InitializeComponent();
            if (a != null)
            {
                RutaId = a.Id;
                b.Content = "Salveaza modificarile";
                SelectedAngajat = a.AngajatId;
                SelectedRutiera = a.RutieraId;
                SelectedLocStart = a.LocStartId;
                SelectedLocDestinatie = a.LocDestinatieId;
                pretbilet.Text = a.PretBilet.ToString();
                int ore = a.OraPornire.Hours;
                int min = a.OraPornire.Minutes;
                foreach(ComboBoxItem c in orapornirii.Items)
                {
                    if (Convert.ToInt32(c.Content) == ore) c.IsSelected = true;
                }
                foreach (ComboBoxItem c in minute.Items)
                {
                    if (Convert.ToInt32(c.Content) == min) c.IsSelected = true;
                }
            }
            Loaded += Adaugare_Ruta_Loaded;
        }

        private void Adaugare_Ruta_Loaded(object sender, RoutedEventArgs e)
        {
            GaraEntityContext db = new GaraEntityContext();
            Window1 maindb = Owner as Window1;
            foreach (Angajat a in maindb.db.Angajats)
            {
                ComboBoxItem comboItem = new ComboBoxItem()
                {
                    Name = "Aid" + a.Id,
                    Content = a.Nume + " " + a.Prenume,
                };
                if (SelectedAngajat == a.Id) comboItem.IsSelected = true;
                angajat.Items.Add(comboItem);
            }
            foreach (Rutiera a in maindb.db.Rutieras)
            {
                ComboBoxItem comboItem = new ComboBoxItem()
                {
                    Name = "Rid" + a.Id,
                    Content = a.Denumire + " " + a.Numar,
                };
                if (SelectedRutiera == a.Id) comboItem.IsSelected = true;
                rutiera.Items.Add(comboItem);
            }
            foreach (Localitate a in maindb.db.Localitates)
            {
                ComboBoxItem comboItem = new ComboBoxItem()
                {
                    Name = "Sid" + a.Id,
                    Content = a.Denumire + " " + db.Raions.Where(t => t.Id == a.RaionId).FirstOrDefault().Denumire,
                };
                ComboBoxItem comboItem1 = new ComboBoxItem()
                {
                    Name = "Did" + a.Id,
                    Content = a.Denumire + " " + db.Raions.Where(t => t.Id == a.RaionId).FirstOrDefault().Denumire,
                };
                if (SelectedLocStart == a.Id) comboItem.IsSelected = true;
                if (SelectedLocDestinatie == a.Id) comboItem1.IsSelected = true;
                locstart.Items.Add(comboItem);
                locdestinatie.Items.Add(comboItem1);
            }
            db.Dispose();
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !"1234567890.".Contains(e.Text);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pretbilet.Text[pretbilet.Text.Length - 1] == '.') pretbilet.Text = pretbilet.Text.Substring(0, pretbilet.Text.Length - 1);
            if (angajat.SelectedItem != null && rutiera.SelectedItem != null && locdestinatie.SelectedItem != null && locstart.SelectedItem != null && pretbilet.Text != "" && orapornirii.SelectedItem != null && minute.SelectedItem != null)  
            {
                TimeSpan ora = new TimeSpan(Convert.ToInt32((orapornirii.SelectedItem as ComboBoxItem).Content), Convert.ToInt32((minute.SelectedItem as ComboBoxItem).Content), 0); 
                Window1 maindb = Owner as Window1;
                string s1 = (angajat.SelectedItem as ComboBoxItem).Name;
                string s2 = (rutiera.SelectedItem as ComboBoxItem).Name;
                string s3 = (locstart.SelectedItem as ComboBoxItem).Name;
                string s4 = (locdestinatie.SelectedItem as ComboBoxItem).Name;
                if (RutaId == 0)
                {
                    maindb.db.Rutas.Add(new Ruta
                    {
                        AngajatId = Convert.ToInt32(s1.Substring(3, s1.Length - 3)),
                        RutieraId = Convert.ToInt32(s2.Substring(3, s2.Length - 3)),
                        LocStartId = Convert.ToInt32(s3.Substring(3, s3.Length - 3)),
                        LocDestinatieId = Convert.ToInt32(s4.Substring(3, s4.Length - 3)),
                        OraPornire = ora,
                        PretBilet = Convert.ToDecimal(pretbilet.Text)
                    });
                }
                else
                {
                    Ruta a = maindb.db.Rutas.Where(t => t.Id == RutaId).FirstOrDefault();
                    a.AngajatId = Convert.ToInt32(s1.Substring(3, s1.Length - 3));
                    a.RutieraId = Convert.ToInt32(s2.Substring(3, s2.Length - 3));
                    a.LocStartId = Convert.ToInt32(s3.Substring(3, s3.Length - 3));
                    a.LocDestinatieId = Convert.ToInt32(s4.Substring(3, s4.Length - 3));
                    a.OraPornire = ora;
                    a.PretBilet = Convert.ToDecimal(pretbilet.Text);
                    maindb.rute_datGrid.ItemsSource = null;
                    maindb.rute_datGrid.ItemsSource = maindb.db.Rutas.Local.ToBindingList();
                }
                maindb.db.SaveChanges();
                Close();
            }
            else
            {
                MessageBox.Show("Nu ati introdus toate datele");
            }
        }
    }
}
