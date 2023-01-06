using System;
using System.Collections.Generic;
using System.Data;
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

namespace Control_de_Tareas
{
    /// <summary>
    /// Interaction logic for NegocioSeleccionado.xaml
    /// </summary>
    public partial class NegocioSeleccionado : Window
    {
        public event Action<bool> NegocioSeleccionadoOK;
        public event Action<string> NegocioSeleccionadoInt;
        public event Action<string> NegocioSeleccionadoString;
        public NegocioSeleccionado()
        {
            InitializeComponent();
            LlenarTabla();
        }

        private void Btn_SeleccionarNegocio_Volver_Click(object sender, RoutedEventArgs e)
        {
            NegocioSeleccionadoOK?.Invoke(false);
            this.Close();
            
        }

        private void LlenarTabla()
        {
            CConexion cConexion = new CConexion();
            cConexion.LlamarTablaSeleccionarNegocio("negocio", DataGrid_SeleccionarNegocio);
        }




        private void Btn_SeleccionarNegocio_Seleccionar_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid_SeleccionarNegocio.SelectedValue == null)
            {
                MessageBox.Show("No se ha seleccionado ningún Negocio");
            }
            else
            {
                //IList rows = tablaUsuarios.SelectedItems;
                DataRowView row = (DataRowView)DataGrid_SeleccionarNegocio.SelectedItems[0];
                string nombreNegocio = row[0].ToString();
                CConexion cConexion = new CConexion();
                cConexion.EstablecerConn();
                string idNegocio = cConexion.GetIDByName("negocio", nombreNegocio);

                NegocioSeleccionadoString?.Invoke(nombreNegocio);
                NegocioSeleccionadoInt?.Invoke(idNegocio);
                NegocioSeleccionadoOK?.Invoke(false);

                this.Close();
            }
        }

        private void DataGrid_SeleccionarNegocio_PreviewMouseWheel(object sender, MouseWheelEventArgs e) //Envia info de mouse wheel a scrollviewer
        {
            //ScrollViewer.ScrollToVerticalOffset(ScrollViewer.VerticalOffset - e.Delta / 3);
        }
    }
}
