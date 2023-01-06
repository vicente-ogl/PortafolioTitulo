using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Data;
using System.Windows;
using Oracle;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Control_de_Tareas
{
    internal class CConexion
    {
        MySqlConnection conex = new MySqlConnection();

        OracleConnection conn = new OracleConnection();


        static string servidor = "dbcontroltareas.ct2rrxcaxo9w.us-east-1.rds.amazonaws.com";
        static string bd = "ProcessSA2";
        static string usuario = "admin";
        static string password = "duoc1234";
        static string puerto = "3306";

        public string cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "uid=" + usuario + ";" + "pwd=" + password + ";" + "database=" + bd + ";";
        public string cadenaConexion2 = "User ID = ADMIN; Password = Duoc12345678; Data Source = processsa_high";


        public bool EstablecerConn()
        {
            try
            {
                conn.ConnectionString = cadenaConexion2;
                conn.Open();
                return true;

            }
            catch (OracleException e)
            {
                
                System.Windows.MessageBox.Show("No se pudo establecer conexion, Error: " + e);
                return false;
            }
        }

        public void CerrarConn2()
        {
            conn.Close();
        }

        public void TestStringQuery()
        {
            try
            {
                string query = "select nombre FROM negocio where id = 21";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader oraReader;
                oraReader = cmd.ExecuteReader();

                while (oraReader.Read())
                {
                    MessageBox.Show(oraReader.GetString(0));
                }
                oraReader.Close();
                conn.Close();

            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public string NombreUsuarioLogeado(int idUsuario)
        {
            return null;
        }

        public MySqlCommand ReadSingleDB(int id, string tabla)
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();

                MySqlCommand dataREAD = new MySqlCommand("SELECT * FROM " + tabla + " WHERE ID= " + id + ";", conex);
                return dataREAD;
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show("test:" + e);
                return null;
            }
        }

        public void CerrarConn()
        {
            //this.conex.Close();
            conn.Close();
        }

        public MySqlConnection Get_connection()
        {
            return this.conex;
        }

        public bool EjecutarMetodoBaseDatos()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                return true;
            }
            catch (MySqlException e)
            {
                System.Windows.MessageBox.Show("No se pudo establecer conexion, Error: " + e);
                return false;
            }
        }

        public string getConnString()
        {            
            return cadenaConexion.ToString();
        }
        
        
        //Oracle OK
        public bool CheckCredentials(string email, string pass)
        {
            try
            {
                string query = "SELECT * FROM usuario a join rol b on a.rol_id = b.id WHERE correo = '" + email + "' AND password = '"+pass+"'";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteReader();
                string result = "";
                string resultRol = "";

                while (reader.Read())
                {
                    result = reader.GetString(0);
                    resultRol = reader.GetString(13);
                }


                if (result == "")
                {
                    //Pass o mail incorrecto
                    MessageBox.Show("Usuario no se encuentra en el sistema");
                    return false;   
                }
                if(resultRol != "Admin Escritorio")
                {
                    MessageBox.Show("Usuario no cuenta con las credenciales para acceder al sistema");
                    return false;
                }
                else
                {
                    //User found
                    reader.Close();
                    query = "SELECT CONCAT(nombre ,CONCAT(' ',CONCAT(apellidop, CONCAT(' ', apellidom)))) FROM usuario WHERE id = "+result+"";
                    cmd = new OracleCommand(query, conn);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result = reader.GetString(0);
                    }

                    Dashboard dashboard = new Dashboard();
                    dashboard.label_logedUser.Content = result;
                    dashboard.Show();

                    return true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        //Oracle OK
        //Llama todos los datos, incluyendo los datos que tengan "deleted" como True
        public void LlamarTablaFull(string tabla, System.Windows.Controls.DataGrid datagridItem)
        {

            try
            {
                EstablecerConn();
                string query = "SELECT * FROM " + tabla + ";";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                datagridItem.DataContext = ds;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Oracle OK
        public void LlamarTabla(string tabla, System.Windows.Controls.DataGrid datagridItem)
        {

            try
            {
                EstablecerConn();
                string query = "SELECT * FROM " + tabla + " where Deleted = 0 ORDER BY ID";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                datagridItem.DataContext = ds;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LlamarTablaUsuariosTodo(System.Windows.Controls.DataGrid datagridItem)
        {

            try
            {
                EstablecerConn();
                string query = "select * from usuario a join rol b on a.rol_id = b.id join grupotrabajo c on a.grupotrabajo_id = c.id where a.deleted = 0";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                datagridItem.DataContext = ds;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LlamarTablaUsuariosTodoNegocioSelected(string negocio, System.Windows.Controls.DataGrid datagridItem)
        {

            try
            {
                EstablecerConn();
                string query = "select * from usuario a join rol b on a.rol_id = b.id join grupotrabajo c on a.grupotrabajo_id = c.id where a.deleted = 0 and a.negocio_id = "+negocio+"";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                datagridItem.DataContext = ds;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LlamarTablaUsuariosGP(string tabla, System.Windows.Controls.DataGrid datagridItem, string idGP)
        {

            try
            {
                EstablecerConn();
                string query = "SELECT * FROM " + tabla + " where grupotrabajo_id = "+idGP+"";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                datagridItem.DataContext = ds;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void LlamarTablaUsuariosGP2(string tabla, System.Windows.Controls.DataGrid datagridItem, string idGP)
        {

            try
            {
                EstablecerConn();
                string query = "SELECT * FROM " + tabla + " a left join rol b on a.rol_id = b.id where a.grupotrabajo_id = " + idGP + "";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                datagridItem.DataContext = ds;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void LlamarTablaTareasDeFlujo(string tabla, System.Windows.Controls.DataGrid datagridItem, string id)
        {
            try
            {
                EstablecerConn();
                string query = "SELECT * FROM " + tabla + " where flujo_pl_id = " + id + " order by 2";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                datagridItem.DataContext = ds;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Oracle OK

        public void LlamarTablaNegocioSelected(string tabla, System.Windows.Controls.DataGrid datagridItem, string negocioID)
        {

            try
            {
                EstablecerConn();
                string query = "SELECT * FROM " + tabla + " where Deleted = 0 and negocio_id = "+negocioID+"";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                datagridItem.DataContext = ds;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Oracle OK
        public void LlamarTablaSeleccionarNegocio(string tabla, System.Windows.Controls.DataGrid datagridItem)
        {

            try
            {
                EstablecerConn();
                string query = "SELECT nombre, encargado, correo_encargado, rut FROM " + tabla + " where Deleted = 0";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataAdapter adp = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                datagridItem.DataContext = ds;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            CerrarConn2();
        }

        //Oracle OK
        public string GetNameByID(string id, string tabla)
        {
            try
            {
                string query = "select nombre FROM " + tabla + " where id = " + id + ";";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteReader();
                string result = "";

                while (reader.Read())
                {
                    result = reader.GetString(1);
                }

                return result;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        public bool CheckFlujoName(string nombre)
        {
            try
            {
                string query = "select nombre from flujo_pl where nombre = '"+ nombre + "'";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteReader();
                string result = "";

                while (reader.Read())
                {
                    result = reader.GetString(0);
                }
                if(result == nombre)
                {
                    return false; //True que si puede agregar flujo
                }
                else
                {
                    return true; //Falso, no puede agregar flujo
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return true;
            }
        }

        //Oracle OK
        public string GetIDByName(string tabla, string name)
        {
            try
            {
                //EstablecerConn(); // para evitar error al seleccionar negocio
                string query = "select id FROM " + tabla + " where nombre = '" + name + "'";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteReader();
                string result = "";

                while (reader.Read())
                {
                    result = reader.GetString(0);
                }
                reader.Close();
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        //ORACLE OK
        public string[] GetUsuariosFromNegocio(string id_negocio, string gt_ninguno)
        {
            List<string> usuariosNegocio = new List<string>();
            string query = "SELECT nombre || ' ' || apellidop || ' ' || apellidom AS nombrecompleto FROM usuario WHERE negocio_id = " + id_negocio + " AND grupotrabajo_id = " + gt_ninguno;
            try
            {
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader mydr;
                mydr = cmd.ExecuteReader();
                while (mydr.Read())
                {
                    string subj = mydr.GetString(0);
                    usuariosNegocio.Add(subj);
                }
                mydr.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return usuariosNegocio.ToArray();
        }

        public string[] GetUsuariosFromNegocioEditGP(string id_negocio, string gt_ninguno, string gt_oldGP)
        {
            List<string> usuariosNegocio = new List<string>();
            string query = "SELECT nombre || ' ' || apellidop || ' ' || apellidom AS nombrecompleto FROM usuario WHERE negocio_id = " + id_negocio + " AND grupotrabajo_id = " + gt_ninguno + " OR grupotrabajo_id = " + gt_oldGP;
            try
            {
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader mydr;
                mydr = cmd.ExecuteReader();
                while (mydr.Read())
                {
                    string subj = mydr.GetString(0);
                    usuariosNegocio.Add(subj);
                }
                mydr.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return usuariosNegocio.ToArray();
        }
        public string[] GetUserIDFromNegocio(string id_negocio, string gt_ninguno)
        {
            List<string> usuariosNegocio = new List<string>();
            string query = "SELECT id FROM usuario WHERE negocio_id = " + id_negocio + " AND grupotrabajo_id = "+ gt_ninguno;
            try
            {
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader mydr;
                mydr = cmd.ExecuteReader();
                while (mydr.Read())
                {
                    string subj = mydr.GetString(0);
                    usuariosNegocio.Add(subj);
                }
                mydr.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return usuariosNegocio.ToArray();            
        }

        public string[] GetUserIDFromNegocioGPEDIT(string id_negocio, string gt_ninguno, string gt_ID)
        {
            List<string> usuariosNegocio = new List<string>();
            string query = "SELECT id FROM usuario WHERE negocio_id = " + id_negocio + " AND grupotrabajo_id = " + gt_ninguno + " OR grupotrabajo_id = " + gt_ID;
            try
            {
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader mydr;
                mydr = cmd.ExecuteReader();
                while (mydr.Read())
                {
                    string subj = mydr.GetString(0);
                    usuariosNegocio.Add(subj);
                }
                mydr.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return usuariosNegocio.ToArray();
        }

        public string[] GetRolFromUsuarios(string id_negocio)
        {
            List<string> usuariosNegocio = new List<string>();
            try
            {
                string query = "SELECT * FROM USUARIO INNER JOIN ROL ON USUARIO.ROL_ID = ROL.ID WHERE NEGOCIO_ID = " + id_negocio + "";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader mydr;
                mydr = cmd.ExecuteReader();
                while (mydr.Read())
                {
                    string subj = mydr.GetString(13);
                    usuariosNegocio.Add(subj);
                }
                mydr.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return usuariosNegocio.ToArray();
        }

        //ORACLE
        public string[] CargarCombobox(string tabla)
        {
            List<string> datosCombo = new List<string>();
            try
            {
                string query = "SELECT nombre FROM " + tabla + " where deleted = 0";
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader mydr;
                mydr = cmd.ExecuteReader();
                while (mydr.Read())
                {
                    string subj = mydr.GetString(0);
                    datosCombo.Add(subj);
                }
                mydr.Close();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return datosCombo.ToArray();
        }

        //ORACLE OK
        public string[] CargarComboboxNegocio(string negocio)
        {
            string query = "SELECT id FROM negocio WHERE nombre = '" + negocio + "' and deleted = 0";
            OracleCommand cmd = new OracleCommand(query, conn);
            OracleDataReader mydr;
            mydr = cmd.ExecuteReader();
            string result = "";

            while (mydr.Read())
            {
                result = mydr.GetString(0);
            }
            mydr.Close();


            query = "select nombre FROM grupotrabajo where negocio_id = " + result + " and deleted = 0";
            cmd = new OracleCommand(query, conn);
            List<string> datosCombo = new List<string>();
            try
            {
                mydr = cmd.ExecuteReader();
                while (mydr.Read())
                {
                    string subj = mydr.GetString(0);
                    datosCombo.Add(subj);
                }
                mydr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return datosCombo.ToArray();
        }

        public void UpdateUsuario (string[] datosUsuario)
        {
            try
            {
                string query = "UPDATE usuario SET correo = '"+datosUsuario[1]+"', password = '"+datosUsuario[2]+"', rut = '"+datosUsuario[3]+"', nombre = '"+datosUsuario[4]+"', apellidop = '"+datosUsuario[5]+"', apellidom = '"+datosUsuario[6]+"', celular = "+datosUsuario[7]+", rol_id = "+datosUsuario[9]+", negocio_id = "+datosUsuario[10]+", grupotrabajo_id = "+datosUsuario[11]+" WHERE id = "+datosUsuario[0]+"";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void ResetGP(string idninguno, string idGP)
        {
            try
            {
                string query = "update usuario set grupotrabajo_id = "+ idninguno + " where grupotrabajo_id = "+idGP;
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void UpdateNombre(string nombre, string tabla, string id)
        {
            try
            {
                string query = "UPDATE "+tabla+" SET nombre = '" + nombre + "' WHERE id = " + id + "";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        //Oracle OK
        public void UpdateNegocio(string[] datosNegocio)
        {
            try
            {
                string query = "UPDATE negocio SET nombre = '" + datosNegocio[0] + "', encargado = '" + datosNegocio[1] + "', correo_encargado = '" + datosNegocio[3] + "', fecha_ingreso = TO_DATE('"+ datosNegocio[2] + "', 'yyyy-MM-dd'), rut = '" + datosNegocio[4] + "', direccion = '"+datosNegocio[5]+"' WHERE id = " + datosNegocio[6] + "";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void UpdateGrupoTrabajo(string nombre, string idGP)
        {
            try
            {
                string query = "UPDATE grupotrabajo SET nombre = '" + nombre + "' WHERE id = " + idGP + "";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        //Oracle OK
        public void DeleteRow(string id, string tabla)
        {
            try
            {
                string query = "UPDATE "+tabla+" SET deleted = '1' WHERE id = " + id + "";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void DeleteFlujo(string idFlujo)
        {
            try
            {
                string query = "delete from flujo_pl where id = " + idFlujo + "";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void DeleteTareasFlujo(string idFlujo)
        {
            try
            {
                string query = "delete from tarea_pl where flujo_pl_id = "+idFlujo+"";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void ResetGPUsuarios(string idgp_eliminado, string gt_ninguno)
        {
            try
            {
                string query = "UPDATE usuario SET grupotrabajo_id = "+ gt_ninguno + " WHERE grupotrabajo_id = "+idgp_eliminado+"";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public int CantidadRows(string tabla)
        {
            try
            {
                string totalID;
                string query = "select COUNT(id) FROM "+tabla+";";
                OracleCommand cmd = new OracleCommand(query, conn);
                totalID = cmd.ExecuteScalar().ToString();

                return Int32.Parse(totalID);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 0;
            }
        }

        //ORACLE OK
        public void InsertNegocio(string[] datosNegocio)
        {
            try
            {
                string query = "INSERT INTO NEGOCIO (ID, NOMBRE, ENCARGADO, CORREO_ENCARGADO, FECHA_INGRESO, RUT, DIRECCION, DELETED) VALUES( NEGOCIO_ID_SEQ.NEXTVAL, '"+datosNegocio[1]+ "', '" + datosNegocio[2] + "', '" + datosNegocio[3] + "', TO_DATE('"+ datosNegocio[4] + "', 'yyyy-MM-dd'), '"+datosNegocio[5]+"', '"+datosNegocio[6]+"',0 )";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void InsertFlujo_PL(string[] datos_flujo_pl)
        {
            try
            {
                string query = "INSERT INTO FLUJO_PL (NOMBRE, DESCRIPCION, DELETED, NEGOCIO_ID) VALUES('"+datos_flujo_pl[0]+"', '"+datos_flujo_pl[1]+"', 0, "+datos_flujo_pl[2]+")";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void InsertTarea_PL(string[] datos_tareaPL)
        {
            try
            {
                string query = "INSERT INTO TAREA_PL (ORDEN, NOMBRE, DESCRIPCION, DURACION, PREDECEDORA,FLUJO_PL_ID, SUBTAREA, DE_SUBTAREA) VALUES(" + datos_tareaPL[0] + ", '" + datos_tareaPL[1] + "', '"+ datos_tareaPL[2]+ "', "+datos_tareaPL[3]+", "+ datos_tareaPL[4]+ ", "+datos_tareaPL[5]+", "+datos_tareaPL[6]+", "+datos_tareaPL[7]+")";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void InsertRol(string nombreRol)
        {
            try
            {
                string query = "INSERT INTO ROL (ID, NOMBRE, DELETED) VALUES( ROL_ID_SEQ.NEXTVAL, '" + nombreRol + "',0 )";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public int GetFlujoTareaCount(string negocioID)
        {
            try
            {
                string query = "select count(gt.negocio_id) from flujoproceso fp join detalleflujo df on fp.id = df.flujoproceso_id join grupotrabajo gt on df.grupotrabajo_id = gt.id where gt.negocio_id = " + negocioID;
                OracleCommand cmd = new OracleCommand(query, conn);
                int reader = cmd.ExecuteNonQuery();
                return reader;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 0;
            }
        }
        public void InsertFlujoTarea(string nombre, int orden, int plantilla)
        {
            try
            {
                string query = "INSERT INTO FLUJOPROCESO (ID, ORDEN, NOMBRE, ESPLANTILLA, DELETED VALUES (FLUJOPROCESO_ID_SEQ.NEXTVAL, "+orden+", '"+nombre+"', "+plantilla+", 0";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void InsertSubFlujo(string nombre, int orden)
        {
            try
            {
                string query = "aaa";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public void InsertUsuario(string[] datosUsuario)
        {
            try
            {
                string query = "INSERT INTO USUARIO (ID, CORREO, PASSWORD, RUT, NOMBRE, APELLIDOP, APELLIDOM, CELULAR, DELETED, ROL_ID, NEGOCIO_ID, GRUPOTRABAJO_ID) VALUES(USUARIO_ID_SEQ.NEXTVAL, '" + datosUsuario[1] + "', '" + datosUsuario[2] + "', '" + datosUsuario[3] + "', '" + datosUsuario[4] + "', '" + datosUsuario[5] + "', '" + datosUsuario[6] + "', " + datosUsuario[7] + ", " + datosUsuario[8] + ", " + datosUsuario[9] + ", " + datosUsuario[10] + ", " + datosUsuario[11] + ")";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //CAMBIAR A ORACLE
        //URGENTE
        public void AgregarGrupoNegocio(string nombreGP, string idNegocio, List<string> listaUsuarios)
        {
            try
            {
                string idGP = "";
                //Ingresar nuevo Grupo de Trabajo
                string query = "INSERT INTO grupotrabajo VALUES (GRUPOTRABAJO_ID_SEQ.NEXTVAL, '" + nombreGP + "', 0, "+ idNegocio + ")";
                OracleCommand cmd = new OracleCommand(query, conn);
                var reader = cmd.ExecuteReader();
                reader.Close();
                //Obtener ID de grupo de trabajo creado            
                query = "SELECT id FROM grupotrabajo where nombre = '" + nombreGP + "'";
                cmd = new OracleCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    idGP = reader.GetString(0); //Tiene que devolver columna ID
                }
                reader.Close();
                query = "";
                for(int i = 0; i < listaUsuarios.Count; i++)
                {
                    query = " UPDATE usuario SET grupotrabajo_id = " + idGP + " WHERE id = "+ listaUsuarios[i]+"";
                    cmd = new OracleCommand(query, conn);
                    var reader2 = cmd.ExecuteNonQuery(); //BUG cuando se agregan mas de 1 usuario
                    reader.Close();
                }
                MessageBox.Show("Grupo de Trabajo creado Exitosamente");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //Cambiar a que actualice los usuarios de la lista al grupo de trabajo ya creado
        public void ActualizarGPdeUsuarios(string idGP, List<string> listaUsuarios)
        {
            try
            {
                string query;
                query = "";
                for (int i = 0; i < listaUsuarios.Count; i++)
                {
                    query = " UPDATE usuario SET grupotrabajo_id = " + idGP + " WHERE id = " + listaUsuarios[i] + "";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    var reader = cmd.ExecuteNonQuery(); //BUG cuando se agregan mas de 1 usuario
                    //reader.Close();
                }
                MessageBox.Show("Grupo de Trabajo Editado Exitosamente");

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

    }
}
