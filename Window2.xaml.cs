using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public GaraEntityContext db = new GaraEntityContext();
        int Client_Id;
        public Window2(int ID)
        {
            InitializeComponent();
            Client_Id = ID;
            Loaded += Window2_Loaded;
        }

       public ObservableCollection<RutaAfisare> rute = new ObservableCollection<RutaAfisare>();
       public ObservableCollection<RuteComandate> ruteComandate = new ObservableCollection<RuteComandate>();
       public void LoadBileteComandate()
        {
            ruteComandate.Clear();
            bilete_ListBox.ItemsSource = null;
            List<Clienti_Rute> clientiRute = db.Clienti_Rute.Where(t => t.ClientId == Client_Id).ToList();
            List<Ruta> ruteCom = new List<Ruta>();
            foreach (Clienti_Rute clrut in clientiRute)
            {

                ruteCom.Add(db.Rutas.Where(t => t.Id == clrut.RutaId).FirstOrDefault());
            }
            foreach (Ruta r in ruteCom)
            {
                ruteComandate.Add(new RuteComandate
                {
                    Ora = r.OraPornire,
                    RutieraNumar = db.Rutieras.Where(t => t.Id == r.RutieraId).FirstOrDefault().Numar,
                    Angajat = db.Angajats.Where(t => t.Id == r.AngajatId).FirstOrDefault().Nume + " " + db.Angajats.Where(t => t.Id == r.AngajatId).FirstOrDefault().Prenume,
                    LocStart = db.Localitates.Where(t => t.Id == r.LocStartId).FirstOrDefault().Denumire,
                    LocDestinatie = db.Localitates.Where(t => t.Id == r.LocDestinatieId).FirstOrDefault().Denumire,
                    Pret = r.PretBilet + " Lei",
                    Data = db.Clienti_Rute.Where(t => t.RutaId == r.Id).Select(t => t.Data).FirstOrDefault().ToString("dd/MM/yyyy"),
                });
            }
            bilete_ListBox.ItemsSource = ruteComandate;
        }
        private void Window2_Loaded(object sender, RoutedEventArgs e)
        {
            GaraEntityContext db1 = new GaraEntityContext();
            foreach (Ruta r in db.Rutas)
            {
                int IdR1 = db1.Localitates.Where(t => t.Id == r.LocStartId).FirstOrDefault().RaionId;
                int IdR2 = db1.Localitates.Where(t => t.Id == r.LocDestinatieId).FirstOrDefault().RaionId;
                rute.Add(new RutaAfisare
                {
                    Id = r.Id.ToString(),
                    Imagine = db1.Rutieras.Where(t => t.Id == r.RutieraId).FirstOrDefault().Imagine,
                    Ora = r.OraPornire,
                    Rutiera = db1.Rutieras.Where(t => t.Id == r.RutieraId).FirstOrDefault().Model,
                    RutieraNumar = db1.Rutieras.Where(t => t.Id == r.RutieraId).FirstOrDefault().Numar,
                    RutieraCuloare = db1.Rutieras.Where(t => t.Id == r.RutieraId).FirstOrDefault().Culoare,
                    Angajat = db1.Angajats.Where(t => t.Id == r.AngajatId).FirstOrDefault().Nume + " " + db1.Angajats.Where(t => t.Id == r.AngajatId).FirstOrDefault().Prenume,
                    LocStart = db1.Localitates.Where(t => t.Id == r.LocStartId).FirstOrDefault().Denumire,
                    RaionStart = db1.Raions.Where(t => t.Id == IdR1).FirstOrDefault().Denumire,
                    LocDestinatie = db1.Localitates.Where(t => t.Id == r.LocDestinatieId).FirstOrDefault().Denumire,
                    RaionDestinatie = db1.Raions.Where(t => t.Id == IdR2).FirstOrDefault().Denumire,
                    Pret = r.PretBilet + " Lei",
                });
            }
            rute_ListBox.ItemsSource = rute;
            LoadBileteComandate();
            foreach (Localitate a in db.Localitates)
            {
                ComboBoxItem comboItem = new ComboBoxItem()
                {
                    Name = "Sid" + a.Id,
                    Content = a.Denumire + " " + db1.Raions.Where(t => t.Id == a.RaionId).FirstOrDefault().Denumire,
                };
                ComboBoxItem comboItem1 = new ComboBoxItem()
                {
                    Name = "Did" + a.Id,
                    Content = a.Denumire + " " + db1.Raions.Where(t => t.Id == a.RaionId).FirstOrDefault().Denumire,
                };
                locstart.Items.Add(comboItem);
                locdestinatie.Items.Add(comboItem1);
            }
        }
        bool startReturn(string s1, string s2)
        {
            if (locstart.SelectedItem != null)
            {
                int ID = Convert.ToInt32((locstart.SelectedItem as ComboBoxItem).Name.Replace("Sid", ""));
                Localitate loc = db.Localitates.Where(m => m.Id == ID).FirstOrDefault();
                if (loc != null && loc.Denumire == s1)
                {
                    if (db.Raions.Where(m => m.Id == loc.RaionId && m.Denumire == s2).Count() > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
            {
                return true;
            }
        }
        bool destinatieReturn(string s1, string s2)
        {
            if (locdestinatie.SelectedItem != null)
            {
                int ID = Convert.ToInt32((locdestinatie.SelectedItem as ComboBoxItem).Name.Replace("Did", ""));
                Localitate loc = db.Localitates.Where(m => m.Id == ID).FirstOrDefault();
                if (loc != null && loc.Denumire == s1)
                {
                    if (db.Raions.Where(m => m.Id == loc.RaionId && m.Denumire == s2).Count() > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
            {
                return true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan ora = new TimeSpan(Convert.ToInt32((orapornirii.SelectedItem as ComboBoxItem).Content), Convert.ToInt32((minute.SelectedItem as ComboBoxItem).Content), 0);
            TimeSpan ora1 = new TimeSpan(Convert.ToInt32((orapornirii1.SelectedItem as ComboBoxItem).Content), Convert.ToInt32((minute1.SelectedItem as ComboBoxItem).Content), 0);
            rute_ListBox.ItemsSource = rute.Where(t => t.Ora >= ora && t.Ora <= ora1 && startReturn(t.LocStart, t.RaionStart) && destinatieReturn(t.LocDestinatie, t.RaionDestinatie));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            locdestinatie.SelectedItem = null;
            locstart.SelectedItem = null;
            def1.IsSelected = true;
            def2.IsSelected = true;
            def3.IsSelected = true;
            def4.IsSelected = true;
            rute_ListBox.ItemsSource = rute;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
          
            int RutaId = Convert.ToInt32((((Button)sender).Content as StackPanel).Children.OfType<Label>().FirstOrDefault().Content);
            Title = RutaId.ToString();
          Bilet_Comandare w = new Bilet_Comandare(rute.Where(t=>t.Id == RutaId.ToString()).FirstOrDefault(), Client_Id)
            {
                Owner = this,
            };
            w.ShowDialog();
        }
    }
}
