using Microsoft.Win32;
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
    /// Interaction logic for Adaugare_Rutiera.xaml
    /// </summary>
    public partial class Adaugare_Rutiera : Window
{

        int RutieraId;
        public Adaugare_Rutiera(Rutiera a)
        {
            InitializeComponent();
            if (a != null)
            {
                RutieraId = a.Id;
                b.Content = "Salveaza modificarile";
                denumire.Text = a.Denumire;
                model.Text = a.Model;
                numar.Text = a.Numar;
                numarlocuri.Text = a.NumarLocuri.ToString();
                imagine.Source = new BitmapImage(new Uri(a.Imagine));
                foreach(ComboBoxItem c in culoare.Items)
                {
                    if (c.Content.ToString() == a.Culoare)
                    {
                        c.IsSelected = true;
                    }
                }
            }
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !"1234567890".Contains(e.Text);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (denumire.Text != "" && model.Text != "" && culoare.SelectedItem != null && numar.Text != "" && numarlocuri.Text != "" && imagine.Source != null)
            {
                Window1 maindb = Owner as Window1;
                if (RutieraId == 0)
                {
                    maindb.db.Rutieras.Add(new Rutiera
                    {
                        Denumire = denumire.Text,
                        Model = model.Text,
                        Culoare = (culoare.SelectedItem as ComboBoxItem).Content.ToString(),
                        Numar = numar.Text,
                        NumarLocuri = Convert.ToInt32(numarlocuri.Text),
                        Imagine = imagine.Source.ToString(),
                    });
                }
                else
                {
                    Rutiera a = maindb.db.Rutieras.Where(t => t.Id == RutieraId).FirstOrDefault();
                    a.Denumire = denumire.Text;
                    a.Model = model.Text;
                    a.Culoare = (culoare.SelectedItem as ComboBoxItem).Content.ToString();
                    a.Numar = numar.Text;
                    a.NumarLocuri = Convert.ToInt32(numarlocuri.Text);
                    a.Imagine = imagine.Source.ToString();
                    maindb.rutiere_datGrid.ItemsSource = null;
                    maindb.rutiere_datGrid.ItemsSource = maindb.db.Rutieras.Local.ToBindingList();
                }
                maindb.db.SaveChanges();
                Close();
            }
            else
            {
                MessageBox.Show("Nu ati introdus toate datele");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog w = new OpenFileDialog();
            w.ShowDialog();
            if (w.FileName != "")
            {
                imagine.Source = new BitmapImage(new Uri(w.FileName));
            }
        }
    }
}
