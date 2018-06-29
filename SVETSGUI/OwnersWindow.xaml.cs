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
using Newtonsoft.Json;
using SVETSAPI.Models;
using SVETSDA;
using NLog;

namespace SVETSGUI
{
    /// <summary>
    /// Interaction logic for OwnersWindow.xaml
    /// </summary>
    public partial class OwnersWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Owner owner = new Owner();
        public DA DA = new DA();

        public OwnersWindow()
        {
            InitializeComponent();

            // Owners
            this.DataContext = owner;
        }

        private async void buttonRead_Click(object sender, RoutedEventArgs e)
        {
            dataGridOwners.ItemsSource = JsonConvert.DeserializeObject<List<Owner>>(await DA.GetEntitiesAsync("Owners"));

            dataGridOwners.Columns.RemoveAt(4);
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            DA.DeleteEntityAsync("Owners/" + owner.OwnerId);
        }

        private void dataGridOwners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridOwners.SelectedIndex != -1)
            {
                owner.OwnerId = Convert.ToInt32(((TextBlock)dataGridOwners.Columns[0].GetCellContent(dataGridOwners.SelectedItem)).Text);
                owner.SurName = ((TextBlock)dataGridOwners.Columns[1].GetCellContent(dataGridOwners.SelectedItem)).Text;
                owner.GivenName = ((TextBlock)dataGridOwners.Columns[2].GetCellContent(dataGridOwners.SelectedItem)).Text;
                owner.Phone = ((TextBlock)dataGridOwners.Columns[3].GetCellContent(dataGridOwners.SelectedItem)).Text;

                textBoxOwnerId.Text = Convert.ToString(owner.OwnerId);
                textBoxSurName.Text = owner.SurName;
                textBoxGivenName.Text = owner.GivenName;
                textBoxPhone.Text = owner.Phone;
            }
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            DA.PostEntityAsync("Owners", owner);
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            DA.PutEntityAsync("Owners/" + owner.OwnerId, owner);
        }

        private void textBoxOwnerId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (textBoxOwnerId.Text == "")
                    throw new CustomExceptions.ValidationFailureException("textBoxOwner.Text is null!");
                
                if (!Int32.TryParse(textBoxOwnerId.Text, out int ownerId))
                    throw new CustomExceptions.ValidationFailureException("Non-integer entered in textBoxOwnerId.Text!");
            } catch (CustomExceptions.ValidationFailureException)
            {
                MessageBox.Show("Enter an integer in OwnerId.");
                logger.Debug("OwnersWindow.textBoxOwnerId: CustomExceptions.ValidationFailureException message displayed.");

                textBoxOwnerId.Text = "";
            } catch (Exception ex)
            {
                logger.Fatal($"OwnersWindow.textBoxOwnerId: Unknown error: {ex.Message}");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logger.Trace("OwnersWindow loaded");
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            logger.Trace("OwnersWindow unloaded");
        }

        private void textBoxSurName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (textBoxSurName.Text == "")
                    throw new CustomExceptions.ValidationFailureException("textBoxSurName.Text is null!");
            }
            catch (CustomExceptions.ValidationFailureException)
            {
                MessageBox.Show("Enter text in SurName.");
                logger.Debug("OwnersWindow.textBoxOwnerId: CustomExceptions.ValidationFailureException message displayed.");

                textBoxSurName.Text = "";
            }
            catch (Exception ex)
            {
                logger.Fatal($"OwnersWindow.textBoxSurName: Unknown error: {ex.Message}");
            }
        }

        private void textBoxGivenName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (textBoxGivenName.Text == "")
                    throw new CustomExceptions.ValidationFailureException("textBoxGivenName.Text is null!");
            }
            catch (CustomExceptions.ValidationFailureException)
            {
                MessageBox.Show("Enter text in GivenName.");
                logger.Debug("OwnersWindow.textBoxOwnerId: CustomExceptions.ValidationFailureException message displayed.");
            }
            catch (Exception ex)
            {
                logger.Fatal($"OwnersWindow.textBoxGivenName: Unknown error: {ex.Message}");
            }
        }

        private void textBoxPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (textBoxPhone.Text == "")
                    throw new CustomExceptions.ValidationFailureException("textBoxPhone.Text is null!");
            }
            catch (CustomExceptions.ValidationFailureException)
            {
                MessageBox.Show("Enter text in Phone.");
                logger.Debug("OwnersWindow.textBoxPhone: CustomExceptions.ValidationFailureException message displayed.");
            }
            catch (Exception ex)
            {
                logger.Fatal($"OwnersWindow.textBoxPhone: Unknown error: {ex.Message}");
            }
        }
    }
}
