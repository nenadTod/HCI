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

namespace HCI_Project.AddDialogs
{
    /// <summary>
    /// Interaction logic for TagDialog.xaml
    /// </summary>
    public partial class TagDialog : Window
    {
        public TagDialog()
        {
            InitializeComponent();
        }

        public TagDialog(Reloadable r)
        {
            InitializeComponent();
            re = r;
        }

        Reloadable re;
        Tag ta = null;
        public TagDialog(Tag t,Reloadable r)
        {
            ta = t;
            re = r;
            InitializeComponent();
            Title = "Edit Tag";
            btnAdd.Content = "Save";

            txtId.Text = t.id;
            txtId.IsEnabled = false;
            txtDesc.Text = t.desc;
            clrPicker.SelectedColor = (Color) ColorConverter.ConvertFromString(t.color);
        }

        private void IDTextChanged(object sender, TextChangedEventArgs e)
        {
            string str = txtId.Text.Trim();
            if (Regex.IsMatch(str, "[^a-zA-Z_-]+"))
            {
                btnAdd.IsEnabled = false;
                lblWarning.Visibility = System.Windows.Visibility.Visible;
                imgIdWarning.ToolTip = "Only letters, '-' and '_' are allowed!";
                imgIdWarning.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                imgIdWarning.ToolTip = "";
                imgIdWarning.Visibility = System.Windows.Visibility.Hidden;
            }

            if (!txtId.Text.Trim().Equals("") && imgIdWarning.Visibility != System.Windows.Visibility.Visible)
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

            if (dBE.Tag.Any(t => t.id == txtId.Text) && btnAdd.Content.Equals("Add"))
            {
                MessageBox.Show("There is already a tag with that ID! Please, change the ID.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (btnAdd.Content.Equals("Add"))
            {
                Tag tag = new Tag();

                tag.id = txtId.Text;
                tag.desc = txtDesc.Text;
                tag.color = clrPicker.SelectedColorText;

                dBE.Tag.Add(tag);
                dBE.SaveChanges();

            }
            else
            {
                var selectedCollectionTag = dBE.Tag.Find(txtId.Text);

                selectedCollectionTag.desc = txtDesc.Text;
                selectedCollectionTag.color = clrPicker.SelectedColorText;

                dBE.SaveChanges();
            }


            if (re != null)
                re.Reload();

            Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
