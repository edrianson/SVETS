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

namespace SVETSGUI
{
    /// <summary>
    /// Interaction logic for ProceduresWindow.xaml
    /// </summary>
    public partial class ProceduresWindow : Window
    {
        public DA DA = new DA();

        public ProceduresWindow()
        {
            InitializeComponent();
        }

        private async void dataGridProcedures_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridProcedures.ItemsSource = JsonConvert.DeserializeObject<List<Procedure>>(await DA.GetEntitiesAsync("Procedures"));

            dataGridProcedures.Columns.RemoveAt(3);
        }

        private async void dataGridProcedures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string procedureId = ((TextBlock)dataGridProcedures.Columns[0].GetCellContent(dataGridProcedures.SelectedItem)).Text;

            textBoxTreatments.Text = await DA.GetEntitiesAsync("Procedures/" + procedureId);
        }
    }
}
