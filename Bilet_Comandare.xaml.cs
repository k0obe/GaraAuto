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

namespace GaraAuto
{
    /// <summary>
    /// Interaction logic for Bilet_Comandare.xaml
    /// </summary>
    public partial class Bilet_Comandare : Window
    {
        int IdRuta, IdClient;
        decimal sumaBilet;
        public Bilet_Comandare(RutaAfisare ruta, int i2)
        {
            InitializeComponent();
            IdRuta = Convert.ToInt32(ruta.Id);
            IdClient = i2;
            Window2 maindb = Owner as Window2;
            List<RutaAfisare> rutaafis = new List<RutaAfisare>();
            rutaafis.Add(ruta);
            rutaDisplay.ItemsSource = rutaafis;
            suma.Content = ruta.Pret.Replace(" Lei", "");
            sumaBilet = Convert.ToDecimal(suma.Content);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            nrBilete.Text = (Convert.ToInt32(nrBilete.Text) + 1).ToString();
            suma.Content = (sumaBilet * Convert.ToInt32(nrBilete.Text)).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(nrBilete.Text) > 1)
            {
                nrBilete.Text = (Convert.ToInt32(nrBilete.Text) - 1).ToString();
            }
            suma.Content = (sumaBilet * Convert.ToInt32(nrBilete.Text)).ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dataPreconizarii.SelectedDate != null && Convert.ToInt32(nrBilete.Text) > 0)
            {
                if (MessageBox.Show("Confirmati comandarea a " + nrBilete.Text + " bilet(e) pe data de " + ((DateTime)dataPreconizarii.SelectedDate).ToString("dd/MM/yyyy") + " la suma de  " + suma.Content + " lei", "Comandare bilete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Window2 maindb = Owner as Window2;
                    for (int i = 0; i < Convert.ToInt32(nrBilete.Text); i++)
                    {
                        maindb.db.Clienti_Rute.Add(new Clienti_Rute
                        {
                            Data = dataPreconizarii.DisplayDate,
                            ClientId = this.IdClient,
                            RutaId = IdRuta,
                        });
                    }
                    maindb.db.SaveChanges();
                    maindb.LoadBileteComandate();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Nu ati introdus datele necesare");
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !"1234567890".Contains(e.Text);
        }
    }
}
