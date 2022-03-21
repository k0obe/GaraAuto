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
    /// Interaction logic for Adaugare_Localitate.xaml
    /// </summary>
    public partial class Adaugare_Localitate : Window
    {
        int LocalitateId;
        int SelectedRaionId;
        public Adaugare_Localitate(Localitate a)
        {
            InitializeComponent();
            if (a != null)
            {
                LocalitateId = a.Id;
                localitate.Text = a.Denumire;
                SelectedRaionId = a.RaionId;
            }
            Loaded += Adaugare_Localitate_Loaded;
        }

        private void Adaugare_Localitate_Loaded(object sender, RoutedEventArgs e)
        {
            Window1 maindb = Owner as Window1;
            foreach (Raion r in maindb.db.Raions) {
                addComboboxItem(r);
            }
        }
        void addComboboxItem(Raion r)
        {
            ComboBoxItem comboItem = new ComboBoxItem();
            Label lab = new Label
            {
                Content = r.Denumire,
            };
            comboItem.Content = lab;
            comboItem.Name = "id" + r.Id;
            if (r.Id == SelectedRaionId) comboItem.IsSelected = true;
            raion.Items.Add(comboItem);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (localitate.Text != "" && raion.SelectedItem != null) 
            {
                Window1 maindb = Owner as Window1;
                if (LocalitateId == 0)
                {
                    maindb.db.Localitates.Add(new Localitate
                    {
                        Denumire = localitate.Text,
                        RaionId = Convert.ToInt32((raion.SelectedItem as ComboBoxItem).Name.Substring(2)),
                    });
                }
                else
                {
                    Localitate a = maindb.db.Localitates.Where(t => t.Id == LocalitateId).FirstOrDefault();
                    a.Denumire = localitate.Text;
                    a.RaionId = Convert.ToInt32((raion.SelectedItem as ComboBoxItem).Name.Substring(2));
                    maindb.localitati_datGrid.ItemsSource = null;
                    maindb.localitati_datGrid.ItemsSource = maindb.db.Localitates.Local.ToBindingList();
                }
                maindb.db.SaveChanges();
                Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 maindb = Owner as Window1;
            if (maindb.db.Raions.Where(t => t.Denumire == raionnou.Text).Count() == 0)
            {
                Raion newRaion = new Raion
                {
                    Denumire = raionnou.Text,
                };
                maindb.db.Raions.Add(newRaion);
                maindb.db.SaveChanges();
                SelectedRaionId = newRaion.Id;
                addComboboxItem(newRaion);
                raionnou.Text = "";
            }
            else
            {
                MessageBox.Show("Deja exista asa raion");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (raion.SelectedItem != null)
            {
                Window1 maindb = Owner as Window1;
                int id = Convert.ToInt32((raion.SelectedItem as ComboBoxItem).Name.Substring(2));
                maindb.db.Raions.Remove(maindb.db.Raions.Where(t => t.Id == id).FirstOrDefault());
                raion.Items.Remove(raion.SelectedItem);
                maindb.db.SaveChanges();
            }
        }
    }
}