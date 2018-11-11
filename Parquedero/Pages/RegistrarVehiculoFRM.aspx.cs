using libClases.BaseDatos;
using System;
using System.Web.UI;
public partial class Pages_RegistrarVehiculoFRM_ : System.Web.UI.Page
{

    private static int txtidCliente;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Cliente oCliente = new Cliente();
        string Cedula = txtDocumentoCliente.Text;
        
        oCliente.Documento = Cedula;

        if (oCliente.Consultar())
        {
            lblCliente.Text = oCliente.Nombre+" "+ oCliente.Apellido;
            txtidCliente = oCliente.idCliente;
        }
        else
        {
            lblError.Text = oCliente.Error;
        }
        oCliente = null;
        //lblCliente.Text = "Juan Carlos Perez Martinez tiene una reserva activa";
    }

    protected void btnRegistrarVehiculo_Click(object sender, EventArgs e)
    {
        
        string marca;
        string color;
        string modelo;
        string placa;
        //int idCliente;
        // bool Activo;



        marca = txtMarca.Text;
        color = txtColor.Text;
        modelo = txtModelo.Text;
        placa = txtPlaca.Text;
       



        Vehiculo vehicilo = new Vehiculo();
        vehicilo.Marca = marca;
        vehicilo.Color = color;
        vehicilo.Modelo = modelo;
        vehicilo.Placa = placa;
        int idCliente1 = txtidCliente;
        vehicilo.IdCliente = idCliente1;


        if (vehicilo.Guardar())
        {
            lblError.Text = "Dato ingresado correctamente";
            txtDocumentoCliente.Text = "";
            txtMarca.Text = "   ";
            txtColor.Text = "";
            txtModelo.Text = "";
            txtPlaca.Text = "";
            lblCliente.Text = "";

            //LlenarGridCiudad();
        }
        else
        {
            lblError.Text = vehicilo.Error;
        }
        vehicilo = null;
        

       // lblError.Text = "El vehículo ya está registrado en el sistema";
    }
}