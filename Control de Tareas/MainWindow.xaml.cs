using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
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
using MySql.Data.MySqlClient;

namespace Control_de_Tareas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private string username;
        private string password;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            username = txtBoxUser.Text;
            password = toSHA256(txtBoxPassword.Password);
            string pass = txtBoxPassword.Password;
            //MessageBox.Show(pass);
            Console.WriteLine(toSHA256(pass));
            //MessageBox.Show(toSHA256(pass));
            //LoginSinCredencial();
            
            
            CConexion cConexion = new CConexion();
            cConexion.EstablecerConn();
            if(cConexion.CheckCredentials(username, password)){
                this.Close();
            }
            
            
            
            

        }        

        private void LoginSinCredencial()
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();
        }

        private void btn_connectBD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CConexion objConexion = new CConexion();
                objConexion.EstablecerConn();
                MessageBox.Show("Conexión con el servidor exitosa.");
                objConexion.CerrarConn();

            }catch (Exception ex)
            {
                MessageBox.Show("No se pudo establecer conexion con el servidor. Error: " + ex.Message);
            }
        }
        public static string toSHA256(string s)
        {
            string hash = String.Empty;

            // Initialize a SHA256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the given string
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

                // Convert the byte array to string format
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return (hash.ToLower());

        }
    }
}
