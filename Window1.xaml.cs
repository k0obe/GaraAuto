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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public GaraEntityContext db = new GaraEntityContext();
        public Window1()
        {
            InitializeComponent();
            db.Angajats.Load();
            db.Clients.Load();
            db.Localitates.Load();
            db.Raions.Load();
            db.Rutieras.Load();
            db.Rutas.Load();
            angajat_datGrid.ItemsSource = db.Angajats.Local.ToBindingList();
            localitati_datGrid.ItemsSource = db.Localitates.Local.ToBindingList();
            clienti_datGrid.ItemsSource = db.Clients.Local.ToBindingList();
            rutiere_datGrid.ItemsSource = db.Rutieras.Local.ToBindingList();
            rute_datGrid.ItemsSource = db.Rutas.Local.ToBindingList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.Dispose();
            Close();
        }

        private void Adaugare_ButtonClick(object sender, RoutedEventArgs e)
        {
            Adaugare_Angajat w = new Adaugare_Angajat(null)
            {
                Owner = this,
            };
            w.ShowDialog();
            
        }

        private void Editare_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (angajat_datGrid.SelectedItems.Count > 0)
            {
                if (angajat_datGrid.SelectedItem is Angajat a)
                {
                    Adaugare_Angajat w = new Adaugare_Angajat(a)
                    {
                        Owner = this,
                    };
                    w.ShowDialog();
                    
                }
            }
        }
        private void Stergere_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (angajat_datGrid.SelectedItems.Count > 0)
            {
                if (angajat_datGrid.SelectedItem is Angajat a)
                {
                    db.Angajats.Remove(a);
                    db.SaveChanges();
                }
            }
        }
        private void Adaugare_Localitate_ButtonClick(object sender, RoutedEventArgs e)
        {
            Adaugare_Localitate w = new Adaugare_Localitate(null)
            {
                Owner = this,
            };
            w.ShowDialog();
            
        }

        private void Editare_Localitate_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (localitati_datGrid.SelectedItems.Count > 0)
            {
                if (localitati_datGrid.SelectedItems[0] is Localitate a)
                {
                    Adaugare_Localitate w = new Adaugare_Localitate(a)
                    {
                        Owner = this,
                    };
                    w.ShowDialog();
                    
                }
            }
        }
        private void Stergere_Localitate_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (localitati_datGrid.SelectedItems.Count > 0)
            {
                if (localitati_datGrid.SelectedItems[0] is Localitate a)
                {
                    db.Localitates.Remove(a);
                    db.SaveChanges();
                }
            }
        }
        private void Adaugare_Client_ButtonClick(object sender, RoutedEventArgs e)
        {
            Adaugare_Client w = new Adaugare_Client(null)
            {
                Owner = this,
            };
            w.ShowDialog();
            
        }
        private void Editare_Client_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (clienti_datGrid.SelectedItems.Count > 0)
            {
                if (clienti_datGrid.SelectedItem is Client a)
                {
                    Adaugare_Client w = new Adaugare_Client(a)
                    {
                        Owner = this,
                    };
                    w.ShowDialog();
                    
                }
            }
        }
        private void Adaugare_Rutiera_ButtonClick(object sender, RoutedEventArgs e)
        {
            Adaugare_Rutiera w = new Adaugare_Rutiera(null)
            {
                Owner = this,
            };
            w.ShowDialog();
         
            
        }
        private void Editare_Rutiera_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (rutiere_datGrid.SelectedItems.Count > 0)
            {
                if (rutiere_datGrid.SelectedItem is Rutiera a)
                {
                    Adaugare_Rutiera w = new Adaugare_Rutiera(a)
                    {
                        Owner = this,
                    };
                    w.ShowDialog();
                    
                }
            }
        }
        private void Adaugare_Ruta_ButtonClick(object sender, RoutedEventArgs e)
        {
            Adaugare_Ruta w = new Adaugare_Ruta(null)
            {
                Owner = this,
            };
            w.ShowDialog();

        }
        private void Editare_Ruta_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (rute_datGrid.SelectedItems.Count > 0)
            {
                if (rute_datGrid.SelectedItem is Ruta a)
                {
                    Adaugare_Ruta w = new Adaugare_Ruta(a)
                    {
                        Owner = this,
                    };
                    w.ShowDialog();
                    
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            angaj.IsSelected = true;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            client.IsSelected = true;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            rutier.IsSelected = true;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            rut.IsSelected = true;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            local.IsSelected = true;
        }

        private void Stergere_Client_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (clienti_datGrid.SelectedItems.Count > 0)
            {
                if (clienti_datGrid.SelectedItem is Client a)
                {
                    db.Clients.Remove(a);
                    db.SaveChanges();
                }
            }
        }

        private void Stergere_Rutiera_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (rutiere_datGrid.SelectedItems.Count > 0)
            {
                if (rutiere_datGrid.SelectedItem is Rutiera a)
                {
                    db.Rutieras.Remove(a);
                    db.SaveChanges();
                }
            }
        }

        private void Stergere_Ruta_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (rute_datGrid.SelectedItems.Count > 0)
            {
                if (rute_datGrid.SelectedItem is Ruta a)
                {
                    db.Rutas.Remove(a);
                    db.SaveChanges();
                }
            }
        }
    }
}
