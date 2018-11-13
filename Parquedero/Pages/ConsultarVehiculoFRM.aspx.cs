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
        int fechaInicial = Convert.ToInt32(Calendar1.SelectedDate.ToString("yyyyMMdd"));
        int fechaFinal = Convert.ToInt32(Calendar2.SelectedDate.ToString("yyyyMMdd"));

        if (ValidarFecha(fechaInicial, fechaFinal))
        {
            Calendar2.Visible = false;
        }
        else
        {
            lblError.Text = "La fecha final debe ser mayor a la inicial.";
        }

    }
    public bool ValidarFecha(int fechaInicial, int fechaFinal)
    {
        if (fechaFinal < fechaInicial)
        {
            return false;
        }
        return true;

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


        if (!oVehiculo.LlenarGrid(txtFechaIncial.Text, txtFechaFinal.Text))
        {
            lblError.Text = oVehiculo.Error;
            oVehiculo = null;
        }
        else if (oVehiculo.grid.Rows.Count == 0)
        {
            lblError.Text = "No se encontro resultados en los filtros ingresados";
        }
        oVehiculo = null;

        //table.Columns.Add("Id vehiculo", typeof(string));
        //table.Columns.Add("Color", typeof(string));
        //table.Columns.Add("Marca", typeof(string));
        //table.Columns.Add("Placa", typeof(string));
        //table.Columns.Add("Modelo", typeof(string));
        //table.Columns.Add("Nombre propietario", typeof(string));
        //table.Columns.Add("Fecha llegada", typeof(string));

        //table.Rows.Add("1", "Rojo", "Ford", "PASO12", "2018", "Alejandro", "31/10/2018");
        //table.Rows.Add("2", "Verde", "Ford 2", "PO12", "2017", "Pedro", "31/10/2018");
        //table.Rows.Add("3", "Rosado", "Ford 3", "ASO12", "2016", "Alejandro", "31/10/2018");

        //GridView1.DataSource = table;
        //GridView1.DataBind();

    }



}