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
    /// Logique d'interaction pour FomulaireTestTypeEmploye.xaml
    /// </summary>
    public partial class FormulaireTypeEmploye : Window
    {
        private string _mode;
        private TypesEmployeDTO _obj;
        private HotelContext _context;
        private TypesEmployesController _controller;
        public FormulaireTypeEmploye(string mode, TypesEmployeDTO obj, HotelContext context)
        {
            InitializeComponent();
            _mode = mode;
            _obj = obj;
            _context = context;
            _controller = new TypesEmployesController(_context);
            switch (_mode)
            {
                case "Modifier":
                    RemplirInput();
                    break;
                case "Supprimer":
                    RemplirInput();
                    DisableInput();
                    break;
                default:
                    break;
            }
        }

        public void RemplirInput()
        {
            TbxLibTypeEmploye.Text = _obj.LibelleTypeEmploye.ToString();
        }

        public void DisableInput()
        {
            TbxLibTypeEmploye.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (_mode)
            {
                case "Ajouter":
                    RemplirObj();
                    _controller.CreateTypesEmploye(_obj);
                    break;
                case "Modifier":
                    RemplirObj();
                    _controller.UpdateTypesEmploye(_obj);

                    break;
                case "Supprimer":
                    _controller.DeleteTypesEmploye(_obj.IdTypeEmploye);
                    break;
                default:
                    break;
            }
            this.Close();
        }

        private void RemplirObj()
        {
            _obj.LibelleTypeEmploye = TbxLibTypeEmploye.Text;
        }
    }
}
