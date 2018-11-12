using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        Calendar2.Visible = false;


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
        }
        oTurno = null;
        /*table.Columns.Add("Fecha", typeof(string));
        table.Columns.Add("Dia", typeof(string));

        table.Rows.Add("26/10/2018", "Viernes");
        table.Rows.Add("29/10/2018", "Lunes");
        table.Rows.Add("30/10/2018", "Martes");
        table.Rows.Add("31/10/2018", "Miercoles");
        table.Rows.Add("01/11/2018", "Jueves");
        table.Rows.Add("02/11/2018", "Viernes");
        table.Rows.Add("03/11/2018", "Sabado");





        GridView1.DataSource = table;
        GridView1.DataBind();
        */
    }
}