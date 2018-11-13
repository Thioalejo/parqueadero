using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libClases.BaseDatos;

public partial class Pages_ConsultarTurnoFRM : System.Web.UI.Page
{
    DataTable table = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    int FechaIncial=0;
    int FechaFinal = 0;
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtFechaIncial.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
        Calendar1.Visible = false;


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

        if (ValidarFecha(fechaInicial,fechaFinal))
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
        if(fechaFinal < fechaInicial)
        {
            return false;
        }
        return true;
        
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Calendar2.Visible = true;
    }
    protected void btnConsultarTurno_Click(object sender, EventArgs e)
    {
        ConsultarTurno();
    }

    private void ConsultarTurno()
    {

        Turno oTurno = new Turno();
        // oVehiculo..NumeroFactura = NumeroFactura;
        oTurno.grid = GridView1;
        //txtfecha.Text = Calendar1.SelectedDate.AddDays(7).ToShortDateString();
        oTurno.FechaInicio = txtFechaIncial.Text;
        oTurno.FechaFin = txtFechaFinal.Text;

        if (!oTurno.LlenarGrid(txtCedula.Text))
        {
            lblError.Text = oTurno.Error;
            oTurno = null;
        }else if(oTurno.grid.Rows.Count==0)
        {
            lblError.Text = "No se encontro resultados en los filtros ingresados";
        }

        oTurno = null;
        //table.Columns.Add("Tipo turno", typeof(string));
        //table.Columns.Add("Fecha inicio", typeof(string));
        //table.Columns.Add("Fecha fin", typeof(string));
        //table.Columns.Add("Nombre", typeof(string));
        //table.Columns.Add("Cedula", typeof(string));

        //table.Rows.Add("N/A","25/10/2018", "28/10/2018", "Pedro", "1152684641");
        //table.Rows.Add("Nocturno", "26/10/2018", "28/10/2018", "Pedro", "1152684641");
        //table.Rows.Add("Diurno", "27/10/2018", "28/10/2018", "Pedro", "1152684641");
        //table.Rows.Add("Casa", "28/10/2018", "28/10/2018", "Pedro", "1152684641");
        //table.Rows.Add("Casa", "29/10/2018", "28/10/2018", "Pedro", "1152684641");
        //table.Rows.Add("N/A", "30/10/2018", "28/10/2018", "Pedro", "1152684641");


        //GridView1.DataSource = table;
        //GridView1.DataBind();

    }
}