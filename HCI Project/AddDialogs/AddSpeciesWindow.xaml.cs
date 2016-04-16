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


namespace HCI_Project
{
    /// <summary>
    /// Interaction logic for AddSpeciesWindow.xaml
    /// </summary>
    public partial class SpeciesDialog : Window
    {
        private Reloadable main;
        
        public SpeciesDialog(Reloadable main)
        {
            InitializeComponent();

            this.main = main;

            var dBEnteties = DataBase.Instance().DataEnteties;

            IQueryable<string> tagIds = dBEnteties.Tag.Select(i => i.id);
            bool enabeling = false;
             
            foreach (var id in tagIds)
            {
                enabeling = true;
                listTag.Items.Add(id);
            }

            listTag.IsEnabled = enabeling;

            IQueryable<string> typeNames = dBEnteties.Type.Select(i => i.name);
            
            foreach (var name in typeNames)
            {
                cmbType.Items.Add(name);
            }
        }

        private String image_location = "";
        ///////////Konstruktor za tabelu
        Species spe = null;
        public SpeciesDialog(Species sp, MainWindow main)
        {
            spe = sp;
            InitializeComponent();
            this.main = main;

            Title = "Edit Specie";
            btnAdd.Content = "Save";

            var dBEnteties = DataBase.Instance().DataEnteties;

            //dovukao sam sve tagove u listu
            IQueryable<string> tagIds = dBEnteties.Tag.Select(i => i.id);
            bool enabeling = false;

            foreach (var id in tagIds)
            {
                enabeling = true;
                listTag.Items.Add(id);
            }

            listTag.IsEnabled = enabeling;


            //selektovati u toj listi tagova one vezane za sp
            var selectedTags = dBEnteties.Tag_Species.Where(d => d.sp_id == sp.id).Select(i => i.tag_id);

            foreach (var selected in selectedTags)
            {
                listTag.SelectedItems.Add(selected);
            }

            //konstruisem combobox typova
            IQueryable<string> typeNames = dBEnteties.Type.Select(i => i.name);

            foreach (var name in typeNames)
            {
                cmbType.Items.Add(name);
            }

            cmbType.SelectedItem = sp.Type.name;

            //sad sve ostale atribute..
            txtId.Text = sp.id;
            txtId.IsEnabled = false;
            txtName.Text = sp.name;
            chckIUCN.IsChecked = sp.IUCN == 1 ? true : false;
            chckDanger.IsChecked = sp.dth == 1 ? true : false;
            chckArea.IsChecked = sp.ppa == 1 ? true : false;
            date.Text = sp.dd;
            txtDesc.Text = sp.desc;

            cmbEndangered.SelectedItem = sp.status == null ? -1 : sp.status;///////////hm?
            cmbTourist.SelectedIndex = sp.ts == null ? (int)0 : (int)sp.ts + 1;
            txtRevenue.Text = sp.ar.ToString();

            BitmapImage icon;

            try
            {
                icon = new BitmapImage();
                icon.BeginInit();
                icon.UriSource = new Uri(sp.icon);
                icon.EndInit();
            }
            catch
            {
                icon = new BitmapImage();
                icon.BeginInit();
                icon.UriSource = new Uri(@"\images\pandaLogo.jpg", UriKind.Relative);
                icon.EndInit();
            }

            
            imgSpecies.Source = icon;

            
            //dodaj za sliku!!!!!!
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dB = DataBase.Instance();
            var dBE = dB.DataEnteties;

            if (dBE.Species.Any(sp => sp.id == txtId.Text) && btnAdd.Content.Equals("Add"))
            {
                MessageBox.Show("There is already a specie with that ID! Please, change the ID.","",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            if ((dBE.Species.Any(sp => sp.name == txtName.Text) && (spe == null)) || (dBE.Species.Any(sp => sp.name == txtName.Text) && !(spe.name.Equals(txtName.Text)))) 
            {
                MessageBox.Show("There is already a specie with that NAME! Please, change the NAME.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (btnAdd.Content.Equals("Add"))
            {
                //Stvaranje species sa podacima iz forme
                Species sp = new Species();

                sp.id = txtId.Text;
                sp.name = txtName.Text;
                sp.desc = txtDesc.Text;
                sp.status = cmbEndangered.SelectedIndex;

                sp.IUCN = chckIUCN.IsChecked == true ? 1 : 0;
                sp.dth = chckDanger.IsChecked == true ? 1 : 0;
                sp.ppa = chckArea.IsChecked == true ? 1 : 0;

                if (cmbTourist.SelectedIndex != 0)
                    sp.ts = cmbTourist.SelectedIndex - 1;
                else
                    sp.ts = null;

                if (!txtRevenue.Text.Equals(""))
                {
                    sp.ar = long.Parse(txtRevenue.Text);
                }
                sp.dd = date.Text;

                string selectedType = (string)cmbType.SelectedItem;
                var typeId = dBE.Type.Where(s => s.name == selectedType).Select(type => type.id);

                foreach (var id in typeId)
                {
                    sp.type_id = id;
                }

                if (image_location.Equals(""))
                {
                    var selectedCollectionType = dBE.Type.Where(i => i.id == sp.type_id);
                    foreach (Type t in selectedCollectionType)
                    {
                        sp.icon = t.icon;
                    }
                }
                else
                {
                    sp.icon = image_location;
                }
                //dodavanje specie
                dBE.Species.Add(sp);

                //stvaranje Tag_Species sa podacima iz forme


                foreach (var tag_id in listTag.SelectedItems)
                {
                    Tag_Species t_s = new Tag_Species();
                    t_s.sp_id = sp.id;
                    t_s.tag_id = (string)tag_id;
                    dBE.Tag_Species.Add(t_s);
                }

                dBE.SaveChanges();
                
                /*SpeciesDialog sD = new SpeciesDialog(sp);
                sD.ShowDialog();*/

                Close();
                main.Reload();
            }
            else
            {
                ///dodao vrednosti svim atributima
                var selectedCollection = dBE.Species.Where(i => i.id == txtId.Text);
                foreach (Species sp in selectedCollection)
                {
                    sp.name = txtName.Text;
                    sp.desc = txtDesc.Text;
                    sp.status = cmbEndangered.SelectedIndex;

                    if (!image_location.Equals(""))
                    {
                        sp.icon = image_location;
                    }

                    sp.IUCN = chckIUCN.IsChecked == true ? 1 : 0;
                    sp.dth = chckDanger.IsChecked == true ? 1 : 0;
                    sp.ppa = chckArea.IsChecked == true ? 1 : 0;

                    if (cmbTourist.SelectedIndex != 0)
                        sp.ts = cmbTourist.SelectedIndex - 1;
                    else
                        sp.ts = null;

                    if (!txtRevenue.Text.Equals(""))
                    {
                        sp.ar = long.Parse(txtRevenue.Text);
                    }
                    sp.dd = date.Text;

                    string selectedType = (string)cmbType.SelectedItem;
                    var typeId = dBE.Type.Where(s => s.name == selectedType).Select(type => type.id);

                    foreach (var id in typeId)
                    {
                        sp.type_id = id;
                    }

                    //brisanje svih povezanih tag_speciesa
                    var selectedCollectionTS = dBE.Tag_Species.Where(i => i.sp_id == txtId.Text);
                    foreach (Tag_Species tS in selectedCollectionTS)
                    {
                        dBE.Tag_Species.Remove(tS);
                    }
                    //dodavanje novih
                    foreach (var tag_id in listTag.SelectedItems)
                    {
                        Tag_Species t_s = new Tag_Species();
                        t_s.sp_id = sp.id;
                        t_s.tag_id = (string)tag_id;
                        dBE.Tag_Species.Add(t_s);
                    }
                }

                dBE.SaveChanges();
                Close();

                main.Reload();
            }
            
        }

        private void txtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = txtId.Text;
            str = str.Trim();
            if(Regex.IsMatch(str,"[^a-zA-Z_ -]+")){
                btnAdd.IsEnabled = false;
                lblWarning.Visibility = System.Windows.Visibility.Visible;
                imgIdWarning.ToolTip = "Only letters, ' ', '-' and '_' are allowed!";//dodaj mogucnost razmaka!
                imgIdWarning.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                imgIdWarning.ToolTip = "";
                imgIdWarning.Visibility = System.Windows.Visibility.Hidden;
            }

            if (!txtId.Text.Trim().Equals("") && imgIdWarning.Visibility != System.Windows.Visibility.Visible &&
                !txtName.Text.Trim().Equals("") && imgNameWarning.Visibility != System.Windows.Visibility.Visible
                && imgRevenueWarning.Visibility != System.Windows.Visibility.Visible)//DODAJ USLOV ZA IZABRANI TIP!
            {
                lblWarning.Visibility = System.Windows.Visibility.Hidden;
                btnAdd.IsEnabled = true;
            }
            else
            {
                lblWarning.Visibility = System.Windows.Visibility.Visible;
                btnAdd.IsEnabled = false;
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = txtName.Text;
            str = str.Trim();
            if (Regex.IsMatch(str, "[^a-zA-Z_ -]+"))
            {
                btnAdd.IsEnabled = false;
                lblWarning.Visibility = System.Windows.Visibility.Visible;
                imgNameWarning.ToolTip = "Only letters, ' ', '-' and '_' are allowed!";
                imgNameWarning.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                imgNameWarning.ToolTip = "";
                imgNameWarning.Visibility = System.Windows.Visibility.Hidden;
            }

            if(!txtId.Text.Trim().Equals("") && imgIdWarning.Visibility!=System.Windows.Visibility.Visible &&
                !txtName.Text.Trim().Equals("") && imgNameWarning.Visibility != System.Windows.Visibility.Visible &&
                imgRevenueWarning.Visibility != System.Windows.Visibility.Visible
                && cmbType.SelectedIndex != -1)//DODAJ USLOV ZA IZABRANI TIP!
            {   
                lblWarning.Visibility = System.Windows.Visibility.Hidden;
                btnAdd.IsEnabled = true;
            }
            else
            {
                lblWarning.Visibility = System.Windows.Visibility.Visible;
                btnAdd.IsEnabled = false;
            }
        }

        private void txtRevenue_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = txtRevenue.Text;
            if (Regex.IsMatch(str, "[^0-9-]+"))
            {
                btnAdd.IsEnabled = false;
                imgRevenueWarning.ToolTip = "Only numbers and '-' are allowed!";
                imgRevenueWarning.Visibility = System.Windows.Visibility.Visible;
            }else{
                imgRevenueWarning.ToolTip = "";
                imgRevenueWarning.Visibility = System.Windows.Visibility.Hidden;
            }

            if (!txtId.Text.Trim().Equals("") && imgIdWarning.Visibility != System.Windows.Visibility.Visible &&
                !txtName.Text.Trim().Equals("") && imgNameWarning.Visibility != System.Windows.Visibility.Visible
                && imgRevenueWarning.Visibility != System.Windows.Visibility.Visible
                && cmbType.SelectedIndex != -1)//DODAJ USLOV ZA IZABRANI TIP!
            {
                lblWarning.Visibility = System.Windows.Visibility.Hidden;
                btnAdd.IsEnabled = true;
            }
            else
            {
                lblWarning.Visibility = System.Windows.Visibility.Visible;
                btnAdd.IsEnabled = false;
            }
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!txtId.Text.Trim().Equals("") && imgIdWarning.Visibility != System.Windows.Visibility.Visible &&
               !txtName.Text.Trim().Equals("") && imgNameWarning.Visibility != System.Windows.Visibility.Visible
               && imgRevenueWarning.Visibility != System.Windows.Visibility.Visible
               && cmbType.SelectedIndex != -1)//DODAJ USLOV ZA IZABRANI TIP!
            {
                lblWarning.Visibility = System.Windows.Visibility.Hidden;
                btnAdd.IsEnabled = true;
            }
            else
            {
                lblWarning.Visibility = System.Windows.Visibility.Visible;
                btnAdd.IsEnabled = false;
            }
        }

        private void ChangePicture_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                image_location = dlg.FileName;

                BitmapImage icon = new BitmapImage();
                icon.BeginInit();
                icon.UriSource = new Uri(image_location);
                icon.EndInit();

                imgSpecies.Source = icon;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

    }
}
