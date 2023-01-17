using GestionHotel.Controllers;
using GestionHotel.Data;
using GestionHotel.Data.Dtos;
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

namespace GestionHotel.Views
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class FormulaireTest : Window
    {
        private string _mode;
        private TypesChambreDTO _obj;
        private HotelContext _context;
        private TypesChambresController _controller;
        public FormulaireTest(string mode, TypesChambreDTO obj, HotelContext context)
        {
            InitializeComponent();
            _mode = mode;
            _obj = obj;
            _context = context;
            _controller = new TypesChambresController(_context);
            switch (_mode)
            {
                case "Modifier":
                    remplirInput();
                    break;
                case "Supprimer":
                    remplirInput();
                    disableInput();
                    break;
                default:
                    break;
            }
        }

        public void remplirInput()
        {
            TbxLibTypeChambre.Text = _obj.LibelleTypeChambre.ToString();
            TbxPrixTypeChambre.Text = _obj.PrixChambre.ToString();
        }

        public void disableInput()
        {
            TbxLibTypeChambre.IsEnabled = false;
            TbxPrixTypeChambre.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (_mode)
            {
                case "Ajouter":
                    remplirObj();
                    _controller.CreateTypesChambre(_obj);
                    break;
                case "Modifier":
                    remplirObj();
                    _controller.UpdateTypesChambre(_obj);
                    
                    break;
                case "Supprimer":
                    _controller.DeleteTypesChambre(_obj.IdTypeChambre);
                    break;
                default:
                    break;
            }
            this.Close();
        }

        private void remplirObj()
        {
            _obj.LibelleTypeChambre = TbxLibTypeChambre.Text;
            _obj.PrixChambre = Convert.ToDecimal(TbxPrixTypeChambre.Text);
        }
    }
}
