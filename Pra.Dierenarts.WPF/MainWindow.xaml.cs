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
using Pra.Dierenarts.CORE;

namespace Pra.Dierenarts.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddMammals();
            AddSomeAnimals();
        }
        private void AddMammals()
        {
            cmbSpecies.ItemsSource = AnimalSpecies.Mammals;
        }
        private void AddBirds()
        {
            cmbSpecies.ItemsSource = AnimalSpecies.Birds;
        }
        private void AddSomeAnimals()
        {
            Bird bird = new Bird("Kanarie", "Piet", 0, null, 12, true);
            lstAnimals.Items.Add(bird);
            bird = new Bird("Kip", "Marie", 1, new DateTime(2012, 4, 23), 42, false);
            lstAnimals.Items.Add(bird);
            Mammal mammal = new Mammal("Hond", "mix", "Sam", 0, new DateTime(2001, 01, 01), 51, true);
            lstAnimals.Items.Add(mammal);
            mammal = new Mammal("Hond", "Cocker Spaniel", "Noor", 1, new DateTime(2008, 12, 01), 34, true);
            lstAnimals.Items.Add(mammal);
            mammal = new Mammal("Kat", "tijger", "Monster", 1, new DateTime(2010, 01, 01), 22, false);
            lstAnimals.Items.Add(mammal);
        }
        private void rdbMammal_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbMammal.IsLoaded)
            {
                AddMammals();
                lblBreed.Visibility = Visibility.Visible;
                txtBreed.Visibility = Visibility.Visible;
                lblHeightWidth.Content = "Schofhoogte : ";
                lblSterilizedCanFly.Content = "Gestereliseerd : ";
            }
        }
        private void rdbBird_Checked(object sender, RoutedEventArgs e)
        {
            if (rdbBird.IsLoaded)
            {
                AddBirds();
                lblBreed.Visibility = Visibility.Hidden;
                txtBreed.Visibility = Visibility.Hidden;
                lblHeightWidth.Content = "Spanwijdte : ";
                lblSterilizedCanFly.Content = "Kan vliegen : ";
            }
        }
        private void lstAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Animal animal = (Animal)lstAnimals.SelectedItem;
            tbkSummary.Text = animal.Summary();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSpecies.SelectedIndex < 0)
            {
                MessageBox.Show("Soort selecteren !", "Fout");
                cmbSpecies.Focus();
                return;
            }
            string specie = cmbSpecies.SelectedItem.ToString();

            string breed = "";
            if (rdbMammal.IsChecked == true)
            {
                breed = txtBreed.Text.Trim();
                if (breed.Length == 0)
                {
                    MessageBox.Show("Ras opgeven !", "Fout");
                    txtBreed.Focus();
                    return;
                }
            }

            string name = txtName.Text.Trim();
            if (name.Length == 0)
            {
                MessageBox.Show("Roepnaam opgeven !", "Fout");
                txtName.Focus();
                return;
            }

            DateTime? dateOfBirth = dtpDateOfBirth.SelectedDate;

            byte? gender = null;
            if (rdbGenderMale.IsChecked == true) gender = 0;
            if (rdbGenderFemale.IsChecked == true) gender = 1;

            if (rdbMammal.IsChecked == true)
            {
                int height;
                try
                {
                    height = int.Parse(txtHeightWidth.Text);
                }
                catch
                {
                    MessageBox.Show("Schofhoogte correct invoeren !", "Fout");
                    txtHeightWidth.Focus();
                    return;
                }
                bool? sterilized = null;
                if (rdbSterilizedCanFlyYes.IsChecked == true) sterilized = true;
                if (rdbSterilizedCanFlyNo.IsChecked == true) sterilized = false;

                Mammal mammal = new Mammal(specie, breed, name, gender, dateOfBirth, height, sterilized);
                lstAnimals.Items.Add(mammal);
            }
            else
            {
                int width;
                try
                {
                    width = int.Parse(txtHeightWidth.Text);
                }
                catch
                {
                    MessageBox.Show("Spanwijdte correct invoeren !", "Fout");
                    txtHeightWidth.Focus();
                    return;
                }
                bool? canFly = null;
                if (rdbSterilizedCanFlyYes.IsChecked == true) canFly = true;
                if (rdbSterilizedCanFlyNo.IsChecked == true) canFly = false;

                Bird bird = new Bird(specie, name, gender, dateOfBirth, width, canFly);
                lstAnimals.Items.Add(bird);

            }

        }
    }
}
