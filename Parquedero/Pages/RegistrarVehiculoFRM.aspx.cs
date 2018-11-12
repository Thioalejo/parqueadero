using libClases.BaseDatos;
using System;
using System.Web.UI;
public partial class Pages_RegistrarVehiculoFRM_ : System.Web.UI.Page
{

    private static int txtidCliente;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(txtDocumentoCliente.Text=="")
        {
            lblMarca.Enabled = false;
            lblColor.Enabled = false;
            lblModelo.Enabled = false;
            lblPlaca.Enabled = false;

            txtMarca.Enabled = false;
            txtColor.Enabled = false;
            txtModelo.Enabled = false;
            txtPlaca.Enabled = false;
            btnRegistrarVehiculo.Enabled = false;
        }
        
    }
    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Cliente oCliente = new Cliente();


        if (txtDocumentoCliente.Text == "")
        {
            lblError.Text = "Debes ingresar el documento";
            lblCliente.Text = "";
        }
        else
        {
                int Cedula = Convert.ToInt32(txtDocumentoCliente.Text);

                oCliente.Documento = Cedula;

                if (oCliente.Consultar())
                {
                    lblCliente.Text = oCliente.Nombre_Completo + " CLIENTE CON RESERVA ACTIVA";
                    lblMarca.Enabled = true;
                    lblColor.Enabled = true;
                    lblModelo.Enabled = true;
                    lblPlaca.Enabled = true;

                    txtMarca.Enabled = true;
                    txtColor.Enabled = true;
                    txtModelo.Enabled = true;
                    txtPlaca.Enabled = true;
                    btnRegistrarVehiculo.Enabled = true;
                    txtidCliente = oCliente.idCliente;
                }
                else
                {
                    lblCliente.Text = "";
                    lblMarca.Enabled = false;
                    lblColor.Enabled = false;
                    lblModelo.Enabled = false;
                    lblPlaca.Enabled = false;

                    txtMarca.Enabled = false;
                    txtColor.Enabled = false;
                    txtModelo.Enabled = false;
                    txtPlaca.Enabled = false;
                    btnRegistrarVehiculo.Enabled = false;
                    lblError.Text = oCliente.Error;
                }
                oCliente = null;
            
        }
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


        if (txtMarca.Text == "" || txtColor.Text == "" || txtModelo.Text == "" || txtPlaca.Text == "")
        {
            lblError.Text = "Debes ingresar todos los datos";
           // lblCliente.Text = "";
        }
        else
        {


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
        }

       // lblError.Text = "El vehículo ya está registrado en el sistema";
    }
}