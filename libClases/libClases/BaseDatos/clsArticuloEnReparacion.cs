using System;
using libComunes.CapaDatos;
//Se requiere la capa de objetos para llenar el combo
using libComunes.CapaObjetos;
//Se requiere la librería System.Web.UI.WebControls, y hay que referenciar a System.Web
using System.Web.UI.WebControls;



namespace libClases.BaseDatos
{
    public class clsArticuloEnReparacion
    {
        #region "Atributos/Propiedades"
        public Int32 Cod_ArticuloEnReparacion { get; set; }
        public string Nombre_Articulo { get; set; }
        public string FechaRecibido { get; set; }
        public string FechaEntrega { get; set; }
        public string Descripcion { get; set; }
        public string Cliente { get; set; }
        public string Empleado { get; set; }
        public bool Activo { get; set; }

        //Crea el objeto grdEquipoEnReparacion como propiedad de entrada y salida
        public GridView grdEquipoEnReparacion { get; set; }
        public DropDownList cboEquipoEnReparacion { get; set; }
        private string SQL;
        public string Error { get; private set; }
        #endregion
        #region "Metodos"
        public bool Ingresar()
        {
            SQL = "INSERT INTO ArticuloEnReparacion (Cod_ArticuloEnReparacion, Nombre_Articulo, FechaRecibido, FechaEntrega, Descripcion, Cliente, Empleado) " +
                  "VALUES (@prCod_ArticuloEnReparacion, @prNombre_Articulo, @FechaRecibido, @prFechaEntrega, @prDescripcion, @prCliente, @prEmpleado)";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCod_ArticuloEnReparacion", Cod_ArticuloEnReparacion);
            oConexion.AgregarParametro("@prNombre_Articulo", Nombre_Articulo);
            oConexion.AgregarParametro("@FechaRecibido", FechaRecibido);
            oConexion.AgregarParametro("@prFechaEntrega", FechaEntrega);
            oConexion.AgregarParametro("@prDescripcion", Descripcion);
            oConexion.AgregarParametro("@prCliente", Cliente);
            oConexion.AgregarParametro("@prEmpleado", Empleado);



            if (oConexion.EjecutarSentencia())
            {

                //Ejecutó la sentencia, liberar memoria y retornar true
                oConexion = null;
                return true;
            }
            else
            {
                //Lee el error, libera y retorna false
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }
        public bool Actualizar()
        {
            SQL = "UPDATE   ArticuloEnReparacion " +
                  "SET      Nombre_Articulo = @prNombre_Articulo, " +
                           "FechaRecibido = @prFechaRecibido, " +
                           "FechaEntrega = @prFechaEntrega, " +
                           "Descripcion =  @prDescripcion, " +
                           "Empleado =  @prEmpleado " +
                           
                  "WHERE    Cod_ArticuloEnReparacion = @prCod_ArticuloEnReparacion";
            
            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCod_ArticuloEnReparacion", Cod_ArticuloEnReparacion);
            oConexion.AgregarParametro("@prNombre_Articulo", Nombre_Articulo);
            oConexion.AgregarParametro("@prFechaRecibido", FechaRecibido);
            oConexion.AgregarParametro("@prFechaEntrega", FechaEntrega);
            oConexion.AgregarParametro("@prDescripcion", Descripcion);
            oConexion.AgregarParametro("@prEmpleado", Empleado);

            if (oConexion.EjecutarSentencia())
            {
                //Ejecutó la sentencia, liberar memoria y retornar true
                oConexion = null;
                return true;
            }
            else
            {
                //Lee el error, libera y retorna false
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }
       
        /*
        public bool Borrar()
        {
            SQL = "DELETE FROM ArticuloEnReparacion " +
                  "WHERE    intCodigo_CIUD = @prCodigo";

            clsConexion oConexion = new clsConexion();

            oConexion.SQL = SQL;
            oConexion.AgregarParametro("@prCodigo", Codigo);

            if (oConexion.EjecutarSentencia())
            {
                //Ejecutó la sentencia, liberar memoria y retornar true
                oConexion = null;
                return true;
            }
            else
            {
                //Lee el error, libera y retorna false
                Error = oConexion.Error;
                oConexion = null;
                return false;
            }
        }
        */
        public bool Consultar()
        {
            if(Cliente!="" && Cod_ArticuloEnReparacion!=0)
            {
                SQL = "SELECT    " +
                           "Cod_ArticuloEnReparacion, " +
                           "Nombre_Articulo, " +
                           "FechaRecibido, " +
                           "FechaEntrega, " +
                           "Descripcion, " +
                           "Empleado " +
                  "FROM     ArticuloEnReparacion " +
                  "WHERE    Cliente = @prDocumento and Cod_ArticuloEnReparacion= @prCod_ArticuloEnReparacion";

                clsConexion oConexion = new clsConexion();
                oConexion.SQL = SQL;
                oConexion.AgregarParametro("@prDocumento", Cliente);
                oConexion.AgregarParametro("@prCod_ArticuloEnReparacion", Cod_ArticuloEnReparacion);
                //Se invoca el método consultar
                if (oConexion.Consultar())
                {
                    //Se verifica si hay datos
                    if (oConexion.Reader.HasRows)
                    {


                        //Tiene filas, se debe leer la información
                        oConexion.Reader.Read();
                        //Se captura la información
                        Cod_ArticuloEnReparacion = oConexion.Reader.GetInt32(0);
                        Nombre_Articulo = oConexion.Reader.GetString(1);
                        FechaRecibido = oConexion.Reader.GetString(2);
                        FechaEntrega = oConexion.Reader.GetString(3);
                        Descripcion = oConexion.Reader.GetString(4);
                        Empleado = oConexion.Reader.GetString(5);

                        //Empleado = oConexion.Reader.GetString(5);
                        //Libera memoria
                        oConexion.CerrarConexion();
                        oConexion = null;
                        return true;
                    }
                    else
                    {
                        //No tiene filas, se levanta un error
                        Error = "El cliente con el documento " + Cliente +
                            " no está en la base de datos. \nVerifique la información " +
                            "o ingréselo al sistema";
                        //Cerrar la conexión
                        oConexion.CerrarConexion();
                        oConexion = null;
                        return false;
                    }
                }
                else
                {
                    Error = oConexion.Error;
                    //Se debe cerrar la conexión
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return false;
                }
            }
            else if(Cliente!="" && Cod_ArticuloEnReparacion==0)
            {
                SQL = "SELECT    " +
                           "Cod_ArticuloEnReparacion, " +
                           "Nombre_Articulo, " +
                           "FechaRecibido, " +
                           "FechaEntrega, " +
                           "Descripcion, " +
                           "Empleado " +
                  "FROM     ArticuloEnReparacion " +
                  "WHERE    Cliente = @prDocumento";

                clsConexion oConexion = new clsConexion();
                oConexion.SQL = SQL;
                oConexion.AgregarParametro("@prDocumento", Cliente);
                //Se invoca el método consultar
                if (oConexion.Consultar())
                {
                    //Se verifica si hay datos
                    if (oConexion.Reader.HasRows)
                    {


                        //Tiene filas, se debe leer la información
                        oConexion.Reader.Read();
                        //Se captura la información
                        Cod_ArticuloEnReparacion = oConexion.Reader.GetInt32(0);
                        Nombre_Articulo = oConexion.Reader.GetString(1);
                        FechaRecibido = oConexion.Reader.GetString(2);
                        FechaEntrega = oConexion.Reader.GetString(3);
                        Descripcion = oConexion.Reader.GetString(4);
                        Empleado = oConexion.Reader.GetString(5);

                        //Empleado = oConexion.Reader.GetString(5);
                        //Libera memoria
                        oConexion.CerrarConexion();
                        oConexion = null;
                        return true;
                    }
                    else
                    {
                        //No tiene filas, se levanta un error
                        Error = "El cliente con el documento " + Cliente +
                            " no está en la base de datos. \nVerifique la información " +
                            "o ingréselo al sistema";
                        //Cerrar la conexión
                        oConexion.CerrarConexion();
                        oConexion = null;
                        return false;
                    }
                }
                else
                {
                    Error = oConexion.Error;
                    //Se debe cerrar la conexión
                    oConexion.CerrarConexion();
                    oConexion = null;
                    return false;
                }
                
            }
            Error = "Ingrese datos validos para la consulta.";
            return false;
        }

       
        public bool LlenarGrid()
        {

            if(Cliente!="" && Cod_ArticuloEnReparacion==0)
            {
                SQL = "SELECT dbo.ArticuloEnReparacion.Cliente AS Documento, dbo.tblCliente.strNombre_CLIE AS Nombres, " +
                "dbo.tblCliente.strPrimerApellido_CLIE AS[Primer apellido], " +
                "dbo.tblCliente.strSegundoApellido_CLIE AS[Segundo apellido], dbo.ArticuloEnReparacion.Cod_ArticuloEnReparacion AS [Articulo en reparación], " +
                "dbo.tblEmpleadoCargo.strDocumento_EMPL AS[Empleado a cargo], dbo.tblEmpleado.strNombre_EMPL [Nombre empleado a cargo] " +
                "FROM dbo.ArticuloEnReparacion INNER JOIN " +
                "dbo.tblCliente ON dbo.ArticuloEnReparacion.Cliente = dbo.tblCliente.strDocumento_CLIE INNER JOIN " +
                "dbo.tblEmpleadoCargo ON dbo.ArticuloEnReparacion.Empleado = dbo.tblEmpleadoCargo.intCodigo_EMCA INNER JOIN " +
                "dbo.tblEmpleado ON dbo.tblEmpleadoCargo.strDocumento_EMPL = dbo.tblEmpleado.strDocumento_EMPL " +
                "WHERE        (dbo.ArticuloEnReparacion.Cliente = @prCedula)";

                clsGrid oGrid = new clsGrid();
                oGrid.SQL = SQL;
                oGrid.AgregarParametro("@prCedula", Cliente);
                oGrid.gridGenerico = grdEquipoEnReparacion;
                oGrid.NombreTabla = "ArticuloEnReparacion";
                if (oGrid.LlenarGridWeb())
                {
                    grdEquipoEnReparacion = oGrid.gridGenerico;
                    oGrid = null;
                    return true;
                }
                else
                {
                    Error = oGrid.Error;
                    oGrid = null;
                    return false;
                }

            }
            else if(Cliente!="" && Cod_ArticuloEnReparacion!=0)
            {
                SQL = "SELECT dbo.ArticuloEnReparacion.Cliente AS Documento, dbo.tblCliente.strNombre_CLIE AS Nombres, " +
               "dbo.tblCliente.strPrimerApellido_CLIE AS[Primer apellido], " +
               "dbo.tblCliente.strSegundoApellido_CLIE AS[Segundo apellido], dbo.ArticuloEnReparacion.Cod_ArticuloEnReparacion AS [Articulo en reparación], " +
               "dbo.tblEmpleadoCargo.strDocumento_EMPL AS[Empleado a cargo], dbo.tblEmpleado.strNombre_EMPL [Nombre empleado a cargo] " +
               "FROM dbo.ArticuloEnReparacion INNER JOIN " +
               "dbo.tblCliente ON dbo.ArticuloEnReparacion.Cliente = dbo.tblCliente.strDocumento_CLIE INNER JOIN " +
               "dbo.tblEmpleadoCargo ON dbo.ArticuloEnReparacion.Empleado = dbo.tblEmpleadoCargo.intCodigo_EMCA INNER JOIN " +
               "dbo.tblEmpleado ON dbo.tblEmpleadoCargo.strDocumento_EMPL = dbo.tblEmpleado.strDocumento_EMPL" +
                "WHERE (dbo.ArticuloEnReparacion.Cliente = @prCedula and Cod_ArticuloEnReparacion= @prCod_ArticuloEnReparacion)";

                clsGrid oGrid = new clsGrid();
                oGrid.SQL = SQL;
                oGrid.AgregarParametro("@prCedula", Cliente);
                oGrid.AgregarParametro("@prCod_ArticuloEnReparacion", Cod_ArticuloEnReparacion);
                oGrid.gridGenerico = grdEquipoEnReparacion;
                oGrid.NombreTabla = "ArticuloEnReparacion";
                if (oGrid.LlenarGridWeb())
                {
                    grdEquipoEnReparacion = oGrid.gridGenerico;
                    oGrid = null;
                    return true;
                }
                else
                {
                    Error = oGrid.Error;
                    oGrid = null;
                    return false;
                }
            }
            else
            {
                SQL = "SELECT dbo.ArticuloEnReparacion.Cliente AS Documento, dbo.tblCliente.strNombre_CLIE AS Nombres, " +
              "dbo.tblCliente.strPrimerApellido_CLIE AS[Primer apellido], " +
              "dbo.tblCliente.strSegundoApellido_CLIE AS[Segundo apellido], dbo.ArticuloEnReparacion.Cod_ArticuloEnReparacion AS [Articulo en reparación], " +
              "dbo.tblEmpleadoCargo.strDocumento_EMPL AS[Empleado a cargo], dbo.tblEmpleado.strNombre_EMPL [Nombre empleado a cargo] " +
              "FROM dbo.ArticuloEnReparacion INNER JOIN " +
              "dbo.tblCliente ON dbo.ArticuloEnReparacion.Cliente = dbo.tblCliente.strDocumento_CLIE INNER JOIN " +
              "dbo.tblEmpleadoCargo ON dbo.ArticuloEnReparacion.Empleado = dbo.tblEmpleadoCargo.intCodigo_EMCA INNER JOIN " +
              "dbo.tblEmpleado ON dbo.tblEmpleadoCargo.strDocumento_EMPL = dbo.tblEmpleado.strDocumento_EMPL";

                clsGrid oGrid = new clsGrid();
                oGrid.SQL = SQL;
                oGrid.AgregarParametro("@prCedula", Cliente);
                oGrid.gridGenerico = grdEquipoEnReparacion;
                oGrid.NombreTabla = "ArticuloEnReparacion";
                if (oGrid.LlenarGridWeb())
                {
                    grdEquipoEnReparacion = oGrid.gridGenerico;
                    oGrid = null;
                    return true;
                }
                else
                {
                    Error = oGrid.Error;
                    oGrid = null;
                    return false;
                }
            }

        }

    

            /*
        public bool LlenarCombo()
        {
            SQL = "SELECT       intCodigo_CIUD, Cod_ArticuloEnReparacion " +
                       "FROM        ArticuloEnReparacion " +
                       "WHERE       Nombre_Articulo = 1 " +
                                   "AND intCodigo_Depa = " + CodigoDpto +
                       " ORDER BY    Cod_ArticuloEnReparacion";

            //Se crea la instancia del objeto combo
            clsCombos oCombo = new clsCombos();
            oCombo.SQL = SQL;
            //Se pasa el combo Depa
            oCombo.cboGenericoWeb = cboCiudad;
            oCombo.NombreTabla = "Ciudad";
            //La columna texto es el nombre de la columna que el combo a mostrar
            oCombo.ColumnaTexto = "Cod_ArticuloEnReparacion";
            //La columna valor, es el  nombre de la columna que quiero capturar en la interfaz
            oCombo.ColumnaValor = "intCodigo_CIUD";
            //Se invoca el combo y se lee
            if (oCombo.LlenarComboWeb())
            {
                //Si lo llenó, lee el combo lleno y lo asigna a la propiedad cboDepaes
                cboCiudad = oCombo.cboGenericoWeb;
                oCombo = null;
                return true;
            }
            else
            {
                Error = oCombo.Error;
                oCombo = null;
                return false;
            }
        }*/
        #endregion
    }
}
