using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddTypeWindow.xaml
    /// </summary>
    public partial class TypeWindow : Window
    {
        public TypeWindow()
        {
            InitializeComponent();
        }
        
        public TypeWindow(Reloadable r)
        {
            InitializeComponent();
            re = r;
        }

        private String image_location = "";

        Type typ = null;
        Reloadable re;
        public TypeWindow(Type ty, Reloadable r)
        {
            typ = ty;
            re = r;
            InitializeComponent();
            Title = "Edit Type";
            btnAdd.Content = "Save";

            /////dodaj za sliku!!!
            txtId.Text = ty.id;
            txtId.IsEnabled = false;
            txtName.Text = ty.name;
            txtDesc.Text = ty.desc;
            image_location = ty.icon;

            if (!ty.icon.Equals(""))
            {
                BitmapImage icon = new BitmapImage();
                icon.BeginInit();
                icon.UriSource = new Uri(ty.icon);
                icon.EndInit();

                imgType.Source = icon;

                imgImgWarning.Visibility = System.Windows.Visibility.Hidden;
            }

            lblWarning.Content = "Fields containing * must be filled correctly.";
            lblWarning.Visibility = System.Windows.Visibility.Hidden;
            lblId.Content = "Id";
        }

        private void DescTextChanged(object sender, TextChangedEventArgs e)
        {

            if (typ != null && !txtName.Equals(""))
            {
                btnAdd.IsEnabled = true;
            }

        }

        private void IDTextChanged(object sender, TextChangedEventArgs e)
        {

            string str = txtId.Text.Trim();
            if (Regex.IsMatch(str, "[^a-zA-Z_ -]+"))
            {
                btnAdd.IsEnabled = false;
                lblWarning.Visibility = System.Windows.Visibility.Visible;
                imgIdWarning.ToolTip = "Only letters, ' ', '-' and '_' are allowed!";
                imgIdWarning.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                imgIdWarning.ToolTip = "";
                imgIdWarning.Visibility = System.Windows.Visibility.Hidden;
            }

            if (!txtId.Text.Trim().Equals("") && imgIdWarning.Visibility != System.Windows.Visibility.Visible &&
                !txtName.Text.Trim().Equals("") && imgNameWarning.Visibility != System.Windows.Visibility.Visible
                && imgImgWarning.Visibility != System.Windows.Visibility.Visible)//DODAJ USLOV ZA SLIKU!
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

        private void NameTextChanged(object sender, TextChangedEventArgs e)
        {
            string str = txtName.Text.Trim();
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

            if (!txtId.Text.Trim().Equals("") && imgIdWarning.Visibility != System.Windows.Visibility.Visible &&
                !txtName.Text.Trim().Equals("") && imgNameWarning.Visibility != System.Windows.Visibility.Visible
                && imgImgWarning.Visibility != System.Windows.Visibility.Visible)//DODAJ USLOV ZA SLIKU!
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

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            var dB = DataBase.Instance();
            var dBE = dB.DataEnteties;

            if (dBE.Type.Any(t => t.id == txtId.Text) && btnAdd.Content.Equals("Add"))
            {
                MessageBox.Show("There is already a type with that ID! Please, change the ID.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if ((dBE.Type.Any(t => t.name == txtName.Text) && (typ == null)) || (dBE.Type.Any(t => t.name == txtName.Text) && !(typ.name.Equals(txtName.Text))))
            {
                MessageBox.Show("There is already a type with that NAME! Please, change the NAME.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (btnAdd.Content.Equals("Add"))
            {
                
                Type type = new Type();

                type.id = txtId.Text;
                type.name = txtName.Text;
                type.icon = image_location;////dodat za sliku....
                type.desc = txtDesc.Text;

                dBE.Type.Add(type);
                dBE.SaveChanges();
            }
            else
            {

                var selectedCollection = dBE.Type.Find(txtId.Text);

                selectedCollection.name = txtName.Text;
                selectedCollection.desc = txtDesc.Text;
                selectedCollection.icon = image_location;
                dBE.SaveChanges();

            }
            
            if(re!=null)
                re.Reload();
            
            Close();
        }

        private void AddPictureButtonClick(object sender, RoutedEventArgs e)
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

                imgType.Source = icon;

                imgImgWarning.Visibility = System.Windows.Visibility.Hidden;
            }

            if (!txtId.Text.Equals("") && imgIdWarning.Visibility != System.Windows.Visibility.Visible &&
                !txtName.Text.Equals("") && imgNameWarning.Visibility != System.Windows.Visibility.Visible
                && imgImgWarning.Visibility != System.Windows.Visibility.Visible)//DODAJ USLOV ZA SLIKU!
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

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
