using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libClases.BaseDatos;
public partial class Pages_ConsultarVehiculoFRM : System.Web.UI.Page
{
    DataTable table = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    int FechaIncial = 0;
    int FechaFinal = 0;
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtFechaIncial.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        Calendar1.Visible = false;
        //lblError.Text = "Usted no tiene turnos asignados en este rango de fechas.";

        //FechaIncial = Convert.ToInt32(Calendar1.TodaysDate.Date);     

        //if (FechaFinal < FechaIncial)
        //{
        //    lblError.Text = "La fecha inicial debe ser menor a la fecha final";
        //    Calendar1.Visible = true;
        //}
        //else
        //{
        //    txtFechaFinal.Text = Calendar1.SelectedDate.ToLongDateString();
        //    Calendar1.Visible = false;
        //}
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Calendar1.Visible = true;
    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        txtFechaFinal.Text = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
        Calendar2.Visible = false;
       // lblError.Text = "La fecha inicial debe ser menor a la fecha final";
        //lblError.Text = "Usted no tiene turnos asignados en este rango de fechas.";
        // FechaFinal = Convert.ToInt32(Calendar2.SelectedDate.ToLongDateString());

        //if (FechaFinal < FechaIncial)
        //{
        //    lblError.Text = "La fecha inicial debe ser menor a la fecha final";
        //    Calendar2.Visible = true;
        //}else
        //{
        //    txtFechaFinal.Text = Calendar2.SelectedDate.ToLongDateString();
        //    Calendar2.Visible = false;
        //}

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Calendar2.Visible = true;
    }
    protected void btnConsultarVehiculos_Click(object sender, EventArgs e)
    {
        ConsultarVehiculos();
    }
    private void ConsultarVehiculos()
    {
        Vehiculo oVehiculo = new Vehiculo();
        // oVehiculo..NumeroFactura = NumeroFactura;
        oVehiculo.grid = GridView1;
        //txtfecha.Text = Calendar1.SelectedDate.AddDays(7).ToShortDateString();


        if (!oVehiculo.LlenarGrid(txtFechaIncial.Text,txtFechaFinal.Text))
        {
            lblError.Text = oVehiculo.Error;
            oVehiculo = null;
        }
        oVehiculo = null;

       /* table.Columns.Add("Documento cliente", typeof(string));
        table.Columns.Add("Cliente", typeof(string));
        table.Columns.Add("Fecha/Hora reserva", typeof(string));
        table.Columns.Add("Fecha/Hora fin reserva", typeof(string));
        //table.Columns.Add("Fecha/Hora salida del parqueadero", typeof(string));
        table.Columns.Add("Celda", typeof(string));
        table.Columns.Add("Placa vehículo", typeof(string));

        table.Rows.Add("1152684632","Juan carlos", "29/10/2018 2:00 pm", "31/10/2018 2:00 pm","410","UDZ4499");
        table.Rows.Add("52684632", "Alejandro carlos", "28/10/2018 5:00 pm", "31/10/2018 2:00 pm" ,"414", "UDI4499");
        table.Rows.Add("684632", "Pedro carlos", "29/10/2018 9:00 pm", "31/10/2018 7:00 pm", "40", "UDS499");
        table.Rows.Add("184632", "Carlos", "29/10/2018 2:00 pm", "31/10/2018 2:00 pm", "418", "UHZ489");

        GridView1.DataSource = table;
        GridView1.DataBind();
        */
    }



}