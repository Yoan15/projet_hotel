using GestionHotel.Controllers;
using GestionHotel.Data;
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
        EtagesController _etagesController;

        public MainWindow()
        {
            InitializeComponent();
            _context = new HotelContext();
            _etagesController = new EtagesController(_context);

            dataGridTest.ItemsSource = _etagesController.GetAllEtages();
        }
    }
}
