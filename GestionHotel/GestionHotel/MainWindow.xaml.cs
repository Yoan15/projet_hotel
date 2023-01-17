using GestionHotel.Controllers;
using GestionHotel.Data;
using GestionHotel.Data.Dtos;
using GestionHotel.Views;
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

namespace GestionHotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HotelContext _context;
        ChambresController _controller;

        public MainWindow()
        {
            InitializeComponent();
            _context = new HotelContext();
            _controller = new ChambresController(_context);
            remplirDataGrid();
        }

        public void remplirDataGrid()
        {
            dataGridTest.ItemsSource = _controller.GetAllChambresAvecDetail();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mode = ((Button)sender).Content.ToString();
            this.Opacity = 0.7;
            TypesChambreDTO tc = (TypesChambreDTO)dataGridTest.SelectedItem;
            if (mode == "Ajouter") tc = new TypesChambreDTO();

            Window formTest = new FormulaireTest(mode, tc, _context);
            formTest.ShowDialog();
            this.Opacity = 1;
            remplirDataGrid();
        }

    }
}
